using bilet5Khromov.BD;
using bilet5Khromov.ViewModels;

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

namespace bilet5Khromov.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        private ProductViewModel _viewModel;

        public ProductsPage()
        {
            InitializeComponent();

            _viewModel = new ProductViewModel();
            DataContext = _viewModel;
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate (new AddProductPage(_viewModel));
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductListView.SelectedItem is Product selectedProduct)
            {
                NavigationService.Navigate(new AddProductPage(_viewModel, selectedProduct));
            }
        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductListView.SelectedItem is Product selectedProduct)
            {
                _viewModel.Product.Remove(selectedProduct);
                _viewModel._productService.DeleteProduct(selectedProduct.idProduct);
            }
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrdersPage());
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadProducts();
        }
    }
}