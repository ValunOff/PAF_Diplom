using System.Collections.Generic;

namespace PAF.Data.Entityies
{
    public class Types : ViewModel.ViewModel
    {
        /// <summary> Id типа </summary>
        public int Id { get; set; }
        /// <summary> Название типа </summary>
        public string Name { get; set; }
        /// <summary> Сокращение типа </summary>
        public string ShortName { get; set; }
        public List<Components> Component { get; set; }
    }
}