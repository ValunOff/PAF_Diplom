using PAF.ViewModel;
using System.Windows;

namespace PAF.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для SalayCompositionAdd.xaml
    /// </summary>
    public partial class SalayCompositionAdd : Window
    {
        public SalayCompositionAdd()
        {
            InitializeComponent();
            this.DataContext = new SalayCompositionVM();
        }
    }
}
