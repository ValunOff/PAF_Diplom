using PAF.ViewModel;
using System.Windows.Controls;

namespace PAF.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SalayComposition.xaml
    /// </summary>
    public partial class SalayComposition : Page
    {
        public SalayComposition()
        {
            InitializeComponent();
            this.DataContext = new SalayCompositionVM();
        }
    }
}
