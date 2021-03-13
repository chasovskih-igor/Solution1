using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace Task6
{
    public partial class Form1 : Form
    {
        public Laptop laptop;
        public Navigator navigator;
        public Smartphone smartphone;
        public List<IComputingDevice> devices;
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(new string[] { "Ноутбук", "Смартфон", "Навигатор" });
            devices = new List<IComputingDevice>();
            Visible(null);
            radioButton2.Checked = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private new void Visible(string t)
        {
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            button3.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;
            label5.Visible = false;
            textBox4.Visible = false;
            button4.Visible = false;
            if (t == null) return;


            if (t.Equals("Ноутбук"))
            {
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                button3.Visible = true;
            }
            if (t.Equals("Смартфон"))
            {
                radioButton5.Visible = true;
                radioButton6.Visible = true;
            }
            if (t.Equals("Навигатор"))
            {
                label5.Visible = true;
                textBox4.Visible = true;
                button4.Visible = true;
            }
        }

        private void GetDevice()
        {
            string t = (string)comboBox1.SelectedItem;
            Visible(t);
            if (t == null) return;

            if (t.Equals("Ноутбук"))
            {
                devices.Add(new Laptop(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), int.Parse(textBox5.Text)));
            }
            if (t.Equals("Смартфон"))
            {
                devices.Add(new Smartphone(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), false, int.Parse(textBox5.Text)));
            }
            if (t.Equals("Навигатор"))
            {
                devices.Add(new Navigator(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), int.Parse(textBox5.Text), textBox4.Text));
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GetDevice();
            if (devices.Count == 0)
            {
                richTextBox2.Text += "Устройство не создано" + "\n";
                return;
            }
            IComputingDevice device = devices[devices.Count - 1];
            richTextBox2.Text += "Создано устройство " + textBox1.Text + " " + textBox2.Text + " с памятью " + textBox3.Text + " и зарядом батареи " + textBox5.Text + " \n";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (devices.Equals(comboBox1.Text[0]))
                label5.Visible = !label5.Visible;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetDevice();
            IComputingDevice device = devices[devices.Count - 1];
            if (device.Equals("Ноутбук"))
            {
                richTextBox2.Text += laptop.ChargeTimeCheck() + "\n";
            }
            if (device.Equals("Смартфон"))
            {
                richTextBox2.Text += smartphone.ChargeCheck() + "\n";
            }
            if (device.Equals("Навигатор"))
            {
                richTextBox2.Text += navigator.ChargeCheck() + "\n";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
