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
using BankManagementSystem.Admin;

namespace BankManagementSystem
{
    /// <summary>
    /// Interaction logic for BMSMain.xaml
    /// </summary>
    public partial class BMSMain : Window
    {
        private Dictionary<string, string> _mdiChildren = new Dictionary<string, string>();

        public BMSMain()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        /// <summary>
        /// Create tab1 if not exists or set focus if exist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuTabAddS_Click(object sender, RoutedEventArgs e)
        {
            //AddStudent addStudent = new AddStudent();
            //AddTab(addStudent);
        }
        /// <summary>
        /// Create tab2 if not exists or set focus if exist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuTabAllS_Click(object sender, RoutedEventArgs e)
        {
            //AllStudent allStudent = new AllStudent("All");
            //AddTab(allStudent);
        }
        /// <summary>
        /// Exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Add tab item to the tab
        /// </summary>
        /// <param name="mdiChild">This is the user control</param>
        private void AddTab(ITabbedMDI mdiChild)
        {
            //Check if the user control is already opened
            if (_mdiChildren.ContainsKey(mdiChild.UniqueTabName))
            {
                //user control is already opened in tab. 
                //So set focus to the tab item where the control hosted
                foreach (object item in tcMdi.Items)
                {
                    TabItem ti = (TabItem)item;
                    if (ti.Name == mdiChild.UniqueTabName)
                    {
                        ti.Focus();
                        break;
                    }
                }
            }
            else
            {
                //the control is not open in the tab item
                tcMdi.Visibility = Visibility.Visible;
                tcMdi.Width = this.ActualWidth;
                tcMdi.Height = this.ActualHeight;

                ((ITabbedMDI)mdiChild).CloseInitiated += new delClosed(CloseTab);

                //create a new tab item
                TabItem ti = new TabItem();
                //set the tab item's name to mdi child's unique name
                ti.Name = ((ITabbedMDI)mdiChild).UniqueTabName;
                //set the tab item's title to mdi child's title
                ti.Header = ((ITabbedMDI)mdiChild).Title;
                //set the content property of the tab item to mdi child
                ti.Content = mdiChild;
                ti.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                ti.VerticalContentAlignment = VerticalAlignment.Top;
                //add the tab item to tab control
                tcMdi.Items.Add(ti);
                //set this tab as selected
                tcMdi.SelectedItem = ti;
                //add the mdi child's unique name in the open children's name list
                _mdiChildren.Add(((ITabbedMDI)mdiChild).UniqueTabName, ((ITabbedMDI)mdiChild).Title);

            }
        }
        /// <summary>
        /// Close a tab item
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="e"></param>
        private void CloseTab(ITabbedMDI tab, EventArgs e)
        {
            TabItem ti = null;
            foreach (TabItem item in tcMdi.Items)
            {
                if (tab.UniqueTabName == ((ITabbedMDI)item.Content).UniqueTabName)
                {
                    ti = item;
                    break;
                }
            }
            if (ti != null)
            {
                _mdiChildren.Remove(((ITabbedMDI)ti.Content).UniqueTabName);
                tcMdi.Items.Remove(ti);
            }
        }
        /// <summary>
        /// Adjust the tab height and weight during load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu1_Loaded(object sender, RoutedEventArgs e)
        {
            tcMdi.Width = this.ActualWidth;
            tcMdi.Height = this.ActualHeight - 10;
        }

        private void mnuTabAddT_Click(object sender, RoutedEventArgs e)
        {
        }

        private void mnuTabAllT_Click(object sender, RoutedEventArgs e)
        {
        }

        private void mnuTab_Click(object sender, RoutedEventArgs e)
        {
        }

        private void mnuTabNewAccount(object sender, RoutedEventArgs e)
        {
        }

        private void mnuTab_Click_1(object sender, RoutedEventArgs e)
        {
            NewAccount newAccount = new NewAccount();
            AddTab(newAccount);
        }

        private void mnuTabCredit_Click(object sender, RoutedEventArgs e)
        {
            AdminCredit adminCredit = new AdminCredit();
            AddTab(adminCredit);
        }

        private void mnuTabDebit_Click(object sender, RoutedEventArgs e)
        {
            AdminDebit adminDebit = new AdminDebit();
            AddTab(adminDebit);
        }

        private void mnuTabTransaction_Click(object sender, RoutedEventArgs e)
        {
            AllTransaction allTran = new AllTransaction();
            AddTab(allTran);
        }

        private void mnuTabBalanceEnquiry_Click(object sender, RoutedEventArgs e)
        {
            AdminBalanceEnquiry adminBalanceEnquiry = new AdminBalanceEnquiry();
            AddTab(adminBalanceEnquiry);
        }

        private void mnuTabDeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            DeleteAccount deleteAccount = new DeleteAccount();
            AddTab(deleteAccount);
        }
    }
}
