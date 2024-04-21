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
using System.Security.Cryptography.X509Certificates;

namespace DB_Final_Project
{
   
    public partial class Add_Class : Form
    {
        int value;
        OleDbConnection con = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True");

        public Add_Class()
        {
            InitializeComponent();
        }

        private void Add_Class_Load(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
            {
                connection.Open();
                OleDbCommand getEmps = connection.CreateCommand();
                getEmps.CommandText = "SELECT T_ID, T_FNAME, T_LNAME FROM TEACHER ORDER BY T_ID";
                getEmps.CommandType = CommandType.Text;
                OleDbDataReader empDR = getEmps.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(empDR);
                dataGridView1.DataSource = dt;
                connection.Close();
            }
            using (OleDbConnection connection = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
            {
                connection.Open();
                OleDbCommand getEmps = connection.CreateCommand();
                getEmps.CommandText = "SELECT * FROM TEACHER_CLASS ORDER BY C_ID";
                getEmps.CommandType = CommandType.Text;
                OleDbDataReader empDR = getEmps.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(empDR);
                dataGridView2.DataSource = dt;
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (OleDbConnection connection = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
            {
                connection.Open();
                
                string sql = "BEGIN ADD_CLASS_OF_COURSE( '" + textBox1.Text + "','" + textBox2.Text +"'); End;";
                OleDbCommand cmd = new OleDbCommand(sql, connection);
                int rows = cmd.ExecuteNonQuery();
           
                Add_StudentClass obj = new Add_StudentClass();
            
                obj.Show();
                this.Hide();
                

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin obj = new Admin();
            this.Hide();
            obj.Show();
        }
    }
}
