using PAF.Commands.Base;
using PAF.Data;
using PAF.Data.Entityies;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace PAF.ViewModel
{
    class EmployeeVM : ViewModel
    {
        #region Commands

        #region SaveChangesCommand
        public ICommand SaveChangesCommand { get; set; }
        private bool CanSaveChangesExecute(object p) => true;
        private void OnSaveChangesExecuted(object p)
        {
            new SQL().UpdateEmployee(_Employees);
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
            Employees = new SQL().SelectEmployee();
        }
        #endregion

        #endregion

        public List<Employees> Employees { get => _Employees; set => Set(ref _Employees, value); }
        List<Employees> _Employees = new SQL().SelectEmployee();

        public EmployeeVM()
        {
            #region Commands
            SaveChangesCommand = new LambdaCommand(OnSaveChangesExecuted, CanSaveChangesExecute);
            AddCommand = new LambdaCommand(OnAddExecuted, CanAddExecute);
            UpdateCommand = new LambdaCommand(OnUpdateExecuted, CanUpdateExecute);
            #endregion
        }
    }
}
