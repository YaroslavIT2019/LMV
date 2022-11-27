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
    public partial class Form_1_1_1_1 : Form
    {
        Statistics stat = new Statistics();
        Information inf = new Information();

        public Form_1_1_1_1()
        {
            InitializeComponent();
            this.Top = 10;
            this.Left = 300;
            stat.GetStatistics();
            Add_One();
            Add_Two();
            Add_Three();
        }

        void Add_One()
        {
            // виведення статистики операцій по типам
            Add_Row1("Перегляд балансу", stat.operation_112);
            Add_Row1("Зняття готівки", stat.operation_113);
            Add_Row1("Переказ на іншу карту", stat.operation_114);
            Add_Row1("Поповнення телефонного рахунку", stat.operation_115);
            Add_Row1("Поповнення балансу своєї карти", stat.operation_116);
        }
        void Add_Two()
        {
            // виведення статистики операцій по датам
            string[] af = File.ReadAllLines(stat.path_statistics);

            for (int i = 0; i < af.Length; i++)
            {
                if (af[i][0] == '2' && af[i][1] == ')' && af[i][2] == ' ')
                    Add_Row2("Перегляд балансу", af[i].Substring(3));
                else if (af[i][0] == '3' && af[i][1] == ')' && af[i][2] == ' ')
                    Add_Row2("Зняття готівки", af[i].Substring(3));
                else if (af[i][0] == '4' && af[i][1] == ')' && af[i][2] == ' ')
                    Add_Row2("Переказ на іншу карту", af[i].Substring(3));
                else if (af[i][0] == '5' && af[i][1] == ')' && af[i][2] == ' ')
                    Add_Row2("Поповнення телефонного рахунку", af[i].Substring(3));
                else if (af[i][0] == '6' && af[i][1] == ')' && af[i][2] == ' ')
                    Add_Row2("Поповнення балансу своєї карти", af[i].Substring(3));
            }
        }
        void Add_Three()
        {
            // виведення інформації щодо заповненості банкомату
            decimal balance_in_atm = 0;

            string[] af = File.ReadAllLines(inf.path_atm);
            balance_in_atm = Convert.ToInt32(af[0].Substring(3));

            label3.Text = (balance_in_atm / inf.max_in_atm) * 100 + "%";
        }

        void Add_Row1(string name_data, int amount_data)
        {
            ListViewItem lvi = new ListViewItem(name_data);
            lvi.SubItems.Add(amount_data.ToString());
            listView1.Items.Add(lvi);
        }

        void Add_Row2(string name_data, string date_data)
        {
            ListViewItem lvi = new ListViewItem(name_data);
            lvi.SubItems.Add(date_data);
            listView2.Items.Add(lvi);
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // перевірка обирання саме цієї інформації для виводу
            if (radioButton1.Checked == true)           panel2.Visible = true;
            else if (radioButton1.Checked == false)     panel2.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            // перевірка обирання саме цієї інформації для виводу
            if (radioButton3.Checked == true)           panel4.Visible = true;
            else if (radioButton3.Checked == false)     panel4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // перехід у головне меню
            Form_1_1 switch_form = new Form_1_1();
            inf.ToForm(switch_form, this);
        }
    }
}
