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
    public partial class FormPrihod : Form
    {
        // Общие процедуры
        Shared shared;

        private void refresh()
        {
            // Сброс фильтра
            filterTextBox.Text = "";
            // TODO: This line of code loads data into the 'pharmacyDataSet.Организация' table. You can move, or remove it, as needed.
            this.организацияTableAdapter.Fill(this.pharmacyDataSet.Организация);
            // TODO: This line of code loads data into the 'pharmacyDataSet.Приход' table. You can move, or remove it, as needed.
            this.приходTableAdapter.Fill(this.pharmacyDataSet.Приход);
        }

        public FormPrihod()
        {
            InitializeComponent();
            // Общие процедуры
            shared = new Shared();
        }

        private void FormPrihod_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Добавление новой записи
            FormPrihodEdit formPrihodEdit = new FormPrihodEdit();
            formPrihodEdit.ShowInTaskbar = false;
            formPrihodEdit.Id = 0;
            formPrihodEdit.ShowDialog();
            refresh();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Изменение текущей записи
            FormPrihodEdit formPrihodEdit = new FormPrihodEdit();
            formPrihodEdit.ShowInTaskbar = false;
            DataRowView drw = приходBindingSource.Current as DataRowView;
            formPrihodEdit.Id = Convert.ToInt64(drw["Код"]);
            formPrihodEdit.ShowDialog();
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
            bindingNavigator1.BindingSource.Filter = "ОрганизацияКод In " + shared.getIdAccess("SELECT Код FROM Организация WHERE Название Like '%" + filterTextBox.Text + "%'");
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
           

        }
    }
}
