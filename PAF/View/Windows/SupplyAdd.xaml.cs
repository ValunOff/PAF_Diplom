using PAF.ViewModel;
using System.Windows;

namespace PAF.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для SupplyAdd.xaml
    /// </summary>
    public partial class SupplyAdd : Window
    {
        public SupplyAdd()
        {
            InitializeComponent();
            this.DataContext = new SupplyVM();
        }
    }
}
