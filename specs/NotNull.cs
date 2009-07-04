using GuardClaws.Exceptions;
using NUnit.Framework;
using GuardClaws;

namespace NotNull
{
    [TestFixture]
    public class when_calling_NotNull_with_a_not_null_input
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
    public class when_calling_NotNull_with_a_null_input : with_ValidationFailureException
    {
        protected override void StatementUnderTest()
        {
            string test = null;
            Claws.NotNull(() => test);
        }

        [Test]
        public void
            it_should_throw_a_GuardClaws_VariableMayNotBeNullException_if_the_input_is_null()
        {
            the_exception.Should().Be.InstanceOf<VariableMayNotBeNullException>();
        }

        [Test]
        public void
            it_should_put_the_variable_name_in_the_exception()
        {
            the_exception.NameOfDelinquent.Should().Be.EqualTo("test");
        }

        [Test]
        public void
            it_should_put_the_variable_name_in_the_message()
        {
            the_exception.Message.Should().Contain("test");
        }
    }
}