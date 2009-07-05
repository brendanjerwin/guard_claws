using GuardClaws.Exceptions;
using NUnit.Framework;
using GuardClaws;

namespace NotNull
{
    [TestFixture]
    public class when_called_with_a_not_null
    {
        [Test]
        public void
            it_should_do_nothing()
        {
            string test = string.Empty;
            Claws.NotNull(() => test);
        }
    }

    [TestFixture]
    public class when_called_with_a_null : expect_an_exception<VariableMustNotBeNullException, string>
    {
        protected override void StatementUnderTest()
        {
            test = null;
            Claws.NotNull(() => test);
        }
    }
}