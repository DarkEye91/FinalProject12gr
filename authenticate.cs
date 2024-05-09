using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FinalProject
{
    internal class authenticate
    {
        public class User
        {
            public string UserID { get; set; }
            public string Username { get; set; }
            public string Passoword { get; set; }
        }

        public class DatabaseManager
        {
            public static User AuthenticateUser(string username, string password)
            {
                User user = RetrieveUserInformation(username, password);
                return user;
            }

            private static User RetrieveUserInformation(string username, string password)
            {
                using (SqlConnection sqlCon = new SqlConnection(@"Data Source=LAB109PC21\SQLEXPRESS; Initial Catalog=RailwaySistema; Integrated Security=True;"))
                {
                    sqlCon.Open();

                    string loginQuery = "SELECT COUNT(1) FROM Users WHERE Username=@Username AND Password=@Password";
                    string userquery = "SELECT UserID FROM Users WHERE Username=@Username AND Password=@Password";

                    using (SqlCommand loginCmd = new SqlCommand(loginQuery, sqlCon))
                    {
                        using (SqlCommand userCmd = new SqlCommand(userquery, sqlCon))
                        {
                            loginCmd.CommandType = CommandType.Text;

                            loginCmd.Parameters.AddWithValue("@Username", username);
                            loginCmd.Parameters.AddWithValue("@Password", password);
                            userCmd.Parameters.AddWithValue("@Username", username);
                            userCmd.Parameters.AddWithValue("@Password", password);

                            int count = Convert.ToInt32(loginCmd.ExecuteScalar());
                            string userid = Convert.ToString(userCmd.ExecuteScalar());

                            if (count == 1)
                            {
                                return new User { Username = username, Passoword = password, UserID = userid };
                            }
                        }
                    }

                    return null;
                }
            }
        }
    }
}
