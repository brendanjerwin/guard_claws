using System;

namespace GuardClaws.Exceptions
{
    public class VariableMustNotBeEqualException<T> : GuardClauseComparisonViolationException<T>
    {
        public VariableMustNotBeEqualException(Func<T> delinquent, T comparedTo) 
            : base(delinquent, comparedTo, "Variable must not be equal to provided comparison value."){}
    }
}