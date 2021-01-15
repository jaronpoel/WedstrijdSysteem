using Exceptions.User;
using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Context
{
    public class UserSqlContext : IUser, IUserCollection
    {
        public void SetName(string name)
        {
            try
            {
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE [User] SET Username = @Name WHERE Id = 1";
                    command.Parameters.AddWithValue("@Name", name);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw new SetFailedException("An unexpected error occured.");
            }
        }

        public void SetPassword(string password)
        {
            try
            {
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE [User] SET Password = @Password WHERE Id = 1";
                    command.Parameters.AddWithValue("@Password", password);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw new SetFailedException("An unexpected error occured.");
            }
        }

        public void SetEmail(string email)
        {
            try
            {
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE [User] SET Email = @Email WHERE Id = 1";
                    command.Parameters.AddWithValue("@Email", email);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw new SetFailedException("An unexpected error occured.");
            }
        }
        public void SignUp(string username, string password, string email)
        {
            try
            {
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO [User] (Email, Username, Password) VALUES (@Email, @Username, @Password)";
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw new SignUpFailedException("An unexpected error occured.");
            }
        }

        public UserDto SignIn(string username, string password)
        {
            try
            {
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE Username = @Username AND Password = @Password", connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    if ((int)command.ExecuteScalar() == 1)
                    {
                        SqlCommand scommand = new SqlCommand("SELECT ID, Username FROM [User] WHERE Username = @Username", connection);
                        scommand.Parameters.AddWithValue("@Username", username);
                        SqlDataReader reader = scommand.ExecuteReader();
                        while (reader.Read())
                        {
                            return new UserDto()
                            {
                                Id = (int)reader["ID"],
                                Username = (string)reader["Username"],
                            };
                        }
                    }
                    throw new AuthenticationFailedException("Incorrect username or password.");
                }
            }
            catch (SqlException)
            {
                throw new AuthenticationFailedException("An unexpected error occured.");
            }
        }

        public void MakingTeam()
        {
            throw new NotImplementedException();
        }
    }
}
