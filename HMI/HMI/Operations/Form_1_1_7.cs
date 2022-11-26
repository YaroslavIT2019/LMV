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
    public partial class Form_1_1_7 : Form
    {
        Information inf = new Information();
        public Form_1_1_7()
        {
            InitializeComponent();
            string[] af = File.ReadAllLines(inf.path_conf);
            textBox1.Text = af[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Перейти до головного меню з меню зняття готівки?")
            {
                File.Delete(inf.path_conf);
                Form_1_1_3 form3 = new Form_1_1_3();
                inf.ToForm(form3, this);
            }
            else if (textBox1.Text == "Перейти до головного меню з меню переказу на іншу карту?")
            {
                File.Delete(inf.path_conf);
                Form_1_1_4 form4 = new Form_1_1_4();
                inf.ToForm(form4, this);
            }
            else if (textBox1.Text == "Перейти до головного меню з меню переказу на номер телефону?")
            {
                File.Delete(inf.path_conf);
                Form_1_1_5 form5 = new Form_1_1_5();
                inf.ToForm(form5, this);
            }
            else if (textBox1.Text == "Чи дійсно ви хочете завершити роботу?")
            {
                File.Delete(inf.path_conf);
                Form_1_1 switch_form = new Form_1_1();
                inf.ToForm(switch_form, this);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Перейти до головного меню з меню зняття готівки?" ||
            textBox1.Text == "Перейти до головного меню з меню переказу на іншу карту?" ||
            textBox1.Text == "Перейти до головного меню з меню переказу на номер телефону?")
            {
                File.Delete(inf.path_conf);
                Form_1_1 switch_form = new Form_1_1();
                inf.ToForm(switch_form, this);
            }
            else if (textBox1.Text == "Чи дійсно ви хочете завершити роботу?")
            {
                File.Delete(inf.path_conf);
                File.Delete(inf.path_mess);
                Application.Exit();
            }
        }
    }
}
