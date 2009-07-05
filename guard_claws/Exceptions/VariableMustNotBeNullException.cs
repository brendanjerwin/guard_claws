namespace GuardClaws.Exceptions
{
    public class VariableMustNotBeNullException : GuardClauseViolationException
    {
        public VariableMustNotBeNullException(string nameOfDelinquent) : base(nameOfDelinquent,"Variable must not be Null."){}
    }
}