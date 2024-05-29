using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolOlymp
{
    public partial class MenuManager : Form
    {
        DataBase database = new DataBase();
        public MenuManager()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            string querry2 = $"SELECT s.Id, s.Date, s.TimeStart, s.TimeFinish, s.Class, g.Named, t.Name, t.SecondName FROM Training s INNER JOIN[Group] g ON s.GroupID = g.ID INNER JOIN Trainer t ON s.TrainerID = t.ID;";
            SqlCommand command2 = new SqlCommand(querry2, database.getConnection());
            SqlDataAdapter adapter2 = new SqlDataAdapter();
            DataTable table2 = new DataTable();
            adapter2.SelectCommand = command2;
            adapter2.Fill(table2);
            dataGridView1.DataSource = table2;

            string querry3 = $"Select Id, Name as Имя, SecondName as Фамилия, Sex as Пол, Date as Дата, Email as Почта, Login as Логин, Password as Пароль from Trainer;";
            SqlCommand command3 = new SqlCommand(querry3, database.getConnection());
            SqlDataAdapter adapter3 = new SqlDataAdapter();
            DataTable table3 = new DataTable();
            adapter3.SelectCommand = command3;
            adapter3.Fill(table3);
            dataGridView2.DataSource = table3;

            string querry4 = $"SELECT s.Id, s.Name as Имя, s.SecondName as Фамилия, g.Named as Группа, s.Sex as Пол, s.Date as Дата, s.Email as Почта, s.Login as Логин, s.Password as Пароль FROM Student s INNER JOIN[Group] g On s.GroupId=g.ID;";
            SqlCommand command4 = new SqlCommand(querry4, database.getConnection());
            SqlDataAdapter adapter4 = new SqlDataAdapter();
            DataTable table4 = new DataTable();
            adapter4.SelectCommand = command4;
            adapter4.Fill(table4);
            dataGridView5.DataSource = table4;


        }
        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string querry3 = $"Select Id, Name, SecondName, Sex, Date, Email, Login, Password from Trainer;";
            SqlCommand command3 = new SqlCommand(querry3, database.getConnection());
            SqlDataAdapter adapter3 = new SqlDataAdapter();
            DataTable table3 = new DataTable();
            adapter3.SelectCommand = command3;
            adapter3.Fill(table3);
            dataGridView2.DataSource = table3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string dr = dateTimePicker1.Text;
            string sex = comboBox1.Text;
            string email = textBox4.Text;
            string qwe = $"Insert into Trainer (Name, SecondName, Date, Sex, Email) values ('{name}', '{surname}', '{dr}', '{sex}', '{email}')";
            SqlCommand zxc = new SqlCommand(qwe, database.getConnection());
            database.openConnection();

            if (zxc.ExecuteNonQuery() == 1) //на заполненность полей
            {
                MessageBox.Show("Тренер добавлен", "Выполнено."); //успешная проверка
            }
            else //если поля не заполнены данными
            {
                MessageBox.Show("Не заполнены все поля"); //проверка не пройдена
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                string qwe = $"Update Trainer SET Login='{textBox7.Text}', Password='{textBox8.Text}' WHERE Id='{textBox5.Text}'";
                SqlCommand zxc = new SqlCommand(qwe, database.getConnection());
                database.openConnection();
                if (zxc.ExecuteNonQuery() == 1) //на заполненность полей
                {
                    MessageBox.Show("Данные изменены", "Выполнено."); //успешная проверка
                }
                else //если поля не заполнены данными
                {
                    MessageBox.Show("Не заполнены логин и пароль"); //проверка не пройдена
                }
            }
            else 
            {
                string qwe = $"Update Trainer SET Email ='{textBox6.Text}', Login='{textBox7.Text}', Password='{textBox8.Text}' WHERE Id='{textBox5.Text}'";
                SqlCommand zxc = new SqlCommand(qwe, database.getConnection());
                database.openConnection();
                if (zxc.ExecuteNonQuery() == 1) //на заполненность полей
                {
                    MessageBox.Show("Данные изменены", "Выполнено."); //успешная проверка
                }
                else //если поля не заполнены данными
                {
                    MessageBox.Show("Не заполнены логин и пароль"); //проверка не пройдена
                }
            }
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string querry4 = $"SELECT s.Id, s.Name as Имя, s.SecondName as Фамилия, g.Named as Группа, s.Sex as Пол, s.Date as Дата, s.Email as Почта, s.Login as Логин, s.Password as Пароль FROM Student s INNER JOIN[Group] g On s.GroupId=g.ID;";
            SqlCommand command4 = new SqlCommand(querry4, database.getConnection());
            SqlDataAdapter adapter4 = new SqlDataAdapter();
            DataTable table4 = new DataTable();
            adapter4.SelectCommand = command4;
            adapter4.Fill(table4);
            dataGridView5.DataSource = table4;
        }

        private void button4_Click(object sender, EventArgs e)
        {
        
            int value=0;
            switch (comboBox3.Text)
            {
                case "A":
                value = 1;
                break;
                case "B":
                value = 2;
                break;
                case "C":
                value = 3;
                break;
            }
            string qwe = $"Insert into Student (Name, SecondName, Date, Sex, Email, GroupID) values ('{textBox14.Text}', '{textBox13.Text}', '{dateTimePicker2.Text}', '{comboBox2.Text}', '{textBox12.Text}', '{value}')";
            SqlCommand zxc = new SqlCommand(qwe, database.getConnection());
            database.openConnection();

            if (zxc.ExecuteNonQuery() == 1) //на заполненность полей
            {
                MessageBox.Show("Ученик добавлен", "Выполнено."); //успешная проверка
            }
            else //если поля не заполнены данными
            {
                MessageBox.Show("Не заполнены все поля"); //проверка не пройдена
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = textBox11.Text;
            string email = textBox10.Text;
            string login = textBox9.Text;
            string password = textBox3.Text;
            if (string.IsNullOrEmpty(textBox10.Text))
            {
                string qwe = $"Update Student SET Login='{login}', Password='{password}' WHERE Id='{id}'";
                SqlCommand zxc = new SqlCommand(qwe, database.getConnection());
                database.openConnection();
                if (zxc.ExecuteNonQuery() == 1) //на заполненность полей
                {
                    MessageBox.Show("Данные изменены", "Выполнено."); //успешная проверка
                }
                else //если поля не заполнены данными
                {
                    MessageBox.Show("Не заполнены логин и пароль"); //проверка не пройдена
                }
            }
            else
            {
                string qwe = $"Update Student SET Email ='{email}', Login='{login}', Password='{password}' WHERE Id='{id}'";
                SqlCommand zxc = new SqlCommand(qwe, database.getConnection());
                database.openConnection();
                if (zxc.ExecuteNonQuery() == 1) //на заполненность полей
                {
                    MessageBox.Show("Данные изменены", "Выполнено."); //успешная проверка
                }
                else //если поля не заполнены данными
                {
                    MessageBox.Show("Не заполнены логин и пароль"); //проверка не пройдена
                }
            }
        }
    }
}
