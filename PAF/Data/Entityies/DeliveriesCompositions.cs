using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PAF.Data.Entityies
{
    public class DeliveriesCompositions : ViewModel.ViewModel
    {
        /// <summary> Id состава поставки </summary>
        public int Id { get => _Id; set => Set(ref _Id,value); }
        public string Name { get => _Name; set => Set(ref _Name, value); }
        /// <summary> Цена закупочная </summary>
        public decimal Price { get => _Price; set => Set(ref _Price, value); }
        /// <summary> Количество </summary>
        public int Amount { get => _Amount; set => Set(ref _Amount, value); }
        /// <summary> Стоимость </summary>
        public decimal Sum
        {
            get => Sum;
            set => Sum = Price * Amount;
        }
        /// <summary> Id компонента </summary>
        [ForeignKey("ComponentsId")]
        public Components Component { get => _Component; set => Set(ref _Component, value); }
        public int ComponentsId { get; set; }


        public List<Supplies> Supplies { get; set; }

        ///// <summary> Номер поставки </summary>возможно это не нужно
        //[ForeignKey("DeliveriesId")]
        //public Deliveries Delivery { get => _Delivery; set => Set(ref _Delivery, value); }
        //public int DeliveriesId { get; set; }






        int _Id;
        string _Name;
        decimal _Price;
        int _Amount;
        decimal _Sum;
        Components _Component;
       // Deliveries _Delivery;
    }
}