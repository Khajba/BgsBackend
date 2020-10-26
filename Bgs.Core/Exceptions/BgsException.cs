using System;
using System.Collections.Generic;
using System.Text;

namespace Bgs.Core.Exceptions
{

   public class BgsException : Exception
    {
        public int Errorcode  { get; set; }

        public BgsException(int errorCode)
        {
            Errorcode = errorCode;
        }

    }
}
