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
    public partial class FormProdazha : Form
    {
        // Общие процедуры
        Shared shared;

        private void refresh()
        {
            // Сброс фильтра
            filterTextBox.Text = "";
            // TODO: This line of code loads data into the 'pharmacyDataSet.Расход' table. You can move, or remove it, as needed.
            this.расходTableAdapter.Fill(this.pharmacyDataSet.Расход);
        }

        public FormProdazha()
        {
            InitializeComponent();
            // Общие процедуры
            shared = new Shared();
        }

        private void FormProdazha_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Добавление новой записи
            FormProdazhaEdit formProdazhaEdit = new FormProdazhaEdit();
            formProdazhaEdit.ShowInTaskbar = false;
            formProdazhaEdit.Id = 0;
            formProdazhaEdit.ShowDialog();
            refresh();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Изменение текущей записи
            FormProdazhaEdit ShowInTaskbar = new FormProdazhaEdit();
            ShowInTaskbar.ShowInTaskbar = false;
            DataRowView drw = расходBindingSource.Current as DataRowView;
            ShowInTaskbar.Id = Convert.ToInt64(drw["Код"]);
            ShowInTaskbar.ShowDialog();
            refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Удаление текущей записи
            shared.delete(bindingNavigator1.BindingSource, this, this.pharmacyDataSet, this.tableAdapterManager);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Обновление таблиц
            refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Закрытие формы
            Close();
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (int.TryParse(filterTextBox.Text, out x) )
            {
                bindingNavigator1.BindingSource.Filter = "Номер=" + filterTextBox.Text;
            }
            else 
            {
                bindingNavigator1.BindingSource.Filter = "";
            }
        }
    }
}
