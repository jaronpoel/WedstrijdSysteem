using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DTOConverter
    {
        //MatchReports
        internal static List<MatchReport> GetAllMatchReports(List<MatchReportDto> list)
        {
            List<MatchReport> matchReports = new List<MatchReport>();
            foreach (MatchReportDto matchreportdto in list)
            {
                matchReports.Add(GetMatchReportFromDTO(matchreportdto));
            }
            return matchReports;
        }

        internal static MatchReport GetMatchReportFromDTO(MatchReportDto dto)
        {
            return new MatchReport(dto.Id, dto.Date, dto.Title, dto.Report, dto.UserId);
        }

        internal static MatchReportDto GetMatchReportDTO(MatchReport matchreport)
        {
            MatchReportDto dto = new MatchReportDto
            {
                Id = matchreport.Id,
                Date = matchreport.Date,
                Title = matchreport.Title,
                Report = matchreport.Report,
                UserId = matchreport.UserId
            };
            return dto;
        }
    }
}
