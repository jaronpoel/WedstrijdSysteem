using Exceptions.MatchReport;
using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Dal.Context
{
    public class MatchReportSqlContext : IMatchReport, IMatchReportCollection
    {
        public void SetTitle(string title, int id)
        {
            try
            {
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE [Matchreport] SET Title = @Title WHERE id = @Id";
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw new SetFailedException("An unexpected error occured.");
            }
        }

        public void SetReport(string report, int id)
        {
            try
            {
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "UPDATE [Matchreport] SET Report = @Report WHERE id = @Id";
                    command.Parameters.AddWithValue("@Report", report);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw new SetFailedException("An unexpected error occured.");
            }
        }

        public List<MatchReportDto> GetAllMatchReports()
        {
            try
            {
                using (SqlConnection conn = DataConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Matchreport WHERE userId = 1";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                    List<MatchReportDto> AllReports = new List<MatchReportDto>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        MatchReportDto matchreports = new MatchReportDto();

                        int.TryParse(dr[0].ToString(), out int id);
                        matchreports.Id = id;
                        int.TryParse(dr[1].ToString(), out int Userid);
                        matchreports.Title = dr[2].ToString();
                        matchreports.Report = dr[3].ToString();
                        matchreports.Date = (DateTime)dr[4];

                        AllReports.Add(matchreports);
                    }
                    return (AllReports);
                }
            }
            catch (SqlException)
            {
                throw new GetMatchReportFailedException("An unexpected error occured.");
            }
        }

        public MatchReportDto GetMatchReportByID(int id)
        {
            try
            {
                using (SqlConnection conn = DataConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * From Matchreport WHERE Id=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    MatchReportDto matchreport = new MatchReportDto();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            matchreport.Id = (int)reader["Id"];
                            matchreport.Title = (string)reader["Title"];
                            matchreport.Date = (DateTime)reader["Date"];
                            matchreport.Report = (string)reader["Report"];
                        }
                    }
                    return (matchreport);
                }
            }
            catch (SqlException)
            {
                throw new GetMatchReportFailedException("An unexpected error occured.");
            }
        }

        public void AddMatchReport(MatchReportDto matchreport)
        {
            try
            {
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO [Matchreport] (Title ,UserId ,Date, Report) VALUES (@Title ,@UserId ,@Date, @Report)";
                    command.Parameters.AddWithValue("@Title", matchreport.Title);
                    command.Parameters.AddWithValue("@UserId", 1);
                    command.Parameters.AddWithValue("@Date", matchreport.Date);
                    command.Parameters.AddWithValue("@Report", matchreport.Report);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw new AddMatchReportFailedException("An unexpected error occured.");
            }
        }

        public void DeleteMatchReport(int id)
        {
            try
            {
                using (SqlConnection connection = DataConnection.GetConnection())
                {
                    connection.Open();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "DELETE FROM [Matchreport] WHERE id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw new DeleteFailedException("An unexpected error occured.");
            }
        }
    }
}
