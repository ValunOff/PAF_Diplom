using PAF.ViewModel;
using System.Windows.Controls;

namespace PAF.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class Client : Page
    {
        public Client()
        {
            InitializeComponent();
            this.DataContext = new ClientVM();
        }
    }
}
