using ME.ConcreteMix.Designer;
using ME.Wpf.Mvvm;
using System;
using System.Windows.Input;

namespace ConcreteMixDesigner.ViewModels
{
    public class MainViewModel : BaseViewModel, IClosable
    {
        #region Events

        public event EventHandler<DialogClosedEventArgs> Closed;

        #endregion

        #region Private Members

        private readonly IDialogService dialogService = null;

        #endregion

        #region Public Properties

        /// <summary>
        /// Concrete mix
        /// </summary>
        public ConcreteMix Mix { get; set; } = new ConcreteMix() { Water = new Water() { Density=1000} };

        /// <summary>
        /// Exposure levels to select from
        /// </summary>
        public Array ExposureLevels { get; set; } = Enum.GetValues(typeof(ExposureConditions));

        /// <summary>
        /// Freezing and thawing exposure to select from
        /// </summary>
        public Array FreezingExposureLevels { get; set; } = Enum.GetValues(typeof(FreezingAndThawingExposure));

        /// <summary>
        /// Nominal aggregate sizes to select from
        /// </summary>
        public Array NominalAggregateSizes { get; set; } = Enum.GetValues(typeof(NominalAggregateSize));

        /// <summary>
        /// Slump ranges to choose from
        /// </summary>
        public Array SlumpAmounts { get; set; } = Enum.GetValues(typeof(SlumpAmount));


        #endregion

        #region Commands

        private ICommand _designCommand;
        private ICommand _aboutCommand;

        #endregion

        #region Public Commands

        public ICommand DesignCommand {
            get {
                if (_designCommand == null)
                    _designCommand = new RelayCommand(this.Mix.DesignMix);
                return _designCommand;
            }
        }

        public ICommand AboutCommand
        {
            get {
                if (_aboutCommand == null)
                    _aboutCommand = new RelayCommand(() => this.dialogService.ShowDialog<AboutViewModel>(new AboutViewModel()));
                return _aboutCommand;
            }
        }

        #endregion

        #region Constructors

        public MainViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }

        #endregion

        #region Static Helpers


        #endregion
    }
}
