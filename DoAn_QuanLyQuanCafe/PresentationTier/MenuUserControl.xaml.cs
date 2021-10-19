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
        public MenuUserControl()
        {
            InitializeComponent();
            var products = GetProducts();
            if (products.Count > 0)
                ListViewProducts.ItemsSource = products;
        }

        private List<ThucUongDTO> GetProducts()
        {
            return new List<ThucUongDTO>()
            {
                new ThucUongDTO("Espresso",35.000, "/Images/product0.jpg" ),
                new ThucUongDTO("Espresso",35.000, "/Images/product0.jpg" ),
                new ThucUongDTO("Espresso",35.000, "/Images/product0.jpg" ),
                new ThucUongDTO("Espresso",35.000, "/Images/product0.jpg" ),
                new ThucUongDTO("Espresso",35.000, "/Images/product0.jpg" ),
                new ThucUongDTO("Espresso",35.000, "/Images/product0.jpg" )
            };
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }


    }
}
