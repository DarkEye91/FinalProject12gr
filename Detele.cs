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
    public partial class Detele : Form
    {
        public int TicketID { get; set; }
        public string UserID { get; set; }
        public string Price { get; set; }
        public string DesFrom { get; set; }
        public string DesTo { get; set; }
        public string Date { get; set; }

        public Detele(int ticketid, string userID, string price, string desFrom, string desTo, string date)
        {
            InitializeComponent();
            TicketID = ticketid;
            UserID = userID;
            Price = price;
            DesFrom = desFrom;
            DesTo = desTo;
            Date = date;
            if (userID != "1")
            {
                label2.Text = "Remove Ticket";
                button1.Text = "Remove";
            }
        }

        private void Detele_Load(object sender, EventArgs e)
        {
            label1.Text = $"Ticket number: {TicketID}";
            textBox1.Text = Price;
            textBox2.Text = DesFrom;
            textBox3.Text = Date;
            textBox4.Text = DesTo;
        }

        private void RemoveEntry(int ticketID)
        {
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAB109PC21\SQLEXPRESS; Initial Catalog=RailwaySistema; Integrated Security=True;"))
            {
                sqlCon.Open();
                string query = "DELETE FROM Auth WHERE TicketID = @TicketID";
                string updateQuery = "UPDATE Price SET availability = 'free' WHERE TicketID = @TicketID";

                using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                {
                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@TicketID", ticketID);
                        updateCmd.Parameters.AddWithValue("@TicketID", ticketID);

                        cmd.ExecuteNonQuery();
                        updateCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void DeleteEntry(int ticketID)
        {
            RemoveEntry(ticketID);
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAB109PC21\SQLEXPRESS; Initial Catalog=RailwaySistema; Integrated Security=True;"))
            {
                sqlCon.Open();
                string query = "DELETE FROM Price WHERE TicketID = @TicketID";

                using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@TicketID", ticketID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserID == "1")
            {
                DialogResult result = MessageBox.Show("Are you sure you want to remove the selected ticket?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DeleteEntry(TicketID);
                        MessageBox.Show("Successful Deletion!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting entry: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                DialogResult result2 = MessageBox.Show("Are you sure you want to remove the selected ticket?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result2 == DialogResult.Yes)
                {
                    try
                    {
                        RemoveEntry(TicketID);
                        MessageBox.Show("Successful Removal!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error removing entry: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
    }
}

