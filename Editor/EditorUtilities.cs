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
        public static void InvokeMethod(this Type source, string name, object[] parameters, BindingFlags bindingAttr = binds)
        {
            _ = source.GetMethod(name, bindingAttr).Invoke(source, parameters);
        }

        public static void InvokeMethod(this MonoBehaviour source, string name, object[] parameters, BindingFlags bindingAttr = binds)
        {
            InvokeMethod(source.GetType(), name, parameters, bindingAttr);
        }

        public static void InvokeMethod(this Type source, string name, BindingFlags bindingAttr = binds)
        {
            InvokeMethod(source, name, null, bindingAttr);
        }

        public static void InvokeMethod(this MonoBehaviour source, string name, BindingFlags bindingAttr = binds)
        {
            InvokeMethod(source, name, null, bindingAttr);
        }
        #endregion

        #region Get Methods Values
        public static T GetMethodValue<T>(this Type source, string name, object[] parameters, BindingFlags bindingAttr = binds)
        {
            MethodInfo method = null;

            if (parameters == null)
            {
                method = source.GetMethods(bindingAttr).Where(x => x.Name == name).FirstOrDefault(x => x.IsGenericMethod);
            }
            else
            {
                method = source.GetMethods(bindingAttr).Where(x => x.Name == name).FirstOrDefault(x => !x.IsGenericMethod);
            }

            return (T)method.Invoke(source, parameters);
        }

        public static T GetMethodValue<T>(this MonoBehaviour source, string name, object[] parameters, BindingFlags bindingAttr = binds)
        {
            return GetMethodValue<T>(source.GetType(), name, parameters, bindingAttr);
        }

        public static T GetMethodValue<T>(this Type source, string name, BindingFlags bindingAttr = binds)
        {
            return GetMethodValue<T>(source, name, null, bindingAttr);
        }

        public static T GetMethodValue<T>(this MonoBehaviour source, string name, BindingFlags bindingAttr = binds)
        {
            return GetMethodValue<T>(source, name, null, bindingAttr);
        }
        #endregion

        #region Field Values
        public static T GetFieldValue<T>(this Type source, string name, BindingFlags bindingAttr = binds)
        {
            return (T)source.GetField(name, bindingAttr).GetValue(source);
        }

        public static T GetFieldValue<T>(this MonoBehaviour source, string name, BindingFlags bindingAttr = binds)
        {
            return GetFieldValue<T>(source.GetType(), name, bindingAttr);
        }

        public static void SetFieldValue<T>(this Type source, string name, T value, BindingFlags bindingAttr = binds)
        {
            var field = source.GetField(name, bindingAttr);
            field.SetValue(source, value);
        }

        public static void SetFieldValue<T>(this MonoBehaviour source, string name, T value, BindingFlags bindingAttr = binds)
        {
            SetFieldValue(source.GetType(), name, value, bindingAttr);
        }
        #endregion

        #region Property Values
        public static T GetPropertyValue<T>(this Type source, string name, BindingFlags bindingAttr = binds)
        {
            return (T)source.GetProperty(name, bindingAttr).GetValue(source);
        }

        public static T GetPropertyValue<T>(this MonoBehaviour source, string name, BindingFlags bindingAttr = binds)
        {
            return GetPropertyValue<T>(source.GetType(), name, bindingAttr);
        }

        public static void SetPropertyValue<T>(this Type source, string name, T value, BindingFlags bindingAttr = binds)
        {
            var property = source.GetProperty(name, bindingAttr);
            property.SetValue(source, value);
        }

        public static void SetPropertyValue<T>(this MonoBehaviour source, string name, T value, BindingFlags bindingAttr = binds)
        {
            SetPropertyValue(source.GetType(), name, value, bindingAttr);
        }
        #endregion
    }
}