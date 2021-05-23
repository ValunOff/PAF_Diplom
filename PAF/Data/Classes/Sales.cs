using System.Collections.Generic;
using System;

namespace PAF.Data.Classes
{
    public class Sale : ViewModel.ViewModel
    {
        /// <summary> Id продажи </summary>
        public int Id { get; set; }
        /// <summary> Id клиента </summary>
        public Client Client { get; set; }
        /// <summary> Id сотрудника </summary>
        public Employee Employee { get; set; }
        /// <summary> Дата продажи </summary>
        public DateTime Date { get; set; }
        /// <summary> Id состава продажи </summary>
        public List<SaleComposition> SaleComposition { get; set; }
    }
}