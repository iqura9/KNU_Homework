using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form3 : Form
    {
        private Good currentGood { get; set; } = null;

        public Form3(Good good)
        {
            InitializeComponent();
            currentGood = good;
            initValues();
        }

        private void initValues()
        {
            textBox1.Text = currentGood.Name;
            textBox2.Text = currentGood.Category;
            textBox3.Text = currentGood.Price.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool checkValidInputs()
        {
            try
            {
                dynamic a = Decimal.Parse(textBox3.Text);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Невірна ціна", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkValidInputs())
            {
                Good g =  Form1.form1Instance.goods.Find(el => el.Id == currentGood.Id);
                g.Name = textBox1.Text;
                g.Category = textBox2.Text;
                g.Price = Math.Round(Decimal.Parse(textBox3.Text),2);
                Form1.form1Instance.goodBindingSource.ResetBindings(false);
                Close();
            }
        }

        
    }
}
