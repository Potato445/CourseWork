using System;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Threading;
using System.Linq;

namespace Pharmacy
{
    class Shared
    {
        // Экземпляр класса для работы с реестром Windows
        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Pharmacy", false);
        // Экземпляры класса генерации рандомных чисел:
        Random rnd;
        Random god;
        Random den;

        public Shared()
        {
            rnd = new Random();
            god = new Random();
            den = new Random();
        }

        // XOR - шифрование/дешифрование значения message с ключом int. Например "admin" с ключом 7 будет зашифровано как "fcjni"
        public string cipherXOR(string message, int key)
        {
            string result = "";
            for (int i = 0; i < message.Length; i++)
                result += (char)(message[i] ^ key);
            return result;
        }

        // Cлучайная дата в диапазоне лет yaer1-(year2 + 1 год)
        public DateTime getRandomDate(int year1, int year2)
        {
            DateTime start = new DateTime(god.Next(year1, year2), 1, 1);
            DateTime d = start.AddDays(den.Next(1, 365));
            return d;
        }

        // Случайный номер телефона +7-7XX-XXX-XXXX
        public string getTel()
        {
            string[] provider = { "700", "701", "702", "705", "747", "776", "777" };
            return "+7-" + provider[rnd.Next(0, provider.Length)] + "-" + rnd.Next(100, 999).ToString() + "-" + rnd.Next(1000, 9999).ToString();
        }

        // Случайный адрес: улица, дом-квартира
        public string getAdres()
        {
            string[] street = { "ул. Академическая", "ул. Баженова", "ул. Вавилова", "ул. Гастелло", "ул. Дружбы", "ул. Ермекова",
                "ул. Жамбыла", "ул. Защитная", "ул. Ипподромная", "ул. Кирпичная", "ул. Луначарского", "ул. Маметовой", "ул. Новоселов",
                "ул. Олимпийская", "ул. Победы", "ул. Рыскулова", "ул. Сарсекова", "ул. Сатыбалдина", "ул. Тулепова", "ул. Университетская", "ул. Фрунзе" };
            return street[rnd.Next(0, street.Length)] + ", " + rnd.Next(1, 200).ToString() + "-" + rnd.Next(1, 192).ToString();
        }

        // Случайный горол
        public string getCity()
        {
            string[] city = { "Актау", "Актобе", "Атырау", "Караганда", "Кокшетау", "Костанай",
                "Кызылорда", "Павлодар", "Петропавловск", "Талдыкорган", "Тараз", "Туркестан", "Уральск",
                "Усть-Каменогорск", "Алматы", "Нур-Султан", "Шымкент" };
            return city[rnd.Next(0, city.Length)];
        }

        // Случайные номер документа длиной l цифр
        public string getDocumentNomer(int l)
        {
            string t = "";
            for (int i = 0; i < l; i++)
                t = t + rnd.Next(0, 9).ToString();
            return t;
        }

        // Случайный БИН
        public string getBIN(DateTime date)
        {
            string t = "";
            string x = "";
            // Год
            t = date.Year.ToString();
            t = t.Substring(2, 2);
            // Месяц
            x = date.Month.ToString();
            if (x.Length == 1) x = "0" + x;
            t = t + x;
            // Значения типа юридического лица или ИП(С):
            t = t + rnd.Next(4, 6).ToString();
            // Дополнительный признак
            t = t + rnd.Next(0, 3).ToString();
            // Порядковый номер
            t = t + rnd.Next(10000, 99999).ToString();
            // Контрольная цифра
            t = t + rnd.Next(0, 9).ToString();
            return t;
        }

        // Случайный ИИН
        public string getIIN(DateTime date)
        {
            string t = "";
            string x = "";
            string y = "";
            string z = "";
            // Год
            t = date.Year.ToString();
            z = t;      // 7 разряд век рождения и пол
            t = t.Substring(2, 2);
            // Месяц
            x = date.Month.ToString();
            if (x.Length == 1) x = "0" + x;
            t = t + x;
            // День
            y = date.Day.ToString();
            if (y.Length == 1) y = "0" + y;
            t = t + y;
            // 7 разряд век рождения и пол:
            if (Convert.ToInt16(z) <= 1900)
            {
                t = t + rnd.Next(1, 2).ToString();
            }
            if ((Convert.ToInt16(z) >= 1901) && (Convert.ToInt16(z) <= 2000))
            {
                t = t + rnd.Next(3, 4).ToString();
            }
            if ((Convert.ToInt16(z) >= 2001) && (Convert.ToInt16(z) <= 2100))
            {
                t = t + rnd.Next(5, 6).ToString();
            }
            // 8-11 разряды - заполняет орган Юстиции
            t = t + rnd.Next(1000, 9999).ToString();
            // 12 разряд - контрольная цифра, которая расчитывается по определенному алгоритму
            t = t + rnd.Next(0, 9).ToString();
            return t;
        }

        // Случайная марка автомобиля
        public string getMotorModel()
        {
            string[] model = { "Subaru Foresterкроссовер", "Lada Granta универсал", "Subaru XV", "KIA Seltos", "Renault Arkana", "Renault Sandero Stepway",
                "Lada 4x4 Urban 3 door", "Mitsubishi Pajero Sport", "Skoda Superb", "Lada Largus универсал", "Lada Vesta SW Cross", "Mitsubishi Outlander",
                "KIA Sorento", "KIA CeKIA Riorato", "JAC S3", "Lada 4x4 Urban 5 door", "Hyundai Sonata", "KIA Rio X-line", "Subaru Outback", "Toyota Land Cruiser Prado",
                "Lada Largus Cross", "Lifan Murman", "JAC T6", "Renault Kaptur", "Lada XRAY Cross", "Hyundai H-1", "Mitsubishi Pajero IV", "Lifan Myway",
                "Lada Vesta", "Nissan Qashqai", "Mitsubishi ASX", "Mitsubishi Eclipse Cross", "Toyota Land Cruiser 200", "Lada Granta лифтбэк", "Hyundai Santa Fe" };
            return model[rnd.Next(0, model.Length)];
        }

        // Случайный государственный номер регистрации автомобиля: 123ABC14
        public string getGosNomer()
        {
            string[] series = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string x = rnd.Next(1, 999).ToString();
            if (x.Length == 1) x = "0" + x;
            if (x.Length == 2) x = "0" + x;
            return x + series[rnd.Next(0, series.Length)] + series[rnd.Next(0, series.Length)] + series[rnd.Next(0, series.Length)] + "14";
        }

        // Случайная поликлиника
        public string getClinic()
        {
            string[] clinic = { "КГП на ПХВ «Поликлиника № 1»", "КГП на ПХВ «Поликлиника № 2»", "КГП на ПХВ «Поликлиника № 3»", "КГП на ПХВ «Поликлиника № 4»" };
            return clinic[rnd.Next(0, clinic.Length)];
        }


        // Сохранение в реестре в ветке HKEY_CURRENT_USER\Software\\Pharmacy в параметре _parameter значение _value (тип string)
        public void writeRegistryS(string _parameter, string _value)
        {
            RegistryKey regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey("Software\\Pharmacy");
            regKey.SetValue(_parameter, _value);
        }

        // Сохранение в реестре в ветке HKEY_CURRENT_USER\Software\\Pharmacy в параметре _parameter значение _value (тип int)
        public void writeRegistryI(string _parameter, int _value)
        {
            RegistryKey regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey("Software\\Pharmacy");
            regKey.SetValue(_parameter, _value);
        }

        // Чтение из ветки реестра HKEY_CURRENT_USER\Software\\Pharmacy параметра _parameter, возвращаемое значение _value (тип string), значение по умолчанию _default
        public string readRegistryS(string _parameter, string _default)
        {
            RegistryKey regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey("Software\\Pharmacy");
            string _value = (string)regKey.GetValue(_parameter, _default);
            // Возврат значения
            return _value;
        }

        // Чтение из ветки реестра HKEY_CURRENT_USER\Software\\Pharmacy параметра _parameter, возвращаемое значение _value (тип int), значение по умолчанию _default          
        public int readRegistryI(string _parameter, int _default)
        {
            RegistryKey regKey = Registry.CurrentUser;
            regKey = regKey.CreateSubKey("Software\\Pharmacy");
            int _value = (int)regKey.GetValue(_parameter, _default);
            // Возврат значения
            return _value;
        }

        // Сокрытие/показ(выключение/включение) кнопок и других контролов
        public void bindingNavigatorStaus1(Form form)
        {
            //foreach (ToolStripButton control in bn.Controls.OfType<ToolStripButton>())
            //{
            //    if (control.Name == "bntAdd") control.Visible = true;
            //    if (control.Name == "btnEdit") control.Visible = true;
            //    if (control.Name == "btnUpdate") control.Visible = false;
            //    if (control.Name == "btnCancel") control.Visible = false;
            //    if (control.Name == "btnDelete") control.Visible = true;
            //    if (control.Name == "btnRefresh") control.Visible = true;
            //    if (control.Name == "bindingNavigatorMoveFirstItem") control.Enabled = true;
            //    if (control.Name == "bindingNavigatorMovePreviousItem") control.Enabled = true;
            //    if (control.Name == "bindingNavigatorMoveNextItem") control.Enabled = true;
            //    if (control.Name == "bindingNavigatorMoveLastItem") control.Enabled = true;
            //    if (control.Name == "bindingNavigatorPositionItem") control.Enabled = true;
            //}

            foreach (BindingNavigator control in form.Controls.OfType<BindingNavigator>())
            {
                string x = control.GetType().ToString();
                foreach (ToolStripButton tsb in control.Controls.OfType<ToolStripButton>())
                {
                    if (tsb.Name == "bntAdd") tsb.Visible = true;
                }
            }


        }


        // Сокрытие/показ(выключение/включение) кнопок и других контролов
        public void bindingNavigatorStaus2(BindingNavigator bn)
        {
            foreach (ToolStripButton control in bn.Controls.OfType<ToolStripButton>())
            {
                if (control.Name == "bntAdd") control.Visible = false;
                if (control.Name == "btnEdit") control.Visible = false;
                if (control.Name == "btnUpdate") control.Visible = true;
                if (control.Name == "btnCancel") control.Visible = true;
                if (control.Name == "btnDelete") control.Visible = false;
                if (control.Name == "btnRefresh") control.Visible = false;
                if (control.Name == "bindingNavigatorMoveFirstItem") control.Enabled = false;
                if (control.Name == "bindingNavigatorMovePreviousItem") control.Enabled = false;
                if (control.Name == "bindingNavigatorMoveNextItem") control.Enabled = false;
                if (control.Name == "bindingNavigatorMoveLastItem") control.Enabled = false;
                if (control.Name == "bindingNavigatorPositionItem") control.Enabled = false;
            }
        }


        // "Только чтение" для TextBox, MaskedTextBox, ComboBox, DateTimePicker, CheckBox, NumericUpDown, DataGridView
        public void readOnlyControlTrue(Form form)
        {
            foreach (TextBox control in form.Controls.OfType<TextBox>())
            {
                control.Enabled = false;
            }
            foreach (MaskedTextBox control in form.Controls.OfType<MaskedTextBox>())
            {
                control.Enabled = false;
            }
            foreach (ComboBox control in form.Controls.OfType<ComboBox>())
            {
                control.Enabled = false;
            }
            foreach (DateTimePicker control in form.Controls.OfType<DateTimePicker>())
            {
                control.Enabled = false;
            }
            foreach (CheckBox control in form.Controls.OfType<CheckBox>())
            {
                control.Enabled = false;
            }
            foreach (NumericUpDown control in form.Controls.OfType<NumericUpDown>())
            {
                control.Enabled = false;
            }
            foreach (DataGridView control in form.Controls.OfType<DataGridView>())
            {
                control.Enabled = true;     // Здесь наоборот когда вводить данные в контролы можно перемещатья по DBGrid нельзя (и наоборот)
            }
            foreach (TabControl control in form.Controls.OfType<TabControl>())
            {
                foreach (TabPage t in control.Controls.OfType<TabPage>())
                {
                    foreach (TextBox c in t.Controls.OfType<TextBox>())
                    {
                        c.Enabled = false;
                    }
                    foreach (MaskedTextBox c in t.Controls.OfType<MaskedTextBox>())
                    {
                        c.Enabled = false;
                    }
                    foreach (ComboBox c in t.Controls.OfType<ComboBox>())
                    {
                        c.Enabled = false;
                    }
                    foreach (DateTimePicker c in t.Controls.OfType<DateTimePicker>())
                    {
                        c.Enabled = false;
                    }
                    foreach (CheckBox c in t.Controls.OfType<CheckBox>())
                    {
                        c.Enabled = false;
                    }
                    foreach (NumericUpDown c in t.Controls.OfType<NumericUpDown>())
                    {
                        c.Enabled = false;
                    }
                    foreach (DataGridView c in t.Controls.OfType<DataGridView>())
                    {
                        c.Enabled = true;     // Здесь наоборот когда вводить данные в контролы можно перемещатья по DBGrid нельзя (и наоборот)
                    }
                }
            }
        }

        // Снять "Только чтение" для TextBox, MaskedTextBox, ComboBox, DateTimePicker, CheckBox, NumericUpDown, DataGridView
        public void readOnlyControlFalse(Form form)
        {
            foreach (TextBox control in form.Controls.OfType<TextBox>())
            {
                control.Enabled = true;
            }
            foreach (MaskedTextBox control in form.Controls.OfType<MaskedTextBox>())
            {
                control.Enabled = true;
            }
            foreach (ComboBox control in form.Controls.OfType<ComboBox>())
            {
                control.Enabled = true;
            }
            foreach (DateTimePicker control in form.Controls.OfType<DateTimePicker>())
            {
                control.Enabled = true;
            }
            foreach (CheckBox control in form.Controls.OfType<CheckBox>())
            {
                control.Enabled = true;
            }
            foreach (NumericUpDown control in form.Controls.OfType<NumericUpDown>())
            {
                control.Enabled = true;
            }
            foreach (DataGridView control in form.Controls.OfType<DataGridView>())
            {
                control.Enabled = false;     // Здесь наоборот когда вводить данные в контролы можно перемещатья по DBGrid нельзя (и наоборот)
            }
            foreach (TabControl control in form.Controls.OfType<TabControl>())
            {
                foreach (TabPage t in control.Controls.OfType<TabPage>())
                {
                    foreach (TextBox c in t.Controls.OfType<TextBox>())
                    {
                        c.Enabled = true;
                    }
                    foreach (MaskedTextBox c in t.Controls.OfType<MaskedTextBox>())
                    {
                        c.Enabled = true;
                    }
                    foreach (ComboBox c in t.Controls.OfType<ComboBox>())
                    {
                        c.Enabled = true;
                    }
                    foreach (DateTimePicker c in t.Controls.OfType<DateTimePicker>())
                    {
                        c.Enabled = true;
                    }
                    foreach (CheckBox c in t.Controls.OfType<CheckBox>())
                    {
                        c.Enabled = true;
                    }
                    foreach (NumericUpDown c in t.Controls.OfType<NumericUpDown>())
                    {
                        c.Enabled = true;
                    }
                    foreach (DataGridView c in t.Controls.OfType<DataGridView>())
                    {
                        c.Enabled = false;     // Здесь наоборот когда вводить данные в контролы можно перемещатья по DBGrid нельзя (и наоборот)
                    }
                }
            }
        }


        // Приводит выражение типа дата в строку формата #12/31/2012# (требуется для формирования SQL-запроса к БД Microsoft Access)
        public string getDataAccess(DateTime dt)
        {
            string da;
            string d = dt.Day.ToString();
            if (d.Length == 1)
            {
                d = "0" + d;
            }
            string m = dt.Month.ToString();
            if (m.Length == 1)
            {
                m = "0" + m;
            }
            string y = dt.Year.ToString();
            da = "#" + m + "/" + d + "/" + y + "#";
            return da;
        }

        // Получение следующего порядкового номера () для базы данных Microsot SQL. Пример вызова getNextNomerSQL("SELECT max(Номер) as maxz FROM Таблица WHERE YEAR(Дата)=" + DateTime.Now.Year.ToString());
        public int getNextNomerSQL(string query)
        {
            // Начальное значение максимального номера равно 1
            int n = 1;
            try
            {
                // Создание экземпляра класса SqlConnection (Представляет подключение к базе данных SQL Server). Строка подключения получается из файла App.config
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Pharmacy.Properties.Settings.PharmacyConnectionString"].ConnectionString);
                // Открытие соединения
                cn.Open();
                // Создание экземпляра класса SqlCommand (Представляет инструкцию SQL или хранимую процедуру, выполняемую над базой данных)
                SqlCommand cmd = new SqlCommand(query, cn);
                // Создание экземпляра класса SqlDataReader (Предоставляет способ чтения потока строк последовательного доступа из базы данных SQL Server)
                SqlDataReader rdr = cmd.ExecuteReader();
                // Если число возвращаемых записей больше нуля, перебор всех записей 
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        try
                        {
                            // Новый номер = максимальный номер + 1
                            n = rdr.GetInt32(0) + 1;
                        }
                        catch
                        {

                        }
                    }
                }
                // Закрытие SqlDataReader
                rdr.Close();
                // Закрытие соединения
                cn.Close();
            }
            catch (Exception ex)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "kk-KZ")
                {
                    MessageBox.Show(ex.ToString(), "Қате", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Возврат нового номера
            return n;
        }

        // Получение следующего порядкового номера для базы данных Microsot Access. Пример вызова getNextNomerAccess("SELECT max(Номер) as maxz FROM Таблица WHERE YEAR(Дата)=" + DateTime.Now.Year.ToString());
        public int getNextNomerAccess(string query)
        {
            // Начальное значение максимального номера равно 1
            int n = 1;
            try
            {
                // Создание экземпляра класса OleDbConnection (Представляет подключение к базе данных SQL Server). Строка подключения получается из файла App.config
                OleDbConnection cn = new OleDbConnection(ConfigurationManager.ConnectionStrings["Pharmacy.Properties.Settings.PharmacyConnectionString"].ConnectionString);
                // Открытие соединения
                cn.Open();
                // Создание экземпляра класса OleDbCommand (Представляет инструкцию SQL или хранимую процедуру, выполняемую над базой данных)
                OleDbCommand cmd = new OleDbCommand(query, cn);
                // Создание экземпляра класса OleDbDataReader (Предоставляет способ чтения потока строк последовательного доступа из базы данных Microsot Access)
                OleDbDataReader rdr = cmd.ExecuteReader();
                // Если число возвращаемых записей больше нуля, перебор всех записей 
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        try
                        {
                            // Новый номер = максимальный номер + 1
                            n = rdr.GetInt32(0) + 1;
                        }
                        catch
                        {

                        }
                    }
                }
                // Закрытие OleDbDataReader
                rdr.Close();
                // Закрытие соединения
                cn.Close();
            }
            catch (Exception ex)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "kk-KZ")
                {
                    MessageBox.Show(ex.ToString(), "Қате", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Возврат нового номера
            return n;
        }

        // Поиск в связанной таблице для базы данных Microsot SQL. Пример возврата функции (-1,7,...,35).
        // Пример использования BindingSource.Filter = ТаблицаКод IN " + shared.getIdSQL("SELECT Код FROM Таблица WHERE Название Like '%" + tbFilter.Text + "%'");
        public string getIdSQL(string query)
        {
            string org = "(-1";
            try
            {
                // Создание экземпляра класса SqlConnection (Представляет подключение к базе данных SQL Server). Строка подключения получается из файла App.config
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Pharmacy.Properties.Settings.PharmacyConnectionString"].ConnectionString);
                // Открытие соединения
                cn.Open();
                // Создание экземпляра класса SqlCommand (Представляет инструкцию SQL или хранимую процедуру, выполняемую над базой данных)
                SqlCommand cmd = new SqlCommand(query, cn);
                // Создание экземпляра класса SqlDataReader (Предоставляет способ чтения потока строк последовательного доступа из базы данных SQL Server)
                SqlDataReader rdr = cmd.ExecuteReader();
                // Если число возвращаемых записей больше нуля, перебор всех записей 
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        try
                        {
                            org = org + "," + rdr.GetInt32(0).ToString();
                        }
                        catch
                        {

                        }
                    }
                }
                // Закрытие скобки
                org = org + ")";
                // Закрытие SqlDataReader
                rdr.Close();
                // Закрытие соединения
                cn.Close();
            }
            catch (Exception ex)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "kk-KZ")
                {
                    MessageBox.Show(ex.ToString(), "Қате", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return org;
        }

        // Поиск в связанной таблице для базы данных Microsot Access. Пример возврата функции (-1,7,...,35).
        // Пример использования BindingSource.Filter = ТаблицаКод IN " + shared.getIdAccess("SELECT Код FROM Таблица WHERE Название Like '%" + tbFilter.Text + "%'");
        public string getIdAccess(string query)
        {
            string org = "(-1";
            try
            {
                // Создание экземпляра класса OleDbConnection (Представляет подключение к базе данных SQL Server). Строка подключения получается из файла App.config
                OleDbConnection cn = new OleDbConnection(ConfigurationManager.ConnectionStrings["Pharmacy.Properties.Settings.PharmacyConnectionString"].ConnectionString);
                // Открытие соединения
                cn.Open();
                // Создание экземпляра класса OleDbCommand (Представляет инструкцию SQL или хранимую процедуру, выполняемую над базой данных)
                OleDbCommand cmd = new OleDbCommand(query, cn);
                // Создание экземпляра класса OleDbDataReader (Предоставляет способ чтения потока строк последовательного доступа из базы данных Microsot Access)
                OleDbDataReader rdr = cmd.ExecuteReader();
                // Если число возвращаемых записей больше нуля, перебор всех записей 
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        try
                        {
                            org = org + "," + rdr.GetInt32(0).ToString();
                        }
                        catch
                        {

                        }
                    }
                }
                // Закрытие скобки
                org = org + ")";
                // Закрытие SqlDataReader
                rdr.Close();
                // Закрытие соединения
                cn.Close();
            }
            catch (Exception ex)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "kk-KZ")
                {
                    MessageBox.Show(ex.ToString(), "Қате", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return org;
        }

        // Добавление записи в источник данных BindingSource
        public void add(BindingSource bs)
        {
            try
            {
                bs.AddNew();
            }
            catch (Exception ex)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "kk-KZ")
                {
                    MessageBox.Show(ex.ToString(), "Қате", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        // Отмена внесенных изменений в источнике данных BindingSource
        public void cancel(BindingSource bs)
        {
            try
            {
                bs.CancelEdit();
            }
            catch (Exception ex)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "kk-KZ")
                {
                    MessageBox.Show(ex.ToString(), "Қате", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        // Сохранение записи
        public void update(BindingSource bs, Form form, PharmacyDataSet ds, PharmacyDataSetTableAdapters.TableAdapterManager tam)
        {
            try
            {
                form.Validate();
                bs.EndEdit();
                tam.UpdateAll(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Удаление записи
        public void delete(BindingSource bs, Form form, PharmacyDataSet ds, PharmacyDataSetTableAdapters.TableAdapterManager tam)
        {
            if (MessageBox.Show("Удалить текущую запись?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bs.RemoveCurrent();
                    tam.UpdateAll(ds);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
