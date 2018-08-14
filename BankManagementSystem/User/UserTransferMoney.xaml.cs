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
using System.Data;
using System.Data.SqlClient;
using BankManagementSystem;
using BankManagementSystem.DATA_SET;
using BankManagementSystem.DATA_SET.BMSDataSetTableAdapters;

namespace BankManagementSystem.User
{
    /// <summary>
    /// Interaction logic for UserTransferMoney.xaml
    /// </summary>
    public partial class UserTransferMoney : ITabbedMDI
    {
        int accountId;

        public UserTransferMoney(int accountId)
        {
            InitializeComponent();
            this.accountId = accountId;
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
                return "MakeTransaction";
            }
        }

        /// <summary>
        /// This is the title that will be shown in the tab.
        /// </summary>
        public string Title
        {
            get { return "Make a Transaction"; }
        }
        #endregion

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            if (CloseInitiated != null)
            {
                CloseInitiated(this, new EventArgs());
            }
        }

        private void btnDebitAccount_Click(object sender, RoutedEventArgs e)
        {
            BankManagementSystem.DATA_SET.BMSDataSetTableAdapters.GetAccountInfoTableAdapter accountInfo = new GetAccountInfoTableAdapter();
            accountInfo.CreditDebitAccount(int.Parse(lblAccountId.Text), "Dr", int.Parse(comboTranAmmount.Text), comboSecondAccount.Text);
            MessageBox.Show("Successfully transfer money to account " + comboSecondAccount.Text + "  By" + comboTranAmmount.Text + " Rupees");
        }

       

        private void UserTransferMoney_Loaded(object sender, RoutedEventArgs e)
        {
            lblAccountId.Text = accountId.ToString();
            GetAllAccount();
        }

        private void GetAllAccount()
        {
            BankManagementSystem.DATA_SET.BMSDataSetTableAdapters.SelectAllAccountTableAdapter getAllAccount = new SelectAllAccountTableAdapter();
            DataTable dt = new DataTable();
            dt = getAllAccount.GetAllAccount();
            if (dt.Rows.Count > 0)
            {
                comboSecondAccount.ItemsSource = dt.DefaultView;
                comboSecondAccount.DisplayMemberPath = dt.Columns["Id"].ToString();
                comboSecondAccount.SelectedValuePath = dt.Columns["Id"].ToString();
            }
        }
    }
}
