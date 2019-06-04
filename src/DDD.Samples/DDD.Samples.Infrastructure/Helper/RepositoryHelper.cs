using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DDD.Samples.Infrastructure.Helper
{
    public class RepositoryHelper
    {
        /// <summary>
        /// 通过反射设置对象的字段值
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="fieldName"></param>
        /// <param name="newValue"></param>
        public static void SetFieldWhenReconstitutingFromPersistence(object instance, string fieldName, object newValue)
        {
            Type t = instance.GetType();
            System.Reflection.FieldInfo fieldInfo = t.GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            fieldInfo.SetValue(instance, newValue);

        }
    }
}
