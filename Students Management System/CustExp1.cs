using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Management_System
{
    internal class CustExp1 : Exception
    {
        public CustExp1(string message) : base(message) { }

        public override string ToString()
        {   
            Console.WriteLine();
            return Message;
        }

    }
}
