using Microsoft.VisualStudio.TestTools.UnitTesting;
using ME.ConcreteMix.Designer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME.ConcreteMix.Designer.Tests
{
    [TestClass()]
    public class ConcreteMixTests
    {
        [TestMethod()]
        public void DesignMixTest()
        {
            var mMix = new ConcreteMix()
            {
                FreezingExposure = FreezingAndThawingExposure.Severe,
                Exposure = ExposureConditions.FreezingAndThawing,
                StructuralStrengthRequired = 35,
                IsAirEntrained = true,
                AirContent = 8,
                AirEntrainerAdmixture = new AdmixtureMaterial()
                {
                    Dosage=0.5
                },
                UseWaterReducer = true,
                WaterReducer = new WaterReducer()
                {
                    Dosage = 3,
                    Reduction = 10
                },
                Slump = SlumpAmount.From50To100,
                CoarseAggregate = new CoarseAggregateMaterial()
                {
                    NominalSize = NominalAggregateSize.Size25,
                    Density = 1600,
                    Absorbtion = 0.5,
                    MoistureContent = 2,
                    IsRounded = true,
                    SpecificGravity = 2.68
                },
                FineAggregate = new FineAggregate()
                {
                    Density = 2640,
                    Absorbtion = 0.7,
                    MoistureContent = 6,
                    FinenessModulus = 2.8,
                    SpecificGravity = 2.64
                },
                Water = new Water()
                {
                    Density=1000
                },
                Cement = new CementMaterial()
                {
                    Density=3000
                }

            };

            mMix.DesignMix();
            Console.WriteLine("Water Content = {0}", mMix.Water.Weight);
            Console.WriteLine("Cement Content = {0}", mMix.Cement.Weight);
            Console.WriteLine("Water/Cement ratio = {0}", mMix.WCRatio);
            Console.WriteLine("Fine Aggregate Content = {0}", mMix.FineAggregate.Weight);
            Console.WriteLine("Coarse Aggregate Content = {0}", mMix.CoarseAggregate.Weight);
            Console.WriteLine("Air entaining admixture content = {0}", mMix.AirEntrainerAdmixture.Weight);
            Console.WriteLine("Water reducer admixture content = {0}", mMix.WaterReducer.Weight);

        }
    }
}