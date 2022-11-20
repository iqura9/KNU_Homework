using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                Good good = new Good(textBox1.Text, textBox2.Text, Decimal.Parse(textBox3.Text, NumberStyles.Any, CultureInfo.InvariantCulture));
                Form1.form1Instance.goods.Add(good);
                Form1.form1Instance.goodBindingSource.ResetBindings(false);
            }
            catch (Exception)
            {
                MessageBox.Show("Число введено невірно", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
