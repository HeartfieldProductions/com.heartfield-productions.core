using System;
using UnityEngine;
using System.Linq;
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

        const BindingFlags binds = BindingFlags.Instance | BindingFlags.NonPublic |
                                   BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod;

        #region Invoke Methods
        public static void InvokeMethod(this MonoBehaviour source, string name, object[] parameters, BindingFlags bindingAttr = binds)
        {
            var type = source.GetType();
            var method = type.GetMethod(name, bindingAttr);
            _ = method.Invoke(source, parameters);
        }

        public static void InvokeMethod(this MonoBehaviour source, string name, object parameter, BindingFlags bindingAttr = binds)
        {
            InvokeMethod(source, name, new object[] { parameter }, bindingAttr);
        }

        public static void InvokeMethod(this MonoBehaviour source, string name, BindingFlags bindingAttr = binds)
        {
            InvokeMethod(source, name, null, bindingAttr);
        }
        #endregion

        #region Get Methods Values
        public static T GetMethodValue<T>(this MonoBehaviour source, string name, object[] parameters, BindingFlags bindingAttr = binds)
        {
            var type = source.GetType();
            MethodInfo method;

            if (parameters == null)
                method = type.GetMethods(bindingAttr).Where(x => x.Name == name).FirstOrDefault(x => x.IsGenericMethod);
            else
                method = type.GetMethods(bindingAttr).Where(x => x.Name == name).FirstOrDefault(x => !x.IsGenericMethod);

            return (T)method.Invoke(source, parameters);
        }

        public static T GetMethodValue<T>(this MonoBehaviour source, string name, object parameter, BindingFlags bindingAttr = binds)
        {
            return GetMethodValue<T>(source, name, new object[] { parameter }, bindingAttr);
        }

        public static T GetMethodValue<T>(this MonoBehaviour source, string name, BindingFlags bindingAttr = binds)
        {
            return GetMethodValue<T>(source, name, null, bindingAttr);
        }
        #endregion

        #region Field Values
        public static T GetFieldValue<T>(this MonoBehaviour source, string name, BindingFlags bindingAttr = binds)
        {
            var type = source.GetType();
            var field = type.GetField(name, bindingAttr);
            return (T)field.GetValue(source);
        }

        public static void SetFieldValue<T>(this MonoBehaviour source, string name, T value, BindingFlags bindingAttr = binds)
        {
            var type = source.GetType();
            var field = type.GetField(name, bindingAttr);
            field.SetValue(source, value);
        }
        #endregion

        #region Property Values
        public static T GetPropertyValue<T>(this MonoBehaviour source, string name, BindingFlags bindingAttr = binds)
        {
            var type = source.GetType();
            var property = type.GetProperty(name, bindingAttr);
            return (T)property.GetValue(source);
        }

        public static void SetPropertyValue<T>(this MonoBehaviour source, string name, T value, BindingFlags bindingAttr = binds)
        {
            var type = source.GetType();
            var property = type.GetProperty(name, bindingAttr);
            property.SetValue(source, value);
        }
        #endregion
    }
}