using System.Collections.Generic;

namespace PAF.Data.Entityies
{
    public class Supplies : ViewModel.ViewModel
    {
        /// <summary> Id поставщика </summary>
        public int Id { get; set; }
        /// <summary> Наименование поставщика </summary>
        public string Name { get; set; }
        /// <summary> Адрес поставщика </summary>
        public string Address { get; set; }
        /// <summary> Id поставки </summary>
        public List<DeliveriesCompositions> DeliveriesCompositions { get; set; }
        /// <summary> Id компонента </summary>
        public List<Components> Component { get; set; }
    }
}