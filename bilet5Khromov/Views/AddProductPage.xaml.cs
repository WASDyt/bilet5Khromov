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
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        private ProductViewModel _viewModel;
        public Product _product;
        internal AddProductPage(ProductViewModel viewModel, Product product = null)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _product = product ?? new Product();

            if (_product != null)
            {
                NameTextBox.Text = _product.name;
                TypeTextBox.Text = _product.type;
                PriceTextBox.Text = _product.price.ToString();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _product.name = NameTextBox.Text;
            _product.type = TypeTextBox.Text;
            
            _product.price = int.Parse(PriceTextBox.Text);

            if (_product.idProduct == 0)
            {
                _viewModel.Product.Add(_product);
                _viewModel._productService.AddProduct(_product);
            }
            else
            {
                _viewModel._productService.EditProduct(_product);
            }

            NavigationService.GoBack();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
