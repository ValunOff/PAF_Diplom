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
