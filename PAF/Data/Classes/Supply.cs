using System.Collections.Generic;

namespace PAF.Data.Classes
{
    public class Supply : ViewModel.ViewModel
    {
        /// <summary> Id поставщика </summary>
        public int Id { get; set; }
        /// <summary> Наименование поставщика </summary>
        public string Name { get; set; }
        /// <summary> Адрес поставщика </summary>
        public string Address { get; set; }
        /// <summary> Id поставки </summary>
        public List<Delivery> Delivery { get; set; }
        /// <summary> Id компонента </summary>
        public List<Component> Component { get; set; }
    }
}