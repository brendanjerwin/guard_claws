using System;
using GuardClaws.Exceptions;

namespace GuardClaws
{
    public static class Claws
    {
        public static void NotNull<T>(Func<T> variable) where T : class
        {
            if (variable.Invoke() != null) return;
            throw new VariableMustNotBeNullException(Reflect.VariableName(variable));
        }

        public static void NotNullNotBlank(Func<string> variable)
        {
            NotNull(variable);

            if(variable.Invoke() != string.Empty) return;
            throw new VariableMustNotBeBlankException(Reflect.VariableName(variable));
        }

        public static void Numeric(Func<string> variable)
        {
            double junk;
            if (double.TryParse(variable.Invoke(),out junk)) return;
            throw new VariableMustBeNumericException(Reflect.VariableName(variable));
        }

        public static void NotDefault<T>(Func<T> variable)
        {
            if (!variable.Invoke().Equals(default(T))) return;
            throw new VariableMustNotBeDefaultValueException(Reflect.VariableName(variable));
        }

        public static void NotEqual<T>(Func<T> variable, T comparedTo) 
        {
            if(!variable.Invoke().Equals(comparedTo)) return;
            throw new VariableMustNotBeEqualException(Reflect.VariableName(variable),comparedTo);
        }
    }
}