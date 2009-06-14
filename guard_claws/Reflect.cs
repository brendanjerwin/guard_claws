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
    public static class Reflect
    {
        static readonly byte Ldarg_0 = (byte) OpCodes.Ldarg_0.Value;
        static readonly byte Ldfld = (byte) OpCodes.Ldfld.Value;
        static readonly byte Ldflda = (byte) OpCodes.Ldflda.Value;
        static readonly byte Constrained = (byte) OpCodes.Constrained.Value;
        static readonly byte Stloc_0 = (byte) OpCodes.Stloc_0.Value;
        static readonly byte CallVirt = (byte) OpCodes.Callvirt.Value;
        static readonly byte Ret = (byte) OpCodes.Ret.Value;

        internal static string MemberName<T>(Func<T> expression)
        {
            var member = Member(expression);
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    return member.Name;
                case MemberTypes.Method:
                    var name = member.Name;
                    if (!name.StartsWith("get_"))
                        throw new InvalidOperationException("Unexpected property getter");

                    return name.Remove(0, 4);
                default:
                    throw new InvalidOperationException("Unexpected member");
            }
        }


        internal static string VariableName<T>(Func<T> expression)
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
        public static FieldInfo Variable<T>(Func<T> expression)
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

        /// <summary>
        /// Retrieves via IL the <em>getter method</em> for the property being reflected.
        /// <code>
        /// var i2 = new
        /// {
        ///   MyProperty = "Value"
        /// }; 
        /// var info = Reflect.Property(() => i2.Property);
        /// // info will have name of "get_MyProperty"
        /// </code>
        /// </summary>
        /// <typeparam name="T">type of the property to reflect</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns>getter method for the property.</returns>
        public static MethodInfo Property<T>(Func<T> expression)
        {
            return DelegatedProperty(expression);
        }

        static MemberInfo Member<T>(Func<T> expression)
        {
            return DelegatedMember(expression);
        }

        // in DEBUG we end up with stack
        // in release, there is a ret at the end
        static MethodInfo DelegatedProperty(Delegate expression)
        {
            var method = expression.Method;
            var il = method.GetMethodBody().GetILAsByteArray();

            if ((il[0] == Ldarg_0) && (il[1] == Ldfld) && (il[6] == CallVirt) && ((il[11] == Stloc_0) || (il[11] == Ret)))
            {
                var getHandle = BitConverter.ToInt32(il, 7);

                return (MethodInfo) method.Module.ResolveMethod(getHandle);
            }
            if ((il[0] == Ldarg_0) && (il[1] == Ldflda) && (il[6] == 0xfe) && (il[7] == Constrained) && (il[12] == CallVirt) &&
                ((il[17] == Stloc_0) || (il[17] == Ret)))
            {
                var getHandle = BitConverter.ToInt32(il, 13);

                return (MethodInfo) method.Module.ResolveMethod(getHandle);
            }
            throw new ArgumentException("Expected simple property reference");
        }

        internal static MemberInfo DelegatedMember(Delegate expression)
        {
            var method = expression.Method;
            var il = method.GetMethodBody().GetILAsByteArray();

            if ((il[0] == Ldarg_0) && (il[1] == Ldfld) && ((il[6] == CallVirt) || (il[6] == Ldfld)) &&
                ((il[11] == Stloc_0) || (il[11] == Ret)))
            {
                var getHandle = BitConverter.ToInt32(il, 7);

                return method.Module.ResolveMember(getHandle);
            }
            throw new ArgumentException("Expected simple member reference");
        }
    }
}