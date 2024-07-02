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
    internal class OrderViewModel : BaseViewModel
    {
        public OrderService _orderService;
        public ObservableCollection<Order> Order { get; set; }

        public OrderViewModel()
        {
            _orderService = new OrderService();
            Order = new ObservableCollection<Order>();
            LoadProducts();
        }

        public void LoadProducts()
        {
            Order.Clear();
            var products = _orderService.GetOrders();
            foreach (var product in products)
            {
                Order.Add(product);
            }
        }
    }
}
