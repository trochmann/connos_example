namespace connos_example.Win
{
    partial class XafSplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XafSplashScreen));
            progressBarControl = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            labelCopyright = new DevExpress.XtraEditors.LabelControl();
            labelStatus = new DevExpress.XtraEditors.LabelControl();
            peImage = new DevExpress.XtraEditors.PictureEdit();
            pcApplicationName = new DevExpress.XtraEditors.PanelControl();
            labelSubtitle = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)progressBarControl.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)peImage.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pcApplicationName).BeginInit();
            pcApplicationName.SuspendLayout();
            SuspendLayout();
            // 
            // progressBarControl
            // 
            progressBarControl.EditValue = 0;
            progressBarControl.Location = new Point(74, 271);
            progressBarControl.Name = "progressBarControl";
            progressBarControl.Properties.Appearance.BorderColor = Color.FromArgb(195, 194, 194);
            progressBarControl.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            progressBarControl.Properties.EndColor = Color.FromArgb(255, 114, 0);
            progressBarControl.Properties.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            progressBarControl.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            progressBarControl.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            progressBarControl.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            progressBarControl.Properties.StartColor = Color.FromArgb(255, 144, 0);
            progressBarControl.Size = new Size(350, 16);
            progressBarControl.TabIndex = 5;
            // 
            // labelCopyright
            // 
            labelCopyright.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            labelCopyright.Location = new Point(24, 324);
            labelCopyright.Name = "labelCopyright";
            labelCopyright.Size = new Size(173, 26);
            labelCopyright.TabIndex = 6;
            labelCopyright.Text = "Copyright\r\nReinert Immobilienverwaltung GmbH";
            // 
            // labelStatus
            // 
            labelStatus.Location = new Point(75, 253);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(50, 13);
            labelStatus.TabIndex = 7;
            labelStatus.Text = "Starting...";
            // 
            // peImage
            // 
            peImage.EditValue = resources.GetObject("peImage.EditValue");
            peImage.Location = new Point(12, 12);
            peImage.Name = "peImage";
            peImage.Properties.AllowFocused = false;
            peImage.Properties.Appearance.BackColor = Color.Transparent;
            peImage.Properties.Appearance.Options.UseBackColor = true;
            peImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            peImage.Properties.ShowMenu = false;
            peImage.Size = new Size(426, 180);
            peImage.TabIndex = 9;
            peImage.Visible = false;
            // 
            // pcApplicationName
            // 
            pcApplicationName.Appearance.BackColor = Color.FromArgb(255, 224, 192);
            pcApplicationName.Appearance.Options.UseBackColor = true;
            pcApplicationName.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            pcApplicationName.Controls.Add(labelSubtitle);
            pcApplicationName.Dock = DockStyle.Top;
            pcApplicationName.Location = new Point(1, 1);
            pcApplicationName.LookAndFeel.UseDefaultLookAndFeel = false;
            pcApplicationName.Name = "pcApplicationName";
            pcApplicationName.Size = new Size(494, 220);
            pcApplicationName.TabIndex = 10;
            // 
            // labelSubtitle
            // 
            labelSubtitle.Appearance.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelSubtitle.Appearance.ForeColor = Color.FromArgb(255, 216, 188);
            labelSubtitle.Appearance.Options.UseFont = true;
            labelSubtitle.Appearance.Options.UseForeColor = true;
            labelSubtitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            labelSubtitle.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("labelSubtitle.ImageOptions.SvgImage");
            labelSubtitle.Location = new Point(23, 27);
            labelSubtitle.Name = "labelSubtitle";
            labelSubtitle.Size = new Size(446, 164);
            labelSubtitle.TabIndex = 1;
            // 
            // XafSplashScreen
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(496, 370);
            Controls.Add(pcApplicationName);
            Controls.Add(peImage);
            Controls.Add(labelStatus);
            Controls.Add(labelCopyright);
            Controls.Add(progressBarControl);
            Name = "XafSplashScreen";
            Padding = new Padding(1);
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)progressBarControl.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)peImage.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pcApplicationName).EndInit();
            pcApplicationName.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.MarqueeProgressBarControl progressBarControl;
        private DevExpress.XtraEditors.LabelControl labelCopyright;
        private DevExpress.XtraEditors.LabelControl labelStatus;
        private DevExpress.XtraEditors.PictureEdit peImage;
        private DevExpress.XtraEditors.PanelControl pcApplicationName;
        private DevExpress.XtraEditors.LabelControl labelSubtitle;
    }
}
