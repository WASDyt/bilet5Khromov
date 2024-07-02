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
    /// Логика взаимодействия для UserOrderPage.xaml
    /// </summary>
    public partial class UserOrderPage : Page
    {
        private OrderViewModel _viewModel;
        public UserOrderPage()
        {
            InitializeComponent();
            _viewModel = new OrderViewModel();
            DataContext = _viewModel;
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserProductPage());
        }
    }
}
