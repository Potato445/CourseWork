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
    public partial class FormPrihodEdit : Form
    {
        // Id записи, если равен нулю то новая запись
        public Int64 Id;
        // Общие процедуры
        Shared shared;

        public FormPrihodEdit()
        {
            InitializeComponent();
            // Общие процедуры
            shared = new Shared();
        }

        private void FormPrihodEdit_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pharmacyDataSet.Товар' table. You can move, or remove it, as needed.
            this.товарTableAdapter.Fill(this.pharmacyDataSet.Товар);
            // TODO: This line of code loads data into the 'pharmacyDataSet.Организация' table. You can move, or remove it, as needed.
            this.организацияTableAdapter.Fill(this.pharmacyDataSet.Организация);
            // TODO: This line of code loads data into the 'pharmacyDataSet.Приход' table. You can move, or remove it, as needed.
            this.приходTableAdapter.Fill(this.pharmacyDataSet.Приход);
            // Master/Detail GridView           
            товарBindingSource.DataSource = приходBindingSource;
            товарBindingSource.DataMember = "НакладнаяТовар";
            if (Id == 0)
            {
                // Добавление новой записи
                shared.add(приходBindingSource);
                DataRowView drw = приходBindingSource.Current as DataRowView;
                drw["Дата"] = DateTime.Now.Date;
                датаDateTimePicker.Value = Convert.ToDateTime(drw["Дата"]);
                организацияКодComboBox.Focus();
                // Блокировать товар пока не добавлена накладная
                ((Control)this.tabPage2).Enabled = false;
            }
            else
            {
                // Изменение текущей записи
                int itemFound = приходBindingSource.Find("Код", Id);
                приходBindingSource.Position = itemFound;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверка обязательности заполнения реквизитов
            this.Validate();
            DataRowView drw = приходBindingSource.Current as DataRowView;
            if (drw["ОрганизацияКод"] == DBNull.Value)
            {
                MessageBox.Show("Введите организацию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (drw["Номер"] == DBNull.Value)
            {
                drw["Номер"] = shared.getNextNomerAccess("SELECT max(Номер) as maxz FROM Приход WHERE YEAR(Дата)=" + DateTime.Now.Year.ToString());
            }
            // Обновление записи
            shared.update(приходBindingSource, this, this.pharmacyDataSet, this.tableAdapterManager);
            // Разблокировать товар пока не добавлена накладная
            ((Control)this.tabPage2).Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            shared.cancel(приходBindingSource);
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            shared.add(bindingNavigator1.BindingSource);
            // Значение по умолчанию 
            DataRowView drw = bindingNavigator1.BindingSource.Current as DataRowView;
            drw["Количество"] = 100;
            количествоNumericUpDown.Value = Convert.ToInt16(drw["Количество"]);
            категорияComboBox.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Проверка обязательности заполнения реквизитов
            this.Validate();
            DataRowView drw = bindingNavigator1.BindingSource.Current as DataRowView;
            if ((drw["Категория"] == DBNull.Value) || (drw["Категория"].ToString().Trim() == ""))
            {
                MessageBox.Show("Введите Категория", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((drw["Название"] == DBNull.Value) || (drw["Название"].ToString().Trim() == ""))
            {
                MessageBox.Show("Введите название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((drw["Количество"] == DBNull.Value) || (Convert.ToInt32(drw["Количество"]) == 0))
            {
                MessageBox.Show("Введите количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((drw["Цена"] == DBNull.Value) || (Convert.ToInt32(drw["Цена"]) == 0) || (drw["Цена"].ToString().Trim() == ""))
            {
                MessageBox.Show("Введите цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Обновление записи
            shared.update(bindingNavigator1.BindingSource, this, this.pharmacyDataSet, this.tableAdapterManager);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            // Отмена внесенных изменений
            shared.cancel(bindingNavigator1.BindingSource);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Удаление текущей записи
            shared.delete(bindingNavigator1.BindingSource, this, this.pharmacyDataSet, this.tableAdapterManager);
        }
    }
}
