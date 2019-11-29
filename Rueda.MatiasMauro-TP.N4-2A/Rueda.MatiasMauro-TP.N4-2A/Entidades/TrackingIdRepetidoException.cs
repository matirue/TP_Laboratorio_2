using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException:Exception
    {
        public TrackingIdRepetidoException(string message) : base(message) { }

        public TrackingIdRepetidoException(string message, Exception inner) : base(message, inner) { }
    }
}
