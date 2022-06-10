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
    public partial class FormReport : Form
    {
        // Общие процедуры
        Shared shared;

        private void td(System.IO.StreamWriter sw, String content)
        {
            sw.WriteLine("<td valign=\"top\">");
            sw.WriteLine(content);
            sw.WriteLine("</td>");
        }

        public FormReport()
        {
            InitializeComponent();
            // Общие процедуры
            shared = new Shared();
            // Диапазон дат
            string m = DateTime.Now.Month.ToString();
            if (m.Length == 1) m = "0" + m;
            m = "01";
            dtpStartDate.Value = Convert.ToDateTime("01." + m + "." + DateTime.Now.Year.ToString());
            dtpEndDate.Value = DateTime.Now.Date;
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pharmacyDataSet.ЗапросРасход' table. You can move, or remove it, as needed.
            this.запросРасходTableAdapter.Fill(this.pharmacyDataSet.ЗапросРасход);
            // TODO: This line of code loads data into the 'pharmacyDataSet.ЗапросПриход' table. You can move, or remove it, as needed.
            this.запросПриходTableAdapter.Fill(this.pharmacyDataSet.ЗапросПриход);

        }

        private void btnPrihod_Click(object sender, EventArgs e)
        {
            // Запись информации в файл Report.html
            try
            {
                // Получаем информацию о файле Report.html"
                System.IO.FileInfo fi = new
                System.IO.FileInfo(System.IO.Path.GetTempPath() + @"\Report.html");
                //поток для записи
                System.IO.StreamWriter sw;
                // Добавляем в файл
                sw = fi.CreateText();
                sw.WriteLine("<html>");
                sw.WriteLine("<head>");
                sw.WriteLine("<meta http-equiv=\"Content-Type\" content = \"text/html; charset=utf-8\">");
                sw.WriteLine("<title>");
                sw.WriteLine("Report");
                sw.WriteLine("</title>");
                sw.WriteLine("</head>");
                sw.WriteLine("<body>");
                sw.WriteLine("<div class=\"container\">");
                if (((ToolStripButton)sender).Name == "btnPrihod") sw.WriteLine("<h3 align=\"center\">" + ((ToolStripButton)sender).Text + " " + dtpStartDate.Value.Date.ToShortDateString() + " - " + dtpEndDate.Value.Date.ToShortDateString() + " </h3 > ");
                if (((ToolStripButton)sender).Name == "btnProdazha") sw.WriteLine("<h3 align=\"center\">" + ((ToolStripButton)sender).Text + " " + dtpStartDate.Value.Date.ToShortDateString() + " - " + dtpEndDate.Value.Date.ToShortDateString() + " </h3 > ");
                sw.WriteLine("<table border=\"1\">");
                sw.WriteLine("<thead>");
                sw.WriteLine("<tr>");
                // Заголовок таблицы
                if (((ToolStripButton)sender).Name == "btnPrihod")
                {
                    sw.WriteLine("<th>Организация</th>");
                    sw.WriteLine("<th>Дата</th>");
                    sw.WriteLine("<th>Номер</th>");
                    sw.WriteLine("<th>Категория</th>");
                    sw.WriteLine("<th>Название</th>");
                    sw.WriteLine("<th>Цена</th>");
                    sw.WriteLine("<th>Количество</th>");
                    sw.WriteLine("<th>Сумма</th>");
                }
                if (((ToolStripButton)sender).Name == "btnProdazha")
                {
                    sw.WriteLine("<th>Дата</th>");
                    sw.WriteLine("<th>Номер</th>");
                    sw.WriteLine("<th>Категория</th>");
                    sw.WriteLine("<th>Название</th>");
                    sw.WriteLine("<th>Цена</th>");
                    sw.WriteLine("<th>Количество</th>");
                    sw.WriteLine("<th>Сумма</th>");
                }
                sw.WriteLine("</tr>");
                sw.WriteLine("</thead>");
                sw.WriteLine("<tbody>");
                // Выводимые данные 
                if (((ToolStripButton)sender).Name == "btnPrihod")
                {
                    запросПриходBindingSource.Sort = "Дата";
                    запросПриходBindingSource.Filter = "Дата >= " + shared.getDataAccess(dtpStartDate.Value.Date) + " AND Дата<= " + shared.getDataAccess(dtpEndDate.Value.Date.AddDays(1));
                    foreach (DataRowView item in запросПриходBindingSource)
                    {
                        sw.WriteLine("<tr>");
                        td(sw, item["Организация"].ToString());
                        if (item["Дата"] != DBNull.Value) td(sw, Convert.ToDateTime(item["Дата"]).ToShortDateString()); else td(sw, "-");
                        td(sw, item["Номер"].ToString());
                        td(sw, item["Категория"].ToString());
                        td(sw, item["Название"].ToString());
                        td(sw, item["Цена"].ToString());
                        td(sw, item["Количество"].ToString());
                        td(sw, item["Сумма"].ToString());
                        sw.WriteLine("</tr>");
                    }
                    запросПриходBindingSource.Sort = "";
                    запросПриходBindingSource.Filter = "";
                }
                if (((ToolStripButton)sender).Name == "btnProdazha")
                {
                    запросРасходBindingSource.Sort = "Дата";
                    запросРасходBindingSource.Filter = "Дата >= " + shared.getDataAccess(dtpStartDate.Value.Date) + " AND Дата<= " + shared.getDataAccess(dtpEndDate.Value.Date.AddDays(1));
                    foreach (DataRowView item in запросРасходBindingSource)
                    {
                        sw.WriteLine("<tr>");
                        if (item["Дата"] != DBNull.Value) td(sw, Convert.ToDateTime(item["Дата"]).ToShortDateString()); else td(sw, "-");
                        td(sw, item["Номер"].ToString());
                        td(sw, item["Категория"].ToString());
                        td(sw, item["Название"].ToString());
                        td(sw, item["Цена"].ToString());
                        td(sw, item["Количество"].ToString());
                        td(sw, item["Сумма"].ToString());
                        sw.WriteLine("</tr>");
                    }
                    запросРасходBindingSource.Sort = "";
                    запросРасходBindingSource.Filter = "";
                }
                sw.WriteLine("</tbody>");
                sw.WriteLine("</table>");
                sw.WriteLine("</div>");
                sw.WriteLine("</body>");
                sw.WriteLine("</html>");
                //Закрываем поток для записи
                sw.Close();
                // Вывод на страницу
                webBrowser1.Navigate(System.IO.Path.GetTempPath() + "Report.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Вызов диалога сохранения страницы html
            webBrowser1.ShowSaveAsDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Вызов диалога вывода на печать
            webBrowser1.ShowPrintPreviewDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }



    }
}
