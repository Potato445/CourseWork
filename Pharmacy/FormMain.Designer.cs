
namespace Pharmacy
{
    partial class FormMain
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.btnPrihod = new System.Windows.Forms.ToolStripButton();
            this.btnProdazha = new System.Windows.Forms.ToolStripButton();
            this.btnSpr = new System.Windows.Forms.ToolStripButton();
            this.btnReport = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrihod,
            this.btnProdazha,
            this.btnSpr,
            this.btnReport,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(884, 50);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 24;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPictureBox.Image = global::Pharmacy.Properties.Resources.Logo;
            this.logoPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.logoPictureBox.Location = new System.Drawing.Point(0, 50);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(884, 511);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 25;
            this.logoPictureBox.TabStop = false;
            // 
            // btnPrihod
            // 
            this.btnPrihod.AutoSize = false;
            this.btnPrihod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrihod.Image = global::Pharmacy.Properties.Resources.Down;
            this.btnPrihod.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrihod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrihod.Name = "btnPrihod";
            this.btnPrihod.Size = new System.Drawing.Size(47, 47);
            this.btnPrihod.Text = "Приход";
            this.btnPrihod.Click += new System.EventHandler(this.btnPrihod_Click);
            // 
            // btnProdazha
            // 
            this.btnProdazha.AutoSize = false;
            this.btnProdazha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnProdazha.Image = global::Pharmacy.Properties.Resources.Up;
            this.btnProdazha.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnProdazha.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProdazha.Name = "btnProdazha";
            this.btnProdazha.Size = new System.Drawing.Size(47, 47);
            this.btnProdazha.Text = "Продажа";
            this.btnProdazha.Click += new System.EventHandler(this.btnProdazha_Click);
            // 
            // btnSpr
            // 
            this.btnSpr.AutoSize = false;
            this.btnSpr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSpr.Image = global::Pharmacy.Properties.Resources.Configuration;
            this.btnSpr.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSpr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSpr.Name = "btnSpr";
            this.btnSpr.Size = new System.Drawing.Size(47, 47);
            this.btnSpr.Text = "Поставщики";
            this.btnSpr.Click += new System.EventHandler(this.btnSpr_Click);
            // 
            // btnReport
            // 
            this.btnReport.AutoSize = false;
            this.btnReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReport.Image = global::Pharmacy.Properties.Resources.Report;
            this.btnReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(47, 47);
            this.btnReport.Text = "Отчеты";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = false;
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClose.Image = global::Pharmacy.Properties.Resources.Exit;
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(47, 47);
            this.btnClose.Text = "Выход";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аптека";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton btnPrihod;
        public System.Windows.Forms.ToolStripButton btnProdazha;
        public System.Windows.Forms.ToolStripButton btnSpr;
        private System.Windows.Forms.ToolStripButton btnReport;
        private System.Windows.Forms.ToolStripButton btnClose;
    }
}

