namespace HMI
{
    public partial class Form_1 : Form
    {
        Information inf = new Information();
        int i = 0;
        public Form_1()
        {
            InitializeComponent();
            string[] af = File.ReadAllLines(inf.path_debug);
            if (af[0][0] == 'i' && af[0][1] == ')')
            {
                if (af[0][3] == '0') timer1.Enabled = true;
                else if (af[0][3] == '1')
                {
                    timer1.Enabled = false;
                    panel1.Visible = true;
                    label2.Visible = false;
                }
            }
            textBox1.MaxLength = 4;  // можна вписувати максимум 4 символа
            File.Delete(inf.path_conf);
            File.Delete(inf.path_mess);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Information inf = new Information();

            if (textBox1.Text == "") return;
            if (Convert.ToInt32(textBox1.Text) == inf.password)
            {
                // перейти до головного меню
                Form_1_1 switch_form = new Form_1_1();
                inf.ToForm(switch_form, this);
            }
            else
            {
                // видати повідомдлення, що пін-код неправильний та повернутися в початковий стан
                inf.MessageToFile(inf.path_mess, "Не правильний пін-код");
               
                Form_1_1_8 form8 = new Form_1_1_8();
                inf.ToForm(form8, this);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;

            if (i >= 5)
            {
                timer1.Enabled = false;
                panel1.Visible = true;
                label2.Visible = false;
            }
        }
    }
}