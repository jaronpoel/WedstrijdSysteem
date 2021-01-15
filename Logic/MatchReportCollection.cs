using Dal.Context;
using Factory;
using Interfaces.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class MatchReportCollection
    {
        //Factory aanroepen
        private readonly IMatchReportCollection MatchreportCollectionDAL;
        public MatchReportCollection()
        {
            MatchreportCollectionDAL = FactoryDal.CreateMatchReporCollectiontDal();
        }
       
        //Begin van de Methodes aanroepen
        public void DeleteMatchReport(int id)
        {
            MatchreportCollectionDAL.DeleteMatchReport(id);
        }

        public List<MatchReport> GetAllMatchReports()
        {
            return DTOConverter.GetAllMatchReports(MatchreportCollectionDAL.GetAllMatchReports());
        }

        public MatchReport GetMatchReportByID(int id)
        {
            return DTOConverter.GetMatchReportFromDTO(MatchreportCollectionDAL.GetMatchReportByID(id));
        }

        public void AddMatchReport(MatchReport matchreport)
        {
            MatchreportCollectionDAL.AddMatchReport(DTOConverter.GetMatchReportDTO(matchreport));
        }
    }
}
