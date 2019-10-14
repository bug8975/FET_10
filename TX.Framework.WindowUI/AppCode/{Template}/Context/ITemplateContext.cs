#region COPYRIGHT
//
//     THIS IS GENERATED BY TEMPLATE
//     
//     AUTHOR  :     ROYE
//     DATE       :     2010
//
//     COPYRIGHT (C) 2010, TIANXIAHOTEL TECHNOLOGIES CO., LTD. ALL RIGHTS RESERVED.
//
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace System.Text.Template
{
    public interface ITemplateContext
    {
        ITemplateContext CreateLocal();

        void Clear();
        
        void Add(string key, object value, Type type);
        void Add<T>(string key, T value);
        void AddLocal(string key, object value, Type type);
        void AddLocal<T>(string key, T value);

        void AddType(string name, Type type);
        void AddFunction(string name, Type type, string methodName);
        void AddFunction(string name, Type type, string methodName, object targetObject);
        void AddFunction(string name, MethodInfo methodInfo);
        void AddFunction(string name, MethodInfo methodInfo, object targetObject);

        bool TryGetValue(string key, out IValueType valueType);

        bool ContainsKey(string key);
        IValueType this[string key] { get;set;}

        bool ToBoolean(object value);
        bool ReturnNullWhenNullReference { get; set; }
        bool NullIsFalse { get; set; }
        bool NotNullIsTrue { get; set; }
        bool EmptyStringIsFalse { get; set; }
        bool NonEmptyStringIsTrue { get; set; }
        bool EmptyCollectionIsFalse { get; set; }
        bool NotZeroIsTrue { get; set; }
        AssignmentPermissions AssignmentPermissions { get; set; }
    }
}
