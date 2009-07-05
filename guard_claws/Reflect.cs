#region (c)2009 Lokad, (c) Brendan Erwin - New BSD license

// Portions Copyright (c) Lokad 2009 
// Company: http://www.lokad.com

// Other Portions Copyright (c) Brendan Erwin 2009

// This code is released under the terms of the new BSD licence

#endregion

using System;
using System.Reflection;
using System.Reflection.Emit;

namespace GuardClaws
{
    /// <summary>
    /// Helper class for the IL-based strongly-typed reflection
    /// </summary>
    /// <remarks>This class is not supported by Silverlight 2.0</remarks>
    internal static class Reflect
    {
        static readonly byte Ldarg_0 = (byte) OpCodes.Ldarg_0.Value;
        static readonly byte Ldfld = (byte) OpCodes.Ldfld.Value;
        static readonly byte Stloc_0 = (byte) OpCodes.Stloc_0.Value;
        static readonly byte Ret = (byte) OpCodes.Ret.Value;


        public static string VariableName<T>(Func<T> expression)
        {
            return Variable(expression).Name;
        }

        /// <summary>
        /// Retrieves via IL the information of the <b>local</b> variable passed in the expression.
        /// <code>
        /// var myVar = "string";
        /// var info = Reflect.Variable(() =&gt; myVar)
        /// </code>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression">The expression containing the local variable to reflect.</param>
        /// <returns>information about the variable</returns>
        static FieldInfo Variable<T>(Func<T> expression)
        {
            var method = expression.Method;
            var il = method.GetMethodBody().GetILAsByteArray();
            // in DEBUG we end up with stack
            // in release, there is a ret at the end
            if ((il[0] == Ldarg_0) && (il[1] == Ldfld) && ((il[6] == Stloc_0) || (il[6] == Ret)))
            {
                var fieldHandle = BitConverter.ToInt32(il, 2);

                var module = method.Module;
                var expressionType = expression.Target.GetType();

                if (!expressionType.IsGenericType)
                {
                    return module.ResolveField(fieldHandle);
                }
                var genericTypeArguments = expressionType.GetGenericArguments();
                // method does not have any generics
                //var genericMethodArguments = method.GetGenericArguments();
                return module.ResolveField(fieldHandle, genericTypeArguments, Type.EmptyTypes);
            }
            throw new ArgumentException("Expected simple field reference");
        }
    }
}