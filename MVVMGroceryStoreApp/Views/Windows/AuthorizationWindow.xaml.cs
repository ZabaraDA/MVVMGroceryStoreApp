﻿using System;
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

namespace MVVMGroceryStoreApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// Окно авторизации
    /// </summary>
    public partial class AuthorizationWindow : Window
    {

        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { 
                ((dynamic)DataContext).Password = ((PasswordBox)sender).SecurePassword;
            }
        }
    }
}
