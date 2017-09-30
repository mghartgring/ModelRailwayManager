using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using HolidayCottageManager.Shared;
using HolidayCottageManager.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelRailwayManager.Shared.ViewModels
{
    public class TrackViewModel : ViewModelBase
    {
        private DatabaseService database = null;
        private List<Track> _trackList = null;
        public List<Track> TrackList
        {
            get
            {
                return _trackList;
            }
            set
            {
                _trackList = value;
                this.RaisePropertyChanged("TrackList");
            }
        }

        public TrackViewModel()
        {
            InitializeData();
        }
        
        private void InitializeData()
        {
            database = new DatabaseService();
            TrackList = database.Tracks.ToList();
        }
    }
}
