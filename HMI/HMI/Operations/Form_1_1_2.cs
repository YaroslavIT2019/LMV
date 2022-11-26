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
    public partial class Form_1_1_2 : Form
    {
        Information inf = new Information();
        Statistics stat = new Statistics();
        void Balance()
        {
            string[] af = File.ReadAllLines(inf.path);
            string a = "";

            for (int i = 0; i < af.Length; i++)
                if (af[i][0] == 'b' && af[i][1] == ')')
                    a = af[i];

            string s = a.Substring(3);
            decimal sum = Convert.ToDecimal(s);

            textBox1.Text = sum.ToString() + " грн";
        }

        public Form_1_1_2()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
            stat.SetStatistics(2, DateTime.Now);
            Balance();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_1_1 switch_form = new Form_1_1();
            inf.ToForm(switch_form, this);
        }
    }
}
