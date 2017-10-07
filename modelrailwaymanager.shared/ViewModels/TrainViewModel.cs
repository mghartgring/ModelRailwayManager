using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HolidayCottageManager.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace HolidayCottageManager.Shared.ViewModels
{
    public class TrainViewModel : BaseItemPageViewModel
    {
        private DatabaseService database;
        public TrainViewModel()
        {
            database = new DatabaseService();
            InitializeCommands();
            InitializeLocomotiveList();
        }

        private List<Locomotive> _locomotiveList = new List<Locomotive>();
        public List<Locomotive> LocomotiveList
        {
            get
            {
                return _locomotiveList;
            }
            set
            {
                _locomotiveList = value;
                this.RaisePropertyChanged("LocomotiveList");
            }
        }

        private Locomotive _currentLocomotive;
        public Locomotive CurrentLocomotive
        {
            get
            {
                return _currentLocomotive;
            }
            set
            {
                _currentLocomotive = value;
                this.RaisePropertyChanged("CurrentLocomotive");
            }
        }
       

        private Locomotive _addLocomotive = new Locomotive();
        public Locomotive AddLocomotive
        {
            get
            {
                return _addLocomotive;
            }
            set
            {
                _addLocomotive = value;
                this.RaisePropertyChanged("AddLocomotive");
            }
        }
        
        #region methods
        private void InitializeCommands()
        {
            AddCommand = new RelayCommand(AddLocomotiveAction);
            DeleteCommand = new RelayCommand(DeleteCurrentLocomotive);
            UpdateCommand = new RelayCommand(UpdateCurrentLocomotive);
        }

        private void UpdateCurrentLocomotive()
        {
            if (CurrentLocomotive == null) return;
            database.UpdateAndSave(CurrentLocomotive);
            InitializeLocomotiveList();
        }

        private void DeleteCurrentLocomotive()
        {
            database.RemoveAndSave(CurrentLocomotive);
            InitializeLocomotiveList();
        }

        private void InitializeLocomotiveList()
        {
            LocomotiveList = database.Locomotives.ToList();
        }

        private void AddLocomotiveAction()
        {
            if (AddLocomotive == null) return;
            database.AddAndSave(AddLocomotive);
            InitializeLocomotiveList();
            ToggleSections();
        }
        #endregion
    }
}
