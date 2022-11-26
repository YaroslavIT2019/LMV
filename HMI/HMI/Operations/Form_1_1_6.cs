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
    public partial class Form_1_1_6 : Form
    {
        Information inf = new Information();
        Statistics stat = new Statistics();

        decimal balance = 0;
        decimal balance_in_atm = 0;

        string[] af;
        string[] af_atm;
        void Balance()
        {
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

        public Form_1_1_6()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
            Random rnd = new Random();
            decimal value = rnd.Next(500, 10001);
            textBox1.Text = value.ToString();
            Balance();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Information inf = new Information();

            if (Convert.ToDecimal(textBox1.Text) + balance_in_atm > inf.max_in_atm)
            {
                inf.MessageToFile(inf.path_mess, "Банкомат переповнено. Не забудьте забрати гроші!");

                Form_1_1_8 form8 = new Form_1_1_8();
                inf.ToForm(form8, this);
            }
            else
            {
                stat.SetStatistics(6, DateTime.Now);
                balance = Convert.ToDecimal(textBox1.Text) + balance;
                balance_in_atm = Convert.ToDecimal(textBox1.Text) + balance_in_atm;
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

                inf.MessageToFile(inf.path_mess, "Баланс карти успішно поповнено");

                Form_1_1_8 form8 = new Form_1_1_8();
                inf.ToForm(form8, this);
            }
        }
    }
}
