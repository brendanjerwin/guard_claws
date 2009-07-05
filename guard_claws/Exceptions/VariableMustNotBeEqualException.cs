using System;

namespace GuardClaws.Exceptions
{
    public class VariableMustNotBeEqualException : GuardClauseViolationException
    {
        public VariableMustNotBeEqualException(string nameOfDelinquent, object comparedTo) : base(nameOfDelinquent, "Variable must not be equal to provided comparison value.")
        {
            ComparedTo = comparedTo;
        }

        public object ComparedTo { get; private set; }
    }
}