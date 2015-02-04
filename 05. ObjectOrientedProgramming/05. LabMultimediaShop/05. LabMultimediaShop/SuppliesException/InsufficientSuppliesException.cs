using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabMultimediaShop.SuppliesException
{
    class InsufficientSuppliesException : Exception
    {
        public InsufficientSuppliesException()
        {
        }

        public InsufficientSuppliesException(string message)
            : base(message)
        {
        }

        public InsufficientSuppliesException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
