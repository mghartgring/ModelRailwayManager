﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HolidayCottageManager.Shared.Services;
using Microsoft.EntityFrameworkCore;
using Windows.UI.Core;

namespace HolidayCottageManager.Shared.ViewModels
{
    public class TrainViewModel : BaseItemPageViewModel
    {
        private DatabaseService database;
        public TrainViewModel()
        {
            LoadDataService();
            InitializeCommands();
           
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
                if (_currentLocomotive == null) ShowDetailView();
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
        private async void LoadDataService()
        {
            await CoreWindow.GetForCurrentThread().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                database = new DatabaseService();
                LoadLocomotiveList();
            });
        }

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
            LoadLocomotiveList();
            ShowMessage();
        }

        private void DeleteCurrentLocomotive()
        {
            database.RemoveAndSave(CurrentLocomotive);
            LoadLocomotiveList();
            ShowMessage();
        }

        private void LoadLocomotiveList()
        {
            LocomotiveList = database.Locomotives.ToList();
        }

        private void AddLocomotiveAction()
        {
            if (AddLocomotive == null) return;
            database.AddAndSave(AddLocomotive);
            AddLocomotive = new Locomotive();
            LoadLocomotiveList();
            ShowMessage();
        }
        #endregion
    }
}
