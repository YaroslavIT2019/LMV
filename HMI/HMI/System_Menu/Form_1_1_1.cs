using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMI.System_Menu
{
    public partial class Form_1_1_1 : Form
    {
        Information inf = new Information();

        public Form_1_1_1()
        {
            InitializeComponent();
            textBox1.MaxLength = 4;  // можна вписувати максимум 4 символа
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
                textBox1.Select(4, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Information inf = new Information();

            // перейти до головного меню
            if (textBox1.Text == "") return;
            if (Convert.ToInt32(textBox1.Text) == inf.system_meny_password)
            {
                Form_1_1_1_1 form11 = new Form_1_1_1_1();
                inf.ToForm(form11, this);
            }
            else
            {
                inf.MessageToFile(inf.path_mess, "Не правильний пін-код для входу в системне меню");

                Form_1_1_8 form8 = new Form_1_1_8();
                inf.ToForm(form8, this);
            }
        }
    }
}
