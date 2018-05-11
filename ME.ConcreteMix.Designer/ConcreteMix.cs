using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer
{
    public class ConcreteMix : INotifyPropertyChanged
    {
        #region Public Properties

        /// <summary>
        /// Mix water
        /// </summary>
        public MixIngredient Water { get; set; }

        /// <summary>
        /// Mix cement
        /// </summary>
        public MixIngredient Cement { get; set; }

        /// <summary>
        /// Mix fine aggregate
        /// </summary>
        public FineAggregate FineAggregate { get; set; }

        /// <summary>
        /// Mix coarse aggregate
        /// </summary>
        public CoarseAggregateMaterial CoarseAggregate {get;set;}

        /// <summary>
        /// Exposure condition of concrete
        /// </summary>
        public ExposureConditions Exposure { get; set; }

        /// <summary>
        /// Required structural strength in MPa (Given in problem)
        /// </summary>
        public double StructuralStrengthRequired { get; set; }

        /// <summary>
        /// Indicates if structural strength satisfies exposure
        /// </summary>
        public bool StrengthSatisfiesExposure {
            get {
                return MixDesignStrengthProvider.IsAdequateForExposure(this.StructuralStrengthRequired, this.Exposure);
            }
        }

        /// <summary>
        /// Design strength of mix that will be used for calculating proportions of mixture materials (in MPa)
        /// </summary>
        public double MixDesignStrength { get; set; }

        /// <summary>
        /// Indicates if standard deviation is provided
        /// </summary>
        public bool IsStandardDeviationProvided { get; set; }

        /// <summary>
        /// Standard deviation of concrete strength
        /// </summary>
        public double StandardDeviation { get; set; }

        /// <summary>
        /// Count of samples used for calculating <see cref="StandardDeviation"/>
        /// </summary>
        public int SampleCount { get; set; }

        /// <summary>
        /// Water/Cement ratio used for mix
        /// </summary>
        public double WCRatio { get; set; }

        /// <summary>
        /// Maximum w/c ratio for exposure condition
        /// </summary>
        public double MaxWCRatio { get; set; }

        /// <summary>
        /// Is the mix should be designed for air entrainment.
        /// </summary>
        public bool IsAirEntrained { get; set; }

        /// <summary>
        /// Indicates if maximum water cement ration is used
        /// </summary>
        public bool IsMaxWCRatioUsed { get; set; }

        /// <summary>
        /// Desing air content percentage of the concrete mix
        /// </summary>
        public double AirContent { get; set; }

        /// <summary>
        /// Freezing and thawing exposure of concrete
        /// </summary>
        public FreezingAndThawingExposure FreezingExposure { get; set; }

        /// <summary>
        /// Required slump for workability
        /// </summary>
        public SlumpAmount Slump { get; set; }

        /// <summary>
        /// Is water reducer is used in concrete mix
        /// </summary>
        public bool UseWaterReducer { get; set; }

        /// <summary>
        /// Properties of water reducer used
        /// </summary>
        public WaterReducer WaterReducer { get; set; } = new WaterReducer();

        /// <summary>
        /// Air entrainment material used if <see cref="IsAirEntrained"/> is set to true.
        /// </summary>
        public AdmixtureMaterial AirEntrainerAdmixture { get; set; } = new AdmixtureMaterial();

        #endregion

        #region Constructors

        public ConcreteMix()
        {
            this.Water = new Water();
            this.Cement = new CementMaterial();
            this.FineAggregate = new FineAggregate();
            this.CoarseAggregate = new CoarseAggregateMaterial();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        /// <summary>
        /// Calculate the Mix Design Strength <see cref="MixDesignStrength"/> in MPa used for mix design.
        /// </summary>
        public void CalculateMixDesignStrength()
        {
            double mModifiedStrength = this.StructuralStrengthRequired;
            if (!this.StrengthSatisfiesExposure)
            {
                mModifiedStrength = MixDesignStrengthProvider.MinStrength[this.Exposure];
            }
            if (this.IsStandardDeviationProvided)
                mModifiedStrength = MixDesignStrengthProvider.DesignStrength(mModifiedStrength, this.SampleCount, this.StandardDeviation);
            else
                mModifiedStrength = MixDesignStrengthProvider.DesignStrength(mModifiedStrength);
            this.MixDesignStrength = mModifiedStrength;
        }

        /// <summary>
        /// Calculate w/c ratio requireed for <see cref="MixDesignStrength"/>, <see cref="Exposure"/> and <see cref="IsAirEntrained"/>
        /// </summary>
        public void CalculateWaterCementRatio()
        {
            this.MaxWCRatio = WaterCementRatioProvider.MaxWCRatio[this.Exposure];
            double mWCRatio = WaterCementRatioProvider.GetWCRatio(this.MixDesignStrength, this.IsAirEntrained);
            if (mWCRatio > this.MaxWCRatio)
            {
                mWCRatio = this.MaxWCRatio;
                this.IsMaxWCRatioUsed = true;
            }
            this.WCRatio = mWCRatio;
        }

        /// <summary>
        /// Calculate <see cref="AirContent"/> of the mixture according to <see cref="CoarseAggregateMaterial.NominalSize"/> and <see cref="FreezingExposure"/> if existed.
        /// </summary>
        //public void CalculateAirContent()
        //{
        //    if (this.IsAirEntrained)
        //        this.AirContent = AirContentProvider.GetAirContent(this.FreezingExposure, this.CoarseAggregate.NominalSize);
        //    else
        //        this.AirContent = AirContentProvider.GetAirContent(this.CoarseAggregate.NominalSize);
        //}

        /// <summary>
        /// Calculate water content <see cref="Water.Weight"/> in kg/m^3 of concrete mix.
        /// </summary>
        public void CalculateWaterContent()
        {
            double mWaterContent = MixingWaterProvider.GetWaterContent(this.CoarseAggregate.NominalSize, this.Slump, this.IsAirEntrained);
            this.Water.Weight = ApplyWaterReductionEffects(mWaterContent);
        }

        /// <summary>
        /// Apply reduction effects on water from aggregate roundness and usage of water reducer
        /// </summary>
        /// <param name="weight">Weight of water in kg/m^3</param>
        /// <returns></returns>
        public double ApplyWaterReductionEffects(double weight)
        {
            double mWaterContent = weight;
            if (this.CoarseAggregate.IsRounded)
                mWaterContent -= MixingWaterProvider.RoundnessReduction;
            if (this.UseWaterReducer)
                mWaterContent = this.WaterReducer.GetReducedWaterContent(mWaterContent);
            return mWaterContent;
        }

        /// <summary>
        /// Calculate cement content <see cref="CementMaterial.Weight"/> in kg/m^3 of concrete mix.
        /// </summary>
        public void CalculateCementContent()
        {
            double mCemetWeight = this.Water.Weight / WCRatio;
            bool mSufficientWeight = CementMaterial.IsSufficientWeight(this.CoarseAggregate.NominalSize, mCemetWeight, this.FreezingExposure == FreezingAndThawingExposure.Severe);
            if (!mSufficientWeight)
            {
                mCemetWeight = CementMaterial.GetSufficientWeight(this.CoarseAggregate.NominalSize, this.FreezingExposure == FreezingAndThawingExposure.Severe);
                double mWaterContent = mCemetWeight * this.WCRatio;
                this.Water.Weight = ApplyWaterReductionEffects(mWaterContent);
            }
            this.Cement.Weight = mCemetWeight;
        }

        /// <summary>
        /// Calculate oven dry weight of coarse aggregate in kg/m^3
        /// </summary>
        public void CalculateCoarseAggregate()
        {
            double mVolume = CoarseAggregateMaterial.CalculateCoarseAggVol(this.CoarseAggregate.NominalSize, this.FineAggregate.FinenessModulus);
            this.CoarseAggregate.Weight = mVolume * this.CoarseAggregate.Density;
        }

        /// <summary>
        /// Sets the admixtures content for concrete mix in kg/m^3
        /// </summary>
        public void CalculateAdmixtureContent()
        {
            if (this.UseWaterReducer)
                this.WaterReducer.SetWeight(this.Cement.Weight);
            if (this.IsAirEntrained)
                this.AirEntrainerAdmixture.SetWeight(this.Cement.Weight);
        }

        /// <summary>
        /// Set the fine aggregate weight
        /// </summary>
        public void CalculateFineAggregate()
        {
            double mContentsVolume = 0;
            mContentsVolume += this.Cement.Volume;
            mContentsVolume += this.Water.Volume;
            mContentsVolume += this.CoarseAggregate.Weight / (this.CoarseAggregate.SpecificGravity *1000);
            mContentsVolume += (this.AirContent / 100);
            double mFineAggregateVolume = 1 - mContentsVolume;
            double mFineAggregateWeight = mFineAggregateVolume * this.FineAggregate.SpecificGravity * 1000;
            this.FineAggregate.Weight = mFineAggregateWeight;
        }

        public void DesignMix()
        {
            CalculateMixDesignStrength();
            CalculateWaterCementRatio();
            //CalculateAirContent();
            CalculateWaterContent();
            CalculateCementContent();
            CalculateCoarseAggregate();
            CalculateAdmixtureContent();
            CalculateFineAggregate();
        }
    }
}
