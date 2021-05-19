using PAF.ViewModel;
using System.Windows;

namespace PAF.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для DeliveryAdd.xaml
    /// </summary>
    public partial class DeliveryAdd : Window
    {
        public DeliveryAdd()
        {
            InitializeComponent();
            this.DataContext = new DeliveryVM();
        }
    }
}
