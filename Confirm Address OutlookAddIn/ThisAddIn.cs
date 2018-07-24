﻿using Outlook = Microsoft.Office.Interop.Outlook;
using System.Windows.Forms;

namespace Confirm_Address_OutlookAddIn {
    public partial class ThisAddIn {
        private void ThisAddIn_Startup(object sender, System.EventArgs e) {
            Application.ItemSend += new Outlook.ApplicationEvents_11_ItemSendEventHandler(Application_ItemSend);
        }

        public void Application_ItemSend(object Item, ref bool Cancel) {
            Outlook.MailItem mail = Item as Outlook.MailItem;
            Form myForm = new FormConfirmAddress(mail);
            var result = myForm.ShowDialog();
            Cancel = result == DialogResult.Cancel;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e) {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}