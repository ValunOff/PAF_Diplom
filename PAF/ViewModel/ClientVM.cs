using PAF.Commands.Base;
using PAF.Data;
using PAF.Data.Entityies;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace PAF.ViewModel
{
    class ClientVM : ViewModel
    {
        #region Commands

        #region SaveChangesCommand
        public ICommand SaveChangesCommand { get; set; }
        private bool CanSaveChangesExecute(object p) => true;
        private void OnSaveChangesExecuted(object p)
        {
            new SQL().UpdateClient(_Clients);
        }
        #endregion

        #region AddCommand
        public ICommand AddCommand { get; set; }
        private bool CanAddExecute(object p) => true;
        private void OnAddExecuted(object p)
        {
            MessageBox.Show("Hello");
        }
        #endregion

        #region UpdateCommand
        public ICommand UpdateCommand { get; set; }
        private bool CanUpdateExecute(object p) => true;
        private void OnUpdateExecuted(object p)
        {
            Clients = new SQL().SelectClient();
        }
        #endregion

        #endregion

        public List<Clients> Clients { get => _Clients; set => Set(ref _Clients, value); }
        List<Clients> _Clients = new SQL().SelectClient();

        public ClientVM()
        {
            #region Commands
            SaveChangesCommand = new LambdaCommand(OnSaveChangesExecuted, CanSaveChangesExecute);
            AddCommand = new LambdaCommand(OnAddExecuted, CanAddExecute);
            UpdateCommand = new LambdaCommand(OnUpdateExecuted, CanUpdateExecute);
            #endregion
        }
    }
}
