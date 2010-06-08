using System;
using System.Collections;

namespace GuardClaws.Exceptions
{
    public class VariableMustNotBeEmptyException<T> : GuardClauseViolationException<T> where T : IEnumerable
    {
        public VariableMustNotBeEmptyException(Func<T> delinquent) : base(delinquent, "Variable must not be empty.") { }
    }
}