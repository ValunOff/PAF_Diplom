using PAF.ViewModel;
using System.Windows;

namespace PAF.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmployeeAdd.xaml
    /// </summary>
    public partial class EmployeeAdd : Window
    {
        public EmployeeAdd()
        {
            InitializeComponent();
            this.DataContext = new EmployeeVM();
        }
    }
}
