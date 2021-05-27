using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        /// <summary> Логин с которым сотрудник будет входить в систему </summary>
        public string Login { get => _Login; set => Set(ref _Login, value); }
        /// <summary> Пароль с которым сотрудник будет входить в систему </summary>
        public string Password { get => _Password; set => Set(ref _Password, value); }
        /// <summary> Роль сотрудника в бд</summary>
        public string Role { get => _Role; set => Set(ref _Role, value); }
        /// <summary> Список продаж </summary>
        public List<SalesCompositions> Sales { get => _SalesCompositions; set => Set(ref _SalesCompositions, value); }

        #region 
        int _Id;
        string _LastName;
        string _FirstName;
        string _MiddleName;
        Genders _Gender;
        decimal _Salary;
        string _Login;
        string _Password;
        string _Role;
        List<SalesCompositions> _SalesCompositions;
        #endregion
    }
}