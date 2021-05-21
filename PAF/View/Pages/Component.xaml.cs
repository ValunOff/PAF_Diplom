using PAF.ViewModel;
using System.Windows.Controls;

namespace PAF.View.Pages
{
    public partial class Component : Page
    {
        public Component()
        {
            InitializeComponent();
            this.DataContext = new ComponentVM();
        }
    }
}
