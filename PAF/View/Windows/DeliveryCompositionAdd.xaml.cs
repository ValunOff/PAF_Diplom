using PAF.ViewModel;
using System.Windows;

namespace PAF.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для DeliveryCompositionAdd.xaml
    /// </summary>
    public partial class DeliveryCompositionAdd : Window
    {
        public DeliveryCompositionAdd()
        {
            InitializeComponent();
            this.DataContext = new DeliveryCompositionVM();
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
    }
}
