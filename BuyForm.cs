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

namespace FinalProject
{
    public partial class BuyForm : Form
    {
        public string Availability { get; set; }
        public int TicketID { get; set; }
        public string UserID { get; set; }
        public string Price { get; set; }
        public string DesFrom { get; set; }
        public string DesTo { get; set; }
        public string Date { get; set; }

        public BuyForm(int ticketid, string userID, string price, string desFrom, string desTo, string date, string ava)
        {
            InitializeComponent();
            TicketID = ticketid;
            UserID = userID;
            Price = price;
            DesFrom = desFrom;
            DesTo = desTo;
            Date = date;
            Availability = ava;
            if (UserID == "1")
            {
                button1.Text = "Update";
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                dateTimePicker1.Enabled = true;
                textBox4.ReadOnly = false;
                label6.Text = "Update Ticket";
                comboBox1.Text = ava;
            }
            else
            {
                comboBox1.Visible = false;
                comboBox1.Enabled = false;
                label5.Visible = false;
                label5.Enabled = false;
            }

        }

        private void BuyForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Price;
            textBox2.Text = DesFrom;
            textBox4.Text = DesTo;
            dateTimePicker1.Value = DateTime.Parse(Date);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserID == "1")
            {
                string connectionString = "Data Source=LAB109PC21\\SQLEXPRESS;Initial Catalog=RailwaySistema;Integrated Security=True";

                string query = "UPDATE Price SET Price = @Price, DesFrom = @DesF, DesTo = @DesT, Date = @Date, availability = @ava WHERE TicketID = @TI";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Price", textBox1.Text);
                        command.Parameters.AddWithValue("@DesF", textBox2.Text);
                        command.Parameters.AddWithValue("@DesT", textBox4.Text);
                        command.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                        command.Parameters.AddWithValue("@ava", comboBox1.Text);
                        command.Parameters.AddWithValue("@TI", TicketID);


                        command.ExecuteNonQuery();


                        MessageBox.Show("Successful Update!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
            }
            else
            {
                string connectionString = "Data Source=LAB109PC21\\SQLEXPRESS;Initial Catalog=RailwaySistema;Integrated Security=True";

                string query = "INSERT INTO Auth (UserID, TicketID) VALUES (@UserID, @TicketID)";
                string updateQuery = "UPDATE Price SET availability = 'not free' WHERE TicketID = @TicketID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            command.Parameters.AddWithValue("@TicketID", TicketID);
                            command.Parameters.AddWithValue("@UserID", UserID);
                            updateCommand.Parameters.AddWithValue("@TicketID", TicketID);

                            command.ExecuteNonQuery();
                            updateCommand.ExecuteNonQuery();

                            MessageBox.Show("Successful payment!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
