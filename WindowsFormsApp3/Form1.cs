using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;


namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        
        public static Form1 form1Instance;
        public Form1()
        {
            InitializeComponent();
            form1Instance = this;
        }
        public List<Good> goods { get; set; } = new List<Good>();
        Dictionary<string, string> map = new Dictionary<string, string>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Helper.FetchFromFile();
            Helper.LoadTimer();
        }     
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                if(MessageBox.Show("Are you sure want to delete this record?", 
                    "Message",MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    goodBindingSource.RemoveCurrent(); // also change the Goods list
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                Good currentGood = (Good)goodBindingSource.Current;
                Form3 updateForm = new Form3(currentGood);
                updateForm.ShowDialog();
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            Helper.SaveToFile();
        }
        private void LoadFromFile_Click(object sender, EventArgs e)
        {
            Helper.FetchFromFile();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            Form2 addForm = new Form2();
            addForm.ShowDialog();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            List<Good> query = (from el in goods
                                where CaseCheckBox.Checked ? (el.Name.Contains(value) || el.Category.Contains(value)) : (el.Name.ToLower().Contains(value.ToLower()) || el.Category.ToLower().Contains(value.ToLower()))
                                select el).ToList();
            goodBindingSource.DataSource = query;
            calcPriceFilter(query);
        }
        public void calcPriceFilter(List<Good> data)
        {
            try
            {
                decimal minValue = data.Min(el => el.Price);
                decimal maxValue = data.Max(el => el.Price);
                textBox2.Text = minValue.ToString();
                textBox3.Text = maxValue.ToString();
            }
            catch (Exception err) {
                Debug.WriteLine(err);
            }
        }
        private void TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal min = decimal.Parse(textBox2.Text);
                decimal max = decimal.Parse(textBox3.Text);
                if (min > max) (min, max) = (max, min); //swap
                List<Good> query = (from el in goods
                                    where el.Price>=min && el.Price<=max
                                    select el).ToList();
                goodBindingSource.DataSource = query;
            }catch(Exception err) {
                Debug.WriteLine(err);
            }
           
        }
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string headerText = dataGridView1.Columns[e.ColumnIndex].HeaderText;
            List<Good> query = null;

            if (headerText == "Delete" || headerText == "Edit") return;

            if (!map.ContainsKey(headerText))
            {
                map[headerText] = "asc";
            }

            if (map[headerText] == "asc")
            {
                query = (from el in goods
                         orderby el.GetName(headerText)
                         select el).ToList();
            }
            if (map[headerText] == "desc")
            {
                query = (from el in goods
                         orderby el.GetName(headerText) descending
                         select el).ToList();
            }
            if(map[headerText] == "asc")
               map[headerText] = "desc"; 
            else
               map[headerText] = "asc";
            goods = query;
            goodBindingSource.DataSource = goods;
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            Helper.ClearTimer();
        }
        private void Start_Click(object sender, EventArgs e)
        {
            Helper.StartTimer();
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            Helper.StopTimer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }
    }
}