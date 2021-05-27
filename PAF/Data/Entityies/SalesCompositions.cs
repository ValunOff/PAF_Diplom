using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAF.Data.Entityies
{
    public class SalesCompositions : ViewModel.ViewModel
    {
        /// <summary> Id состава продажи </summary>
        public int Id { get; set; }
        /// <summary> Цена реализации </summary>
        public decimal Price { get; set; }
        /// <summary> Количество </summary>
        public int Amount { get; set; }
        /// <summary> Стоимость </summary>
        public decimal Sum
        {
            get => Sum;
            set => Sum = Price * Amount;
        }


        /// <summary> Id компонента </summary>
        [ForeignKey("ComponentsId")] 
        public Components Component { get; set; }
        public int ComponentsId { get; set; }


        public List<Clients> Clients { get; set; }

        public List<Employees> Employees { get; set; }

        ///// <summary> Номер продажи </summary>
        //[ForeignKey("SalesId")] 
        //public Sales Sale { get; set; }
        //public int SalesId { get; set; }

    }
}