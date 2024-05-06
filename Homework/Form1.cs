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
using System.Data.SQLite;

namespace Homework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //adding everything in datagrid
            List<Object> objectList = new List<Object>(100);
            SQLiteConnection connection = new SQLiteConnection("Integrated Security = SSPI; Data Source = libruary.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT  Id, Type, Name, Author, Year FROM objects";
            using (var rd1 = command.ExecuteReader())
            {
                while (rd1.Read())
                {
                    objectList.Add(new Object(rd1.GetInt32(0), rd1.GetString(1), rd1.GetString(2), rd1.GetString(3), rd1.GetInt32(4)));
                }
            }
            dataGridView1.DataSource = objectList;

            // Searching for number of books
            var command2 = connection.CreateCommand();
            command2.CommandText = @"SELECT COUNT(*) FROM objects WHERE Type = 'book'";
            int r = 0;
            using (var rd2 = command2.ExecuteReader())
            {
                while (rd2.Read())
                {
                    r = rd2.GetInt32(0);
                }
            }
            chart1.Series[0].Points.Add(r);

            // Searching for number of films
            var command3 = connection.CreateCommand();
            command3.CommandText = @"SELECT COUNT(*) FROM objects WHERE Type = 'film'";
            int r1 = 0;
            using (var rd3 = command3.ExecuteReader())
            {
                while (rd3.Read())
                {
                    r1 = rd3.GetInt32(0);
                }
            }
            // adding number of books and films to the pie chart(chart 1)
            chart1.Series[0].Points.Add(r1);
            chart1.Series[0].Points[0].Label = "books";
            chart1.Series[0].Points[1].Label = "film";

            connection.Close();
                       
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonInsert_Click(object sender, EventArgs e)
        {
            SQLiteConnection connection = new SQLiteConnection("Integrated Security = SSPI; Data Source = libruary.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = String.Format("INSERT INTO objects (Id, Type, Name, Author, Year) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", textBoxId.Text, textBoxType.Text, textBoxName.Text, textBoxAuthor.Text, textBoxYear.Text);
            command.ExecuteNonQuery();
            connection.Close();
        }


        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            SQLiteConnection connection = new SQLiteConnection("Integrated Security = SSPI; Data Source = libruary.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = String.Format("DELETE  FROM objects WHERE Id={0}", id);
            command.ExecuteNonQuery();
            connection.Close();

        }


        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<Object> objectList = new List<Object>(100);
            SQLiteConnection connection = new SQLiteConnection("Integrated Security = SSPI; Data Source = libruary.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = @"SELECT  Id, Type, Name, Author, Year FROM objects";
            using (var rd1 = command.ExecuteReader())
            {
                while (rd1.Read())
                {
                    objectList.Add(new Object(rd1.GetInt32(0), rd1.GetString(1), rd1.GetString(2), rd1.GetString(3), rd1.GetInt32(4)));
                }
            }
            dataGridView1.DataSource = objectList;

            chart1.Series[0].Points.Clear();

            // Searching for number of books
            var command2 = connection.CreateCommand();
            command2.CommandText = @"SELECT COUNT(*) FROM objects WHERE Type = 'book'";
            int r = 0;
            using (var rd2 = command2.ExecuteReader())
            {
                while (rd2.Read())
                {
                    r = rd2.GetInt32(0);
                }
            }
            chart1.Series[0].Points.Add(r);

            // Searching for number of films
            var command3 = connection.CreateCommand();
            command3.CommandText = @"SELECT COUNT(*) FROM objects WHERE Type = 'film'";
            int r1 = 0;
            using (var rd3 = command3.ExecuteReader())
            {
                while (rd3.Read())
                {
                    r1 = rd3.GetInt32(0);
                }
            }
            // adding number of books and films to the pie chart(chart 1)
            chart1.Series[0].Points.Add(r1);
            chart1.Series[0].Points[0].Label = "books";
            chart1.Series[0].Points[1].Label = "film";

            connection.Close();
        }
    }
}
