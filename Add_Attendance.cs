using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DB_Final_Project
{
    public partial class Add_Attendance : Form
    {
        public Add_Attendance()
        {
            InitializeComponent();
        }

        private void Add_Attendance_Load(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
            {
                connection.Open();
                OleDbCommand getEmps = connection.CreateCommand();
                getEmps.CommandText = "SELECT tc.C_ID, tc.C_NAME COURSE FROM TEACHER_CLASS tc, TEACHER t, USERS u, CURRENT_LOGIN cl WHERE tc.T_ID = t.T_ID AND t.USERNAME = u.USERNAME AND u.USERNAME = cl.TEMP_USERNAME";
                getEmps.CommandType = CommandType.Text;
                OleDbDataReader empDR = getEmps.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(empDR);
                dataGridView1.DataSource = dt;
                connection.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
            {
                connection.Open();
                OleDbCommand getEmps = connection.CreateCommand();
                getEmps.CommandText = "SELECT * FROM ATTENDANCE WHERE C_ID = " + textBox1.Text + "";
                getEmps.CommandType = CommandType.Text;
                OleDbDataReader empDR = getEmps.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(empDR);
                dataGridView2.DataSource = dt;
                connection.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
            {
                connection.Open();
                string sql = "BEGIN UPDTE_REPORT_ATT("+ textBox1.Text + ", "+ textBox2.Text + ", '"+ comboBox1.Text +"'); END; ";
                OleDbCommand cmd = new OleDbCommand(sql, connection);
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show("Attendance submitted successfully");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
            {
                connection.Open();
                string sql = "BEGIN UPDATE ATTENDANCE SET STATUS = '"+ comboBox1.Text + "' WHERE S_ID = '"+ textBox2.Text +"'; END;";
                OleDbCommand cmd = new OleDbCommand(sql, connection);
                int rows = cmd.ExecuteNonQuery();
                using (OleDbConnection con = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
                {
                    con.Open();
                    OleDbCommand getEmps = connection.CreateCommand();
                    getEmps.CommandText = "SELECT * FROM ATTENDANCE WHERE C_ID = " + textBox1.Text + "";
                    getEmps.CommandType = CommandType.Text;
                    OleDbDataReader empDR = getEmps.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(empDR);
                    dataGridView2.DataSource = dt;
                    con.Close();
                }

            }
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Teacher obj = new Teacher();
            this.Hide();
            obj.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
