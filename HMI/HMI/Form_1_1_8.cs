using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMI
{
    public partial class Form_1_1_8 : Form
    {
        Information inf = new Information();
        string[] af1;
        void Title()
        {
            if (textBox1.Text == "Не правильний пін-код" || textBox1.Text == "У банкоматі недостатньо грошей" ||
                textBox1.Text == "Не правильний пін-код для входу в системне меню" ||
                textBox1.Text == "На карті недостатньо грошей для здійснення операції зняття готівки" ||
                textBox1.Text == "На карті недостатньо грошей для здійснення операції переведення грошей на іншу картку" ||
                textBox1.Text == "На карті недостатньо грошей для здійснення операції переведення грошей на номер телефону" ||
                textBox1.Text == "Банкомат переповнено. Не забудьте забрати гроші!")
            {
                label1.Text = "Помилка!";
            }
            else if (textBox1.Text == "Отримайте гроші" || textBox1.Text == "Переказ грошей успішно здійснено" ||
                textBox1.Text == "Баланс карти успішно поповнено")
            {
                label1.Text = "Успіх!";
            }
            else if (textBox1.Text == "Вкладіть до банкомату необхідну кількість грошей у гривнях")
            {
                label1.Text = "Попередження!";
            }
        }
        public Form_1_1_8()
        {
            InitializeComponent();
            string[] af = File.ReadAllLines(inf.path_mess); // отримати повідомлення для виведення
            af1 = File.ReadAllLines(inf.path_atm); 
            textBox1.Text = af[0];
            Title();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // виводити повідомлення щодо стану здійснення операцій
            if (textBox1.Text == "Не правильний пін-код")
            {
                using (FileStream file = new FileStream(inf.path_debug, FileMode.OpenOrCreate))
                using (StreamWriter stream = new StreamWriter(file))
                {
                    stream.WriteLine("i) 1");
                }
                Form_1 main_form = new Form_1();
                File.Delete(inf.path_mess);
                inf.ToForm(main_form, this);
            }            
            else if (textBox1.Text == "Не правильний пін-код для входу в системне меню")
            {
                Form_1_1 switch_form = new Form_1_1();
                File.Delete(inf.path_mess);
                inf.ToForm(switch_form, this); 
            }
            else if (textBox1.Text == "На карті недостатньо грошей для здійснення операції зняття готівки" ||
                textBox1.Text == "У банкоматі недостатньо грошей")
            {
                Operations.Form_1_1_3 form3 = new Operations.Form_1_1_3();
                File.Delete(inf.path_mess);
                inf.ToForm(form3, this);
            }
            else if (textBox1.Text == "На карті недостатньо грошей для здійснення операції переведення грошей на іншу картку")
            {
                Operations.Form_1_1_4 form4 = new Operations.Form_1_1_4();
                File.Delete(inf.path_mess);
                inf.ToForm(form4, this);
            }
            else if (textBox1.Text == "На карті недостатньо грошей для здійснення операції переведення грошей на номер телефону")
            {
                Operations.Form_1_1_5 form5 = new Operations.Form_1_1_5();
                File.Delete(inf.path_mess);
                inf.ToForm(form5, this);
            }
            else if (textBox1.Text == "Отримайте гроші" ||
                textBox1.Text == "Переказ грошей успішно здійснено" ||
                textBox1.Text == "Баланс карти успішно поповнено" ||
                textBox1.Text == "Банкомат переповнено. Не забудьте забрати гроші!")
            {
                Form_1_1 switch_form = new Form_1_1();
                File.Delete(inf.path_mess);
                inf.ToForm(switch_form, this);
            }
            else if (textBox1.Text == "Вкладіть до банкомату необхідну кількість грошей у гривнях")
            {
                Operations.Form_1_1_6 form6 = new Operations.Form_1_1_6();
                File.Delete(inf.path_mess);
                inf.ToForm(form6, this);
            }
        }
    }
}
