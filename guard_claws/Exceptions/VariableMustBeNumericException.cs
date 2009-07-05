using System;

namespace GuardClaws.Exceptions
{
    public class VariableMustBeNumericException : GuardClauseViolationException<string>
    {
        public VariableMustBeNumericException(Func<string> delinquent)
            : base(delinquent, "Variable must be numeric.")
        {
        }
    }
}