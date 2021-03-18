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
                button3.Visible = true;
                radioButton5.Visible = true;
                radioButton6.Visible = true;
            }
            if (t.Equals("Навигатор"))
            {
                button3.Visible = true;
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
            radioButton2.Checked = true;

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


        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.TextLength != 0)
            {
                if (devices.Count != 0)
                {
                    IComputingDevice device = devices[devices.Count - 1];
                    richTextBox2.Text += ((Navigator)device).LeadTheWay() + "\n";
                }
            }
            else richTextBox2.Text += "Enter the distanation" + "\n";
        }





        private void button3_Click(object sender, EventArgs e)
        {
            IComputingDevice device = devices[devices.Count - 1];
            richTextBox2.Text += ((Computer)device).ChargeCheck() + "\n";


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (devices.Count != 0 && radioButton1.Checked) {
                IComputingDevice device = devices[devices.Count - 1];
                richTextBox2.Text += ((Computer)device).DeviceOn() + "\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (devices.Count != 0)
            {
                IComputingDevice device = devices[devices.Count - 1];
                richTextBox2.Text += ((Computer)device).Reboot() + "\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (devices.Count != 0)
            {
                IComputingDevice device = devices[devices.Count - 1];
                richTextBox2.Text += ((Computer)device).Sleep() + "\n";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (devices.Count != 0 && radioButton2.Checked)
            {
                IComputingDevice device = devices[devices.Count - 1];
                richTextBox2.Text += ((Computer)device).DeviceOff() + "\n";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (devices.Count != 0 && radioButton1.Checked && radioButton3.Checked)
            {
                IComputingDevice device = devices[devices.Count - 1];
                richTextBox2.Text += ((Laptop)device).TouchPadOn() + "\n";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (devices.Count != 0 && radioButton1.Checked && radioButton4.Checked)
            {
                IComputingDevice device = devices[devices.Count - 1];
                richTextBox2.Text += ((Laptop)device).TouchPadOff() + "\n";
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (devices.Count != 0 && radioButton1.Checked && radioButton5.Checked)
            {
                IComputingDevice device = devices[devices.Count - 1];
                richTextBox2.Text += ((Smartphone)device).FlashlightOn() + "\n";
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (devices.Count != 0 && radioButton1.Checked && radioButton6.Checked)
            {
                IComputingDevice device = devices[devices.Count - 1];
                richTextBox2.Text += ((Smartphone)device).FlashlightOff() + "\n";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
