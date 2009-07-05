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

        public static void NotNullNotBlank(Func<string> func)
        {
            throw new NotImplementedException();
        }

        public static void Numeric(Func<string> func)
        {
            throw new NotImplementedException();
        }
    }
}