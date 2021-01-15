using Exceptions.ClubTeam;
using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Context
{
    public class ClubTeamSqlContext : IClubTeam, IClubTeamCollection
    {
        public void SetClub(string club)
        {
            try
            {
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE INTO [Clubteam] (Club) VALUES (@Club)";
                    command.Parameters.AddWithValue("@Club", club);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw new SetFailedException("An unexpected error occured.");
            }
        }

        public void SetTeam(string team)
        {
            try
            {
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE INTO [Clubteam] (Club) VALUES (@Team)";
                    command.Parameters.AddWithValue("@Team", team);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw new SetFailedException("An unexpected error occured.");
            }
        }

        public void AddTeam(ClubTeamDto clubTeam)
        {
            try
            {
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO [Clubteam] (Club ,Team) VALUES (@Club ,@Team)";
                    command.Parameters.AddWithValue("@Club", clubTeam.Club);
                    command.Parameters.AddWithValue("@Team", clubTeam.Team);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw new AddClubTeamFailedException("An unexpected error occured.");
            }
        }

        public ClubTeamDto GetTeamByID(int id)
        {
            try
            {
                using (SqlConnection conn = DataConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * From Clubteam WHERE Id=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    ClubTeamDto clubteam = new ClubTeamDto();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clubteam.Id = (int)reader["Id"];
                            clubteam.Club = (string)reader["Club"];
                            clubteam.Team = (string)reader["Team"];
                        }
                    }
                    return (clubteam);
                }
            }
            catch (SqlException)
            {
                throw new GetClubTeamFailedException("An unexpected error occured.");
            }
        }

        public void DeleteTeam(ClubTeamDto clubTeam)
        {
            throw new NotImplementedException();
        }
    }
}
