using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Core.Exceptions
{

   public class BgsException : Exception
    {
        public BgsExceptionType Type { get; set; }

        public BgsException(BgsExceptionType type)
        {
            Type = type;
        }

    }
}
