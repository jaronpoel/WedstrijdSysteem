using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.ClubTeam
{
    public class AddClubTeamFailedException : Exception
    {
        public AddClubTeamFailedException()
        {

        }

        public AddClubTeamFailedException(string message) : base(message)
        {

        }
    }
}
