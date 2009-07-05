namespace GuardClaws.Exceptions
{
    public class VariableMayNotBeNullException : ValidationFailureException
    {
        public VariableMayNotBeNullException(string nameOfDelinquent) : base(nameOfDelinquent,"Variable may not be Null."){}
    }
}