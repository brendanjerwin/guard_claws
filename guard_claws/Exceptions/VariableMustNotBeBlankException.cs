using System;

namespace GuardClaws.Exceptions
{
    public class VariableMustNotBeBlankException : GuardClauseViolationException<string>
    {
        public VariableMustNotBeBlankException(Func<string> delinquent) : base(delinquent, "Variable must not be blank.")
        {
        }
    }
}