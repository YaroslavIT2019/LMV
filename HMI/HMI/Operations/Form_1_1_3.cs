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
    public partial class Form_1_1_3 : Form
    {
        Information inf = new Information();
        Statistics stat = new Statistics();

        decimal balance = 0;
        decimal balance_in_atm = 0;
        
        string[] af;
        string[] af_atm;
        void Balance()
        {
            // отримати дані про баланс користувача та кількість грошей в банкоматі
            af = File.ReadAllLines(inf.path);
            af_atm = File.ReadAllLines(inf.path_atm);
            string a = "";
            string b = "";

            for (int i = 0; i < af.Length; i++)
                if (af[i] != "" && af[i][0] == 'b' && af[i][1] == ')')
                    a = af[i];

            for (int i = 0; i < af_atm.Length; i++)
                if (af_atm[i] != "" && af_atm[i][0] == 'b' && af_atm[i][1] == ')')
                    b = af_atm[i];

            string s1 = a.Substring(3);
            string s2 = b.Substring(3);

            balance = Convert.ToDecimal(s1);
            balance_in_atm = Convert.ToDecimal(s2);
        }

        public Form_1_1_3()
        {
            InitializeComponent();
            textBox1.MaxLength = 6;  // можна вписувати максимум 4 символа
            Balance();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // якщо запрошувана сума менша (чи дорівнює) за суму на карті та суму в банкоматі, то виконати операцію
            // якщо ні, то видати відповідне повідомлення
            decimal count = Convert.ToDecimal(textBox1.Text);
            if (count <= balance)
            {
                if (count <= balance_in_atm)
                {
                    stat.SetStatistics(3, DateTime.Now);
                    balance = balance - count;
                    balance_in_atm = balance_in_atm - count;
                    File.Delete(inf.path);
                    File.Delete(inf.path_atm);
                    using (FileStream file = new FileStream(inf.path, FileMode.OpenOrCreate))
                        using (StreamWriter stream = new StreamWriter(file))
                        {
                            for (int i = 0; i < af.Length; i++)
                                if (!(af[i][0] == 'b' && af[i][1] == ')'))
                                    stream.WriteLine(af[i]);

                            stream.WriteLine("b) " + balance);
                        }
                    
                    using (FileStream file_atm = new FileStream(inf.path_atm, FileMode.OpenOrCreate))
                        using (StreamWriter stream = new StreamWriter(file_atm))
                        {
                            for (int i = 0; i < af_atm.Length; i++)
                                if (!(af_atm[i][0] == 'b' && af_atm[i][1] == ')'))
                                    stream.WriteLine(af_atm[i]);

                            stream.WriteLine("b) " + balance_in_atm);
                        }

                    inf.MessageToFile(inf.path_mess, "Отримайте гроші");

                    Form_1_1_8 form8 = new Form_1_1_8();
                    inf.ToForm(form8, this);
                }
                else 
                {
                    inf.MessageToFile(inf.path_mess, "У банкоматі недостатньо грошей");
                        
                    Form_1_1_8 form8 = new Form_1_1_8();
                    inf.ToForm(form8, this);
                }
            }
            else
            {
                inf.MessageToFile(inf.path_mess, "На карті недостатньо грошей для здійснення операції зняття готівки");
                    
                Form_1_1_8 form8 = new Form_1_1_8();
                inf.ToForm(form8, this);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // можна вписувати тільки цифри
            if (textBox1.Text == "") return;
            try
            {
                int s = Convert.ToInt32(textBox1.Text);
            }
            catch (System.FormatException)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                textBox1.Select(6, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // перейти до форми з підтвердженням
            inf.MessageToFile(inf.path_conf, "Перейти до головного меню з меню зняття готівки?");

            Form_1_1_7 conf_form = new Form_1_1_7();
            inf.ToForm(conf_form, this);
        }
    }
}
