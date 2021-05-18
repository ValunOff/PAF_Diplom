using PAF.ViewModel;
using System.Windows.Controls;

namespace PAF.View.Pages
{
    public partial class Employee : Page
    {
        public Employee()
        {
            InitializeComponent();
            this.DataContext = new EmployeeVM();
        }
    }
}
