using Database;
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

namespace ProductsFinder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ProductsManager ProductsManager { get; set; }
        public MainWindow()
        {
            ProductsManager = new ProductsManager();
            InitializeComponent();
        }

        private async void searchByNumberButton_Click(object sender, RoutedEventArgs e)
        {
            string modelNumber = modelNumberTextbox.Text;
            if (String.IsNullOrEmpty(modelNumber))
            {
                MessageBox.Show("Numer modelu jest pusty!", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (!Int32.TryParse(modelNumber, out int i_modelNumber))
            {
                MessageBox.Show("Numer modelu nie jest liczbą!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var product = await ProductsManager.GetProductByNumber(i_modelNumber);
            if (product == null)
            {
                MessageBox.Show("Nie znaleziono produktu", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            DetailsWindow detailsWindow = new DetailsWindow(product);
            detailsWindow.ShowDialog();
        }

        private async void searchByAddonButton_Click(object sender, RoutedEventArgs e)
        {
            int addonNumber = 0;
            string addonContent = "";
            if (!String.IsNullOrEmpty(addon1Textbox.Text))
            {
                addonNumber = 1;
                addonContent = addon1Textbox.Text;
            }
            else if (!String.IsNullOrEmpty(addon2Textbox.Text))
            {
                addonNumber = 2;
                addonContent = addon2Textbox.Text;
            }
            else if (!String.IsNullOrEmpty(addon3Textbox.Text))
            {
                addonNumber = 3;
                addonContent = addon3Textbox.Text;
            }
            else if (!String.IsNullOrEmpty(addon4Textbox.Text))
            {
                addonNumber = 4;
                addonContent = addon4Textbox.Text;
            }

            var productsList = await ProductsManager.GetProductsByAddon(addonContent, addonNumber);

            ListWindow listWindow = new ListWindow(productsList);
            listWindow.Show();
        }
    }
}
