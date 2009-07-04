using GuardClaws.Exceptions;
using NUnit.Framework;


public abstract class with_ValidationFailureException
{
    protected ValidationFailureException the_exception;

    protected abstract void StatementUnderTest();

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
}