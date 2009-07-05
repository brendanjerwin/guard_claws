namespace GuardClaws.Exceptions
{
    public class VariableMayNotBeBlankException : ValidationFailureException
    {
        public VariableMayNotBeBlankException(string nameOfDelinquent, string message) : base(nameOfDelinquent, message)
        {
        }
    }
}