using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ClassLibrary3
{

    public class DatabaseControler
    {
        public string connectionString;

        public DatabaseControler(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Authorization(string login, string password)
        {
            int userTypeId = -1;
            int userId = -1;
            bool isSuccessful = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT userTypeID, userID FROM Users WHERE login = @login AND password = @password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        userId = reader.GetInt32(1);
                        userTypeId = reader.GetInt32(0);
                        isSuccessful = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
                }
            }
            return isSuccessful;
        }

        public static string GenerateString(int length)
        {

            Random random = new Random();
            const string chars = "abcdefghirstuvwxyzABCDEFGHRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


    }
}
