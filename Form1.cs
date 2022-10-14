using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Show info about input(TextBox main page)
        {
            string input = textBox1.Text;
            if (!long.TryParse(input, out long number))
            {
                MessageBox.Show("Ви ввели некоректне число", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show($"Ви ввели число {number}", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}