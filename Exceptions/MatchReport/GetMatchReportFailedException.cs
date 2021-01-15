using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.MatchReport
{
    public class GetMatchReportFailedException : Exception
    {
        public GetMatchReportFailedException()
        {

        }

        public GetMatchReportFailedException(string message) : base(message)
        {

        }
    }
}
