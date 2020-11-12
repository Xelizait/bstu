using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab5;

namespace lab5
{
    public class WrongIdValue : Exception
    {
        public WrongIdValue(string message) : base(message)
        {


        }
    }
}
