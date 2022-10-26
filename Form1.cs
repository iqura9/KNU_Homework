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
    
    public partial class Form1 : Form
    {
        public List<Book> books { get; set; } = new List<Book>();
        public static Form1 form1instance;
        public Form1()
        {
            InitializeComponent();
            form1instance = this;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            books.Add(new Book("Шерлок Холмс", "А-БА-БА-ГА-ЛА-МА-ГА",750,true));
            books.Add(new Book("Паскудна звістка", "Фабула",222,false));
            bindingSource1.DataSource = books;
            dataGridView.RowHeadersVisible = false;
            //dataGridView.AutoResizeColumns();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dataGridView.CurrentCell.RowIndex; //find rowIndex
                DataGridViewRow selectedRow = dataGridView.Rows[rowIndex]; //find allRow
                int selectedId = Int32.Parse(selectedRow.Cells[0].Value.ToString()); // find value at selected Id
                books.RemoveAll(r => r.Id == selectedId);
                bindingSource1.ResetBindings(false);
                
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Таблиця пуста","Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
