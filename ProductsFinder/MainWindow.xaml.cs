using Database;
using ProductsFinder.Models;
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

            AddAddonsToComboBox();
        }

        private void AddAddonsToComboBox()
        {
            addonsComboBox.Items.Add(new Addon() { Id = 1, Name = "Tarcza" });
            addonsComboBox.Items.Add(new Addon() { Id = 2, Name = "Lokalizacja tarczy" });
            addonsComboBox.Items.Add(new Addon() { Id = 3, Name = "Króciec olejowy" });
            addonsComboBox.Items.Add(new Addon() { Id = 4, Name = "Nasadka" });
        }

        private async void searchByNumberButton_Click(object sender, RoutedEventArgs e)
        {
            await SearchByModelNumber();
        }

        private async void searchByTagButton_Click(object sender, RoutedEventArgs e)
        {
            await SearchByTag();
        }

        private async void searchByAddonButton_Click(object sender, RoutedEventArgs e)
        {
            await SearchByAddon();
        }

        private async void modelNumberTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                await SearchByModelNumber();
            }
        }

        private async void tagTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                await SearchByTag();
            }
        }

        private async void addonTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                await SearchByAddon();
            }
        }

        private async Task SearchByModelNumber()
        {
            string modelNumber = modelNumberTextbox.Text;
            if (String.IsNullOrEmpty(modelNumber))
            {
                MessageBox.Show("Numer modelu jest pusty!", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var product = await ProductsManager.GetProductByNumber(modelNumber);
            if (product == null)
            {
                MessageBox.Show("Nie znaleziono produktu", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            DetailsWindow detailsWindow = new DetailsWindow(product);
            detailsWindow.ShowDialog();
        }

        private async Task SearchByTag()
        {
            string tag = tagTextbox.Text;
            if (String.IsNullOrEmpty(tag))
            {
                MessageBox.Show("Tag jest pusty!", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var product = await ProductsManager.GetProductByTag(tag);
            if (product == null)
            {
                MessageBox.Show("Nie znaleziono produktu", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            DetailsWindow detailsWindow = new DetailsWindow(product);
            detailsWindow.ShowDialog();
        }

        private async Task SearchByAddon()
        {
            var selectedItem = addonsComboBox.SelectedItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Wybierz parametr z listy!", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Addon selectedAddon = (Addon)selectedItem;
            int addonNumber = selectedAddon.Id;
            string addonContent = addonTextbox.Text;

            var productsList = await ProductsManager.GetProductsByAddon(addonContent, addonNumber);

            ListWindow listWindow = new ListWindow(productsList);
            listWindow.Show();
        }
    }
}
