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
using Excel = Microsoft.Office.Interop.Excel;

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

        private void TaiDanhSachHoaDonLenManHinh(int y = 0, int m = 0, int d = 0)
        {
            
            if (y > 0 && m > 0)
                listViewHoaDon.ItemsSource = hoaDonBT.LocHoaDon(y, m, d);
            else
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
            if (item != null)
                listViewChiTietHoaDon.ItemsSource = chiTietHoaDonBT.LayDanhSachChiTietTheoMaHoaDon(item.MaHoaDon);
        }

        private void LocaleDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime a = (DateTime)dtpChonNgayHienHoaDon.SelectedDate;

            TaiDanhSachHoaDonLenManHinh(a.Year, a.Month, a.Day);
        }

        private void btnExcelExport_Click(object sender, RoutedEventArgs e)
        {
            var ExcelApp = new Excel.Application
            {
                Visible = true
            };
            var wb = ExcelApp.Workbooks.Add(1); 
            var ws = wb.Worksheets[1]; 
            int Columns = 1;
            int Rows = 1;

            ws.Cells[Rows, Columns++] = "Mã hoá đơn";
            ws.Columns[Columns].ColumnWidth = 12;
            ws.Cells[Rows, Columns++] = "Ngày lập";
            ws.Cells[Rows, Columns++] = "Tổng tiền";
            ws.Columns[Columns].ColumnWidth = 20;
            ws.Cells[Rows, Columns++] = "Ghi chú";

            foreach (HoaDonDTO lvi in listViewHoaDon.Items)
            {
                Columns = 1;
                Rows++;
                ws.Cells[Rows, Columns++] = lvi.MaHoaDon;
                ws.Cells[Rows, Columns++] = lvi.NgayMua.ToShortDateString();
                ws.Cells[Rows, Columns++] = lvi.TongTien;
                ws.Cells[Rows, Columns++] = lvi.GhiChu;
            }
        }
    }
}
