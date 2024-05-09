using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FinalProject
{
    public partial class Preview : Form
    {
        public string UserID { get; set; }

        public Preview(string userid)
        {
            InitializeComponent();
            UserID = userid;
        }

        private void Preview_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView2();
        }

        private void LoadDataIntoDataGridView2()
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAB109PC21\SQLEXPRESS; Initial Catalog=RailwaySistema; Integrated Security=True;"))
                {
                    sqlCon.Open();
                    string query = "SELECT Users.Username, Auth.TicketID FROM Auth INNER JOIN Users ON Auth.UserID = Users.UserID WHERE Auth.UserID = @UserID";
                    using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            dataGridView1.DataSource = ds.Tables.Count > 0 ? ds.Tables[0] : null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int ticketID = Convert.ToInt32(row.Cells["TicketID"].Value);
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAB109PC21\SQLEXPRESS; Initial Catalog=RailwaySistema; Integrated Security=True;"))
                {
                    sqlCon.Open();
                    string query = "SELECT Price, DesFrom, DesTo, Date FROM Price WHERE TicketID = @TicketID";
                    using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                    {
                        cmd.Parameters.AddWithValue("@TicketID", ticketID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string price = reader["Price"].ToString();
                                string desFrom = reader["DesFrom"].ToString();
                                string desTo = reader["DesTo"].ToString();
                                string date = reader["Date"].ToString();
                                Detele a = new Detele(ticketID, UserID, price, desFrom, desTo, date);
                                a.Show();
                            }
                            else
                            {
                                MessageBox.Show("No data found for the specified TicketID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage welcome = new HomePage(UserID);
            welcome.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView2();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
