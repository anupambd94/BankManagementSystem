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

namespace BankManagementSystem.Admin
{
    /// <summary>
    /// Interaction logic for AllTransaction.xaml
    /// </summary>
    public partial class AllTransaction : ITabbedMDI
    {
        private DataTable dt = new DataTable();
        private ListSortDirection sortingDirection = ListSortDirection.Ascending;
        private string sortingColumnName = "Name";
        private int columnIndex = 0;
        public AllTransaction()
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
                return "AllTransaction";
            }
        }

        /// <summary>
        /// This is the title that will be shown in the tab.
        /// </summary>
        public string Title
        {
            get { return "All Transaction"; }
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
            BankManagementSystem.DATA_SET.BMSDataSetTableAdapters.SelectAllAccountTableAdapter accountInfo = new SelectAllAccountTableAdapter();
            dt.Constraints.Clear();
            dt = accountInfo.GetAllTransaction();
            DataGridAllTransaction.DataContext = dt;
        }

        private void DataGridAllTransactionSorting(object sender, DataGridSortingEventArgs e)
        {
            sortingDirection = (e.Column.SortDirection != ListSortDirection.Ascending) ? ListSortDirection.Ascending : ListSortDirection.Descending;
            sortingColumnName = e.Column.SortMemberPath;
            columnIndex = e.Column.DisplayIndex;
        }
    }
}
