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
    public partial class FormPoisk : Form
    {
        FormProdazhaEdit mainForm;
        // Общие процедуры
        Shared shared;

        public FormPoisk(FormProdazhaEdit mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
            shared = new Shared();
        }

        private void FormPoisk_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pharmacyDataSet.ЗапросДоступныйТовар' table. You can move, or remove it, as needed.
            this.запросДоступныйТоварTableAdapter.Fill(this.pharmacyDataSet.ЗапросДоступныйТовар);
            запросДоступныйТоварBindingSource.Filter = "Доступно>0";
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            запросДоступныйТоварBindingSource.Filter = "Доступно>0 AND Категория Like '%" + tbFilter.Text + "%' OR Название Like '%" + tbFilter.Text + "%'";
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DataRowView drw = запросДоступныйТоварBindingSource.Current as DataRowView;
            mainForm.idTovar = Convert.ToInt32(drw["Код"]);
            mainForm.maxKolvo = Convert.ToInt32(drw["Доступно"]);
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
