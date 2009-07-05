using System;

namespace GuardClaws.Exceptions
{
    public class VariableMustNotBeDefaultValueException<T> : GuardClauseViolationException<T>
    {
        public VariableMustNotBeDefaultValueException(Func<T> delinquent) : base(delinquent, "Variable must not be it's default value.")
        {
        }
    }
}