using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAF.Data.Entityies
{
    public class Components : ViewModel.ViewModel
    {
        /// <summary> Id компонента </summary>
        public int Id { get; set; }
        /// <summary> Название компонента </summary>
        public string Name { get; set; }
        /// <summary> Id компонента </summary>
        [ForeignKey("TypesId")] 
        public Types Type { get; set; }

        public int TypesId { get; set; }
        /// <summary> Единиц на складе </summary>
        public int Amount { get; set; }
        /// <summary> Id поставщика </summary>
        [ForeignKey("SuppliesId")] 
        public Supplies Supply { get; set; }
        public int SuppliesId { get; set; }
        /// <summary> Id состава продажи </summary>
        public List<SalesCompositions> SaleComposition { get; set; }
        /// <summary> Id состава поставки </summary>
        public List<DeliveriesCompositions> DeliveryComposition { get; set; }
    }
}