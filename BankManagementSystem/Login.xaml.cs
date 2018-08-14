using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using BankManagementSystem.DATA_SET;

namespace BankManagementSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();
            BankManagementSystem.DATA_SET.BMSDataSetTableAdapters.AuthenticateUserTableAdapter user = new BankManagementSystem.DATA_SET.BMSDataSetTableAdapters.AuthenticateUserTableAdapter();
            dt = user.AuthenticateUser(EmailBox.Text, passwordBox.Password);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["UserType"].ToString() == "A")
                {
                    BMSMain bms = new BMSMain();
                    Application.Current.MainWindow = bms;
                    bms.Show();
                    Close();
                }
                else
                {
                    BmsUser bmsUser = new BmsUser(int.Parse(dt.Rows[0]["Id"].ToString()));
                    Application.Current.MainWindow = bmsUser;
                    bmsUser.Show();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Login failed, try again.", "SMS", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EmailBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
