using PAF.Commands.Base;
using PAF.Data;
using PAF.Data.Classes;
using PAF.Data.Entityies;
using PAF.Data.Clases;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using PAF.View.Windows;

namespace PAF.ViewModel
{
    class EmployeeVM : ViewModel
    {
        /// <summary>Пока прога работает с бд, лучше запретить все кнопки для работы с бд</summary>
        bool CanButtonClick = true;

        public Employees SelectedEmployee { get; set; }

        #region Commands

        #region SaveChangesCommand
        public ICommand SaveChangesCommand { get; set; }
        private bool CanSaveChangesExecute(object p) => CanButtonClick;
        private void OnSaveChangesExecuted(object p)
        {
            CanButtonClick = false;
            new SQLEmployee().UpdateEmployee(_Employees);
            CanButtonClick = true;
        }
        #endregion

        #region AddCommand
        public ICommand AddCommand { get; set; }
        private bool CanAddExecute(object p) => CanButtonClick;
        private void OnAddExecuted(object p)
        {
            CanButtonClick = false;
            EmployeeAdd clientAdd = new EmployeeAdd();
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
            Employees = new SQLEmployee().SelectEmployee();
            CanButtonClick = true;
        }
        #endregion

        #region DeleteCommand
        public ICommand DeleteCommand { get; set; }
        private bool CanDeleteExecute(object p) => CanButtonClick;
        private void OnDeleteExecuted(object p)
        {
            if (SelectedEmployee != null)
            {
                CanButtonClick = false;
                new SQLEmployee().DeleteEmployee(SelectedEmployee);
                CanButtonClick = true;
                OnUpdateExecuted(null);
            }
        }
        #endregion

        #endregion

        public List<Employees> Employees { get => _Employees; set => Set(ref _Employees, value); }
        List<Employees> _Employees = new SQLEmployee().SelectEmployee();

        public EmployeeVM()
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
