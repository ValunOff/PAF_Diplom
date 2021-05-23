using PAF.Commands.Base;
using PAF.Data.Classes;
using PAF.Data.Clases;
using PAF.View.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Input;

namespace PAF.ViewModel
{
    class ClientVM : ViewModelForWindow
    {
        /// <summary>Пока прога работает с бд, лучше запретить все кнопки для работы с бд</summary>
        bool CanButtonClick = true;

        Client _AddClient = new Client();
        /// <summary>Данные нового клиента</summary>
        public Client AddClient { get => _AddClient; set => Set(ref _AddClient, value); }

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
            //AddClient = new Clients();
            DeliveryAdd clientAdd = new DeliveryAdd();
            clientAdd.ShowDialog();
            CanButtonClick = true;
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
            CanButtonClick = false;
            MessageBox.Show("Delete");
            CanButtonClick = true;
        }
        #endregion

        #region AddClientCommand
        public ICommand AddClientCommand { get; set; }
        private bool CanAddClientExecute(object p) => CanButtonClick;
        private void OnAddClientExecuted(object p)
        {
            CanButtonClick = false;
            ClientAdd clientAdd;
            CanButtonClick = true;
        }
        #endregion
        #endregion

        public ObservableCollection<Client> Clients 
        { 
            get => _Client;
            set 
            {
                _Client.CollectionChanged += Users_CollectionChanged;
                Set(ref _Client, value);
            } 
        }
        
        ObservableCollection<Client> _Client = new SQLClient().SelectClientToObservableCollection();

        public ClientVM()
        {
            #region Commands
            SaveChangesCommand = new LambdaCommand(OnSaveChangesExecuted, CanSaveChangesExecute);
            AddCommand = new LambdaCommand(OnAddExecuted, CanAddExecute);
            UpdateCommand = new LambdaCommand(OnUpdateExecuted, CanUpdateExecute);
            DeleteCommand = new LambdaCommand(OnDeleteExecuted, CanDeleteExecute);
            AddClientCommand = new LambdaCommand(OnAddClientExecuted, CanAddClientExecute);
            #endregion
        }

        private static void Users_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    Client newUser = e.NewItems[0] as Client;
                    newUser.Status = Status.Added;
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    Client oldUser = e.OldItems[0] as Client;
                    oldUser.Status = Status.Deleted;
                    break;
                case NotifyCollectionChangedAction.Replace: // если замена
                    Client replacingUser = e.NewItems[0] as Client;
                    replacingUser.Status = Status.Modified;
                    break;
            }
        }
    }
}
