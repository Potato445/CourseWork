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
    public partial class FormSprEdit : Form
    {
        // Id записи, если равен нулю то новая запись
        public Int64 Id;
        // Общие процедуры
        Shared shared;

        public FormSprEdit()
        {
            InitializeComponent();
            // Общие процедуры
            shared = new Shared();
        }
              

        private void FormSprEdit_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pharmacyDataSet.Организация' table. You can move, or remove it, as needed.
            this.организацияTableAdapter.Fill(this.pharmacyDataSet.Организация);
            if (Id == 0)
            {
                // Добавление новой записи
                shared.add(организацияBindingSource);
            }
            else
            {
                // Изменение текущей записи
                int itemFound = организацияBindingSource.Find("Код", Id);
                организацияBindingSource.Position = itemFound;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверка обязательности заполнения реквизитов
            this.Validate();
            DataRowView drw = организацияBindingSource.Current as DataRowView;
            if ((drw["Название"] == DBNull.Value) || (drw["Название"].ToString().Trim() == ""))
            {
                MessageBox.Show("Введите Название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((drw["Адрес"] == DBNull.Value) || (drw["Адрес"].ToString().Trim() == ""))
            {
                MessageBox.Show("Введите Адрес", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((drw["Телефон"] == DBNull.Value) || (drw["Телефон"].ToString().Trim() == ""))
            {
                MessageBox.Show("Введите Телефон", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Обновление записи
            shared.update(организацияBindingSource, this, this.pharmacyDataSet, this.tableAdapterManager);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            shared.cancel(организацияBindingSource);
            Close();
        }
    }
}
