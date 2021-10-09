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
using System.Windows.Shapes;

namespace DoAn_QuanLyQuanCafe.PresentationTier
{
    /// <summary>
    /// Interaction logic for MainScreenWindow.xaml
    /// </summary>
    public partial class MainScreenWindow : Window
    {
        public MainScreenWindow()
        {
            InitializeComponent();
        }

        private void MenuClick(object sender, RoutedEventArgs e)
        {
            myFrame.NavigationService.Navigate(new MenuUserControl());
            txtName.Text = "Menu";
        }

        private void ThongKeClick(object sender, RoutedEventArgs e)
        {
            myFrame.NavigationService.Navigate(new ThongKeUserControl());
            txtName.Text = "Thống kê";
        }

        private void CaiDatClick(object sender, RoutedEventArgs e)
        {
            myFrame.NavigationService.Navigate(new CaiDatUserControl());
            txtName.Text = "Cài đặt";
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
