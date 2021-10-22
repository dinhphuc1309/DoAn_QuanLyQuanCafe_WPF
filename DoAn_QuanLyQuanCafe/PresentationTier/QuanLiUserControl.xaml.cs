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
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TaiDanhMenuLenManHinh();
        }

        private void ListViewQuanLi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private string _imageInput = "/Images/backgroudAnh.png";
        public string ImageInput
        {
            get { return _imageInput; }
            set
            {
                if(_imageInput != value)
                {
                    _imageInput = value;
                }
            }
        }


        private void btnImageInput_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
          
        }
    }
}
