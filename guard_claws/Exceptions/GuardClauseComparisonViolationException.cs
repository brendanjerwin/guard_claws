using System;

namespace GuardClaws.Exceptions
{
    public class GuardClauseComparisonViolationException<T> : GuardClauseViolationException<T>
    {
        protected GuardClauseComparisonViolationException(Func<T> delinquent,  T comparedTo, string message) : base(delinquent, message)
        {
            ComparedTo = comparedTo;
        }

        public T ComparedTo { get; private set; }
    }
}