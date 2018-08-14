using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankManagementSystem
{
    public delegate void delClosed(ITabbedMDI sender, EventArgs e);
    public interface ITabbedMDI
    {
        /// <summary>
        /// This event will be fired from user control and will be listened
        /// by parent MDI form. when this event will be fired from child control
        /// parent will close the form
        /// </summary>
        event delClosed CloseInitiated;
        /// <summary>
        /// This is unique name for the control. This will be used in dictonary object
        /// to keep track of the opened user control in parent form.
        /// </summary>
        string UniqueTabName { get; }

        /// <summary>
        /// This is the tile will be shown in the tile when this control
        /// will be show in parent
        /// </summary>
        string Title { get; }
    }
}
