using PAF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PAF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowVM VM = new MainWindowVM();
            this.DataContext = VM;
            if (VM.CloseAction == null) VM.CloseAction = new Action(() => this.Close());
            if (VM.FullscreenAction == null) VM.FullscreenAction = new Action(() => WindowStateCheck());
            if (VM.MinimizeAction == null) VM.MinimizeAction = new Action(() => this.WindowState = WindowState.Minimized);
        }
        public void WindowStateCheck()
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                FullscreenIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowRestore;
            }
            else
            {
                this.WindowState = WindowState.Normal;
                FullscreenIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowMaximize;
            }
        }

    private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
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
