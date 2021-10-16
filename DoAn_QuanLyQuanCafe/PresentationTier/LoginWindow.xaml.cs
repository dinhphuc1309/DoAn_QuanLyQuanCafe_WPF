using DoAn_QuanLyQuanCafe.BusinessTier;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly TaiKhoanBT taikhoanBT;
        MainScreenWindow mainScreenWindow;
        ErrorNullTK errorNullTK;
        ErrorSaiTKMK errorSaiTKMK;
        public LoginWindow()
        {
            taikhoanBT = new TaiKhoanBT();
            InitializeComponent();
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }


        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            string userName = txtTenDangNhap.Text.Trim();
            string passWord = txtMatKhau.Password.Trim();
            //CheckLogin(userName, passWord);   
            if (userName == "" || passWord == "")
            {
                errorNullTK = new ErrorNullTK();
                errorNullTK.ShowDialog();
                return;
            }

            if (taikhoanBT.KiemTraDangNhap(userName, passWord))
            {
                mainScreenWindow = new MainScreenWindow();
                this.Hide();
                mainScreenWindow.Show();
                this.Close();

            }
            else
            {
                errorSaiTKMK = new ErrorSaiTKMK();
                errorSaiTKMK.ShowDialog();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
