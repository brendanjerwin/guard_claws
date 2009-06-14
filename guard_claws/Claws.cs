using System;

namespace GuardClaws
{
    public class Claws
    {
        /// <exception cref="VariableMayNotBeNullException"><c>VariableMayNotBeNullException</c>.</exception>
        public static void NotNull<T>(Func<T> variable) where T : class
        {
            if (variable.Invoke() != null) return;
            throw new VariableMayNotBeNullException(Reflect.VariableName(variable));
        }
    }
}