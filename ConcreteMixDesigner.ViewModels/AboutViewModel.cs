using ME.Wpf.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteMixDesigner.ViewModels
{
    public class AboutViewModel : BaseViewModel, IClosable
    {
        public event EventHandler<DialogClosedEventArgs> Closed;
    }
}
