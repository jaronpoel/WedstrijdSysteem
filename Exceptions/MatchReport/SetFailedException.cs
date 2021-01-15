using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions.MatchReport
{
    public class SetFailedException : Exception
    {
        public SetFailedException()
        {

        }

        public SetFailedException(string message) : base(message)
        {

        }
    }
}
