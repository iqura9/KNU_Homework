using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        DataGridView DGV = new DataGridView();
        public Form2(DataGridView dataGridView)
        {
            InitializeComponent();
            DGV = dataGridView;
        }
        
        private void AddB_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = new Book(Book.maxVal + 1, textBox1.Text, textBox2.Text, Int32.Parse(textBox3.Text), false);
                Form1.form1instance.books.Add(book);
                Form1.form1instance.bindingSource1.ResetBindings(false);
                DGV.AutoResizeColumns(); // resize


            }
            catch (Exception ex)
            {
                MessageBox.Show("Число введено невірно","Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            this.Close();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
