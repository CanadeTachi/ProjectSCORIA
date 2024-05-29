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
    public partial class Autorization : Form
    {
        DataBase database = new DataBase();
        public Autorization()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            textBox2.PasswordChar = '*';
            textBox1.MaxLength = 50;//максимальная длина поля логина
            textBox2.MaxLength = 50;//максимальная длина поля пароль
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Login = textBox1.Text; //логин 
            var Password = textBox2.Text; //пароль
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string iduser = $"select ID from Student where Login = '{Login}' and Password = '{Password}' "; //запрос на выборку данных из БД
            SqlCommand comanduser = new SqlCommand(iduser, database.getConnection());
            database.openConnection();
            SqlDataReader reader = comanduser.ExecuteReader();
            while (reader.Read())
            {
                int post = reader.GetInt32(0);
                Data.id = post;
            }
            database.closeConnection();


            database.openConnection();
            string idtrainer = $"select ID from Trainer where Login = '{Login}' and Password = '{Password}' "; //запрос на выборку данных из БД
            SqlCommand comtrainer = new SqlCommand(idtrainer, database.getConnection());
            SqlDataReader reader1 = comtrainer.ExecuteReader();
            while (reader1.Read())
            {
                int post1 = reader1.GetInt32(0);
                Data.idtrainer = post1;
            }
            database.closeConnection();

           
            if (checkBox2.Checked == true)//проверка на точность данных с правами администрации
            {
                //запрос на выборку данных из БД с правами администрации
                string querry = $"select ID, Login, Password from Admin where Login ='{Login}' and Password = '{Password}'";
                SqlCommand command = new SqlCommand(querry, database.getConnection());

                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count == 1)//условие точности логина пароля приложения и БД
                {
                    MessageBox.Show("Вы вошли!", "Выполнено!", MessageBoxButtons.OK, MessageBoxIcon.Information);//успешная проверка
                    MenuManager managermenu = new MenuManager();
                    managermenu.ShowDialog();//открытие меню администрации
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует", "Безуспешно", MessageBoxButtons.OK, MessageBoxIcon.Information); //проверка не пройдена
                }
            }
            else if (checkBox1.Checked == true)// проверка на точность данных без прав администрации
            {
                string querry = $"select ID, Login, Password from Trainer where Login ='{Login}' and Password = '{Password}' "; //запрос на выборку данных из БД
                SqlCommand command = new SqlCommand(querry, database.getConnection());

                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count == 1) ////условие точности логина пароля приложения и БД
                {
                    MessageBox.Show("Вы вошли!", "Выполнено!", MessageBoxButtons.OK, MessageBoxIcon.Information); //успешная проверка
                    TrainerRasp formtrainer = new TrainerRasp();
                    formtrainer.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует", "Безуспешно", MessageBoxButtons.OK, MessageBoxIcon.Information);//проверка не пройдена
                }
            }
            else
            {
                string querry = $"select ID, Login, Password from Student where Login = '{Login}' and Password = '{Password}' "; //запрос на выборку данных из БД
                SqlCommand command = new SqlCommand(querry, database.getConnection());

                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count == 1) ////условие точности логина пароля приложения и БД
                {
                    MessageBox.Show("Вы вошли!", "Выполнено!", MessageBoxButtons.OK, MessageBoxIcon.Information); //успешная проверка
                    UserMain formmenu = new UserMain();
                    formmenu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует", "Безуспешно", MessageBoxButtons.OK, MessageBoxIcon.Information);//проверка не пройдена
                }

            }
        }

        private void Autorization_Load(object sender, EventArgs e)
        {

        }
    }
}
