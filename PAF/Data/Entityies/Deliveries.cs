using System;
using System.Collections.Generic;

namespace PAF.Data.Entityies
{
    public class Deliveries : ViewModel.ViewModel
    {
        /// <summary> Id поставки </summary>
        public int Id { get; set; }
        /// <summary> Id поставщика </summary>
        public Supplies Supply { get; set; }
        /// <summary> Дата продажи </summary>
        public DateTime Date { get; set; }
        /// <summary> Id состава продажи </summary>
        public List<DeliveriesCompositions> DeliveryComposition { get; set; }
    }
}