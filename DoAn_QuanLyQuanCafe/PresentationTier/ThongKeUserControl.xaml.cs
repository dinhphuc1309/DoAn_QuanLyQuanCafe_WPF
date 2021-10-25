using DoAn_QuanLyQuanCafe.BusinessTier;
using DoAn_QuanLyQuanCafe.DataContext;
using DoAn_QuanLyQuanCafe.DataTier;
using DoAn_QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// Interaction logic for ThongKeUserControl.xaml
    /// </summary>
    public partial class ThongKeUserControl : UserControl
    {
        private HoaDonBT hoaDonBT;
        private ChiTietHoaDonBT chiTietHoaDonBT;
        public ThongKeUserControl()
        {
            InitializeComponent();
            hoaDonBT = new HoaDonBT();
            chiTietHoaDonBT = new ChiTietHoaDonBT();
        }

        private void TaiDanhSachHoaDonLenManHinh()
        {
            listViewHoaDon.ItemsSource = hoaDonBT.LayDanhSachTatCaHoaDon();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listViewHoaDon.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("MaHoaDon", ListSortDirection.Descending));

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TaiDanhSachHoaDonLenManHinh();
        }

        private void listViewHoaDon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HoaDonDTO item = ((ListView)sender).SelectedItem as HoaDonDTO;

            listViewChiTietHoaDon.ItemsSource = chiTietHoaDonBT.LayDanhSachChiTietTheoMaHoaDon(item.MaHoaDon); // nay de hien chi tiet hoa don h lay mahoadonchon dua vao la dc
        }
    }
}
