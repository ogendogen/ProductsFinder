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

            // open window with full details of product
        }

        private void searchByAddonButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
