using PAF.Data.Entityies;
using PAF.ViewModel;
using System.Windows;

namespace PAF.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для DeliveryAdd.xaml
    /// </summary>
    public partial class DeliveryAdd : Window
    {
        Deliveries delivery = new Deliveries();
        public DeliveryAdd()
        {
            InitializeComponent();
            this.DataContext = new DeliveryVM();
        }

        private void StackPanel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            delivery.Supply = Supply.Text;

        }
    }
}
