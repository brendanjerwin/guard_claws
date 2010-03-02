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
    public class when_called_with_an_equal_value_string : expect_a_ComparisonViolation_exception<VariableMustNotBeEqualException<string>,string>
    {
        protected override void StatementUnderTest()
        {
            compareTo = "foo";
            test = compareTo;
            Claws.NotEqual(()=>test,compareTo);
        }
    }

    [TestFixture]
    public class when_called_with_an_equal_value_int : expect_a_ComparisonViolation_exception<VariableMustNotBeEqualException<int>, int>
    {
        protected override void StatementUnderTest()
        {
            compareTo = 1;
            test = compareTo;
            Claws.NotEqual(() => test, compareTo);
        }
    }
}
