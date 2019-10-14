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
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace System.Text.Template
{
    public class TemplateContext : ITemplateContext
    {
        private readonly Dictionary<string, object> _Variables = new Dictionary<string, object>();
        private readonly Dictionary<string, Type> _Types = new Dictionary<string, Type>();
        private readonly ITemplateContext _Parent;

        private bool _NullIsFalse;
        private bool _NotNullIsTrue;
        private bool _NotZeroIsTrue;
        private bool _EmptyStringIsFalse;
        private bool _NonEmptyStringIsTrue;
        private bool _ReturnNullWhenNullReference;
        private bool _EmptyCollectionIsFalse;
        private AssignmentPermissions _AssignmentPermissions = AssignmentPermissions.None;
       
        public TemplateContext()
        {
            this.NullIsFalse = true;
        }

        protected TemplateContext(TemplateContext parent)
        {
            _Parent = parent;
            _AssignmentPermissions = parent.AssignmentPermissions;
            _NullIsFalse = parent.NullIsFalse;
            _NotNullIsTrue = parent.NotNullIsTrue;
            _NotZeroIsTrue = parent.NotZeroIsTrue;
            _EmptyStringIsFalse = parent.EmptyStringIsFalse;
            _NonEmptyStringIsTrue = parent.NonEmptyStringIsTrue;
            _ReturnNullWhenNullReference = parent.ReturnNullWhenNullReference;
            _EmptyCollectionIsFalse = parent.EmptyCollectionIsFalse;
        }

        public void AddType(string name, Type type)
        {
            Add(name, ContextFactory.CreateType(type));
        }

        public void AddFunction(string name, Type type, string methodName)
        {
            Add(name, ContextFactory.CreateFunction(type, methodName));
        }

        public void AddFunction(string name, Type type, string methodName, object targetObject)
        {
            Add(name, ContextFactory.CreateFunction(type, methodName, targetObject));
        }

        public void AddFunction(string name, MethodInfo methodInfo)
        {
            Add(name, ContextFactory.CreateFunction(methodInfo));
        }

        public void AddFunction(string name, MethodInfo methodInfo, object targetObject)
        {
            Add(name, ContextFactory.CreateFunction(methodInfo, targetObject));
        }

        #region ITemplateContext Members

        public virtual ITemplateContext CreateLocal()
        {
            return new TemplateContext(this);
        }

        public void Add(string key, object value, Type type)
        {
            if (_Parent != null && _Parent.ContainsKey(key))
            {
                _Parent.Add(key, value, type);
            }
            AddLocal(key, value, type);
        }

        public void Add<T>(string key, T value)
        {
            Add(key, value, typeof(T));
        }

        public void AddLocal(string key, object value, Type type)
        {
            _Variables[key] = value;
            _Types[key] = type;
        }

        public void AddLocal<T>(string key, T value)
        {
            AddLocal(key, value, typeof(T));
        }

        public bool ContainsKey(string key)
        {
            if (_Variables.ContainsKey(key))
                return true;

            if (_Parent == null || !_Parent.ContainsKey(key))
                return false;
         
            return true;
        }

        public bool ToBoolean(object value)
        {
            if (value is bool)
                return ((bool)value);

            if (_NotZeroIsTrue)
            {
                if (value is int || value is uint || value is short || value is ushort || value is long || value is ulong || value is byte || value is sbyte)
                    return Convert.ToInt64(value) != 0;

                if (value is decimal)
                    return (decimal)value != 0m;

                if (value is float || value is double)
                    return Convert.ToDouble(value) == 0.0;
            }

            if (value is ICollection && _EmptyCollectionIsFalse)
                return ((ICollection)value).Count > 0;

            if (value is IEnumerable && _EmptyCollectionIsFalse)
            {
                IEnumerator enumerator = ((IEnumerable)value).GetEnumerator();
                if (enumerator.MoveNext())
                    return true;
                return false;
            }

            if (_NonEmptyStringIsTrue && (value is string) && ((string)value).Length > 0)
                return true;

            if (_EmptyStringIsFalse && (value is string) && ((string)value).Length == 0)
                return false;

            if (_NotNullIsTrue && value != null)
                return true;

            if (_NullIsFalse && value == null)
                return false;

            if (_Parent != null)
                return _Parent.ToBoolean(value);

            throw new NullReferenceException();
        }

        public bool TryGetValue(string key, out IValueType valueType)
        {
            valueType = InternalGet(key);
            return valueType == null ? false : true;
        }

        private IValueType InternalGet(string key)
        {
            IValueType pair = null;
            if (_Variables.ContainsKey(key))
            {
                pair = new ValueTypePair();
                pair.Value = _Variables[key];
                pair.Type = _Types[key];
            }
            else if (_Parent != null)
            {
                pair = ((TemplateContext)_Parent).InternalGet(key);
            }
            if (pair != null)
            {
                if (pair.Value != null && pair.Type == typeof(object))
                {
                    pair.Type = pair.Value.GetType();
                }
            }
            return pair;
        }

        public void Clear()
        {
            _Variables.Clear();
            _Types.Clear();
        }

        public IValueType this[string key]
        {
            get { return InternalGet(key); }
            set { this.Add(key, value); }
        }

        #endregion

        public ITemplateContext Parent
        {
            get { return this._Parent; }
        }

        public bool ReturnNullWhenNullReference
        {
            get { return _ReturnNullWhenNullReference; }
            set { _ReturnNullWhenNullReference = value; }
        }

        public bool NullIsFalse
        {
            get { return _NullIsFalse; }
            set { _NullIsFalse = value; }
        }

        public bool NotNullIsTrue
        {
            get { return _NotNullIsTrue; }
            set { _NotNullIsTrue = value; }
        }

        public bool EmptyStringIsFalse
        {
            get { return _EmptyStringIsFalse; }
            set { _EmptyStringIsFalse = value; }
        }

        public bool NonEmptyStringIsTrue
        {
            get { return _NonEmptyStringIsTrue; }
            set { _NonEmptyStringIsTrue = value; }
        }

        public bool EmptyCollectionIsFalse
        {
            get { return _EmptyCollectionIsFalse; }
            set { _EmptyCollectionIsFalse = value; }
        }

        public bool NotZeroIsTrue
        {
            get { return _NotZeroIsTrue; }
            set { _NotZeroIsTrue = value; }
        }

        public AssignmentPermissions AssignmentPermissions
        {
            get { return _AssignmentPermissions; }
            set { _AssignmentPermissions = value; }
        }
    }
}
