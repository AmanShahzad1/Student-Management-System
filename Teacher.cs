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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DB_Final_Project
{
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            View_Students obj = new View_Students();
            this.Hide();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            View_Class obj = new View_Class();
            this.Hide();
            obj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            View_Attendance obj = new View_Attendance();
            this.Hide();
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_Attendance obj = new Add_Attendance();
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
    }
}
