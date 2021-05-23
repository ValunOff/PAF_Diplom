using System.Collections.Generic;

namespace PAF.Data.Classes
{
    public class Component : ViewModel.ViewModel
    {
        /// <summary> Id компонента </summary>
        public int Id { get; set; }
        /// <summary> Название компонента </summary>
        public string Name { get; set; }
        /// <summary> Id компонента </summary>
        public Type Type { get; set; }
        /// <summary> Единиц на складе </summary>
        public int Amount { get; set; }
        /// <summary> Id поставщика </summary>
        public Supply Supply { get; set; }
        /// <summary> Id состава продажи </summary>
        public List<SaleComposition> SaleComposition { get; set; }
        /// <summary> Id состава поставки </summary>
        public List<DeliveryComposition> DeliveryComposition { get; set; }
    }
}