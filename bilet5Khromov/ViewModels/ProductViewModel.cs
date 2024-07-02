using bilet5Khromov.BD;
using bilet5Khromov.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bilet5Khromov.ViewModels
{
    internal class ProductViewModel : BaseViewModel
    {
        public ProductService _productService;
        public ObservableCollection<Product> Product { get; set; }

        public ProductViewModel()
        {
            _productService = new ProductService();
            Product = new ObservableCollection<Product>();
            LoadProducts();
        }

        public void LoadProducts()
        {
            Product.Clear();
            var products = _productService.GetProducts();
            foreach (var product in products)
            {
                Product.Add(product);
            }
        }
    }
}
