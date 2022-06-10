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
    public partial class FormSpr : Form
    {
        // Общие процедуры
        Shared shared;

        private void refresh()
        {
            // Сброс фильтра
            filterTextBox.Text = "";
            // TODO: This line of code loads data into the 'pharmacyDataSet.Организация' table. You can move, or remove it, as needed.
            this.организацияTableAdapter.Fill(this.pharmacyDataSet.Организация);
        }


        public FormSpr()
        {
            InitializeComponent();
            // Общие процедуры
            shared = new Shared();
        }

        private void FormSpr_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Добавление новой записи
            FormSprEdit formSprEdit = new FormSprEdit();
            formSprEdit.ShowInTaskbar = false;
            formSprEdit.Id = 0;
            formSprEdit.ShowDialog();
            refresh();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Изменение текущей записи
            FormSprEdit formSprEdit = new FormSprEdit();
            formSprEdit.ShowInTaskbar = false;
            DataRowView drw = организацияBindingSource.Current as DataRowView;
            formSprEdit.Id = Convert.ToInt64(drw["Код"]);
            formSprEdit.ShowDialog();
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
            bindingNavigator1.BindingSource.Filter = "Название Like '%" + filterTextBox.Text + "%' OR Адрес Like '%" + filterTextBox.Text + "%' OR Телефон Like '%" + filterTextBox.Text + "%'"; ;
        }
    }
}
