using System;

namespace GuardClaws.Exceptions
{
    public class VariableMustNotBeDefaultValueException : GuardClauseViolationException
    {
        protected VariableMustNotBeDefaultValueException(string nameOfDelinquent) : base(nameOfDelinquent, "Variable must not be it's default value.")
        {
        }
    }
}