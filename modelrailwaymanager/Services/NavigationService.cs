using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ModelRailwayManager
{
    public class NavigationService
    {
        public void NavigateTo(Frame contentFrame, Type destination)
        {
            contentFrame.Navigate(destination);
        }

        public Type FindViewByButtonName(string name)
        {
            switch(name)
            {
                case "TrackButton": return typeof(TrackPage);
                case "TrainButton": return typeof(TrainPage);
                case "SettingsButton": return typeof(SettingsPage);
                default: return typeof(TrainPage);
            }
        }
    }
}
