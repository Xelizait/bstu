using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab5;


namespace lan6
{


    class WrongIdValue : Exception
    {
        int Value { get; set; }
        public WrongIdValue(string message, int value) : base(message)
        {
            Value = value;

        }
    }

    class WrongColorValue : ArgumentOutOfRangeException
    {
        int Value { get; set; }
        public WrongColorValue(string message, int value) : base(message)
        {
            Value = value;

        }
    }


    class IsNotFigure : ArgumentException
    {
        string Value { get; set; }
        public IsNotFigure(string message, string value) : base(message)
        {
            Value = value;

        }
    }

    class IsNotName : ArgumentException
    {
        string Value { get; set; }
        public IsNotName(string message, string value) : base(message)
        {
            Value = value;

        }
    }

}















    


   

