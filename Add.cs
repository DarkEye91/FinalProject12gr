using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinalProject
{
    public partial class Add : Form
    {
        public string UserID { get; set; }
        public Add(string userid)
        {
            InitializeComponent();
            UserID = userid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAB109PC21\\SQLEXPRESS;Initial Catalog=RailwaySistema;Integrated Security=True";

            string query = "INSERT INTO Price (Price, DesFrom, DesTo, Date, availability) VALUES (@Price, @DesFrom, @DesTo, @Date, @ava)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Price", textBox1.Text);
                    command.Parameters.AddWithValue("@DesFrom", textBox3.Text);
                    command.Parameters.AddWithValue("@DesTo", textBox2.Text);
                    command.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                    command.Parameters.AddWithValue("@ava", comboBox1.Text);

                    command.ExecuteNonQuery();


                    MessageBox.Show("Successful add!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();



                }
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            bool containsNonNumeric = textBox1.Text.Any(c => !char.IsDigit(c));

            if (containsNonNumeric)
            {
                MessageBox.Show("Phone number not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
