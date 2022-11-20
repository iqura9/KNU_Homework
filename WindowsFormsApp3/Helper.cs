using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class Helper
    {
        static System.Timers.Timer t;
        static int h, m, s;
        const string path = @"D:\VSProject\Excel\WindowsFormsApp3\WindowsFormsApp3\Goods.json";

        public static async void FetchFromFile()
        {
            var option = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            };
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                Form1.form1Instance.goods = await JsonSerializer.DeserializeAsync<List<Good>>(fs); // зчитати з файлу
                var show = JsonSerializer.Serialize(Form1.form1Instance.goods, option);
            }
            Form1.form1Instance.calcPriceFilter(Form1.form1Instance.goods);
            Form1.form1Instance.goodBindingSource.DataSource = Form1.form1Instance.goods;
        }
        public static async void SaveToFile()
        {
            var option = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
            };
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    await JsonSerializer.SerializeAsync(fs, Form1.form1Instance.goods, option);
                }
                MessageBox.Show("The file has been saved", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Error", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static void LoadTimer()
        {
            t = new System.Timers.Timer(1000);
            t.Elapsed += (sender, eventArgs) =>
            {
                s += 1;
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }
                Form1.form1Instance.textBox4.Text = TimerResult(); 
                //Console.WriteLine($"Elapsed event at {eventArgs.SignalTime:G}");
                //Console.WriteLine($"{TimerResult()}");
            };
            
        }
        static public void StartTimer()
        {
            t.Start();
        }
        static public void StopTimer()
        {
            t.Stop();
        }
        static public void ClearTimer()
        {
            h = 0; m = 0; s = 0;
            Form1.form1Instance.textBox4.Text = TimerResult();
        }
        static private string TimerResult()
        {
            return string.Format("{0}:{1}:{2}",
                        h.ToString().PadLeft(2, '0'),
                        m.ToString().PadLeft(2, '0'),
                        s.ToString().PadLeft(2, '0'));
        }



    }
}
