using PAF.Commands.Base;
using System.Configuration;
using PAF.Data.Classes;
using PAF.Data.Clases;
using PAF.View.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Data;
using System;
using PAF.Data.Entityies;

namespace PAF.ViewModel
{
    public class ClientVM : ViewModelForWindow
    {
        /// <summary>Пока прога работает с бд, лучше запретить все кнопки для работы с бд</summary>
        bool CanButtonClick = true;

        public Clients SelectedClient { get; set; }

        #region Commands

        #region SaveChangesCommand
        public ICommand SaveChangesCommand { get; set; }

        private bool CanSaveChangesExecute(object p) => CanButtonClick;
        private void OnSaveChangesExecuted(object p)
        {
            CanButtonClick = false;
            new SQLClient().UpdateClient(_Client);
            CanButtonClick = true;
        }
        #endregion

        #region AddCommand
        public ICommand AddCommand { get; set; }
        private bool CanAddExecute(object p) => CanButtonClick;
        private void OnAddExecuted(object p)
        {
            CanButtonClick = false;
            ClientAdd clientAdd = new ClientAdd();
            clientAdd.ShowDialog();
            CanButtonClick = true;
            OnUpdateExecuted(null);
        }
        #endregion

        #region UpdateCommand
        public ICommand UpdateCommand { get; set; }
        private bool CanUpdateExecute(object p) => CanButtonClick;
        private void OnUpdateExecuted(object p)
        {
            CanButtonClick = false;
            Clients = new SQLClient().SelectClientToObservableCollection();
            CanButtonClick = true;
        }
        #endregion

        #region DeleteCommand
        public ICommand DeleteCommand { get; set; }
        private bool CanDeleteExecute(object p) => CanButtonClick;
        private void OnDeleteExecuted(object p)
        {
            if(SelectedClient != null)
            {
                CanButtonClick = false;
                new SQLClient().DeleteClient(SelectedClient);
                CanButtonClick = true;
                OnUpdateExecuted(null);
            }
        }
        #endregion

        #endregion

        public ObservableCollection<Clients> Clients { get => _Client; set => Set(ref _Client, value); }
        
        ObservableCollection<Clients> _Client = new SQLClient().SelectClientToObservableCollection();

        public ClientVM()
        {
            #region Commands
            SaveChangesCommand = new LambdaCommand(OnSaveChangesExecuted, CanSaveChangesExecute);
            AddCommand = new LambdaCommand(OnAddExecuted, CanAddExecute);
            UpdateCommand = new LambdaCommand(OnUpdateExecuted, CanUpdateExecute);
            DeleteCommand = new LambdaCommand(OnDeleteExecuted, CanDeleteExecute);
            #endregion
        }
    }
}
