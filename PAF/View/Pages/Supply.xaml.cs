using PAF.ViewModel;
using System.Windows.Controls;

namespace PAF.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для Supply.xaml
    /// </summary>
    public partial class Supply : Page
    {
        public Supply()
        {
            InitializeComponent();
            this.DataContext = new SupplyVM();
        }
    }
}
