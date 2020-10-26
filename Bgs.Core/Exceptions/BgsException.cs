using System;

namespace Bgs.Core.Exceptions
{
    public class BgsException : Exception
    {
        public int Errorcode { get; set; }

        public BgsException(int errorCode)
        {
            Errorcode = errorCode;
        }
    }
}