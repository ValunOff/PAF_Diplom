namespace PAF.Data.Classes
{
    public class SaleComposition : ViewModel.ViewModel
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
        public Component Component { get; set; }
        /// <summary> Номер продажи </summary>
        public Sale Sale { get; set; }
    }
}