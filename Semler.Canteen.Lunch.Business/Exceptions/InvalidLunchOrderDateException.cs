using System;
using System.Runtime.Serialization;

namespace Semler.Canteen.Lunch.Business.Exceptions
{
    [Serializable]
    public class InvalidLunchOrderDateException : Exception
    {
       
        public InvalidLunchOrderDateException()
        {
        }

        public InvalidLunchOrderDateException(string message) : base(message)
        {
        }

    }
}
