namespace GuardClaws.Exceptions
{
    public class VariableMustNotBeBlankException : GuardClauseViolationException
    {
        public VariableMustNotBeBlankException(string nameOfDelinquent, string message) : base(nameOfDelinquent, message)
        {
        }
    }
}