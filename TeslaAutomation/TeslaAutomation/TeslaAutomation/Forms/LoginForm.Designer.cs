namespace TeslaAutomation.Forms
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LcWelcome = new DevExpress.XtraEditors.LabelControl();
            this.LcUsername = new DevExpress.XtraEditors.LabelControl();
            this.LcPassword = new DevExpress.XtraEditors.LabelControl();
            this.TeUsername = new DevExpress.XtraEditors.TextEdit();
            this.TePassword = new DevExpress.XtraEditors.TextEdit();
            this.BwLogin = new System.ComponentModel.BackgroundWorker();
            this.CbShowHide = new DevExpress.XtraEditors.CheckButton();
            this.SbLogin = new DevExpress.XtraEditors.SimpleButton();
            this.PpWait = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.TeUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TePassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // LcWelcome
            // 
            this.LcWelcome.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.LcWelcome.Appearance.Options.UseFont = true;
            this.LcWelcome.Location = new System.Drawing.Point(143, 12);
            this.LcWelcome.Name = "LcWelcome";
            this.LcWelcome.Size = new System.Drawing.Size(113, 16);
            this.LcWelcome.TabIndex = 0;
            this.LcWelcome.Text = "Welcome to Tesla";
            // 
            // LcUsername
            // 
            this.LcUsername.Location = new System.Drawing.Point(47, 68);
            this.LcUsername.Name = "LcUsername";
            this.LcUsername.Size = new System.Drawing.Size(63, 16);
            this.LcUsername.TabIndex = 0;
            this.LcUsername.Text = "Username:";
            // 
            // LcPassword
            // 
            this.LcPassword.Location = new System.Drawing.Point(50, 104);
            this.LcPassword.Name = "LcPassword";
            this.LcPassword.Size = new System.Drawing.Size(60, 16);
            this.LcPassword.TabIndex = 0;
            this.LcPassword.Text = "Password:";
            // 
            // TeUsername
            // 
            this.TeUsername.Location = new System.Drawing.Point(116, 65);
            this.TeUsername.Name = "TeUsername";
            this.TeUsername.Size = new System.Drawing.Size(230, 22);
            this.TeUsername.TabIndex = 1;
            this.TeUsername.Enter += new System.EventHandler(this.TeUsername_Enter);
            this.TeUsername.Leave += new System.EventHandler(this.TeUsername_Leave);
            // 
            // TePassword
            // 
            this.TePassword.Location = new System.Drawing.Point(116, 101);
            this.TePassword.Name = "TePassword";
            this.TePassword.Properties.DisplayFormat.FormatString = "*";
            this.TePassword.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.TePassword.Properties.PasswordChar = '*';
            this.TePassword.Size = new System.Drawing.Size(208, 22);
            this.TePassword.TabIndex = 2;
            this.TePassword.Enter += new System.EventHandler(this.TePassword_Enter);
            this.TePassword.Leave += new System.EventHandler(this.TePassword_Leave);
            // 
            // BwLogin
            // 
            this.BwLogin.WorkerSupportsCancellation = true;
            this.BwLogin.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwLogin_DoWork);
            this.BwLogin.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwLogin_RunWorkerCompleted);
            // 
            // CbShowHide
            // 
            this.CbShowHide.ImageOptions.Image = global::TeslaAutomation.Properties.Resources.icons8_hide_16;
            this.CbShowHide.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.CbShowHide.Location = new System.Drawing.Point(324, 101);
            this.CbShowHide.Name = "CbShowHide";
            this.CbShowHide.Size = new System.Drawing.Size(22, 22);
            this.CbShowHide.TabIndex = 3;
            this.CbShowHide.CheckedChanged += new System.EventHandler(this.CbShowHide_CheckedChanged);
            // 
            // SbLogin
            // 
            this.SbLogin.ImageOptions.Image = global::TeslaAutomation.Properties.Resources.icons8_login_16;
            this.SbLogin.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.SbLogin.Location = new System.Drawing.Point(154, 151);
            this.SbLogin.Name = "SbLogin";
            this.SbLogin.Size = new System.Drawing.Size(93, 32);
            this.SbLogin.TabIndex = 4;
            this.SbLogin.Text = "Login";
            this.SbLogin.Click += new System.EventHandler(this.SbLogin_Click);
            // 
            // PpWait
            // 
            this.PpWait.Location = new System.Drawing.Point(155, 152);
            this.PpWait.Name = "PpWait";
            this.PpWait.ShowCaption = false;
            this.PpWait.ShowDescription = false;
            this.PpWait.Size = new System.Drawing.Size(91, 30);
            this.PpWait.TabIndex = 5;
            this.PpWait.Text = "progressPanel1";
            this.PpWait.Visible = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 210);
            this.Controls.Add(this.PpWait);
            this.Controls.Add(this.CbShowHide);
            this.Controls.Add(this.SbLogin);
            this.Controls.Add(this.TePassword);
            this.Controls.Add(this.TeUsername);
            this.Controls.Add(this.LcPassword);
            this.Controls.Add(this.LcUsername);
            this.Controls.Add(this.LcWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.Image = global::TeslaAutomation.Properties.Resources.icons8_tesla_24;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.TeUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TePassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl LcWelcome;
        private DevExpress.XtraEditors.LabelControl LcUsername;
        private DevExpress.XtraEditors.LabelControl LcPassword;
        private DevExpress.XtraEditors.TextEdit TeUsername;
        private DevExpress.XtraEditors.TextEdit TePassword;
        private DevExpress.XtraEditors.SimpleButton SbLogin;
        private DevExpress.XtraEditors.CheckButton CbShowHide;
        private System.ComponentModel.BackgroundWorker BwLogin;
        private DevExpress.XtraWaitForm.ProgressPanel PpWait;
    }
}