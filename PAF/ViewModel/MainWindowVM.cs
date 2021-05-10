using PAF.Commands.Base;
using PAF.View.Pages;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PAF.ViewModel
{
    class MainWindowVM : ViewModelForWindow
    {
        Page _ContentPage = new Client();
        public Page ContentPage { get => _ContentPage; set => Set(ref _ContentPage, value); }

        Page _ContentPageForSubform = new View.Pages.Type();
        public Page ContentPageForSubform { get => _ContentPageForSubform; set => Set(ref _ContentPageForSubform, value); }

        #region Commands

        #region LogoutCommand
        public ICommand LogoutCommand { get; set; }
        private bool CanLogoutExecute(object p) => true;
        private void OnLogoutExecuted(object p)
        {
            MessageBox.Show("Hello");
            // Сделать переход на форму авторизации
        }
        #endregion

        #region ConnectionCommand
        public ICommand ConnectionCommand { get; set; }
        private bool CanConnectionExecute(object p) => true;
        private void OnConnectionExecuted(object p)
        {
            // Строка подключения
        }
        #endregion

        #region SelectEmployees
        public ICommand SelectEmployees { get; set; }
        private bool CanSEmployeesExecute(object p) => true;
        private void OnSEmployeesExecuted(object p)
        {
            ContentPage = new Employee();
        }
        #endregion

        #region SelectClients
        public ICommand SelectClients { get; set; }
        private bool CanSClientsExecute(object p) => true;
        private void OnSClientsExecuted(object p)
        {
            ContentPage = new Client();
        }
        #endregion

        #region SelectComponents
        public ICommand SelectComponents { get; set; }
        private bool CanSComponentsExecute(object p) => true;
        private void OnSComponentsExecuted(object p)
        {
            ContentPage = new Component();
        }
        #endregion

        #region SelectTypes
        public ICommand SelectTypes { get; set; }
        private bool CanSTypesExecute(object p) => true;
        private void OnSTypesExecuted(object p)
        {
            ContentPage = new View.Pages.Type();
        }
        #endregion

        #endregion

        public MainWindowVM()
        {
            #region Commands
            LogoutCommand = new LambdaCommand(OnLogoutExecuted, CanLogoutExecute);
            ConnectionCommand = new LambdaCommand(OnConnectionExecuted, CanConnectionExecute);
            SelectEmployees = new LambdaCommand(OnSEmployeesExecuted, CanSEmployeesExecute);
            SelectClients = new LambdaCommand(OnSClientsExecuted, CanSClientsExecute);
            SelectComponents = new LambdaCommand(OnSComponentsExecuted, CanSComponentsExecute);
            SelectTypes = new LambdaCommand(OnSTypesExecuted, CanSTypesExecute);
            #endregion
        }
    }
}