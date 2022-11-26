namespace HMI
{
    public partial class Form_1 : Form
    {
        Information inf = new Information();
        public Form_1()
        {
            InitializeComponent();
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
            // перейти до головного меню
            Information inf = new Information();

            if (textBox1.Text == "") return;
            if (Convert.ToInt32(textBox1.Text) == inf.password)
            {
                Form_1_1 switch_form = new Form_1_1();
                inf.ToForm(switch_form, this);
            }
            else
            {
                inf.MessageToFile(inf.path_mess, "Не правильний пін-код");
               
                Form_1_1_8 form8 = new Form_1_1_8();
                inf.ToForm(form8, this);
            }
        }
    }
}