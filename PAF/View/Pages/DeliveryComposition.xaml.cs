using PAF.ViewModel;
using System.Windows.Controls;

namespace PAF.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для DeliveryComposition.xaml
    /// </summary>
    public partial class DeliveryComposition : Page
    {
        public DeliveryComposition()
        {
            InitializeComponent();
            DataContext = new DeliveryCompositionVM();
        }
    }
}
