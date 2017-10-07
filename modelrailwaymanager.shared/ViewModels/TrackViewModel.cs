using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using HolidayCottageManager.Shared;
using HolidayCottageManager.Shared.Services;
using HolidayCottageManager.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace ModelRailwayManager.Shared.ViewModels
{
    public class TrackViewModel : BaseItemPageViewModel
    {
        public TrackViewModel()
        {
            AddCommand = new RelayCommand(AddTrack);
            DeleteCommand = new RelayCommand(DeleteTrack);
           
            UpdateCommand = new RelayCommand(UpdateTrack);
            InitializeData();
        }

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

        

        private int _addTrackCount = 0;
        public int AddTrackCount
        {
            get
            {
                return _addTrackCount;
            }
            set
            {
                _addTrackCount = value;
                this.RaisePropertyChanged("AddTrackCount");
            }
        }

        private int _addTrackPartNumber = 0;
        public int AddTrackPartNumber
        {
            get
            {
                return _addTrackPartNumber;
            }
            set
            {
                _addTrackPartNumber = value;
                this.RaisePropertyChanged("AddTrackPartNumber");
            }
        }

        private Track _currentTrack = null;
        public Track CurrentTrack
        {
            get
            {
                return _currentTrack;
            }
            set
            {
                if (_currentTrack == null) ShowDetailView();
                _currentTrack = value;
                this.RaisePropertyChanged("CurrentTrack");
            }
        }
        
        #region methods
        private  async void InitializeData()
        {
            await CoreWindow.GetForCurrentThread().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => 
            {
                database = new DatabaseService();
                LoadTrackList();
            });
            
        }

        private void LoadTrackList()
        {
            TrackList = database.Tracks.ToList();
        }

        private void DeleteTrack()
        {
            if (CurrentTrack == null) return;
            database.RemoveAndSave(CurrentTrack);
            ShowMessage();
            LoadTrackList();
        }

        private void AddTrack()
        {
            if (AddTrackCount == 0 || AddTrackPartNumber == 0) return;
            Track t = new Track() { PartNumber = AddTrackPartNumber, Count = AddTrackCount };
            database.AddAndSave(t);
            AddTrackCount = 0;
            AddTrackPartNumber = 0;
            ShowMessage();
            LoadTrackList();
        }

        private void UpdateTrack()
        {
            database.UpdateAndSave(CurrentTrack);
            ShowMessage();
            LoadTrackList();
        }
        #endregion
        
    }
}
