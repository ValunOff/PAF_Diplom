using PAF.Data.Clases;
using PAF.Data.Entityies;
using PAF.ViewModel;
using System.Collections.Generic;
using System.Windows;
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
