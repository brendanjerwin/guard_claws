using System;

namespace GuardClaws.Exceptions
{
    public class VariableMustNotBeEqualException<T> : GuardClauseViolationException<T>
    {
        public VariableMustNotBeEqualException(Func<T> delinquent, T comparedTo) : base(delinquent, "Variable must not be equal to provided comparison value.")
        {
            ComparedTo = comparedTo;
        }

        public T ComparedTo { get; private set; }
    }
}