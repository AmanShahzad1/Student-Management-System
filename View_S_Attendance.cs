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

namespace DB_Final_Project
{
    public partial class View_S_Attendance : Form
    {
        public View_S_Attendance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student obj = new Student();
            this.Hide();
            obj.Show();
        }

        private void View_S_Attendance_Load(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
            {
                connection.Open();
                OleDbCommand getEmps = connection.CreateCommand();
                getEmps.CommandText = "SELECT tc.C_ID, tc.C_NAME COURSE FROM TEACHER_CLASS tc, CLASS_STUDENT cs, STUDENT s, USERS u, CURRENT_LOGIN cl WHERE tc.C_ID = cs.C_ID AND cs.S_ID = s.S_ID AND u.USERNAME = s.USERNAME AND u.USERNAME = cl.TEMP_USERNAME";
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
            using (OleDbConnection connection = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
            {
                connection.Open();
                OleDbCommand getEmps = connection.CreateCommand();
                getEmps.CommandText = "SELECT ar.S_ID Roll_Number, s.S_FName First_Name, s.S_LName Last_Name, ar.Total_Classes, ar.Attended_Classes, TRUNC((ar.Attended_Classes/ar.Total_Classes)*100) Percentage  FROM ATTENDANCE_REPORT ar, STUDENT s, CURRENT_LOGIN cl WHERE ar.S_ID = s.S_ID AND cl.TEMP_USERNAME = s.USERNAME AND C_ID = " + textBox1.Text + " ";
                getEmps.CommandType = CommandType.Text;
                OleDbDataReader empDR = getEmps.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(empDR);
                dataGridView2.DataSource = dt;
                connection.Close();
            }
        }
    }
}
