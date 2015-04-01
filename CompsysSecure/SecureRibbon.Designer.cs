namespace CompsysSecure
{
    partial class SecureRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public SecureRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.groupSendSecure = this.Factory.CreateRibbonGroup();
            this.btnSendSecure = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.groupSendSecure.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.ControlId.OfficeId = "TabNewMailMessage";
            this.tab1.Groups.Add(this.groupSendSecure);
            this.tab1.Label = "TabNewMailMessage";
            this.tab1.Name = "tab1";
            // 
            // groupSendSecure
            // 
            this.groupSendSecure.Items.Add(this.btnSendSecure);
            this.groupSendSecure.Name = "groupSendSecure";
            // 
            // btnSendSecure
            // 
            this.btnSendSecure.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnSendSecure.Description = "Send a secure and encrypted message";
            this.btnSendSecure.Image = global::CompsysSecure.Properties.Resources.envelope_lock_closed;
            this.btnSendSecure.ImageName = "Send Secure";
            this.btnSendSecure.Label = "Send Secure";
            this.btnSendSecure.Name = "btnSendSecure";
            this.btnSendSecure.Position = this.Factory.RibbonPosition.BeforeOfficeId("GroupClipboard");
            this.btnSendSecure.ShowImage = true;
            // 
            // SecureRibbon
            // 
            this.Name = "SecureRibbon";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.SecureRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.groupSendSecure.ResumeLayout(false);
            this.groupSendSecure.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupSendSecure;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSendSecure;
    }

    partial class ThisRibbonCollection
    {
        internal SecureRibbon SecureRibbon
        {
            get { return this.GetRibbon<SecureRibbon>(); }
        }
    }
}
