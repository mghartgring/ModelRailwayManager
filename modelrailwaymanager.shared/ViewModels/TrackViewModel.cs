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

        private Track _currentTrack;
        public Track CurrentTrack
        {
            get
            {
                return _currentTrack;
            }
            set
            {
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
            LoadTrackList();
        }

        private void AddTrack()
        {
            if (AddTrackCount == 0 || AddTrackPartNumber == 0) return;
            Track t = new Track() { PartNumber = AddTrackPartNumber, Count = AddTrackCount };
            database.AddAndSave(t);
            AddTrackCount = 0;
            AddTrackPartNumber = 0;
            ToggleSections();
            LoadTrackList();
        }

        private void UpdateTrack()
        {
            database.UpdateAndSave(CurrentTrack);
        }
        
        
        #endregion

        #region commands
        private RelayCommand _deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return _deleteCommand;
            }
            set
            {
                _deleteCommand = value;
                this.RaisePropertyChanged("DeleteCommand");
            }
        }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand;
            }
            set
            {
                _addCommand = value;
                this.RaisePropertyChanged("AddCommand");
            }
        }

        private RelayCommand _updateCommand;
        public RelayCommand UpdateCommand
        {
            get
            {
                return _updateCommand;
            }
            set
            {
                _updateCommand = value;
                this.RaisePropertyChanged("UpdateCommand");
            }
        }
        #endregion
    }
}
