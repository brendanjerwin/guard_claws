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
            throw new NotImplementedException();
        }

        public static void Numeric(Func<string> variable)
        {
            throw new NotImplementedException();
        }

        public static void NotDefault<T>(Func<T> variable)
        {
            throw new NotImplementedException();
        }

        public static void NotEqual<T>(Func<T> variable, T comparedTo) 
        {
            throw new NotImplementedException();
        }
    }
}