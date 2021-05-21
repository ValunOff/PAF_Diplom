using PAF.ViewModel;
using System.Windows.Controls;

namespace PAF.View.Pages
{
    public partial class Type : Page
    {
        public Type()
        {
            InitializeComponent();
            this.DataContext = new TypeVM();
        }
    }
}
