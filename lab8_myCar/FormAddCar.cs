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

namespace lab8_myCar
{
    public partial class FormAddCar : Form
    {
        public FormAddCar()
        {
            InitializeComponent();
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form1.flagAdd = false;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            textBox1.Text.Trim(' ');
            try
            {
                if (textBox1.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
                {
                    Car car = new Car(textBox1.Text, comboBox1.Text, comboBox2.Text, comboBox3.Text, float.Parse(textBox5.Text), float.Parse(textBox6.Text), float.Parse(textBox7.Text), float.Parse(textBox8.Text), float.Parse(textBox9.Text));
                    Form1.cars.Add(car);
                    Form1.flagAdd = true;
                    this.Close();
                }
                else { MessageBox.Show("некоторые поля не заполнены, или заполнены неверно");
                }
            }
            catch
            {
                MessageBox.Show("некоторые поля не заполнены, или заполнены неверно");
            }
        }

        private void FormAddCar_Load(object sender, EventArgs e)
        {
            try
            {
                

                string pathCodeG = "CodeMandMarka.txt";

                using (StreamReader sr = new StreamReader(pathCodeG, System.Text.Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] lines = line.Split(',');
                        comboBox1.Items.Add(lines[1]);
                        comboBox2.Items.Add(lines[0]);
                    }
                }
                string pathDisciplina = "benzin.txt";

                using (StreamReader sr = new StreamReader(pathDisciplina, System.Text.Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        comboBox3.Items.Add(line);
                    }
                }
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            comboBox2.SelectedIndex = index;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox2.SelectedIndex;
            comboBox1.SelectedIndex = index;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (textBox9.Text.IndexOf(',') == -1)
            {
                if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
                {

                    e.Handled = true;
                }
            }
            else
            {
                if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
                {

                    e.Handled = true;
                }
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (textBox7.Text.IndexOf(',') == -1)
            {
                if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
                {

                    e.Handled = true;
                }
            }
            else
            {
                if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
                {

                    e.Handled = true;
                }
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (textBox8.Text.IndexOf(',') == -1)
            {
                if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
                {

                    e.Handled = true;
                }
            }
            else
            {
                if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
                {

                    e.Handled = true;
                }
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (textBox6.Text.IndexOf(',') == -1)
            {
                if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
                {

                    e.Handled = true;
                }
            }
            else
            {
                if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
                {

                    e.Handled = true;
                }
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (textBox5.Text.IndexOf(',') == -1)
            {
                if (!Char.IsDigit(number) && number != 8 && number != 44) // цифры, клавиша BackSpace и запятая
                {

                    e.Handled = true;
                }
            }
            else
            {
                if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
                {

                    e.Handled = true;
                }
            }
        }
    }
}
