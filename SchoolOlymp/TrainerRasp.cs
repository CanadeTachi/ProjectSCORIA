using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolOlymp
{
    public partial class TrainerRasp : Form
    {
        DataBase database = new DataBase();
        public int trainerId;
        public TrainerRasp()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            SqlDataAdapter adapter1 = new SqlDataAdapter();
            DataTable table1 = new DataTable();
            int Idtrainer = Data.idtrainer;
            string querry1 = $"select Name from Trainer where Id='{Idtrainer}';";
            SqlCommand command1 = new SqlCommand(querry1, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                label2.Text = reader.GetString(0);
            }
            database.closeConnection();

            string querry2 = $"select A.Date AS Дата, A.TimeStart AS 'Время начала', A.TimeFinish AS 'Время конца', A.Class AS 'Кабинет', U.Named AS 'Группа' from Training A join [Group] U ON A.TrainerId=U.Id where A.TrainerID='{Idtrainer}';";
            SqlCommand command2 = new SqlCommand(querry2, database.getConnection());

            adapter1.SelectCommand = command2;
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;

            string querry = $"select A.Id as 'Номер', A.Name as 'Имя', A.SecondName as 'Фамилия', U.Named AS 'Группа' from Student A join [Group] U ON GroupID=U.Id;";
            SqlCommand command = new SqlCommand(querry, database.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView2.DataSource = table;
        }

        private void TrainerRasp_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string num = textBox1.Text;
            string dis = comboBox1.Text;
            string usp = textBox2.Text;
            DateTime today = DateTime.Today;
            string qwe = $"Insert into Achivments (StudentId, Discipline, Date, Overview) values ('{num}', '{dis}', '{today.ToString("yyyy-MM-dd")}', '{usp}')";
            SqlCommand zxc = new SqlCommand(qwe, database.getConnection());
            database.openConnection();

            if (zxc.ExecuteNonQuery() == 1) //на заполненность полей
            {
                MessageBox.Show("Достижение зафискировано!", "Выполнено."); //успешная проверка
            }
            else //если поля не заполнены данными
            {
                MessageBox.Show("Не заполнены все поля"); //проверка не пройдена
            }

        }
    }
}
