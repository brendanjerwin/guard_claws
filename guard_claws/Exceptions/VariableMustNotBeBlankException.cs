namespace GuardClaws.Exceptions
{
    public class VariableMustNotBeBlankException : GuardClauseViolationException
    {
        public VariableMustNotBeBlankException(string nameOfDelinquent) : base(nameOfDelinquent, "Variable must not be blank.")
        {
        }
    }
}