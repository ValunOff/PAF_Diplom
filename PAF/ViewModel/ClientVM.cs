using PAF.Commands.Base;
using PAF.Data;
using PAF.Data.Entityies;
using PAF.View.Windows;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace PAF.ViewModel
{
    class ClientVM : ViewModelForWindow
    {
        /// <summary>Разрешение нажатия для всех управляемых кнопок таблицы пока изменения не будут занесены в бд</summary>
        bool CanButtonClick = true;        

        #region Commands

        #region SaveChangesCommand
        public ICommand SaveChangesCommand { get; set; }

        private bool CanSaveChangesExecute(object p) => CanButtonClick;
        private void OnSaveChangesExecuted(object p)
        {
            CanButtonClick = false;
            new SQL().UpdateClient(_Clients);
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
        }
        #endregion

        #region UpdateCommand
        public ICommand UpdateCommand { get; set; }
        private bool CanUpdateExecute(object p) => CanButtonClick;
        private void OnUpdateExecuted(object p)
        {
            CanButtonClick = false;
            Clients = new SQL().SelectClient();
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
        #endregion

        public List<Clients> Clients { get => _Clients; set => Set(ref _Clients, value); }
        List<Clients> _Clients = new SQL().SelectClient();

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
