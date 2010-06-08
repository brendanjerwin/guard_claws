using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GuardClaws;

namespace playground
{
    public class foobar
    {
        public string SomeString { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var test = new foobar { SomeString = string.Empty};
            Claws.NotNullNotBlank(() => test.SomeString);
        }
    }
}
