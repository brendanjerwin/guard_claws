using GuardClaws.Exceptions;

namespace GuardClaws.Numeric
{
    public class VariableMustBeNumericException : GuardClauseViolationException
    {
        public VariableMustBeNumericException(string nameOfDelinquent, string message) : base(nameOfDelinquent, message)
        {
        }
    }
}