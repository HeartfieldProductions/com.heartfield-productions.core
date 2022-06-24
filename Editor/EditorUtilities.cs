using System;
using System.Reflection;

namespace HeartfieldEditor
{
    public static class EditorUtilities
    {
        /// <summary>
        /// Search class using Reflection
        /// </summary>
        /// <param name="assemblyName">name of referenced assembly</param>
        /// <param name="className">namespace.class name</param>
        /// <returns></returns>
        public static Type GetClassType(string assemblyName, string className)
        {
            var refAssemblies = Assembly.GetCallingAssembly().GetReferencedAssemblies();

            for (int i = 0; i < refAssemblies.Length; i++)
            {
                var assembly = refAssemblies[i];

                if (assembly.FullName.Contains(assemblyName))
                {
                    return Assembly.Load(assembly).GetType(className);
                }
            }

            return null;
        }

        const BindingFlags reflectionBinds = BindingFlags.Instance | BindingFlags.NonPublic |
                                             BindingFlags.Public | BindingFlags.Static;

        public static void InvokeMethod(this Type source, string name, object[] args, BindingFlags bindingFlags = reflectionBinds)
        {
            var method = source.GetMethod(name, reflectionBinds);
            _ = method.Invoke(source, args);
        }

        public static void InvokeMethod(this Type source, string name, BindingFlags bindingFlags = reflectionBinds)
        {
            InvokeMethod(source, name, null);
        }

        public static T GetMethodValue<T>(this Type source, string name, object[] args, BindingFlags bindingFlags = reflectionBinds)
        {
            var method = source.GetMethod(name, reflectionBinds);
            return (T)method.Invoke(source, args);
        }

        public static T GetMethodValue<T>(this Type source, string name, BindingFlags bindingFlags = reflectionBinds)
        {
            return GetMethodValue<T>(source, name, null);
        }

        public static T GetFieldValue<T>(this Type source, string name, BindingFlags bindingFlags = reflectionBinds)
        {
            return (T)source.GetField(name, reflectionBinds).GetValue(source);
        }

        public static void SetFieldValue<T>(this Type source, string name, T value, BindingFlags bindingFlags = reflectionBinds)
        {
            var field = source.GetField(name, reflectionBinds);
            field.SetValue(source, value);
        }

        public static T GetPropertyValue<T>(this Type source, string name, BindingFlags bindingFlags = reflectionBinds)
        {
            return (T)source.GetProperty(name, reflectionBinds).GetValue(source);
        }

        public static void SetPropertyValue<T>(this Type source, string name, T value, BindingFlags bindingFlags = reflectionBinds)
        {
            var property = source.GetProperty(name, reflectionBinds);
            property.SetValue(source, value);
        }
    }
}