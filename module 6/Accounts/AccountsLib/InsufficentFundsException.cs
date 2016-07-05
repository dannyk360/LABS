using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    [Serializable]
    public class InsufficentFundsException : Exception
    {

        public InsufficentFundsException()
        {
        }

        public InsufficentFundsException(string message) : base(message)
        {
        }

        public InsufficentFundsException(string message, Exception inner) : base(message, inner)
        {
        }

        protected InsufficentFundsException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }

}
