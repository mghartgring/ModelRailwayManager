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
            AddSectionCommand = new RelayCommand(ShowAddView);
        }

        private Visibility _messageVisibility = Visibility.Visible;
        public Visibility MessageVisibility
        {
            get
            {
                return _messageVisibility;
            }
            set
            {
                _messageVisibility = value;
                this.RaisePropertyChanged("MessageVisibility");
            }
        }
        

        private Visibility _detailVisibility = Visibility.Collapsed;
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
        protected void ShowAddView()
        {
            AddVisibility = Visibility.Visible;
            DetailVisibility = Visibility.Collapsed;
            MessageVisibility = Visibility.Collapsed;
        }

        protected void ShowDetailView()
        {
            AddVisibility = Visibility.Collapsed;
            MessageVisibility = Visibility.Collapsed;
            DetailVisibility = Visibility.Visible;
        }

        protected void ShowMessage()
        {
            AddVisibility = Visibility.Collapsed;
            MessageVisibility = Visibility.Visible;
            DetailVisibility = Visibility.Collapsed;
        }
    }
}
