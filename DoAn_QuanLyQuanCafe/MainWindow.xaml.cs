using DoAn_QuanLyQuanCafe.PresentationTier;
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

namespace DoAn_QuanLyQuanCafe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginWindow loginWindow;
        ErrorWindow errorWindow;
        VaoCaWindow vaoCaWindow;
        public MainWindow()
        {
            InitializeComponent();
            loginWindow = new LoginWindow();
            loginWindow.Show();
            errorWindow = new ErrorWindow();
            errorWindow.Show();
            vaoCaWindow = new VaoCaWindow();
            vaoCaWindow.Show();


        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MenuClick(object sender, RoutedEventArgs e)
        {
            myFrame.NavigationService.Navigate(new MenuUserControl());
        }

        private void ThongKeClick(object sender, RoutedEventArgs e)
        {
            myFrame.NavigationService.Navigate(new ThongKeUserControl());
        }

        private void CaiDatClick(object sender, RoutedEventArgs e)
        {
            myFrame.NavigationService.Navigate(new CaiDatUserControl());
        }
    }
}
