using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using HolidayCottageManager.Shared;
using HolidayCottageManager.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace ModelRailwayManager.Shared.ViewModels
{
    public class TrackViewModel : ViewModelBase
    {
        public TrackViewModel()
        {
            AddCommand = new RelayCommand(AddTrack);
            DeleteCommand = new RelayCommand(DeleteTrack);
            AddSectionCommand = new RelayCommand(ToggleSections);
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

        private Visibility _detailVisibility = Visibility.Visible;
        public Visibility DetailVisibility
        {
            get
            {
                return _detailVisibility;
            }
            set
            {
                _detailVisibility = value;
                this.RaisePropertyChanged("DetailVisibility");
            }
        }

        private Visibility _addVisibility = Visibility.Collapsed;
        public Visibility AddVisibility
        {
            get
            {
                return _addVisibility;
            }
            set
            {
                _addVisibility = value;
                this.RaisePropertyChanged("AddVisibility");
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
        private void InitializeData()
        {
            database = new DatabaseService();
            LoadTrackList();
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
        
        private void ToggleSections()
        {
            AddVisibility = AddVisibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
            DetailVisibility = DetailVisibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }
        #endregion

        #region commands
        private RelayCommand _addSectionCommand;
        public RelayCommand AddSectionCommand
        {
            get
            {
                return _addSectionCommand;
            }
            set
            {
                _addSectionCommand = value;
                this.RaisePropertyChanged("AddSectionCommand");
            }
        }

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
