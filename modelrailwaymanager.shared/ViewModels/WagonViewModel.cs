using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HolidayCottageManager.Shared.Models;
using HolidayCottageManager.Shared.Services;
using Windows.UI.Core;

namespace HolidayCottageManager.Shared.ViewModels
{
    public class WagonViewModel : BaseItemPageViewModel
    {
        public WagonViewModel()
        {
            LoadDataService();
            AddCommand = new RelayCommand(AddWagonAction);
            UpdateCommand = new RelayCommand(UpdateWagonAction);
            DeleteCommand = new RelayCommand(DeleteWagonAction);
        }

        private DatabaseService database;

        private List<Wagon> _wagonList = new List<Wagon>();
        public List<Wagon> WagonList
        {
            get
            {
                return _wagonList; 
            }
            set
            {
                _wagonList = value;
                this.RaisePropertyChanged("WagonList");
            }
        }

        private Wagon _currentWagon;
        public Wagon CurrentWagon
        {
            get
            {
                return _currentWagon;
            }
            set
            {
                if (_currentWagon == null) ShowDetailView();
                _currentWagon = value;
                this.RaisePropertyChanged("CurrentWagon");
            }
        }

        private Wagon _addWagon = new Wagon();
        public Wagon AddWagon
        {
            get
            {
                return _addWagon;
            }
            set
            {
                _addWagon = value;
                this.RaisePropertyChanged("AddWagon");
            }
        }
        
        #region methods
        private async void LoadDataService()
        {
            await CoreWindow.GetForCurrentThread().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                database = new DatabaseService();
                LoadWagonList();
            });
        }

        private void LoadWagonList()
        {
            WagonList = database.Wagons.ToList();
        }

        private void DeleteWagonAction()
        {
            database.RemoveAndSave(CurrentWagon);
            LoadWagonList();
            ShowMessage();
        }

        private void UpdateWagonAction()
        {
            database.UpdateAndSave(CurrentWagon);
            LoadWagonList();
            ShowMessage();
        }

        private void AddWagonAction()
        {
            if (AddWagon == null) return;
            database.AddAndSave(AddWagon);
            LoadWagonList();
            ShowMessage();
            AddWagon = new Wagon();
        }
        #endregion
    }
}
