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
using System.Security.Cryptography;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DB_Final_Project
{
    public partial class SMS_Login : Form
    {
        public SMS_Login()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True");

        private void SMS_Login_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hashedPassword = HashPassword(password);
            string role = string.Empty;

            using (OleDbConnection connection = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
            {
                connection.Open();
                string sql = "SELECT Role FROM Users WHERE Username=? AND Password=?";
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("username", textBox1.Text);
                    cmd.Parameters.AddWithValue("password", textBox2.Text);
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            role = dr["Role"].ToString();
                        }
                    }
                }
            }


            if (!string.IsNullOrEmpty(role))
            {
                switch (role)
                {
                    case "admin":
                        Admin obj1 = new Admin();
                        this.Hide();
                        obj1.Show();
                        break;
                    case "teacher":
                        // Show teacher form

                        using (OleDbConnection connection = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
                        {
                            connection.Open();

                            string sql = "BEGIN INSERT INTO CURRENT_LOGIN VALUES('" + textBox1.Text + "'); End;";
                            OleDbCommand cmd = new OleDbCommand(sql, connection);
                            int rows = cmd.ExecuteNonQuery();
                        }
                        Teacher obj2 = new Teacher();
                        this.Hide();
                        obj2.Show();
                        break;
                    case "student":
                        // Show student form
                        using (OleDbConnection connection = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=XE;Persist Security Info=True;User ID=21F-9156;Password=amanj1;Unicode=True"))
                        {
                            connection.Open();

                            string sql = "BEGIN INSERT INTO CURRENT_LOGIN VALUES('" + textBox1.Text + "'); End;";
                            OleDbCommand cmd = new OleDbCommand(sql, connection);
                            int rows = cmd.ExecuteNonQuery();
                        }
                        Student obj3 = new Student();
                        this.Hide();
                        obj3.Show();
                        break;
                    default:
                        MessageBox.Show("Invalid role.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string hashedPassword = Convert.ToBase64String(hashBytes);

            return hashedPassword;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
