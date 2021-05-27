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
        /// <summary> основная таблица </summary>
        public Page ContentPage { get => _ContentPage; set => Set(ref _ContentPage, value); }
        Page _ContentPage = new Client();
        /// <summary> второстепенная таблица </summary>
        public Page SubPage { get => _ContentPage; set => Set(ref _ContentPage, value); }
        Page _SubPage = new Client();

        /// <summary> видно ли преключатель для второстепенной формы</summary>
        public Visibility RadioButtonVisible { get => _RadioButtonVisible; set => Set(ref _RadioButtonVisible, value); }
        Visibility _RadioButtonVisible = Visibility.Collapsed;

        /// <summary> видно ли вторую таблицу </summary>
        public Visibility SecondTable { get => _SecondTable; set => Set(ref _SecondTable, value); }
        Visibility _SecondTable = Visibility.Hidden;

       public bool ToggleButton
        {
            get => _ToggleButton;
            set
            {
                if (value)
                {
                    SecondTable = Visibility.Visible;
                    MessageBox.Show("вторую таблицу видно");
                }
                else
                {
                    SecondTable = Visibility.Hidden;
                    MessageBox.Show("вторую таблицу не видно");
                }
                Set(ref _ToggleButton, value);
            }
        }
       bool _ToggleButton = false;

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

        #region SelectClients
        public ICommand SelectClients { get; set; }
        private bool CanSClientsExecute(object p) => true;
        private void OnSClientsExecuted(object p)
        {
            ContentPage = new Client();
            RadioButtonVisible = Visibility.Hidden;
        }
        #endregion

        #region SelectSales
        public ICommand SelectSales { get; set; }
        private bool CanSelectSalesExecute(object p) => true;
        private void OnSelectSalesExecuted(object p)
        {
            ContentPage = new Salay();
            RadioButtonVisible = Visibility.Hidden;
        }
        #endregion

        #region SelectEmployees
        public ICommand SelectEmployees { get; set; }
        private bool CanSEmployeesExecute(object p) => true;
        private void OnSEmployeesExecuted(object p)
        {
            ContentPage = new Employee();
            RadioButtonVisible = Visibility.Visible;
        }
        #endregion

        #region SelectDeliveries
        public ICommand SelectDeliveries { get; set; }
        private bool CanSelectDeliveriesExecute(object p) => true;
        private void OnSelectDeliveriesExecuted(object p)
        {
            ContentPage = new Delivery();
            RadioButtonVisible = Visibility.Hidden;
        }
        #endregion

        #region SelectComponents
        public ICommand SelectComponents { get; set; }
        private bool CanSelectComponentsExecute(object p) => true;
        private void OnSelectComponentsExecuted(object p)
        {
            ContentPage = new Component();
            RadioButtonVisible = Visibility.Visible;
        }
        #endregion

        #region SelectTypes
        public ICommand SelectTypes { get; set; }
        private bool CanSelectTypesExecute(object p) => true;
        private void OnSelectTypesExecuted(object p)
        {
            ContentPage = new View.Pages.Type();
            RadioButtonVisible = Visibility.Hidden;
        }
        #endregion

        #region SelectSupplies
        public ICommand SelectSupplies { get; set; }
        private bool CanSelectSuppliesExecute(object p) => true;
        private void OnSelectSuppliesExecuted(object p)
        {
            ContentPage = new Supply();
            RadioButtonVisible = Visibility.Visible;
        }
        #endregion
        #endregion

        public MainWindowVM()
        {
            #region Commands
            LogoutCommand = new LambdaCommand(OnLogoutExecuted, CanLogoutExecute);
            ConnectionCommand = new LambdaCommand(OnConnectionExecuted, CanConnectionExecute);
            
            SelectClients = new LambdaCommand(OnSClientsExecuted, CanSClientsExecute);
            SelectSales = new LambdaCommand(OnSelectSalesExecuted, CanSelectSalesExecute);
            SelectEmployees = new LambdaCommand(OnSEmployeesExecuted, CanSEmployeesExecute);
            SelectDeliveries = new LambdaCommand(OnSelectDeliveriesExecuted, CanSelectDeliveriesExecute);
            SelectComponents = new LambdaCommand(OnSelectComponentsExecuted, CanSelectComponentsExecute);
            SelectTypes = new LambdaCommand(OnSelectTypesExecuted, CanSelectTypesExecute);
            SelectSupplies = new LambdaCommand(OnSelectSuppliesExecuted, CanSelectSuppliesExecute);
            #endregion
        }
    }
}