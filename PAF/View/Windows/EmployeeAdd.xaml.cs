using PAF.Data.Clases;
using PAF.Data.Entityies;
using PAF.ViewModel;
using System;
using System.Windows;

namespace PAF.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmployeeAdd.xaml
    /// </summary>
    public partial class EmployeeAdd : Window
    {
        Employees employee = new Employees();
        public EmployeeAdd()
        {
            InitializeComponent();
            this.DataContext = new EmployeeVM();
            Gender.SelectedValue = Genders.Муж;
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

        private void ButtonEmployeeAdd(object sender, RoutedEventArgs e)
        {
            bool error;
            employee.LastName = LastName.Text;
            employee.FirstName = FirstName.Text;
            employee.MiddleName = MiddleName.Text;

            if (Gender.SelectedValue == null)
                employee.Gender = Genders.Муж;
            else
                employee.Gender = (Genders)Gender.SelectedValue;
            try
            {
                employee.Salary = Convert.ToDecimal(Salary.Text);
                new SQLEmployee().InsertEmployee(employee);

                Close();
            }
            catch
            {
                MessageBox.Show("Вводи сука числа в зарплату!");
            }
        }

        private void ButtonClose(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
