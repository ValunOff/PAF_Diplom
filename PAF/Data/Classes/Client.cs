using PAF.Data.Entityies;
using System.Collections.Generic;

namespace PAF.Data.Classes
{
    public class Client : ViewModel.ViewModel
    {
        /// <summary> Id клиента </summary>
        public int Id { get => _Id; set => Set(ref _Id, value); }
        /// <summary> Фамилия </summary>
        public string LastName { get => _LastName; set => Set(ref _LastName, value); }
        /// <summary> Имя </summary>
        public string FirstName { get => _FirstName; set => Set(ref _FirstName, value); }
        /// <summary> Отчество </summary>
        public string MiddleName { get => _MiddleName; set => Set(ref _MiddleName, value); }
        /// <summary> Пол </summary>
        public Genders Gender { get => _Gender; set => Set(ref _Gender, value); }
        /// <summary> Телефон клиента </summary>
        public string Phone { get => _Phone; set => Set(ref _Phone, value); }
        /// <summary> Список продаж </summary>
        public List<Sale> Sales { get => _Sale; set => Set(ref _Sale, value); }

        #region 
        int _Id;
        string _LastName;
        string _FirstName;
        string _MiddleName;
        Genders _Gender;
        string _Phone;
        List<Sale> _Sale;
        #endregion
    }
}