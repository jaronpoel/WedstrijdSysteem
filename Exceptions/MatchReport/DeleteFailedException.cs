using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions.MatchReport
{
    public class DeleteFailedException : Exception
    {
        public DeleteFailedException()
        {

        }

        public DeleteFailedException(string message) : base(message)
        {

        }
    }
}
