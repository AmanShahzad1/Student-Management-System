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
using System.Windows.Forms.VisualStyles;

namespace DB_Final_Project
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void Student_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            View_S_CS obj = new View_S_CS();
            this.Hide();
            obj.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
            {
                connection.Open();

                string sql = "BEGIN DELETE FROM CURRENT_LOGIN; End;";
                OleDbCommand cmd = new OleDbCommand(sql, connection);
                int rows = cmd.ExecuteNonQuery();
            }
            SMS_Login obj = new SMS_Login();
            this.Hide();
            obj.Show();
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            View_S_Attendance obj = new View_S_Attendance();
            this.Hide();
            obj.Show();
        }
    }
}
