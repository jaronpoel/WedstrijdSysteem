using Dal.Context;
using Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class MatchReport
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Report { get; set; }
        public string UserId { get; set; }

        public MatchReport(int id, DateTime date ,string title, string report, string userid)
        {
            Id = id;
            Date = date;
            Title = title;
            Report = report;
            UserId = userid;
        }

        //Factory aanroepen
        private readonly IMatchReport MatchreportDAL;
        public MatchReport()
        {
            MatchreportDAL = FactoryDal.CreateMatchReportDal();
        }

        //Begin van de Methodes aanroepen
        public void SetTitle(string name, int id)
        {
            MatchreportDAL.SetTitle(name, id);
        }

        public void SetReport(string report, int id)
        {
            MatchreportDAL.SetReport(report, id);
        }
    }
}
