using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static SchoolOlymp.CreateRasp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SchoolOlymp
{
    public partial class CreateRasp : Form
    {
        DataBase database = new DataBase();

        public CreateRasp()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            GetGroups();
            GetTrainer();
        }

        private void CreateRasp_Load(object sender, EventArgs e)
        {

        }

        public void GetGroups()
        {
            string grouopnamesql = $"select Id, Named from [Group]"; //запрос на выборку данных из БД
            SqlCommand command = new SqlCommand(grouopnamesql, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    ComboboxGroup comboboxGroup = new ComboboxGroup();
                    comboboxGroup.Text = name;
                    comboboxGroup.Value = id;
                    comboBox5.Items.Add(comboboxGroup);
                }
            }
            database.closeConnection();
        }
        public void GetTrainer()
        {
            string trainernamesql = $"select Id, SecondName from Trainer"; //запрос на выборку данных из БД
            SqlCommand command = new SqlCommand(trainernamesql, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    ComboboxTrainer comboboxTrainer = new ComboboxTrainer();
                    comboboxTrainer.Text = name;
                    comboboxTrainer.Value = id;
                    comboBox4.Items.Add(comboboxTrainer);
                }
            }
            database.closeConnection();
        }
        public class ComboboxGroup
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        public class ComboboxTrainer
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedGroupId = (int)((ComboboxGroup)comboBox5.SelectedItem).Value;
            int selectedTrainerId = (int)((ComboboxTrainer)comboBox4.SelectedItem).Value;
            string querry = $"Insert into Training (Date, TimeStart, TimeFinish, Class, GroupID, TrainerID) values ('{dateTimePicker1.Text}', '{comboBox1.Text}', '{comboBox2.Text}', '{comboBox3.Text}', '{selectedGroupId}', '{selectedTrainerId}')";
            SqlCommand command = new SqlCommand(querry, database.getConnection());
            database.openConnection();

            if (command.ExecuteNonQuery() == 1) //на заполненность полей
            {
                MessageBox.Show("Расписание добавлен", "Выполнено."); //успешная проверка
            }
            else //если поля не заполнены данными
            {
                MessageBox.Show("Не заполнены все поля"); //проверка не пройдена
            }
        }
        }
    }

