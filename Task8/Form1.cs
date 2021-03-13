using Implementation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;


namespace Interface
{
    public partial class Form1 : Form
    {
        private ClassInformation _classInformation;

        private Emulator _emulator;

        private Image _forklift, _mechanic, _warehouse1, _warehouse2, _warehouse3, _warehouse4, _warehouse5, _warehouse6;

        private Thread _repaintThread;

        private List<Type> _types;

        public Form1()
        {
            InitializeImages();
            InitializeComponent();
            panel1.Paint += panel1_Paint;
            _classInformation = new ClassInformation(@"C:\Users\user\source\repos\Solution1\Task8\bin\Debug\ClassLibrary.dll");
            InitializeForklifts();
            _repaintThread = null;
        }

        private Image GetImage(int status)
        {
            switch (status)
            {
                case 1:
                    return _warehouse1;
                case 2:
                    return _warehouse2;
                case 3:
                    return _warehouse3;
                case 4:
                    return _warehouse4;
                case 5:
                    return _warehouse5;
                case 6:
                    return _warehouse6;
                default:
                    throw new ArgumentException();
            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void InitializeForklifts()
        {
            _types = _classInformation.GetTypesOfImplementingClasses(typeof(IForklift));
            UpdateComboBox();
        }

        private void InitializeImages()
        {
            string basePath = Directory.GetCurrentDirectory() + @"\Resources\";
            _forklift = Image.FromFile(basePath + "forklift.png");
            _mechanic = Image.FromFile(basePath + "mechanic.png");
            _warehouse1 = Image.FromFile(basePath + "warehouse1.png");
            _warehouse2 = Image.FromFile(basePath + "warehouse2.png");
            _warehouse3 = Image.FromFile(basePath + "warehouse3.png");
            _warehouse4 = Image.FromFile(basePath + "warehouse4.png");
            _warehouse5 = Image.FromFile(basePath + "warehouse5.png");
            _warehouse6 = Image.FromFile(basePath + "warehouse6.png");
        }

        private void PaintImage(Graphics graphics)
        {
            if (_emulator == null)
            {
                return;
            }
            for (int i = 0; i < _emulator.Mechanics.Count; i++)
            {
                graphics.DrawImage(GetImage(_emulator.Mechanics[i].Warehouse.ImageId),
                    _emulator.Mechanics[i].Warehouse.Coordinates.X, _emulator.Mechanics[i].Warehouse.Coordinates.Y, 128, 128);
                if (_emulator.Mechanics[i].InHouse())
                {
                    graphics.DrawImage(_mechanic, _emulator.Mechanics[i].BaseCoordinates.X, _emulator.Mechanics[i].BaseCoordinates.Y, 38, 54);
                }
                else
                {
                    graphics.DrawImage(_mechanic, _emulator.Mechanics[i].NextCoordinates.X, _emulator.Mechanics[i].NextCoordinates.Y, 38, 54);
                }
            }
            if (_emulator.Forklift.InBaseCoordinates())
            {
                graphics.DrawImage(_forklift, _emulator.Forklift.BaseCoordinates.X, _emulator.Forklift.BaseCoordinates.Y, 81, 59);
            }
            else
            {
                graphics.DrawImage(_forklift, _emulator.Forklift.NextCoordinates.X, _emulator.Forklift.NextCoordinates.Y, 81, 59);
            }
        }

        private void PanelRepaint()
        {
            while (true)
            {
                Thread.Sleep(100);
                panel1.Invalidate();
            }
        }

        private void UpdateComboBox()
        {
            comboBox1.DataSource = null;
            List<string> typeNames = new List<string>();
            foreach (Type type in _types)
            {
                typeNames.Add(type.Name);
            }
            comboBox1.DataSource = typeNames;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_repaintThread == null)
            {
                Random random = new Random();
                IForklift forklift = (IForklift)Activator.CreateInstance(_types[comboBox1.SelectedIndex], new Coordinates(panel1.Width / 2 - 50, panel1.Height / 2, 20),
                    new Coordinates(panel1.Width / 2 - 50, panel1.Height / 2, 30));
                List<Mechanic> mechanics = new List<Mechanic>();
                for (int i = 0; i < Convert.ToInt32(numericUpDown1.Value); i++)
                {
                    mechanics.Add(new Mechanic(new Coordinates(135 + 158 * i, panel1.Height - 70, 20), new Coordinates(135 + 158 * i, panel1.Height - 70, 20),
                        new Warehouse(new Coordinates(90 + 158 * i, 60, 0), Convert.ToInt32(numericUpDown2.Value), random)));
                }
                _emulator = new Emulator(forklift, mechanics);
                _emulator.Run();
                _repaintThread = new Thread(PanelRepaint)
                {
                    IsBackground = true
                };
                _repaintThread.Start();
                button1.Text = "Остановить";
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                comboBox1.Enabled = false;
            }
            else
            {
                _emulator.Abort();
                _repaintThread.Abort();
                _repaintThread = null;
                button1.Text = "Запустить";
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                comboBox1.Enabled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = panel1.CreateGraphics();
            Bitmap bitmap = new Bitmap(panel1.Width, panel1.Height);
            Graphics bitmapGraphics = Graphics.FromImage(bitmap);
            bitmapGraphics.Clear(Color.White);
            PaintImage(bitmapGraphics);
            graphics.DrawImage(bitmap, 0, 0);
            bitmapGraphics.Dispose();
            bitmap.Dispose();
        }
    }
}
