using Dal.Context;
using Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ClubTeamCollection
    {
        //Factory aanroepen
        private readonly IClubTeamCollection ClubTeamCollectionDAL;
        public ClubTeamCollection()
        {
            ClubTeamCollectionDAL = FactoryDal.CreateClubTeamCollectionDal();
        }

        //Begin van de Methodes aanroepen
        public void AddTeam(ClubTeam clubTeam)
        {
            throw new NotImplementedException();
        }

        public void DeleteTeam(ClubTeam clubTeam)
        {
            throw new NotImplementedException();
        }

        public ClubTeam GetTeamByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
