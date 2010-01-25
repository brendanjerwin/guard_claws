using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GuardClaws;

namespace playground
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = string.Empty;
            Claws.NotNullNotBlank(() => test);
        }
    }
}
