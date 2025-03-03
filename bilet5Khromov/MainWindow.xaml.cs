﻿using bilet5Khromov.BD;
using bilet5Khromov.Views;
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

namespace bilet5Khromov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LoginPage());
        }

        public void NavigateToHomePage(Users user)
        {
            if (user.role == "user")
            {
                MainFrame.Navigate(new UserProductPage());
            }
            else if (user.role == "manager")
            {
                MainFrame.Navigate(new OrdersPage());
            }
            else if (user.role == "admin")
            {
                MainFrame.Navigate(new ProductsPage()); // Navigate to Admin page if needed
            }
        }
    }
}
