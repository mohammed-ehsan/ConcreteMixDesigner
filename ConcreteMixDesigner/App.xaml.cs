using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ME.Wpf.Mvvm;
using ConcreteMixDesigner.ViewModels;


namespace ConcreteMixDesigner
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IDialogService DialogService = new Dialog(null);
        public App()
        {
            this.DialogService = new Dialog(null);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.DialogService.Register<MainViewModel, MainWindow>();
            this.DialogService.Register<AboutViewModel, AboutDialog>();
            this.DialogService.ShowDialog<MainViewModel>(new MainViewModel(this.DialogService));
        }
    }
}
