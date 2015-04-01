using CompsysSecure.Properties;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;


namespace CompsysSecure
{
    [ComVisible(true)]
    public class Ribbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        public Ribbon()
        {
        }

        /// <summary>
        /// When the user clicks the Send secure button
        /// </summary>
        /// <param name="control"></param>
        public void btnSendSecure_Click(Office.IRibbonControl control)
        {
            MailItem mailItem = null;
            try
            {
                mailItem = Globals.ThisAddIn.Application.ActiveInspector().CurrentItem as MailItem;
                if (mailItem == null)
                    return;

                mailItem.Save();
                if (string.IsNullOrEmpty(mailItem.To) && string.IsNullOrEmpty(mailItem.CC) && string.IsNullOrEmpty(mailItem.BCC))
                    MessageBox.Show("You must enter at least one e-mail address in the TO, CC, or BCC field before you can send.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    var config = ConfigurationManager.AppSettings;
                    string schemaName = string.Format("{0}/{1}", ConfigurationManager.AppSettings["SchemaUri"], ConfigurationManager.AppSettings["Schema"]);
                    string schemaValue = ConfigurationManager.AppSettings["SchemaValue"];
                    mailItem.PropertyAccessor.SetProperty(schemaName, schemaValue);
                    mailItem.Save();

                    // Send message
                    mailItem.Send();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (mailItem != null)
                    Marshal.ReleaseComObject(mailItem);
            }
        }

        /// <summary>
        /// Gets the label for the button
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public string GetLabel(Office.IRibbonControl control)
        {
            return ConfigurationManager.AppSettings["ButtonLabel"];
        }

        public string GetScreenTip(Office.IRibbonControl control)
        {
            return ConfigurationManager.AppSettings["ScreenTip"];
        }

        public string GetSuperTip(Office.IRibbonControl control)
        {
            return ConfigurationManager.AppSettings["SuperTip"];
        }

        /// <summary>
        /// Gets the image being used for the send secure button
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public Bitmap GetSendSecureImage(Office.IRibbonControl control)
        {
            return Resources.envelope_lock_closed;
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("CompsysSecure.Ribbon.xml");
        }

        #endregion

        #region Ribbon Callbacks

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
