namespace PAF.Data.Entityies
{
    public class DeliveriesCompositions : ViewModel.ViewModel
    {
        /// <summary> Id состава поставки </summary>
        public int Id { get; set; }
        /// <summary> Id компонента </summary>
        public Components Component { get; set; }
        /// <summary> Цена закупочная </summary>
        public decimal Price { get; set; }
        /// <summary> Количество </summary>
        public int Amount { get; set; }
        /// <summary> Стоимость </summary>
        public decimal Sum
        {
            get => Sum;
            set => Sum = Price * Amount;
        }
        /// <summary> Номер поставки </summary>
        public Deliveries Delivery { get; set; }
    }
}