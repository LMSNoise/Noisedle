using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Noisedle.Domain.Exceptions
{
    internal class LingoException : Exception
    {
        public LingoException(string message) : base(message) { }
    }
}
