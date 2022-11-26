using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMI.Operations
{
    public partial class Form_1_1_5 : Form
    {
        Information inf = new Information();
        Statistics stat = new Statistics();

        decimal balance = 0;

        string[] af;

        void Balance()
        {
            af = File.ReadAllLines(inf.path);
            string a = "";

            for (int i = 0; i < af.Length; i++)
                if (af[i] != "" && af[i][0] == 'b' && af[i][1] == ')')
                    a = af[i];

            string s1 = a.Substring(3);

            balance = Convert.ToDecimal(s1);
        }
        public Form_1_1_5()
        {
            InitializeComponent();
            textBox1.MaxLength = 10;  // можна вписувати максимум 8 символів
            textBox2.MaxLength = 6;  // можна вписувати максимум 6 символів
            Balance();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            inf.MessageToFile(inf.path_conf, "Перейти до головного меню з меню переказу на номер телефону?");

            Form_1_1_7 conf_form = new Form_1_1_7();
            inf.ToForm(conf_form, this);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // можна вписувати тільки цифри
            if (textBox1.Text == "") return;
            try
            {
                long s = Convert.ToInt64(textBox1.Text);
            }
            catch (System.FormatException)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                textBox1.Select(10, 0);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // можна вписувати тільки цифри
            if (textBox2.Text == "") return;
            try
            {
                int s = Convert.ToInt32(textBox2.Text);
            }
            catch (System.FormatException)
            {
                textBox2.Text = textBox2.Text.Substring(0, textBox2.Text.Length - 1);
                textBox2.Select(6, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal count = Convert.ToDecimal(textBox2.Text);
            if (count <= balance)
            {
                stat.SetStatistics(5, DateTime.Now);
                balance = balance - count;
                File.Delete(inf.path);

                using (FileStream file = new FileStream(inf.path, FileMode.OpenOrCreate))
                using (StreamWriter stream = new StreamWriter(file))
                {
                    for (int i = 0; i < af.Length; i++)
                        if (!(af[i][0] == 'b' && af[i][1] == ')'))
                            stream.WriteLine(af[i]);

                    stream.WriteLine("b) " + balance);
                }

                inf.MessageToFile(inf.path_mess, "Переказ грошей успішно здійснено");

                Form_1_1_8 form8 = new Form_1_1_8();
                inf.ToForm(form8, this);
            }
            else
            {
                inf.MessageToFile(inf.path_mess, "На карті недостатньо грошей для здійснення операції переведення грошей на номер телефону");

                Form_1_1_8 form8 = new Form_1_1_8();
                inf.ToForm(form8, this);
            }
        }
    }
}
