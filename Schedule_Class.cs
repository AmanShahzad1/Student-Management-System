using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DB_Final_Project
{
    public partial class Schedule_Class : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True");

        public Schedule_Class()
        {
            InitializeComponent();
        }

        private void Schedule_Class_Load(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
            {
                connection.Open();
                OleDbCommand getEmps = connection.CreateCommand();
                getEmps.CommandText = "SELECT * FROM TEACHER_CLASS ORDER BY C_ID";
                getEmps.CommandType = CommandType.Text;
                OleDbDataReader empDR = getEmps.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(empDR);
                dataGridView1.DataSource = dt;
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin obj = new Admin();
            this.Hide();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (OleDbConnection connection = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
            {
                connection.Open();
                string sql = "BEGIN SCHEDULE_CLASS_OF_COURSE( "+ textBox1.Text + ", TO_TIMESTAMP('"+ textBox2.Text + "', 'HH24:MI:SS'),TO_TIMESTAMP('"+ textBox3.Text +"', 'HH24:MI:SS'), '"+ textBox4.Text + "', '"+ textBox5.Text +"'); End;";
                OleDbCommand cmd = new OleDbCommand(sql, connection);
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show("Data inserted successfully");
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
