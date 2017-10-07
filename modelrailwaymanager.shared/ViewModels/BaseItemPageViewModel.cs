using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight.Command;

namespace HolidayCottageManager.Shared.ViewModels
{

    public class BaseItemPageViewModel : ViewModelBase
    {
        public BaseItemPageViewModel()
        {
            AddSectionCommand = new RelayCommand(ToggleSections);
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
        #region Commands
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
        #endregion
        protected void ToggleSections()
        {
            AddVisibility = AddVisibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
            DetailVisibility = DetailVisibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
