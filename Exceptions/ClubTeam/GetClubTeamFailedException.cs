using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.ClubTeam
{
     public class GetClubTeamFailedException : Exception
    {
        public GetClubTeamFailedException()
        {

        }

        public GetClubTeamFailedException(string message) : base(message)
        {

        }
    }
}
