using GuardClaws.Exceptions;
using NUnit.Framework;


public abstract class expect_a_ValidationFailureException<TVariableType,TExpectedExceptionType> where TExpectedExceptionType:ValidationFailureException
{
    protected ValidationFailureException the_exception;

    protected abstract void StatementUnderTest();

    protected TVariableType test;

    [SetUp]
    public void BecauseOf()
    {
        try
        {
            StatementUnderTest();
        }
        catch (ValidationFailureException ex)
        {
            the_exception = ex;
        }
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

    [Test]
    public void
        the_exception_should_be_of_expected_type()
    {
        the_exception.Should().Be.InstanceOf<TExpectedExceptionType>();
    }
}