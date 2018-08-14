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

namespace BankManagementSystem.Admin
{
    /// <summary>
    /// Interaction logic for DeleteAccount.xaml
    /// </summary>
    public partial class DeleteAccount : ITabbedMDI
    {
        public DeleteAccount()
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
                return "DeleteAccount";
            }
        }

        /// <summary>
        /// This is the title that will be shown in the tab.
        /// </summary>
        public string Title
        {
            get { return "Delete Account"; }
        }
        #endregion

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            if (CloseInitiated != null)
            {
                CloseInitiated(this, new EventArgs());
            }
        }

        private void btnDeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            BankManagementSystem.DATA_SET.BMSDataSetTableAdapters.GetAccountInfoTableAdapter accountInfo = new GetAccountInfoTableAdapter();
            accountInfo.Admin_CloseAnAccount(int.Parse(comboAccountList.Text));
            MessageBox.Show("Account Deleted Successfully ");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            GetAllAccount();
        }
        private void GetAllAccount()
        {
            BankManagementSystem.DATA_SET.BMSDataSetTableAdapters.SelectAllAccountTableAdapter getAllAccount = new SelectAllAccountTableAdapter();
            DataTable dt = new DataTable();
            dt = getAllAccount.GetAllAccount();
            if (dt.Rows.Count > 0)
            {
                comboAccountList.ItemsSource = dt.DefaultView;
                comboAccountList.DisplayMemberPath = dt.Columns["Id"].ToString();
                comboAccountList.SelectedValuePath = dt.Columns["Id"].ToString();
            }
        }
    }
}
