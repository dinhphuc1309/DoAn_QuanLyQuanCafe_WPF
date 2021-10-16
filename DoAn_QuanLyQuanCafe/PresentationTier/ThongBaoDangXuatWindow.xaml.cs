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
    /// Interaction logic for ThongBaoDangXuatWindow.xaml
    /// </summary>
    public partial class ThongBaoDangXuatWindow : Window
    {
        public ThongBaoDangXuatWindow()
        {
            InitializeComponent();
        }

        private void btnKhong_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCo_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
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
