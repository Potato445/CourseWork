using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnPrihod_Click(object sender, EventArgs e)
        {
            FormPrihod formPrihod = new FormPrihod();
            formPrihod.ShowInTaskbar = false;
            formPrihod.ShowDialog();
        }

        private void btnProdazha_Click(object sender, EventArgs e)
        {
            FormProdazha formProdazha = new FormProdazha();
            formProdazha.ShowInTaskbar = false;
            formProdazha.ShowDialog();
        }

        private void btnSpr_Click(object sender, EventArgs e)
        {
            FormSpr formSpr = new FormSpr();
            formSpr.ShowInTaskbar = false;
            formSpr.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            FormReport formReport = new FormReport();
            formReport.ShowInTaskbar = false;
            formReport.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
