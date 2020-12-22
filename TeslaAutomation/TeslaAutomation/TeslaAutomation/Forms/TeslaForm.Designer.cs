namespace TeslaAutomation.Forms
{
    partial class TeslaForm
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
            this.TeURL = new DevExpress.XtraEditors.TextEdit();
            this.SbStart = new DevExpress.XtraEditors.SimpleButton();
            this.LcURL = new DevExpress.XtraEditors.LabelControl();
            this.PgrsPanel = new DevExpress.XtraWaitForm.ProgressPanel();
            this.BwStart = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.TeURL.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // TeURL
            // 
            this.TeURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TeURL.Location = new System.Drawing.Point(92, 12);
            this.TeURL.Name = "TeURL";
            this.TeURL.Size = new System.Drawing.Size(294, 22);
            this.TeURL.TabIndex = 1;
            this.TeURL.Enter += new System.EventHandler(this.TeURL_Enter);
            this.TeURL.Leave += new System.EventHandler(this.TeURL_Leave);
            // 
            // SbStart
            // 
            this.SbStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SbStart.Location = new System.Drawing.Point(161, 119);
            this.SbStart.Name = "SbStart";
            this.SbStart.Size = new System.Drawing.Size(80, 29);
            this.SbStart.TabIndex = 2;
            this.SbStart.Text = "Start";
            this.SbStart.Click += new System.EventHandler(this.SbStart_Click);
            // 
            // LcURL
            // 
            this.LcURL.Location = new System.Drawing.Point(12, 15);
            this.LcURL.Name = "LcURL";
            this.LcURL.Size = new System.Drawing.Size(74, 16);
            this.LcURL.TabIndex = 0;
            this.LcURL.Text = "Product URL:";
            // 
            // PgrsPanel
            // 
            this.PgrsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.PgrsPanel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.PgrsPanel.Appearance.Options.UseBackColor = true;
            this.PgrsPanel.Location = new System.Drawing.Point(129, 40);
            this.PgrsPanel.Name = "PgrsPanel";
            this.PgrsPanel.Size = new System.Drawing.Size(144, 66);
            this.PgrsPanel.TabIndex = 0;
            this.PgrsPanel.Visible = false;
            // 
            // BwStart
            // 
            this.BwStart.WorkerSupportsCancellation = true;
            this.BwStart.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwStart_DoWork);
            this.BwStart.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwStart_RunWorkerCompleted);
            // 
            // TeslaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 160);
            this.Controls.Add(this.PgrsPanel);
            this.Controls.Add(this.LcURL);
            this.Controls.Add(this.SbStart);
            this.Controls.Add(this.TeURL);
            this.IconOptions.Image = global::TeslaAutomation.Properties.Resources.icons8_tesla_24;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TeslaForm";
            this.Text = "Tesla";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TeslaForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.TeURL.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit TeURL;
        private DevExpress.XtraEditors.SimpleButton SbStart;
        private DevExpress.XtraEditors.LabelControl LcURL;
        private DevExpress.XtraWaitForm.ProgressPanel PgrsPanel;
        private System.ComponentModel.BackgroundWorker BwStart;
    }
}

