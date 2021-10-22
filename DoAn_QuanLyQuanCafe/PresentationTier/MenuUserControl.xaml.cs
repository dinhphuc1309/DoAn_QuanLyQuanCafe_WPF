using DoAn_QuanLyQuanCafe.BusinessTier;
using DoAn_QuanLyQuanCafe.DataContext;
using DoAn_QuanLyQuanCafe.DTO;
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

namespace DoAn_QuanLyQuanCafe.PresentationTier
{
    /// <summary>
    /// Interaction logic for MenuUserControl.xaml
    /// </summary>
    public partial class MenuUserControl : UserControl
    {
        private ThucUongBT thucUongBT;

        public MenuUserControl()
        {
            InitializeComponent();
            thucUongBT = new ThucUongBT();
        }


        private void TaiDanhMenuLenManHinh()
        {
            ListViewProducts.ItemsSource = thucUongBT.LayDanhSachTatCaThucUong();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            TaiDanhMenuLenManHinh();
        }



        private void btnThemVaoHoaDon_Click(object sender, RoutedEventArgs e)
        {
            int soLuong = 1;
            Button a = (Button)sender;
            int maTU = (int)a.Tag;
            //MessageBox.Show("Ma thuc uong: " + maTU);
            ThucUong asd = thucUongBT.LayThucUong(maTU);
            ListViewOrder.Items.Add(new { Name = asd.tenThucUong, Value = asd.price, Image = asd.hinh, soLuong = soLuong });


        }

        private void ListViewProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListViewOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void rdbPhanTram_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;
            // ... Display button content as title.
            //TextBlock asd = (TextBlock)button.Content;
            //MessageBox.Show(asd.Text.ToString());
        }
    }
}
