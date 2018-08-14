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
    /// Interaction logic for BalanceEnquiry.xaml
    /// </summary>
    public partial class BalanceEnquiry : ITabbedMDI
    {
        int accountId;        
        private DataTable dt = new DataTable();

        public BalanceEnquiry(int accountId)
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
                return "BalanceEnquiry";
            }
        }

        /// <summary>
        /// This is the title that will be shown in the tab.
        /// </summary>
        public string Title
        {
            get { return "Balance Enquiry"; }
        }
        #endregion

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            if (CloseInitiated != null)
            {
                CloseInitiated(this, new EventArgs());
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            BankManagementSystem.DATA_SET.BMSDataSetTableAdapters.GetAccountSummaryTableAdapter bms = new GetAccountSummaryTableAdapter();           
            dt = bms.GetAccountDetailsById(accountId);
            TextBlockAvaliableBalance.Text = dt.Rows[0]["Ammount"].ToString();
            TextBlockWelcome.Text = "Welcome " + dt.Rows[0]["Name"].ToString();           
        }

    }
}
