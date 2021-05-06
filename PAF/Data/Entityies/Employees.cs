using System.Collections.Generic;

namespace PAF.Data.Entityies
{
    public class Employees : ViewModel.ViewModel
    {
        /// <summary> Id сотрудника </summary>
        public int Id { get => _Id; set => Set(ref _Id, value); }
        /// <summary> Фамилия </summary>
        public string LastName { get => _LastName; set => Set(ref _LastName, value); }
        /// <summary> Имя </summary>
        public string FirstName { get => _FirstName; set => Set(ref _FirstName, value); }
        /// <summary> Отчество </summary>
        public string MiddleName { get => _MiddleName; set => Set(ref _MiddleName, value); }
        /// <summary> Пол </summary>
        public Genders Gender { get => _Gender; set => Set(ref _Gender, value); }
        /// <summary> Зарплата сотрудника </summary>
        public decimal Salary { get => _Salary; set => Set(ref _Salary, value); }
        /// <summary> Список продаж </summary>
        public List<Sales> Sales { get => _Sales; set => Set(ref _Sales, value); }

        #region 
        int _Id;
        string _LastName;
        string _FirstName;
        string _MiddleName;
        Genders _Gender;
        decimal _Salary;
        List<Sales> _Sales;
        #endregion
    }
}