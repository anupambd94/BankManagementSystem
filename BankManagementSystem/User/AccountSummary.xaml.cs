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
using System.ComponentModel;
using Microsoft.Windows.Controls;
using BankManagementSystem.DATA_SET;
using BankManagementSystem.DATA_SET.BMSDataSetTableAdapters;

namespace BankManagementSystem.User
{
    /// <summary>
    /// Interaction logic for AccountSummary.xaml
    /// </summary>
    public partial class AccountSummary : ITabbedMDI
    {
        int accountId;
        private DataTable dt = new DataTable();
        private DataTable dt1 = new DataTable();
        private ListSortDirection sortingDirection = ListSortDirection.Ascending;
        private string sortingColumnName = "colDate";
        private int columnIndex = 0;


        public AccountSummary(int accountId)
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
                return "AccountSummary";
            }
        }

        /// <summary>
        /// This is the title that will be shown in the tab.
        /// </summary>
        public string Title
        {
            get { return "Account Summary"; }
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
            dt = bms.GetData(accountId);
            dt1 = bms.GetAccountDetailsById(accountId);
            TextBlockAvaliableBalance.Text = dt1.Rows[0]["Ammount"].ToString();
            TextBlockWelcome.Text = "Welcome " + dt.Rows[0]["Name"].ToString();
            DataGridAccountSummary.DataContext = dt;
        }

        private void DataGridAccountSummarySorting(object sender, DataGridSortingEventArgs e)
        {
            sortingDirection = (e.Column.SortDirection != ListSortDirection.Ascending) ? ListSortDirection.Ascending : ListSortDirection.Descending;
            sortingColumnName = e.Column.SortMemberPath;
            columnIndex = e.Column.DisplayIndex;
        }
    }
}
