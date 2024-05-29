using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SchoolOlymp
{
    public partial class UserMain : Form
    {
        DataBase database = new DataBase();
        public int groupid;

        private List<System.Windows.Forms.Label> labels = new List<System.Windows.Forms.Label>();

        public UserMain()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            SqlDataAdapter adapter1 = new SqlDataAdapter();
            DataTable table1 = new DataTable();
            int IdUser = Data.id;
            string querry1 = $"select G.Named As GroupName, S.GroupId from Student S left join [Group] G on S.GroupId = g.Id where S.Id='{IdUser}';";
            SqlCommand command1 = new SqlCommand(querry1, database.getConnection());
            database.openConnection();
            SqlDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                label2.Text = reader.GetString(0);
                groupid = reader.GetInt32(1);
            }
            database.closeConnection();


            string querry2 = $"select A.Date AS Дата, A.TimeStart AS 'Время начала', A.TimeFinish AS 'Время конца', A.Class AS 'Кабинет', U.Name + U.SecondName AS 'Имя тренера' from Training A join Trainer U ON A.TrainerId=U.Id where A.Id='{groupid}'";
            SqlCommand command2 = new SqlCommand(querry2, database.getConnection());

            adapter1.SelectCommand = command2;
            adapter1.Fill(table1);
            dataGridView1.DataSource = table1;

            LoadDate();
        }
        private void LoadDate()
        {
            int IdUser = Data.id;
            string querry = $"select Discipline, Date, Overview from Achivments where StudentId='{IdUser}';";
            SqlCommand command = new SqlCommand(querry, database.getConnection());
            database.openConnection();
            SqlDataReader reader1 = command.ExecuteReader();
            int yPosition = 10; // Начальная позиция по оси Y
            int number = 1;
            while (reader1.Read())
            {
                System.Windows.Forms.Label labelNum = new System.Windows.Forms.Label();
                labelNum.Text = $"{number}";
                labelNum.Location = new Point(3, yPosition);
                labelNum.Font = new Font("Arial", 14, FontStyle.Bold);
                labelNum.MaximumSize = new Size(30, 0);
                labelNum.AutoSize = true;
                panel1.Controls.Add(labelNum);
                number++;

                System.Windows.Forms.Label labelDiscipline = new System.Windows.Forms.Label();
                labelDiscipline.Text = reader1.GetString(0);
                labelDiscipline.Location = new Point(78, yPosition);
                labelDiscipline.Font = new Font("Arial", 14, FontStyle.Bold);
                panel1.Controls.Add(labelDiscipline);

                System.Windows.Forms.Label labelDate = new System.Windows.Forms.Label();
                labelDate.Text = Convert.ToString(reader1[1]);
                labelDate.Location = new Point(203, yPosition);
                labelDate.Font = new Font("Arial", 13, FontStyle.Bold);
                panel1.Controls.Add(labelDate);

                System.Windows.Forms.Label labelOver = new System.Windows.Forms.Label();
                labelOver.Text = reader1.GetString(2);
                labelOver.Location = new Point(308, yPosition);
                labelOver.Font = new Font("Arial", 14, FontStyle.Bold);
                labelOver.MaximumSize = new Size(500, 0);
                labelOver.AutoSize = true;
                panel1.Controls.Add(labelOver);
                

                yPosition += labelOver.Height + 20;

           
            }
            database.closeConnection();

                //VScrollBar vScrollBar1 = new VScrollBar();
                //vScrollBar1.Dock = DockStyle.Right; // Прикрепляем к правой стороне формы
                //vScrollBar1.Minimum = 0;
                //vScrollBar1.Maximum = yPosition;
                //vScrollBar1.SmallChange = 1;
                //vScrollBar1.LargeChange = 10;
                //panel1.Controls.Add(vScrollBar1);
                //vScrollBar1_Scroll(vScrollBar1);
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
        }




        private void tabPage2_Click(object sender, EventArgs e)
        {
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserMain_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
