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
    public partial class Form_1_1 : Form
    {
        Information inf = new Information();
        public Form_1_1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // перейти до операції перегляду балансу
            Operations.Form_1_1_2 form2 = new Operations.Form_1_1_2();
            inf.ToForm(form2, this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // перейти до операції зняття готівки з карти
            Operations.Form_1_1_3 form3 = new Operations.Form_1_1_3();
            inf.ToForm(form3, this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // перейти до операції переведення грошей на іншу карту
            Operations.Form_1_1_4 form4 = new Operations.Form_1_1_4();
            inf.ToForm(form4, this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // перейти до форми з підтвердженням щодо завершення роботи програми
            inf.MessageToFile(inf.path_conf, "Чи дійсно ви хочете завершити роботу?");

            Operations.Form_1_1_7 form7 = new Operations.Form_1_1_7();
            inf.ToForm(form7, this);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // перейти до операції поповнення номеру телефону
            Operations.Form_1_1_5 form5 = new Operations.Form_1_1_5();
            inf.ToForm(form5, this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // перейти до операції поповнення карти
            inf.MessageToFile(inf.path_mess, "Вкладіть до банкомату необхідну кількість грошей у гривнях");

            Form_1_1_8 form8 = new Form_1_1_8();
            inf.ToForm(form8, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // перейти до форми входу у системне меню
            System_Menu.Form_1_1_1 form1 = new System_Menu.Form_1_1_1();
            inf.ToForm(form1, this);
        }
    }
}
