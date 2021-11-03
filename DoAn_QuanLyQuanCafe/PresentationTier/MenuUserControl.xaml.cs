using DoAn_QuanLyQuanCafe.BusinessTier;
using DoAn_QuanLyQuanCafe.DataContext;
using DoAn_QuanLyQuanCafe.DataTier;
using DoAn_QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// 

    public partial class MenuUserControl : UserControl
    {
        private HoaDonDT hoaDonDT;
        private ThucUongBT thucUongBT;
        private ChiTietHoaDonDT chiTietHoaDonDT;

        public MenuUserControl()
        {
            DataContext = this;
            InitializeComponent();
            thucUongBT = new ThucUongBT();
            hoaDonDT = new HoaDonDT();
            chiTietHoaDonDT = new ChiTietHoaDonDT();
        }


        private void TaiDanhMenuLenManHinh()
        {
            ListViewProducts.ItemsSource = thucUongBT.LayDanhSachTatCaThucUong();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListViewProducts.ItemsSource);
            view.Filter = UserFileter;
            view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
        }

        private bool UserFileter(object item)
        {
            if (string.IsNullOrEmpty(txtTimThucUong.Text))
                return true;
            else
                return ((item as ThucUongDTO).Name.IndexOf(txtTimThucUong.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            TaiDanhMenuLenManHinh();
        }

        private int TinhTien()
        {
            int TongTien = 0;
            foreach (BillOrderDTO el in ListViewOrder.Items)
                TongTien += (int)el.tu.price * el.soLuong;
            string tongTien = TongTien == 0 ? "0" : TongTien.ToString() + ".000";
            txtThanhTien.Text = tongTien + "vnđ";
            return TongTien;
        }

        private void btnThemVaoHoaDon_Click(object sender, RoutedEventArgs e)
        {

            //lấy mã thức uống của thẻ được chọn
            Button a = (Button)sender;
            int maTU = (int)a.Tag;
            //lấy dữ liệu của đối tượng thức uống theo mã thức uống
            ThucUong asd = thucUongBT.LayThucUong(maTU);

            foreach (BillOrderDTO el in ListViewOrder.Items)
            {

                if (el.tu.maThucUong == asd.maThucUong)
                {
                    el.soLuong++;
                    ListViewOrder.Items.Refresh();
                    TinhTien();
                    return;
                }
            }
            ListViewOrder.Items.Add(new BillOrderDTO { tu = asd, soLuong = 1 });
            TinhTien();
        }

        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            int tongtien = TinhTien();
            if (tongtien > 0)
            {  
                int maHoaDon = hoaDonDT.NhapHoaDon(txtGhiChu.Text, tongtien);
                foreach (BillOrderDTO el in ListViewOrder.Items)
                {
                    chiTietHoaDonDT.NhapCTHoaDon(maHoaDon, el.tu.maThucUong, el.soLuong);
                    //MessageBox.Show(el.tu.maThucUong + "," + el.soLuong);
                }
                txtThanhTien.Text = "0vnđ";
                txtGhiChu.Text = null;
                ListViewOrder.Items.Clear();
                ThemHoaDonThanhCong themHoaDonThanhCong = new ThemHoaDonThanhCong();
                themHoaDonThanhCong.ShowDialog();
            }
            else
            {
                ChuaChonMon chuaChonMon = new ChuaChonMon();
                chuaChonMon.ShowDialog();
            }
        }


        private void btnTru_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int ma = (int)btn.Tag;
            foreach (BillOrderDTO el in ListViewOrder.Items)
            {
                if (el.tu.maThucUong == ma && el.soLuong > 0)
                {
                    el.soLuong--;
                    if (el.soLuong <= 0) ListViewOrder.Items.Remove(el);
                    ListViewOrder.Items.Refresh();
                    TinhTien();
                    return;
                }
            }
        }

        private void btnCong_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int ma = (int)btn.Tag;
            foreach (BillOrderDTO el in ListViewOrder.Items)
            {
                if (el.tu.maThucUong == ma && el.soLuong > 0)
                {
                    el.soLuong++;
                    ListViewOrder.Items.Refresh();
                    TinhTien();
                    return;
                }
            }
        }

        private void txtTimThucUong_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ListViewProducts.ItemsSource).Refresh();
        }
    }
}
