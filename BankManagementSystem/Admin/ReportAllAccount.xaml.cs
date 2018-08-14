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
using Microsoft.Reporting.WinForms;

namespace BankManagementSystem.Admin
{
    /// <summary>
    /// Interaction logic for ReportAllAccount.xaml
    /// </summary>
    public partial class ReportAllAccount : ITabbedMDI
    {
        public ReportAllAccount()
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
                return "ReportAllAccount";
            }
        }

        /// <summary>
        /// This is the title that will be shown in the tab.
        /// </summary>
        public string Title
        {
            get { return "Report - All Account"; }
        }
        #endregion

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            if (CloseInitiated != null)
            {
                CloseInitiated(this, new EventArgs());
            }
        }

        private void UserControlReportAllAccount_Loaded(object sender, RoutedEventArgs e)
        {
            ReportViewerAllAccount.ProcessingMode = ProcessingMode.Local;
            ReportViewerAllAccount.LocalReport.ReportPath = @"c:\Orders.rdlc";
            ReportViewerAllAccount.Refresh();
        }

    }
}
