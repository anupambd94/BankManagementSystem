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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BankManagementSystem;
using BankManagementSystem.DATA_SET.BMSDataSetTableAdapters;

namespace BankManagementSystem
{
    /// <summary>
    /// Interaction logic for NewAccount.xaml
    /// </summary>
    public partial class NewAccount : ITabbedMDI
    {
        public NewAccount()
        {
            InitializeComponent();
        }

        #region ITabbedMDI Members

        /// <summary>
        /// This event will be fired when user will click close button
        /// </summary>
        public event delClosed CloseInitiated;

        /// <summary>
        /// This is unique name of the tab
        /// </summary>
        public string UniqueTabName
        {
            get
            {
                return "OpenNewAccount";
            }
        }

        /// <summary>
        /// This is the title that will be shown in the tab.
        /// </summary>
        public string Title
        {
            get { return "Open New Account"; }
        }
        #endregion

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            if (CloseInitiated != null)
            {
                CloseInitiated(this, new EventArgs());
            }
        }

        private void btnOpenNewAccount_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != string.Empty && txtAddress.Text != string.Empty && txtAge.Text != string.Empty && txtEmail.Text!=string.Empty && txtPassword.Text!=string.Empty)
            {
                BankManagementSystem.DATA_SET.BMSDataSetTableAdapters.GetAccountInfoTableAdapter bms = new GetAccountInfoTableAdapter();
                bms.NewAccount(txtName.Text, txtAddress.Text, txtContactNumber.Text, comboTitle.Text, txtAge.Text, Int32.Parse(comboAnnualIncome.Text), Int32.Parse(comboOpeningAmmount.Text),txtEmail.Text,txtPassword.Text);
                txtName.Text = "";
                txtAddress.Text = "";
                txtContactNumber.Text = "";
                txtAge.Text = "";
                MessageBox.Show("New Account Successfully Created");
            }
            else
            {
                MessageBox.Show("Enter all required field...");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtContactNumber.Text = "";
        }
    }
}
