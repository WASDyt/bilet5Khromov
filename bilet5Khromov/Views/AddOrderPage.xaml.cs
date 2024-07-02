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
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        private OrderViewModel _viewModel;
        public Order _order;
        internal AddOrderPage(OrderViewModel viewModel, Order order = null)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _order = order ?? new Order();


            if (_order != null)
            {
                DateTextBox.Text = _order.order_date.ToString("yyyy-MM-dd");
                QuantityTextBox.Text = _order.quantity.ToString();
                idUserTextBox.Text = _order.idUser.ToString();
                idProductTextBox.Text = _order.idProduct.ToString();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DateTime.TryParse(DateTextBox.Text, out DateTime date))
            {
                _order.order_date = date;
                _order.quantity = int.Parse(QuantityTextBox.Text);
                _order.idUser = int.Parse(idUserTextBox.Text);
                _order.idProduct = int.Parse(idProductTextBox.Text);

                if (_order.idProduct == 0)
                {
                    _viewModel.Order.Add(_order);
                    _viewModel._orderService.AddOrder(_order);
                }
                else
                {
                    _viewModel._orderService.EditOrder(_order);
                }
                NavigationService.GoBack();
            }
            else
            {
                // Обработка ошибки преобразования даты
                MessageBox.Show("Неверный формат даты.");
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
