using Database.Models;
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

namespace ProductsFinder
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        public IEnumerable<Product> ProductsList { get; }
        public ListWindow(IEnumerable<Product> productsList)
        {
            InitializeComponent();
            ProductsList = productsList;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProductsGrid.ItemsSource = ProductsList;
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow dataGridRow = (DataGridRow)sender;
            Product product = (Product)dataGridRow.DataContext;

            DetailsWindow detailsWindow = new DetailsWindow(product);
            detailsWindow.Show();
        }
    }
}
