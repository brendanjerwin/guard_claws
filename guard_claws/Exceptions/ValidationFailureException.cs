using System;

namespace GuardClaws.Exceptions
{
    public class ValidationFailureException : ApplicationException
    {
        public ValidationFailureException(string nameOfDelinquent, string message) : base(BuildMessage(nameOfDelinquent, message))
        {
            NameOfDelinquent = nameOfDelinquent;
        }

        static string BuildMessage(string nameOfDelinquent, string message)
        {
            return string.Format("{0}/n/nDelinquent: {1}", message, nameOfDelinquent); 
        }

        public string NameOfDelinquent { get; private set; }
    }
}