using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace test1
{
    // одна строка входных данных
    struct data
    {
        public int id { get; set; }
        public int weight { get; set; }
        public int region { get; set; }
        public DateTime time { get; set; }

        public data(string[] s)
        {
            id = Convert.ToInt32(s[0]);
            weight = Convert.ToInt32(s[1]);
            region = Convert.ToInt32(s[2]);
            time = DateTime.ParseExact(s[3] + " " + s[4], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public override string ToString() => $"{id} {weight} {region} {time}";
    }

    public partial class Form1 : Form
    {
        FolderBrowserDialog fbd;
        OpenFileDialog ofd;

        // входной, лог и результирующий файлы соответственно
        string fin = "";
        string log = Directory.GetCurrentDirectory();
        string res = Directory.GetCurrentDirectory();

        // флаг, обозначающий были ли фходные данные уже считаны из файла
        bool inpRead;

        // списки со всеми данными из файла и результатом фильтрации
        List<data> dataList = new List<data>();
        List<data> resList = new List<data>();

        TimeSpan span = new TimeSpan(0, 30, 0);


        public Form1()
        {
            InitializeComponent();
            log_textBox.Text = log;
            res_textBox.Text = res;
            inpRead = false;
        }

        private void inpFile_button_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();

            ofd.InitialDirectory = Directory.GetCurrentDirectory();
            ofd.Filter = "txt files (*.txt)|*.txt";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK && fin != ofd.FileName)
            {
                fin = ofd.FileName;
                inpFile_textBox.Text = fin;

                if (inpRead)
                {
                    dataList.Clear();
                    resList.Clear();
                    inpRead = false;
                }
            }
        }

        private void log_button_Click(object sender, EventArgs e)
        {
            fbd = new FolderBrowserDialog();

            if (Directory.Exists(log))
                fbd.SelectedPath = log;
            else
                fbd.SelectedPath = Directory.GetCurrentDirectory();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                log = fbd.SelectedPath;
                log_textBox.Text = log;
            }
        }

        private void inpFile_textBox_TextChanged(object sender, EventArgs e)
        {
            if (fin != inpFile_textBox.Text)
            {
                fin = inpFile_textBox.Text;
                if (inpRead)
                {
                    dataList.Clear();
                    resList.Clear();
                    inpRead = false;
                }
            }   
        }

        private void log_textBox_TextChanged(object sender, EventArgs e)
        {
            log = log_textBox.Text;
        }

        private void res_textBox_TextChanged(object sender, EventArgs e)
        {
            res = res_textBox.Text;
        }

        private void res_button_Click(object sender, EventArgs e)
        {
            fbd = new FolderBrowserDialog();

            if (Directory.Exists(res))
                fbd.SelectedPath = res;
            else
                fbd.SelectedPath = Directory.GetCurrentDirectory();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                res = fbd.SelectedPath;
                res_textBox.Text = res;
            }
        }

        // обработка ошибок при заполнении формы
        private bool errorHand()
        {
            if (fin == "")
            {
                MessageBox.Show("Не задан входной файл");
                return false;
            }
            if (!File.Exists(fin))
            {
                MessageBox.Show("Заданный входной файл не существует");
                return false;
            }
            if (Path.GetExtension(fin) != ".txt")
            {
                MessageBox.Show("Неверное расширение входного файла");
                return false;
            }
            if (reg_comboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран район доставки");
                return false;
            }
            if (!Directory.Exists(log))
            {
                MessageBox.Show("Неверный путь к лог-файлу");
                return false;
            }
            if (!Directory.Exists(res))
            {
                MessageBox.Show("Неверный путь к файлу с результатом");
                return false;
            }

            return true;
        }

        // чтение входного файла
        private bool readInp(TextWriter logWriter)
        {
            bool fl = true;
            data d;

            using (FileStream fs = new FileStream(fin, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    logWriter.Write($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}  ");
                    logWriter.WriteLine($"Открыт входной файл {fin}");

                    while (!sr.EndOfStream && fl)
                    {
                        string[] s = sr.ReadLine().Split(' ');
                        if (s.Length != 5)
                        {
                            MessageBox.Show("Ошибка ввода: неверная строка с данными");
                            logWriter.Write($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}  ");
                            logWriter.WriteLine("Ошибка ввода: неверная строка с данными");
                            fl = false;
                        }
                        else
                        {
                            try
                            {
                                d = new data(s);

                                var unique = dataList.Where(x => x.id == d.id);

                                if (unique.Any())
                                    throw new Exception("Ошибка: идентификатор не уникальный");
                                else
                                {
                                    dataList.Add(d);

                                    // так как это первое считывание файла, входные данные сразу фильтруются
                                    if (d.region == Convert.ToInt32(reg_comboBox.SelectedItem) && d.time >= dateTimePicker.Value && d.time <= dateTimePicker.Value + span)
                                        resList.Add(d);
                                }
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                                logWriter.Write($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} ");
                                logWriter.WriteLine(e.Message);
                                fl = false;
                            }
                        }
                    }
                }
            }

            logWriter.Write($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}  ");
            if (fl)
                logWriter.WriteLine($"Входной файл успешно прочитан, данные отфильтрованы по району {Convert.ToInt32(reg_comboBox.SelectedItem)} и времени первой доставки {dateTimePicker.Value}");
            else
            {
                logWriter.WriteLine("При чтении входнного файла возникли ошибки, данные не были обработаны");
                dataList.Clear();
                resList.Clear();
            }
            return fl;
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            if (errorHand())
            {
                using (StreamWriter logFileWriter = new StreamWriter(log + "\\log.txt", true))
                {
                    if (inpRead)
                    {
                        // фильтрация данных, если входной файл уже был считан
                        resList = dataList.Where(x => x.region == Convert.ToInt32(reg_comboBox.SelectedItem) && x.time >= dateTimePicker.Value && x.time <= dateTimePicker.Value + span).ToList();

                        logFileWriter.Write($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}  ");
                        logFileWriter.WriteLine($"Данные отфильтрованы по району {Convert.ToInt32(reg_comboBox.SelectedItem)} и времени первой доставки {dateTimePicker.Value}");
                    }
                    else
                        inpRead = readInp(logFileWriter);

                    if (inpRead)
                    {
                        using (FileStream fs = new FileStream(res + "\\res.txt", FileMode.Create, FileAccess.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                logFileWriter.Write($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} ");
                                logFileWriter.WriteLine("Открыт файл с результатом");

                                foreach (var item in resList)
                                {
                                    sw.WriteLine(item.ToString());
                                }

                                logFileWriter.Write($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} ");
                                logFileWriter.WriteLine($"Результат фильтрации ({resList.Count} строк) успешно записан в файл {res}\\res.txt");
                                MessageBox.Show($"Результат фильтрации ({resList.Count} строк) успешно записан в файл {res}\\res.txt");
                            }
                        }
                    }
                }
            }
                
        }
    }
}
