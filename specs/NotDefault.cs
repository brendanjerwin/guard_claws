using GuardClaws;
using GuardClaws.Exceptions;
using NUnit.Framework;

namespace NotDefault
{
    [TestFixture]
    public class when_called_with_a_not_default_value
    {
        [Test] public void 
            it_should_do_nothing()
        {
            var test = "asdf";
            Claws.NotDefault(() => test);
        }
    }

    [TestFixture]
    public class when_called_with_a_default_value : expect_an_exception<VariableMustNotBeDefaultValueException<int>,int>
    {
        protected override void StatementUnderTest()
        {
            test = default(int);
            Claws.NotDefault(()=>test);
        }
    }
}
