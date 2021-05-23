using PAF.Data.Entityies;
using System.Collections.Generic;

namespace PAF.Data.Classes
{
    public class Employee : ViewModel.ViewModel
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
        public List<Sale> Sales { get => _Sale; set => Set(ref _Sale, value); }

        #region 
        int _Id;
        string _LastName;
        string _FirstName;
        string _MiddleName;
        Genders _Gender;
        decimal _Salary;
        List<Sale> _Sale;
        #endregion
    }
}