using System;

namespace GuardClaws.Exceptions
{
    public class VariableMustNotBeNullException<T> : GuardClauseViolationException<T>
    {
        public VariableMustNotBeNullException(Func<T> delinquent) : base(delinquent,"Variable must not be Null."){}
    }
}