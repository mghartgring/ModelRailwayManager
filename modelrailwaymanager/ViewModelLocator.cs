using GalaSoft.MvvmLight.Ioc;
using ModelRailwayManager.Shared.ViewModels;
using Microsoft.Practices.ServiceLocation;
using ModelRailwayManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidayCottageManager.Shared.ViewModels;

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

        public TrackViewModel TrackView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TrackViewModel>();
            }
        }

        public TrainViewModel TrainView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TrainViewModel>();
            }
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<NavigationService>(() => new NavigationService());
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TrackViewModel>();
            SimpleIoc.Default.Register<TrainViewModel>();

        }

    }
}
