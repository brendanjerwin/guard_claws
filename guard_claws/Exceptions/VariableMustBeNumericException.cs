namespace GuardClaws.Exceptions
{
    public class VariableMustBeNumericException : GuardClauseViolationException
    {
        public VariableMustBeNumericException(string nameOfDelinquent) : base(nameOfDelinquent, "Variable must be numeric.")
        {
        }
    }
}