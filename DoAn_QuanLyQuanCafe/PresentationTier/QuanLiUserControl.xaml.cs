using DoAn_QuanLyQuanCafe.BusinessTier;
using DoAn_QuanLyQuanCafe.DataContext;
using DoAn_QuanLyQuanCafe.DTO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for QuanLiUserControl.xaml
    /// </summary>
    public partial class QuanLiUserControl : UserControl
    {
        private ThucUongBT thucUongBT;

        public QuanLiUserControl()
        {
            DataContext = this;
            InitializeComponent();
            thucUongBT = new ThucUongBT();
        }

        private void TaiDanhMenuLenManHinh()
        {
            ListViewQuanLi.ItemsSource = thucUongBT.LayDanhSachTatCaThucUong();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListViewQuanLi.ItemsSource);
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

        private void CaiDatChucNang(bool status)
        {
            btnThem.IsEnabled = status;
            btnCapNhat.IsEnabled = !status;
            btnHuy.IsEnabled = !status;
            btnXoa.IsEnabled = !status;
     
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TaiDanhMenuLenManHinh();
            CaiDatChucNang(true);
        }


        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenThucUong.Text))
            {
                TenMonNull tenMonNull = new TenMonNull();
                tenMonNull.ShowDialog();
                return;
            }
            if (string.IsNullOrEmpty(txtGia.Text))
            {
                GiaNull giaNull = new GiaNull();
                giaNull.ShowDialog();
                return;
            }
            string error;
            ThucUong thucUong = new ThucUong();
            thucUong.tenThucUong = txtTenThucUong.Text;
            thucUong.price = int.Parse(txtGia.Text);
            thucUong.hinh = txtDuongDanHinh.Text;
            if (thucUongBT.LuuThucUong(thucUong, out error))
            {
                ThemMonThanhCong themMonThanhCong = new ThemMonThanhCong();
                themMonThanhCong.ShowDialog();
                //lam moi danh sach tu DB
                TaiDanhMenuLenManHinh();
                txtTenThucUong.Text = "";
                txtGia.Text = "";
                txtDuongDanHinh.Text = "";
            }
            else
            {
                MessageBox.Show("Lỗi: " + error);
                return;
            }
        }
        int maTU;
        private void btnChinhSua_Click(object sender, RoutedEventArgs e)
        {
         
            Button a = (Button)sender;
            maTU = (int)a.Tag;
            ThucUong asd = thucUongBT.LayThucUong(maTU);
            txtTenThucUong.Text = asd.tenThucUong;
            txtGia.Text = asd.price.ToString();
            txtDuongDanHinh.Text = asd.hinh;
            CaiDatChucNang(false);
          

        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            

            if (maTU == -1)
            {
                ChuaChonMon chuaChonMon = new ChuaChonMon();
                chuaChonMon.ShowDialog();
                return;

            }
            string error;

            if (thucUongBT.XoaThucUong(maTU, out error))
            {
                XoaMonThanhCong xoaMonThanhCong = new XoaMonThanhCong();
                xoaMonThanhCong.ShowDialog();
                //lam moi danh sach tu DB
                TaiDanhMenuLenManHinh();
                CaiDatChucNang(true);
                txtTenThucUong.Text = "";
                txtGia.Text = "";
                txtDuongDanHinh.Text = "";
            }
            else
            {
                MessageBox.Show("Lỗi: " + error);
                return;
            }
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            CaiDatChucNang(true);
            txtTenThucUong.Text = "";
            txtGia.Text = "";
            txtDuongDanHinh.Text = "";
        }

        private void btnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenThucUong.Text))
            {
                TenMonNull tenMonNull = new TenMonNull();
                tenMonNull.ShowDialog();
                return;
            }
            if (string.IsNullOrEmpty(txtGia.Text))
            {
                GiaNull giaNull = new GiaNull();
                giaNull.ShowDialog();
                return;
            }
            string error;
            ThucUong thucUong = new ThucUong();
            thucUong.tenThucUong = txtTenThucUong.Text;
            thucUong.price = int.Parse(txtGia.Text);
            thucUong.hinh = txtDuongDanHinh.Text;
            thucUong.maThucUong = maTU;
            if (thucUongBT.LuuThucUong(thucUong, out error))
            {
                SuaThangCong suaThangCong = new SuaThangCong();
                suaThangCong.ShowDialog();
                //lam moi danh sach tu DB
                TaiDanhMenuLenManHinh();
                CaiDatChucNang(true);
                txtTenThucUong.Text = "";
                txtGia.Text = "";
                txtDuongDanHinh.Text = "";
            }
            else
            {
                MessageBox.Show("Lỗi: " + error);
                return;
            }
        }

        private void txtTimThucUong_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ListViewQuanLi.ItemsSource).Refresh();
        }


        private void txtGia_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
