using System.Collections.Generic;
using System;

namespace PAF.Data.Entityies
{
    public class Sales : ViewModel.ViewModel
    {
        /// <summary> Id продажи </summary>
        public int Id { get; set; }
        /// <summary> Id клиента </summary>
        public Clients Client { get; set; }
        /// <summary> Id сотрудника </summary>
        public Employees Employee { get; set; }
        /// <summary> Дата продажи </summary>
        public DateTime Date { get; set; }
        /// <summary> Id состава продажи </summary>
        public List<SalesCompositions> SaleComposition { get; set; }
    }
}