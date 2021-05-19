using PAF.Commands.Base;
using PAF.Data;
using PAF.Data.Entityies;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace PAF.ViewModel
{
    class ComponentVM : ViewModel
    {
        /// <summary>Пока прога работает с бд, лучше запретить все кнопки для работы с бд</summary>
        bool CanButtonClick = true;
        
        #region Commands

        #region SaveChangesCommand
        public ICommand SaveChangesCommand { get; set; }
        private bool CanSaveChangesExecute(object p) => CanButtonClick;
        private void OnSaveChangesExecuted(object p)
        {
            new SQL().UpdateComponent(_Components);
        }
        #endregion

        #region AddCommand
        public ICommand AddCommand { get; set; }
        private bool CanAddExecute(object p) => CanButtonClick;
        private void OnAddExecuted(object p)
        {
            MessageBox.Show("Hello");
        }
        #endregion

        #region UpdateCommand
        public ICommand UpdateCommand { get; set; }
        private bool CanUpdateExecute(object p) => CanButtonClick;
        private void OnUpdateExecuted(object p)
        {
            Components = new SQL().SelectComponent();
        }
        #endregion

        #endregion

        public List<Components> Components { get => _Components; set => Set(ref _Components, value); }
        List<Components> _Components = new SQL().SelectComponent();

        public ComponentVM()
        {
            #region Commands
            SaveChangesCommand = new LambdaCommand(OnSaveChangesExecuted, CanSaveChangesExecute);
            AddCommand = new LambdaCommand(OnAddExecuted, CanAddExecute);
            UpdateCommand = new LambdaCommand(OnUpdateExecuted, CanUpdateExecute);
            #endregion
        }
    }
}
