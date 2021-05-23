using System;
using System.Collections.Generic;

namespace PAF.Data.Classes
{
    public class Delivery : ViewModel.ViewModel
    {
        /// <summary> Id поставки </summary>
        public int Id { get; set; }
        /// <summary> Id поставщика </summary>
        public Supply Supply { get; set; }
        /// <summary> Дата продажи </summary>
        public DateTime Date { get; set; }
        /// <summary> Id состава продажи </summary>
        public List<DeliveryComposition> DeliveryComposition { get; set; }
    }
}