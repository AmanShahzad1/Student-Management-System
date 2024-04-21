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

namespace DB_Final_Project
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_teacher obj = new Add_teacher();
            this.Hide();
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_student obj = new Add_student();    
            this.Hide();    
            obj.Show(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Admin obj = new Add_Admin();    
            this.Hide();    
            obj.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Update_teacher obj = new Update_teacher();
            this.Hide();
            obj.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Update_student obj = new Update_student();
            this.Hide();
            obj.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Add_Class obj = new Add_Class();
            this.Hide();
            obj.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Class_list obj = new Class_list();
            this.Hide();
            obj.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Class_Student obj = new Class_Student();
            this.Hide();
            obj.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Schedule_Class obj = new Schedule_Class();
            this.Hide();
            obj.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            View_Schedule obj = new View_Schedule();
            this.Hide();
            obj.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SMS_Login obj = new SMS_Login();
            this.Hide();
            obj.Show();
        }
    }
}
