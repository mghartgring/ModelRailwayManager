using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ModelRailwayManager.Shared.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public RelayCommand NavigateCommand { get; private set; }
        
        public MainViewModel()
        {
            NavigateCommand = new RelayCommand(NavigateCommandAction);
        }
        
        private void NavigateCommandAction()
        {
            //SimpleIoc.Default.GetInstance<INavigationService>().NavigateTo("SecondPage");
        }
    }
}
