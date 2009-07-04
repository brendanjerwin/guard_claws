using GuardClaws.Exceptions;
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

    [TestFixture]
    public class when_called_with_a_null : with_ValidationFailureException
    {
        protected override void StatementUnderTest()
        {
            string test = null;
            Claws.NotNullNotBlank(() => test);
        }
    }

    [TestFixture]
    public class when_called_with_a_blank : with_ValidationFailureException
    {
        protected override void StatementUnderTest()
        {
            string test = string.Empty;
            Claws.NotNullNotBlank(() => test);
        }

        [Test]
        public void 
            it_should_throw_a_GuardClaws_VariableMayNotBeBlankException()
        {
            the_exception.Should().Be.InstanceOf<VariableMayNotBeBlankException>();
        }
    }
}    