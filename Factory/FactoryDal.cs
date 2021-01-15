using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Context;

namespace Factory
{
    public class FactoryDal
    {
        //Voor User
        public static IUser CreateUserDal()
        {
            return new UserSqlContext();
        }

        public static IUserCollection CreateUserCollectionDal()
        {
            return new UserSqlContext();
        }

        //Voor Clubteam
        public static IClubTeam CreateClubTeamDal()
        {
            return new ClubTeamSqlContext();
        }

        public static IClubTeamCollection CreateClubTeamCollectionDal()
        {
            return new ClubTeamSqlContext();
        }

        //Voor MatchReport
        public static IMatchReport CreateMatchReportDal()
        {
            return new MatchReportSqlContext();
        }

        public static IMatchReportCollection CreateMatchReporCollectiontDal()
        {
            return new MatchReportSqlContext();
        }
    }
}
