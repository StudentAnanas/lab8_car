using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace lab8_myCar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static bool flagAdd = false;
        static public List<Car> cars = new List<Car>();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddCar formAdd = new FormAddCar();
            this.Visible = false;
            formAdd.ShowDialog();
            Car car = cars.Last();
            if (flagAdd == true)
            {
                listBox1.Items.Add(car.FIO + " " + car.CodeMark + " " + car.Marka + " " + car.TypeB + " " + car.Power + " " + car.VmaxB + " " + car.VB + " " + car.VmaxM + " " + car.VM);
                btnFind.Enabled = true;
            }
            this.Visible = true;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            cars.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            if (listBox1.Items.Count == 0)
            {
                btnDel.Enabled = false;
                btnFind.Enabled = false;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FormBM formBM = new FormBM(cars);
            this.Visible = false;
            formBM.ShowDialog();
            this.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            XmlSerializer formatter = new XmlSerializer(typeof(List<Car>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                formatter.Serialize(fs, cars);
                MessageBox.Show("File сохранен");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            LoadMyFile(filename);
            listBox1.Items.Clear();
            foreach (Car car in cars)
                listBox1.Items.Add(car.FIO + " " + car.CodeMark + " " + car.Marka + " " + car.TypeB + " " + car.Power+ " " + car.VmaxB+" "+car.VB+" "+car.VmaxM+" "+car.VM);
            
            if (listBox1.Items.Count == 0)
            {
                btnFind.Enabled = false;
            }
            else
            {
                btnFind.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int errorInXml = 0;
            int record = 1;
            string filename = "myCars.xml";
            LoadMyFile(filename);
            foreach (Car car in cars)
                listBox1.Items.Add(car.FIO + " " + car.CodeMark + " " + car.Marka + " " + car.TypeB + " " + car.Power + " " + car.VmaxB + " " + car.VB + " " + car.VmaxM + " " + car.VM);
        }
        public static void LoadMyFile(string filename)
        {
            int errorInXml = 0;
            int record = 1;
            cars.Clear();
            try
            {

                XmlDocument xDoc = new XmlDocument();
                errorInXml = 10;
                xDoc.Load(filename);
                // получим корневой элемент
                XmlElement xRoot = xDoc.DocumentElement;


                // обход всех узлов в корневом элементе
                foreach (XmlNode xnode in xRoot)
                {
                    string Element = "";
                    Car car = new Car();

                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {

                        // если узел - company

                        if (childnode.Name == "FIO")
                        {
                            errorInXml = 1;
                            car.FIO = childnode.InnerText;
                           
                        }
                        // если узел age
                        if (childnode.Name == "CodeMark")
                        {
                            errorInXml = 2;
                            car.CodeMark = childnode.InnerText;
                        }
                        if (childnode.Name == "Marka")
                        {
                            errorInXml = 3;
                            car.Marka = childnode.InnerText;
                        }
                        // если узел age
                        if (childnode.Name == "TypeB")
                        {
                            errorInXml = 4;
                            car.TypeB = childnode.InnerText;
                        }
                        if (childnode.Name == "Power")
                        {
                            errorInXml = 5;
                            car.Power =float.Parse(childnode.InnerText);
                        }
                        // если узел age
                        if (childnode.Name == "VmaxB")
                        {
                            errorInXml = 6;
                            car.VmaxB = float.Parse(childnode.InnerText);
                        }
                        if (childnode.Name == "VB")
                        {
                            errorInXml = 7;
                            car.VB = float.Parse(childnode.InnerText);
                        }
                        if (childnode.Name == "VmaxM")
                        {
                            errorInXml = 8;
                            car.VmaxM = float.Parse(childnode.InnerText);
                        }
                        if (childnode.Name == "VM")
                        {
                            errorInXml = 9;
                            car.VM = float.Parse(childnode.InnerText);
                        }

                    }
                    record++;
                    cars.Add(car);
                }
            }
            catch (Exception ex)
            {
                switch (errorInXml)
                {
                    case 0: MessageBox.Show("xml-файл " + filename + " не найден"); break;
                    case 1: MessageBox.Show("Данные с xml-документа о FIO в записи" + record + " были прочитаны неверно"); break;
                    case 2: MessageBox.Show("Данные с xml-документа о CodeMark в записи" + record + " были прочитаны неверно"); break;
                    case 3: MessageBox.Show("Данные с xml-документа о Marka в записи" + record + " были прочитаны неверно"); break;
                    case 4: MessageBox.Show("Данные с xml-документа о TypeB в записи" + record + " были прочитаны неверно"); break;
                    case 5: MessageBox.Show("Данные с xml-документа о Power в записи" + record + " были прочитаны неверно"); break;
                    case 6: MessageBox.Show("Данные с xml-документа о VmaxB в записи " + record + " были прочитаны неверно"); break;
                    case 7: MessageBox.Show("Данные с xml-документа о VB в записи " + record + " были прочитаны неверно"); break;
                    case 8: MessageBox.Show("Данные с xml-документа о VmaxM в записи " + record + " были прочитаны неверно"); break;
                    case 9: MessageBox.Show("Данные с xml-документа о VM в записи " + record + " были прочитаны неверно"); break;
                    case 10: MessageBox.Show(ex.Message); break;
                    default: MessageBox.Show(ex.Message); errorInXml = 8; break;
                }
                MessageBox.Show("Загрузка последующих записей остановлена");
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDel.Enabled = true;
            if (listBox1.SelectedIndex == -1)
            {
                btnDel.Enabled = false;

                
            }
        }
    }
}
