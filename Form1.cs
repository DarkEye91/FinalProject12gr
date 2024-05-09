using Microsoft.VisualBasic.Logging;
using System.Data.SqlClient;
using System;
using System.Text;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Form1 : Form
    {

        SqlConnection cn;
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.ImageLocation = @"H:\Informatics 12 grade\FinalProject\vlak.jpg";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=LAB109PC21\SQLEXPRESS; Initial Catalog=RailwaySistema; Integrated Security=True;");
            cn.Open();

            if (textBox2.Text != string.Empty || textBox3.Text != string.Empty)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    SqlCommand cmd = new SqlCommand("select * from dbo.Users where Username='" + textBox1.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        StringBuilder builder = new StringBuilder();
                        Enumerable
                           .Range(65, 26)
                            .Select(e => ((char)e).ToString())
                            .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                            .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                            .OrderBy(e => Guid.NewGuid())
                            .Take(11)
                            .ToList().ForEach(e => builder.Append(e));
                        string id = builder.ToString();

                        dr.Close();

                        cmd = new SqlCommand("insert into dbo.Users values(@UserID, @Username, @Password, @email, @phone, @birthday)", cn);
                        cmd.Parameters.AddWithValue("@UserID", id);
                        cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                        cmd.Parameters.AddWithValue("@email", textBox5.Text);
                        cmd.Parameters.AddWithValue("@phone", textBox4.Text);
                        cmd.Parameters.AddWithValue("@birthday", dateTimePicker1.Value);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Your Account is created. Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        LogIN login = new LogIN();
                        login.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label3.Show();
            label4.Show();
            label5.Show();

            if (textBox2.Text.Any(char.IsUpper))
                label4.ForeColor = Color.Green;
            else
                label4.ForeColor = Color.Red;

            if (textBox2.Text.Any(char.IsNumber))
                label5.ForeColor = Color.Green;
            else
                label5.ForeColor = Color.Red;

            if (textBox2.Text.Length >= 5)
                label3.ForeColor = Color.Green;
            else
                label3.ForeColor = Color.Red;
        }

        private void textBox1_Validating_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textBox1.Text.Length < 5 && textBox1.Text.Length != 0)
            {
                MessageBox.Show("Sorry, username should be at least 5 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogIN welcome = new LogIN();
            welcome.Show();
            this.Hide();
        }

        private void textBox4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (string.IsNullOrEmpty(email))
                return false;

            Regex regex = new Regex(emailPattern);
            return regex.IsMatch(email);
        }



        private void textBox5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (!IsValidEmail(textBox5.Text))
            {
                MessageBox.Show("Email not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox4_Validating_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool containsNonNumeric = textBox4.Text.Any(c => !char.IsDigit(c));

            if (containsNonNumeric)
            {
                MessageBox.Show("Phone number not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}