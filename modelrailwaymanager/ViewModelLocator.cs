using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using ModelRailwayManager.Shared.ViewModels;
using Microsoft.Practices.ServiceLocation;
using ModelRailwayManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelRailwayManager
{
    public class ViewModelLocator
    {
        public MainViewModel MainView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public SecondViewModel SecondView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SecondViewModel>();
            }
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            var nav = new NavigationService();
            nav.Configure("MainPage", typeof(MainPage));
            nav.Configure("SecondPage", typeof(SecondPage));
            SimpleIoc.Default.Register<INavigationService>(() => nav);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SecondViewModel>();

        }

    }
}
