using System;

namespace Mono.MoonDesk
{
    public class MoonBaseException : Exception
    {
        public MoonBaseException ( string format, params object[] args ) : base ( string.Format( format, args ) )
        {
        }
    }
}

