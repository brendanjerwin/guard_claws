using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GuardClaws;
using GuardClaws.Exceptions;
using NUnit.Framework;

namespace NotEqual
{
    [TestFixture]
    public class when_called_with_a_different_value
    {
        [Test] public void 
            it_should_do_nothing()
        {
            var test = "foo";
            var compareTo = "bar";

            Claws.NotEqual(() => test, compareTo);
        }
    }

    [TestFixture]
    public class when_called_with_an_equal_value : expect_an_exception<VariableMustNotBeEqualException<string>,string>
    {
        string compareTo = "foo";
        protected override void StatementUnderTest()
        {
            test = compareTo;
            Claws.NotEqual(()=>test,compareTo);
        }

        [Test] public void 
            it_should_put_the_compareTo_value_in_the_ComparedTo_on_the_exception()
        {
            the_exception.ComparedTo.Should().Be.EqualTo(compareTo);
        }
    }
}
