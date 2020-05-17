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
using System.Xml.Serialization;

namespace lab8_myCar
{
    public partial class FormBM : Form
    {
        static public List<Car> cars = new List<Car>();
        static public List<Car> SaveCars = new List<Car>();
        public FormBM(List<Car> arrayOfCars)
        {
            InitializeComponent();
            cars.Clear();
            cars.AddRange(arrayOfCars);
        }
        double priceB = 45.90;
        double priceM = 23.99;
        private void btnCancel_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            this.Close();
        }

        private void btnRefresher_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Car car in cars)
                listBox1.Items.Add(car.FIO + " " + car.CodeMark + " " + car.Marka + " " + car.TypeB + " " + car.Power + " " + car.VmaxB + " " + car.VB + " " + car.VmaxM + " " + car.VM);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            XmlSerializer formatter = new XmlSerializer(typeof(List<Car>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                formatter.Serialize(fs, SaveCars);
                MessageBox.Show("File сохранен");
            }
        }

        private void FormBM_Load(object sender, EventArgs e)
        {
            
                try
                {
                listBox1.Items.Clear();
                foreach (Car car in cars)
                    listBox1.Items.Add(car.FIO + " " + car.CodeMark + " " + car.Marka + " " + car.TypeB + " " + car.Power + " " + car.VmaxB + " " + car.VB + " " + car.VmaxM + " " + car.VM);


                string pathCodeG = "CodeMandMarka.txt";

                    using (StreamReader sr = new StreamReader(pathCodeG, System.Text.Encoding.UTF8))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] lines = line.Split(',');
                            comboBox1.Items.Add(lines[0]);
                        }
                    }
                    string pathDisciplina = "benzin.txt";

                    using (StreamReader sr = new StreamReader(pathDisciplina, System.Text.Encoding.UTF8))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            comboBox2.Items.Add(line);
                        }
                    }
                    comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

                    comboBox1.SelectedIndex = 0;
                    comboBox2.SelectedIndex = 0;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            bool flag = false;
            listBox1.Items.Clear();
            SaveCars.Clear();
            List<Car> FindCars = new List<Car>();
            FindCars.AddRange(cars);
            if (checkBox1.Checked == true && textBox1.Text != "")
            {
                IEnumerable<Car> evens = from i in FindCars
                                             where i.FIO.Equals(textBox1.Text) == true
                                             select i;
                if (evens.ToList().Count != 0)
                {
                    FindCars = new List<Car>(evens);
                    flag = true;
                }
            }
            if (checkBox2.Checked == true)
            {
                IEnumerable<Car> evens = from i in FindCars
                                             where i.Marka.Equals(comboBox1.Text) == true
                                             select i;
                if (evens.ToList().Count != 0)
                {
                    FindCars = new List<Car>(evens); flag = true;
                }
            }
            if (checkBox3.Checked == true)
            {
                IEnumerable<Car> evens = from i in FindCars
                                             where i.TypeB.Equals(comboBox2.Text) == true
                                             select i;
                if (evens.ToList().Count != 0)
                {
                    FindCars = new List<Car>(evens); flag = true;
                };
            }
            if (checkBox4.Checked == true)
            {
                IEnumerable<Car> evens = from i in FindCars
                                             where i.Power.Equals(float.Parse(textBox2.Text)) == true
                                             select i;
                if (evens.ToList().Count != 0)
                {
                    FindCars = new List<Car>(evens); flag = true;
                }
            }
            if (flag == true)
            {
                foreach (Car car in FindCars)
                    listBox1.Items.Add(car.FIO + " " + car.CodeMark + " " + car.Marka + " " + car.TypeB + " " + car.Power + " " + car.VmaxB + " " + car.VB + " " + car.VmaxM + " " + car.VM);
                SaveCars.AddRange(FindCars);
            }
        }

        private void btnPriceBM_Click(object sender, EventArgs e)
        {
            bool flag = false;
           
            listBox1.Items.Clear();
            SaveCars.Clear();
            List<Car> FindCars = new List<Car>();

            FindCars.AddRange(cars);
            IEnumerable<Car> evens = FindCars;
            if (checkBox1.Checked == true && textBox1.Text != "")
            {
                evens = from i in FindCars
                                         where i.FIO.Equals(textBox1.Text) == true
                                         select i;
                if (evens.ToList().Count != 0)
                {
                    FindCars = new List<Car>(evens); flag = true;
                }
            }
            if (checkBox2.Checked == true)
            {
                 evens = from i in FindCars
                                         where i.Marka.Equals(comboBox1.Text) == true
                                         select i;
                if (evens.ToList().Count != 0)
                {
                    FindCars = new List<Car>(evens); flag = true;
                }
            }
            if (checkBox3.Checked == true)
            {
                 evens = from i in FindCars
                                         where i.TypeB.Equals(comboBox2.Text) == true
                                         select i;
                if (evens.ToList().Count != 0)
                {
                    FindCars = new List<Car>(evens); flag = true;
                };
            }
            if (checkBox4.Checked == true)
            {
                 evens = from i in FindCars
                                         where i.Power.Equals(textBox2.Text) == true
                                         select i;
                if (evens.ToList().Count != 0)
                {
                    FindCars = new List<Car>(evens); flag = true;
                }
            }
            if (evens.ToList().Count != 0)
            {
                double sum = 0;
                int count = 1;
                foreach (Car car in FindCars)
                {

                    float rB = car.VmaxB - car.VB;
                    float rM = car.VmaxM - car.VM;
                    double curCarB = rB * priceB;
                    double curCarM = rM * priceM;
                    double curCarSum = curCarB + curCarM;
                    if (curCarB < 0 || curCarM < 0)
                    {
                        MessageBox.Show(count + " Владелец " + car.FIO + " у которого авто марки" + car.Marka + " данные введены неверно: остаток бензина или масло больше чем объем. Данный автомобиль не пойдет в вычисление итоговой суммы");
                    }
                    else
                    {
                        MessageBox.Show(count + " Владелец " + car.FIO + " у которого авто марки" + car.Marka + " должен заплатить за бензин: " + curCarB + " за масло: " + curCarM + ". К оплате требуется: " + curCarSum);
                        listBox1.Items.Add(car.FIO + " " + car.CodeMark + " " + car.Marka + " " + car.TypeB + " " + car.Power + " " + car.VmaxB + " " + car.VB + " " + car.VmaxM + " " + car.VM);
                        count++;
                        sum += curCarSum;
                    }
                }
                MessageBox.Show("Итого к оплате: " + sum);
                SaveCars.AddRange(FindCars);
            }
            
        }
    }
}
