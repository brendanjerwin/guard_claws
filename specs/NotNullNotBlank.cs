using NUnit.Framework;
using NUnit.Framework.ExtensionsImpl;
using NUnit.Framework.Constraints;
using System;
using GuardClaws;

namespace NotNullNotBlank
{
	[TestFixture]
    public class when_called_with_a_valid_input
    {
		[Test]
        public void it_should_do_nothing () 
        {
            var test = "valid value";
            Claws.NotNullNotBlank(()=>test);
        }
    }
}    