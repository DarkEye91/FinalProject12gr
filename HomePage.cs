using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class HomePage : Form
    {

        public string UserID { get; set; }

        private bool labelsVisible = false;

        public HomePage(string userid)
        {
            InitializeComponent();
            UserID = userid;
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            labelsVisible = false;

            if (userid != "1")
            {
                pictureBox1.ImageLocation = @"H:\Informatics 12 grade\FinalProject\vlak2.jpg";
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                button5.Visible = false;
                button5.Enabled = false;
            }
            else
            {
                BackColor = Color.SlateGray;
                label1.Text = "Admin Info:";
                button2.Visible = false;
                button2.Enabled = false;
                button5.Visible = true;
                button5.Enabled = true;
            }

        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        public void LoadDataIntoDataGridView()
        {
            if (UserID != "1")
            {
                try
                {
                    using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAB109PC21\SQLEXPRESS; Initial Catalog=RailwaySistema; Integrated Security=True;"))
                    {
                        sqlCon.Open();
                        string query = @"SELECT * 
                    FROM Price 
                    WHERE availability='free' 
                    AND Price.TicketID NOT IN (SELECT TicketID FROM Auth WHERE UserID=@U)";
                        SqlCommand cmd = new SqlCommand(query, sqlCon);
                        cmd.Parameters.AddWithValue("@U", UserID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            dataGridView1.DataSource = ds.Tables.Count > 0 ? ds.Tables[0] : null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                try
                {
                    using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAB109PC21\SQLEXPRESS; Initial Catalog=RailwaySistema; Integrated Security=True;"))
                    {
                        sqlCon.Open();
                        string query = "SELECT * FROM Price";
                        SqlCommand cmd = new SqlCommand(query, sqlCon);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            dataGridView1.DataSource = ds.Tables.Count > 0 ? ds.Tables[0] : null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (UserID != "1")
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    int ticketid = Convert.ToInt32(row.Cells["TicketID"].Value);
                    string price = row.Cells["Price"].Value.ToString();
                    string desFrom = row.Cells["DesFrom"].Value.ToString();
                    string desTo = row.Cells["DesTo"].Value.ToString();
                    string date = row.Cells["Date"].Value.ToString();

                    BuyForm detailsForm = new BuyForm(ticketid, UserID, price, desFrom, desTo, date, "");
                    detailsForm.ShowDialog();
                }
            }
            else if (UserID == "1")
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    DialogResult result = MessageBox.Show("Do you want to delete this row?", "Action Selection", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {


                        int ticketid = Convert.ToInt32(row.Cells["TicketID"].Value);
                        string price = row.Cells["Price"].Value.ToString();
                        string desFrom = row.Cells["DesFrom"].Value.ToString();
                        string desTo = row.Cells["DesTo"].Value.ToString();
                        string date = row.Cells["Date"].Value.ToString();
                        Detele c = new Detele(ticketid, UserID, price, desFrom, desTo, date);
                        c.ShowDialog();
                    }
                    else
                    {
                        DialogResult result1 = MessageBox.Show("Do you want to update this row?", "Action Selection", MessageBoxButtons.YesNo);
                        if (result1 == DialogResult.Yes)
                        {
                            int ticketid = Convert.ToInt32(row.Cells["TicketID"].Value);
                            string price = row.Cells["Price"].Value.ToString();
                            string desFrom = row.Cells["DesFrom"].Value.ToString();
                            string desTo = row.Cells["DesTo"].Value.ToString();
                            string date = row.Cells["Date"].Value.ToString();
                            string ava = row.Cells["availability"].Value.ToString();
                            BuyForm c = new BuyForm(ticketid, UserID, price, desFrom, desTo, date, ava);
                            c.ShowDialog();
                        }
                    }


                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Preview previewForm = new Preview(UserID);
            previewForm.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string sqlQuery = "SELECT Username, Password, email, phone, birthday FROM Users WHERE UserID=@UserID";

            if (!labelsVisible)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(@"Data Source=LAB109PC21\SQLEXPRESS; Initial Catalog=RailwaySistema; Integrated Security=True;"))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlQuery, connection);
                        command.Parameters.AddWithValue("@UserID", UserID);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            label2.Text = "Username: " + reader["Username"].ToString();
                            label3.Text = "*****";
                            if (UserID != "1")
                            {
                                label5.Text = "Phone: " + reader["phone"].ToString();
                                label4.Text = "Email: " + reader["email"].ToString();
                                label6.Text = "Date of Birth: " + reader["birthday"].ToString();
                            }
                            labelsVisible = true;
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {

                label2.Text = "";
                label3.Text = "";
                label4.Text = "";
                label5.Text = "";
                label6.Text = "";
                labelsVisible = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            string sqlQuery = "SELECT Password FROM Users WHERE UserID=@UserID";
            if (labelsVisible)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to reveal the password?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(@"Data Source=LAB109PC21\SQLEXPRESS; Initial Catalog=RailwaySistema; Integrated Security=True;"))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(sqlQuery, connection);
                            command.Parameters.AddWithValue("@UserID", UserID);
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                label3.Text = "Password: " + reader["Password"].ToString();
                            }
                            reader.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LogIN lol = new LogIN();
                lol.Show();
                this.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Add a = new Add(UserID);
            a.ShowDialog();
        }
    }
}
