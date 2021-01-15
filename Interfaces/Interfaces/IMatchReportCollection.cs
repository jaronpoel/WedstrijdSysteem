using Interfaces.DTO;
using System.Collections.Generic;

namespace Dal.Context
{
    public interface IMatchReportCollection
    {
        void AddMatchReport(MatchReportDto matchreport);
        void DeleteMatchReport(int id);
        List<MatchReportDto> GetAllMatchReports();
        MatchReportDto GetMatchReportByID(int id);
    }
}