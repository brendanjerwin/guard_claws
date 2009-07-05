using System;

namespace GuardClaws.Exceptions
{
    public class VariableMustNotBeEqualException : GuardClauseViolationException
    {
        protected VariableMustNotBeEqualException(string nameOfDelinquent, object comparedTo) : base(nameOfDelinquent, "Variable must not be equal to provided comparison value.")
        {
            ComparedTo = comparedTo;
        }

        public object ComparedTo { get; private set; }
    }
}