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
using System.ComponentModel;
using Microsoft.Windows.Controls;
using BankManagementSystem;
using BankManagementSystem.DATA_SET;
using BankManagementSystem.DATA_SET.BMSDataSetTableAdapters;

namespace BankManagementSystem.Admin
{
    /// <summary>
    /// Interaction logic for AdminBalanceEnquiry.xaml
    /// </summary>
    public partial class AdminBalanceEnquiry : ITabbedMDI
    {
        private DataTable dt = new DataTable();
        private DataTable dtTransaction = new DataTable();
        private ListSortDirection sortingDirection = ListSortDirection.Ascending;
        private string sortingColumnName = "colDate";
        private int columnIndex = 0;

        public AdminBalanceEnquiry()
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
                return "AdminBalanceEnquiry";
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

        private void btnCheckBalance_Click(object sender, RoutedEventArgs e)
        {
            BankManagementSystem.DATA_SET.BMSDataSetTableAdapters.GetAccountSummaryTableAdapter bms = new GetAccountSummaryTableAdapter();
            dt = bms.GetAccountDetailsById(Int32.Parse(comboAccountList.Text));
            TextBlockAvaliableBalance.Text = dt.Rows[0]["Ammount"].ToString();
            TextBlockWelcome.Text = dt.Rows[0]["Name"].ToString();

            dtTransaction = bms.GetData(Int32.Parse(comboAccountList.Text));
            DataGridAccountSummary.DataContext = dtTransaction;
        }

        private void DataGridAccountSummarySorting(object sender, DataGridSortingEventArgs e)
        {
            sortingDirection = (e.Column.SortDirection != ListSortDirection.Ascending) ? ListSortDirection.Ascending : ListSortDirection.Descending;
            sortingColumnName = e.Column.SortMemberPath;
            columnIndex = e.Column.DisplayIndex;
        }
    }
}
