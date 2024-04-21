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
    public partial class Add_StudentClass : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True");

        public Add_StudentClass()
        {
            InitializeComponent();
        }

        private void Add_StudentClass_Load(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
            {
                connection.Open();
                OleDbCommand getEmps = connection.CreateCommand();
                getEmps.CommandText = "SELECT S_ID, S_FNAME, S_LNAME FROM STUDENT ORDER BY S_ID";
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
            Add_Class obj = new Add_Class();
            this.Hide();
            obj.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (OleDbConnection connection = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
            {
                connection.Open();

                string sql = "DECLARE TEMP NUMBER; BEGIN SELECT MAX(C_ID) INTO TEMP FROM TEACHER_CLASS; ADD_STUDENT_TO_CLASS_OF_COURSE( TEMP,'" + textBox1.Text + "'); INSERT INTO ATTENDANCE VALUES( TEMP,'" + textBox1.Text + "', '-');  INSERT INTO ATTENDANCE_REPORT VALUES( TEMP,'" + textBox1.Text + "', 0, 0); End;";
                OleDbCommand cmd = new OleDbCommand(sql, connection);
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show("STUDENT inserted successfully");

            }
        }
    }
}
