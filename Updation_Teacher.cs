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
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DB_Final_Project
{
    public partial class Updation_Teacher : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True");
        public Updation_Teacher()
        {
            InitializeComponent();
        }

        private void Updation_Teacher_Load(object sender, EventArgs e)
        {
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
            {
                connection.Open();
                OleDbCommand getEmps = connection.CreateCommand();
                getEmps.CommandText = "SELECT * FROM TEACHER WHERE T_ID = '" + textBox1.Text + "'";
                getEmps.CommandType = CommandType.Text;
                OleDbDataReader empDR = getEmps.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(empDR);
                dataGridView1.DataSource = dt;
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string temp2 = textBox2.Text;
            string temp3 = textBox3.Text;
            string temp4 = textBox4.Text;
            string temp5 = textBox5.Text;
            string temp6 = textBox6.Text;
            string temp8 = textBox8.Text;
            string temp7 = textBox7.Text;
            using (OleDbConnection connection = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
            {
                connection.Open();
                if (temp2 != "")
                {
                    string sql = "BEGIN UPDATE TEACHER SET T_FNAME = '"+ textBox2.Text + "' WHERE T_ID = "+ textBox1.Text + "; End;";
                    OleDbCommand cmd = new OleDbCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                }
                if (temp3 != "")
                {
                    string sql = "BEGIN UPDATE TEACHER SET T_LNAME = '" + textBox3.Text + "' WHERE T_ID = " + textBox1.Text + "; End;";
                    OleDbCommand cmd = new OleDbCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                }
                if (temp4 != "")
                {
                    string sql = "BEGIN UPDATE TEACHER SET USERNAME = '" + textBox4.Text + "' WHERE T_ID = " + textBox1.Text + ";END;";
                    OleDbCommand cmd = new OleDbCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                }
                if (temp5 != "")
                {
                    string sql = "BEGIN UPDATE TEACHER SET T_EMAIL = '" + textBox5.Text + "' WHERE T_ID = " + textBox1.Text + "; End;";
                    OleDbCommand cmd = new OleDbCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                }
                if (temp6 != "")
                {
                    string sql = "BEGIN UPDATE TEACHER_CONTACT SET T_CONTACT = '" + textBox6.Text + "' WHERE T_ID = " + textBox1.Text + "; End;";
                    OleDbCommand cmd = new OleDbCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                }
                if (temp7 != "")
                {
                    string sql = "BEGIN UPDATE TEACHER SET T_ADDRESS = '" + textBox7.Text + "' WHERE T_ID = " + textBox1.Text + "; End;";
                    OleDbCommand cmd = new OleDbCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                }
                if (temp8 != "")
                {
                    string sql = "BEGIN UPDATE TEACHER SET T_CITY = '" + textBox8.Text + "' WHERE T_ID = " + textBox1.Text + "; End;";
                    OleDbCommand cmd = new OleDbCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Data inserted successfully");
                Update_teacher obj = new Update_teacher();
                this.Hide();
                obj.Show();
            }
            
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Update_teacher obj = new Update_teacher();
            this.Hide();
            obj.Show();
        }
    }
}
