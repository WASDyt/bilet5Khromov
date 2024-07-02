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
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        private OrderViewModel _viewModel;

        public OrdersPage()
        {
            InitializeComponent();
            _viewModel = new OrderViewModel();
            DataContext = _viewModel;
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddOrderPage(_viewModel));
        }

        private void EditOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrderListView.SelectedItem is Order selectedOrder)
            {
                NavigationService.Navigate(new AddOrderPage(_viewModel, selectedOrder));
            }
        }
        private void DeleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (OrderListView.SelectedItem is Order selectedOrder)
            {
                _viewModel.Order.Remove(selectedOrder);
                _viewModel._orderService.DeleteOrder(selectedOrder.idOrder);
            }
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage());
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadProducts();
        }
    }
}