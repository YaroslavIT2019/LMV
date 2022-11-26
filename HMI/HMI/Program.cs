namespace HMI
{
    class Information
    {
        public int password = 1111;
        public int system_meny_password = 2222;
        public decimal max_in_atm = 1000000;

        public string path = @"C:\ATM\Users.txt";
        public string path_mess = @"C:\ATM\Message.txt";
        public string path_conf = @"C:\ATM\Confirmation.txt";
        public string path_atm = @"C:\ATM\ATM.txt";

        public void ToForm(Form form, Form thisform)
        {
            form.Show();
            thisform.Hide();
        }

        public void MessageToFile(string path_temp, string mess)
        {
            using (FileStream file = new FileStream(path_temp, FileMode.OpenOrCreate))
            using (StreamWriter stream = new StreamWriter(file))
                stream.WriteLine(mess);
        }
    }

    class Statistics
    {
        public string path_statistics = @"C:\ATM\Statistics.txt";

        public int operation_112 = 0;
        public int operation_113 = 0;
        public int operation_114 = 0;
        public int operation_115 = 0;
        public int operation_116 = 0;

        public void GetStatistics()
        {
            string[] af = File.ReadAllLines(path_statistics);

            for (int i = 0; i < af.Length; i++)
            {
                if (af[i][0] == '2' && af[i][1] == ')' && af[i][2] == ' ')
                    operation_112++;
                else if (af[i][0] == '3' && af[i][1] == ')' && af[i][2] == ' ')
                    operation_113++;
                else if (af[i][0] == '4' && af[i][1] == ')' && af[i][2] == ' ')
                    operation_114++;
                else if (af[i][0] == '5' && af[i][1] == ')' && af[i][2] == ' ')
                    operation_115++;
                else if (af[i][0] == '6' && af[i][1] == ')' && af[i][2] == ' ')
                    operation_116++;
            }
        }

        public void SetStatistics(int num, DateTime dt)
        {
            using (FileStream file = new FileStream(path_statistics, FileMode.Append))
            using (StreamWriter stream = new StreamWriter(file))
            {
                stream.WriteLine(num + ") " + dt.ToString());
            }
        }
    }

    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form_1());
        }
    }
}