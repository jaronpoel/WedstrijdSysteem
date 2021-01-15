using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.MatchReport
{
    public class AddMatchReportFailedException : Exception
    {
        public AddMatchReportFailedException()
        {

        }

        public AddMatchReportFailedException(string message) : base(message)
        {

        }
    }
}
