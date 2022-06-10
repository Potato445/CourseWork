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
    public partial class FormProdazhaEdit : Form
    {
        // Id записи, если равен нулю то новая запись
        public Int64 Id;
        // Общие процедуры
        Shared shared;
        // Id товара
        public int idTovar;
        // Максимальное количество товара
        public int maxKolvo;

        public FormProdazhaEdit()
        {
            InitializeComponent();
            // Общие процедуры
            shared = new Shared();
        }
              

        private void FormProdazhaEdit_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pharmacyDataSet.Товар' table. You can move, or remove it, as needed.
            this.товарTableAdapter.Fill(this.pharmacyDataSet.Товар);
            // TODO: This line of code loads data into the 'pharmacyDataSet.РасходТовар' table. You can move, or remove it, as needed.
            this.расходТоварTableAdapter.Fill(this.pharmacyDataSet.РасходТовар);
            // TODO: This line of code loads data into the 'pharmacyDataSet.Расход' table. You can move, or remove it, as needed.
            this.расходTableAdapter.Fill(this.pharmacyDataSet.Расход);
            // Master/Detail GridView           
            расходТоварBindingSource.DataSource = расходBindingSource;
            расходТоварBindingSource.DataMember = "РасходРасходТовар";
            if (Id == 0)
            {
                // Добавление новой записи
                shared.add(расходBindingSource);
                DataRowView drw = расходBindingSource.Current as DataRowView;
                drw["Дата"] = DateTime.Now.Date;
                датаDateTimePicker.Value = Convert.ToDateTime(drw["Дата"]);
                // Блокировать товар пока не добавлена накладная
                ((Control)this.tabPage2).Enabled = false;
            }
            else
            {
                // Изменение текущей записи
                int itemFound = расходBindingSource.Find("Код", Id);
                расходBindingSource.Position = itemFound;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверка обязательности заполнения реквизитов
            this.Validate();
            DataRowView drw = расходBindingSource.Current as DataRowView;
            if (drw["Номер"] == DBNull.Value)
            {
                drw["Номер"] = shared.getNextNomerAccess("SELECT max(Номер) as maxz FROM Расход WHERE YEAR(Дата)=" + DateTime.Now.Year.ToString());
            }
            // Обновление записи
            shared.update(расходBindingSource, this, this.pharmacyDataSet, this.tableAdapterManager);
            // Разблокировать товар пока не добавлена накладная
            ((Control)this.tabPage2).Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            shared.cancel(расходBindingSource);
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            shared.add(bindingNavigator1.BindingSource);            
            // Поиск товара
            FormPoisk formPoisk = new FormPoisk(this);
            formPoisk.ShowDialog();
            DataRowView drw2 = bindingNavigator1.BindingSource.Current as DataRowView;
            drw2["ТоварКод"] = idTovar;
            товарКодComboBox.SelectedValue = idTovar;
            количествоNumericUpDown.Maximum = maxKolvo;
            drw2["Количество"] = 1;
            количествоNumericUpDown.Value = Convert.ToInt32(drw2["Количество"]);
            // Передача фокуса
            товарКодComboBox.Focus();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Проверка обязательности заполнения реквизитов
            this.Validate();
            DataRowView drw = bindingNavigator1.BindingSource.Current as DataRowView;
            if (drw["ТоварКод"] == DBNull.Value) 
            {
                MessageBox.Show("Введите Товар", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((drw["Количество"] == DBNull.Value) || (Convert.ToInt32(drw["Количество"]) == 0))
            {
                MessageBox.Show("Введите количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {


        }
    }
}
