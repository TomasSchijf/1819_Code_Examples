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

namespace _1819_12_Project_BTR.Windows
{
    /// <summary>
    /// Interaction logic for wShowPrice.xaml
    /// </summary>
    public partial class wShowPrice : Window
    {
        /*
         * Controls scherm:
         * 1 ComboBox input -> cbProducts
         * 1 Button -> btnShowPrice
         */
        dcBTRDataContext db = new dcBTRDataContext();
        public wShowPrice()
        {
            InitializeComponent();
            SetData();
        }

        private void SetData()
        {
            // ComboBox vullen met producten uit de Database
            cbProducts.ItemsSource = db.tbl_products.ToList();
            cbProducts.DisplayMemberPath = "name";
        }

        private void btnShowPrice_Click(object sender, RoutedEventArgs e)
        {
            // Controle of er een item geselecteerd is
            if (cbProducts.SelectedItem != null)
            {
                // product ophalen uit ComboBox en opslaan in 'myProduct'
                tbl_product myProduct = (tbl_product)cbProducts.SelectedItem;

                // Prijs ophalen bij het product
                tbl_pricehistory myPH = (from ph in db.tbl_pricehistories
                                         where ph.productId == myProduct.id
                                         && ph.enddate == null
                                         select ph).FirstOrDefault();

                // Controle of er een prijs beschikbaar is
                if (myPH != null)
                {
                    // (OPTIONEEL) Tussenstap: prijs in variable opslaan
                    decimal dPrice = myPH.price;
                    MessageBox.Show("De prijs van " + myProduct.name + " is " + dPrice);
                }
                else
                {
                    MessageBox.Show("Er is voor dit product geen prijs beschikbaar");
                }
            }
        }
    }
}
