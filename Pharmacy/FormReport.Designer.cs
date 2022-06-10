
namespace Pharmacy
{
    partial class FormReport
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
            this.components = new System.ComponentModel.Container();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnPrihod = new System.Windows.Forms.ToolStripButton();
            this.btnProdazha = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.pharmacyDataSet = new Pharmacy.PharmacyDataSet();
            this.запросПриходBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.запросПриходTableAdapter = new Pharmacy.PharmacyDataSetTableAdapters.ЗапросПриходTableAdapter();
            this.tableAdapterManager = new Pharmacy.PharmacyDataSetTableAdapters.TableAdapterManager();
            this.запросРасходBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.запросРасходTableAdapter = new Pharmacy.PharmacyDataSetTableAdapters.ЗапросРасходTableAdapter();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pharmacyDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.запросПриходBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.запросРасходBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrihod,
            this.btnProdazha,
            this.btnSave,
            this.btnPrint,
            this.btnClose});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(884, 50);
            this.toolStrip2.TabIndex = 91;
            this.toolStrip2.Text = "toolStrip2";
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
            this.btnProdazha.Click += new System.EventHandler(this.btnPrihod_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::Pharmacy.Properties.Resources.Check;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(47, 47);
            this.btnSave.Text = "Сохранить как html-документ";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.AutoSize = false;
            this.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrint.Image = global::Pharmacy.Properties.Resources.Printer;
            this.btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(47, 47);
            this.btnPrint.Text = "Печать";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            // pharmacyDataSet
            // 
            this.pharmacyDataSet.DataSetName = "PharmacyDataSet";
            this.pharmacyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // запросПриходBindingSource
            // 
            this.запросПриходBindingSource.DataMember = "ЗапросПриход";
            this.запросПриходBindingSource.DataSource = this.pharmacyDataSet;
            // 
            // запросПриходTableAdapter
            // 
            this.запросПриходTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = Pharmacy.PharmacyDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.ОрганизацияTableAdapter = null;
            this.tableAdapterManager.ПриходTableAdapter = null;
            this.tableAdapterManager.РасходTableAdapter = null;
            this.tableAdapterManager.РасходТоварTableAdapter = null;
            this.tableAdapterManager.ТоварTableAdapter = null;
            // 
            // запросРасходBindingSource
            // 
            this.запросРасходBindingSource.DataMember = "ЗапросРасход";
            this.запросРасходBindingSource.DataSource = this.pharmacyDataSet;
            // 
            // запросРасходTableAdapter
            // 
            this.запросРасходTableAdapter.ClearBeforeFill = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 109);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(884, 452);
            this.webBrowser1.TabIndex = 93;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpEndDate);
            this.panel1.Controls.Add(this.dtpStartDate);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 59);
            this.panel1.TabIndex = 92;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(337, 16);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 23);
            this.dtpEndDate.TabIndex = 6;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(131, 16);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 23);
            this.dtpStartDate.TabIndex = 5;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(20, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(105, 17);
            this.label21.TabIndex = 4;
            this.label21.Text = "Диапазон дат:";
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отчеты";
            this.Load += new System.EventHandler(this.FormReport_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pharmacyDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.запросПриходBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.запросРасходBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnClose;
        public System.Windows.Forms.ToolStripButton btnProdazha;
        public System.Windows.Forms.ToolStripButton btnPrihod;
        private PharmacyDataSet pharmacyDataSet;
        private System.Windows.Forms.BindingSource запросПриходBindingSource;
        private PharmacyDataSetTableAdapters.ЗапросПриходTableAdapter запросПриходTableAdapter;
        private PharmacyDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource запросРасходBindingSource;
        private PharmacyDataSetTableAdapters.ЗапросРасходTableAdapter запросРасходTableAdapter;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label21;
    }
}