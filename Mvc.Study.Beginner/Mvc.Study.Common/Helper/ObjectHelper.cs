using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Mvc.Study.Common
{
    /// <summary>
    /// Класс содержит методы расширения для объектов
    /// </summary>
    public static class ObjectHelper
    {
        /// <summary>
        /// Кэш типов
        /// </summary>
        private static readonly IDictionary<string, Type> _typeCache = new Dictionary<string, Type>();

        #region ParseObject

        /// <summary>
        /// Разбирает значение и приводит его к указанному типу
        /// </summary>
        /// <param name="type">Нужный тип</param>
        /// <param name="obj">Объект для разбора</param>
        /// <returns></returns>
        public static object ParseObject(Type type, object obj)
        {
            // Если объект строка
            if (type == typeof(string))
            {
                return (obj ?? string.Empty).ToString();
            }

            // Воссоздаем тип
            var defaultValue = Activator.CreateInstance(type);

            // Если вдруг пытаемся воссоздать тип Nullable<>
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                type = Nullable.GetUnderlyingType(type);

            try
            {
                var parseMethod = type.GetMethod("Parse", new[] { typeof(string), typeof(IFormatProvider) });

                if (null != parseMethod)
                {
                    var cultureInfo = Thread.CurrentThread.CurrentCulture;
                    var formatProider = type == typeof(DateTime)
                                            ? (IFormatProvider)cultureInfo.DateTimeFormat
                                            : (IFormatProvider)cultureInfo.NumberFormat;

                    return parseMethod
                        .Invoke(null,
                                new object[]
                                    {
                                        (obj ?? string.Empty).ToString(),
                                        formatProider
                                    });
                }

                parseMethod = type.GetMethod("Parse", new[] { typeof(string) });
                if (null != parseMethod)
                {
                    return parseMethod
                        .Invoke(null,
                                new object[]
                                    {
                                        (obj ?? string.Empty).ToString()
                                    });
                }

                return defaultValue;
            }
            catch (AmbiguousMatchException)
            {
                // Для переданного типа не нашлось метода Parse
                // или их более одного
                return defaultValue;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Разбирает значение и приводит его к указанному типу
        /// </summary>
        /// <typeparam name="T">Нужный тип</typeparam>
        /// <param name="obj">Объект для разбора</param>
        /// <returns></returns>
        public static T ParseObject<T>(object obj)
        {
            return (T)ParseObject(typeof(T), obj);
        }

        #endregion

        #region IsObjectMathType

        /// <summary>
        /// Проверяет соответствует ли объект указанному типу
        /// </summary>
        /// <param name="obj">Объект для проверки</param>
        /// <param name="type">Нужный тип</param>
        /// <returns></returns>
        public static bool IsObjectMathType(object obj, Type type)
        {
            // Тип не может быть Null
            if (null == type)
                throw new ArgumentException("Type cant be null", "type");

            // Если желаемый тип Nullable, то объет может быть Null
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) && null == obj)
                return true;

            // Если тип данных строковой то не нужно проверять
            // у строк нет метода Parse
            if (type == typeof(string))
                return true;

            try
            {
                // Для проверки вызовем метод Parse
                type
                    .GetMethod("Parse", new[] { typeof(string) })
                    .Invoke(Activator.CreateInstance(type), new object[] { obj.ToString() });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Проверяет соответствует ли объект указанному типу
        /// </summary>
        /// <param name="obj">Объект для проверки</param>
        /// <param name="typeName">Нужный тип</param>
        /// <returns></returns>
        public static bool IsObjectMathType(object obj, string typeName)
        {
            return IsObjectMathType(obj, ConstructType(typeName));
        }

        /// <summary>
        /// Проверяет соответствует ли объект указанному типу
        /// </summary>
        /// <param name="obj">Объект для проверки</param>
        /// <typeparam name="T">Нужный тип</typeparam>
        /// <returns></returns>
        public static bool IsObjectMathType<T>(object obj)
        {
            return IsObjectMathType(obj, typeof(T));
        }

        #endregion

        /// <summary>
        /// Воссоздает тип по его строковому представлению
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static Type ConstructType(string typeName)
        {
            if (!_typeCache.ContainsKey(typeName))
                _typeCache.Add(typeName, Type.GetType(string.Format("System.{0}", typeName)));

            return _typeCache[typeName];
        }
    }
}
