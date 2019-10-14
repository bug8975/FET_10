﻿#region COPYRIGHT
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
using System.Linq;
using System.Text;
using System.Reflection.Emit;

namespace System.Reflection
{
    public class Reflector
    {
        private readonly DelegateCache cache = new DelegateCache();

        private Reflector()
        {
        }

        public static Reflector Create()
        {
            return new Reflector();
        }

        #region Construction

        public object Construct(Type targetType)
        {
            return Construct(targetType, Type.EmptyTypes, Constants.EmptyObjectArray);
        }

        public object Construct(Type targetType, Type[] paramTypes, object[] parameters)
        {
            CallInfo_ callInfo = CallInfo_.GetConstructorCallInfo(targetType, paramTypes, parameters);
            return new CtorInvocationEmitter_(callInfo, cache).Execute<object>();
        }

        public ConstructorInvoker DelegateForConstruct(Type targetType)
        {
            return DelegateForConstruct(targetType, Type.EmptyTypes);
        }

        public ConstructorInvoker DelegateForConstruct(Type targetType, Type[] paramTypes)
        {
            CallInfo_ callInfo = CallInfo_.GetConstructorCallInfo(targetType, paramTypes, null);
            return (ConstructorInvoker)new CtorInvocationEmitter_(callInfo, cache).GetDelegate();
        }

        #endregion

        #region Batch Setters/Getters

        public Reflector SetProperties(Type targetType, object obj)
        {
            obj.GetProperties().ForEach(prop =>
                SetProperty(targetType, prop.Name, prop.GetValue(obj))
            );
            return this;
        }

        public Reflector SetProperties(object target, object obj)
        {
            obj.GetProperties().ForEach(prop =>
                SetProperty(target, prop.Name, prop.GetValue(obj))
            );
            return this;
        }

        public Reflector SetFields(object target, object obj)
        {
            obj.GetProperties().ForEach(prop =>
                SetField(target, prop.Name, prop.GetValue(obj))
            );
            return this;
        }

        public Reflector SetFields(Type targetType, object obj)
        {
            obj.GetProperties().ForEach(prop =>
                SetField(targetType, prop.Name, prop.GetValue(obj))
            );
            return this;
        }

        #endregion

        #region Static Setters

        public Reflector SetProperty(Type targetType, string propertyName, object value)
        {
            return SetFieldOrProperty(targetType, MemberTypes.Property, propertyName, value);
        }

        public StaticAttributeSetter DelegateForSetStaticProperty(Type targetType, string propertyName)
        {
            return DelegateForSetStaticFieldOrProperty(targetType, MemberTypes.Property, propertyName);
        }

        public Reflector SetField(Type targetType, string fieldName, object value)
        {
            return SetFieldOrProperty(targetType, MemberTypes.Field, fieldName, value);
        }

        public StaticAttributeSetter DelegateForSetStaticField(Type targetType, string fieldName)
        {
            return DelegateForSetStaticFieldOrProperty(targetType, MemberTypes.Field, fieldName);
        }

        private Reflector SetFieldOrProperty(Type targetType, MemberTypes memberTypes, string fieldOrProperty, object value)
        {
            CallInfo_ callInfo = CallInfo_.CreateStaticSetCallInfo(targetType, memberTypes, fieldOrProperty, value);
            new AttributeSetEmitter(callInfo, cache).Execute();
            return this;
        }

        private StaticAttributeSetter DelegateForSetStaticFieldOrProperty(Type targetType, MemberTypes memberTypes, string fieldOrProperty)
        {
            CallInfo_ callInfo = CallInfo_.CreateStaticSetCallInfo(targetType, memberTypes, fieldOrProperty, null);
            return (StaticAttributeSetter)new AttributeSetEmitter(callInfo, cache).GetDelegate();
        }

        #endregion

        #region Static Getters

        public TReturn GetProperty<TReturn>(Type targetType, string propertyName)
        {
            return GetFieldOrProperty<TReturn>(targetType, MemberTypes.Property, propertyName);
        }

        public StaticAttributeGetter DelegateForGetStaticProperty(Type targetType, string propertyName)
        {
            return DelegateForGetStaticFieldOrProperty(targetType, MemberTypes.Property, propertyName);
        }

        public TReturn GetField<TReturn>(Type targetType, string fieldName)
        {
            return GetFieldOrProperty<TReturn>(targetType, MemberTypes.Field, fieldName);
        }

        public StaticAttributeGetter DelegateForGetStaticField(Type targetType, string fieldName)
        {
            return DelegateForGetStaticFieldOrProperty(targetType, MemberTypes.Field, fieldName);
        }

        private TReturn GetFieldOrProperty<TReturn>(Type targetType, MemberTypes memberTypes, string fieldOrPropertyName)
        {
            CallInfo_ callInfo = CallInfo_.CreateStaticGetCallInfo(targetType, memberTypes, fieldOrPropertyName);
            return new AttributeGetEmitter(callInfo, cache).Execute<TReturn>();
        }

        private StaticAttributeGetter DelegateForGetStaticFieldOrProperty(Type targetType, MemberTypes memberTypes, string fieldOrPropertyName)
        {
            CallInfo_ callInfo = CallInfo_.CreateStaticGetCallInfo(targetType, memberTypes, fieldOrPropertyName);
            return (StaticAttributeGetter)new AttributeGetEmitter(callInfo, cache).GetDelegate();
        }

        #endregion

        #region Instance Setters

        public Reflector SetProperty(object target, string propertyName, object value)
        {
            return SetFieldOrProperty(target, MemberTypes.Property, propertyName, value);
        }

        public AttributeSetter DelegateForSetProperty(Type targetType, string propertyName)
        {
            return DelegateForSetFieldOrProperty(targetType, MemberTypes.Property, propertyName);
        }

        public Reflector SetField(object target, string fieldName, object value)
        {
            return SetFieldOrProperty(target, MemberTypes.Field, fieldName, value);
        }

        public AttributeSetter DelegateForSetField(Type targetType, string propertyName)
        {
            return DelegateForSetFieldOrProperty(targetType, MemberTypes.Field, propertyName);
        }

        private Reflector SetFieldOrProperty(object target, MemberTypes memberTypes, string fieldOrProperty, object value)
        {
            CallInfo_ callInfo = CallInfo_.CreateSetCallInfo(target.GetType(), target, memberTypes, fieldOrProperty, value);
            new AttributeSetEmitter(callInfo, cache).Execute();
            return this;
        }

        private AttributeSetter DelegateForSetFieldOrProperty(Type targetType, MemberTypes memberTypes, string fieldOrProperty)
        {
            CallInfo_ callInfo = CallInfo_.CreateSetCallInfo(targetType, null, memberTypes, fieldOrProperty, null);
            return (AttributeSetter)new AttributeSetEmitter(callInfo, cache).GetDelegate();
        }

        #endregion

        #region Instance Getters

        public TReturn GetProperty<TReturn>(object target, string propertyName)
        {
            return GetFieldOrProperty<TReturn>(target, MemberTypes.Property, propertyName);
        }

        public AttributeGetter DelegateForGetProperty(Type targetType, string propertyName)
        {
            return DelegateForGetFieldOrProperty(targetType, MemberTypes.Property, propertyName);
        }

        public TReturn GetField<TReturn>(object target, string fieldName)
        {
            return GetFieldOrProperty<TReturn>(target, MemberTypes.Field, fieldName);
        }

        public AttributeGetter DelegateForGetField(Type targetType, string fieldName)
        {
            return DelegateForGetFieldOrProperty(targetType, MemberTypes.Field, fieldName);
        }

        private TReturn GetFieldOrProperty<TReturn>(object target, MemberTypes memberTypes, string fieldOrPropertyName)
        {
            CallInfo_ callInfo = CallInfo_.CreateGetCallInfo(target.GetType(), target, memberTypes, fieldOrPropertyName);
            return new AttributeGetEmitter(callInfo, cache).Execute<TReturn>();
        }

        private AttributeGetter DelegateForGetFieldOrProperty(Type targetType, MemberTypes memberTypes, string fieldOrPropertyName)
        {
            CallInfo_ callInfo = CallInfo_.CreateGetCallInfo(targetType, null, memberTypes, fieldOrPropertyName);
            return (AttributeGetter)new AttributeGetEmitter(callInfo, cache).GetDelegate();
        }

        #endregion

        #region Static Methods

        public Reflector Invoke(Type targetType, string methodName)
        {
            return Invoke(targetType, methodName, Type.EmptyTypes, Constants.EmptyObjectArray);
        }

        public Reflector Invoke(Type targetType, string methodName, Type[] paramTypes, object[] parameters)
        {
            CallInfo_ callInfo = CallInfo_.CreateStaticMethodCallInfo(targetType, methodName, paramTypes, parameters);
            new MethodInvocationEmitter_(callInfo, cache).Execute();
            return this;
        }

        public TReturn Invoke<TReturn>(Type targetType, string methodName)
        {
            return Invoke<TReturn>(targetType, methodName, Type.EmptyTypes, Constants.EmptyObjectArray);
        }

        public TReturn Invoke<TReturn>(Type targetType, string methodName, Type[] paramTypes, object[] parameters)
        {
            CallInfo_ callInfo = CallInfo_.CreateStaticMethodCallInfo(targetType, methodName, paramTypes, parameters);
            return new MethodInvocationEmitter_(callInfo, cache).Execute<TReturn>();
        }

        public StaticMethodInvoker DelegateForStaticInvoke(Type targetType, string methodName)
        {
            return DelegateForStaticInvoke(targetType, methodName, Type.EmptyTypes);
        }

        public StaticMethodInvoker DelegateForStaticInvoke(Type targetType, string methodName, Type[] paramTypes)
        {
            CallInfo_ callInfo = CallInfo_.CreateStaticMethodCallInfo(targetType, methodName, paramTypes, null);
            return (StaticMethodInvoker)new MethodInvocationEmitter_(callInfo, cache).GetDelegate();
        }

        #endregion

        #region Instance Methods

        public Reflector Invoke(object target, string methodName)
        {
            return Invoke(target, methodName, Type.EmptyTypes, Constants.EmptyObjectArray);
        }

        public Reflector Invoke(object target, string methodName, Type[] paramTypes, object[] parameters)
        {
            CallInfo_ callInfo = CallInfo_.CreateMethodCallInfo(target.GetType(), target, methodName, paramTypes, parameters);
            new MethodInvocationEmitter_(callInfo, cache).Execute();
            return this;
        }

        public TReturn Invoke<TReturn>(object target, string methodName)
        {
            return Invoke<TReturn>(target, methodName, Type.EmptyTypes, Constants.EmptyObjectArray);
        }

        public TReturn Invoke<TReturn>(object target, string methodName, Type[] paramTypes, object[] parameters)
        {
            CallInfo_ callInfo = CallInfo_.CreateMethodCallInfo(target.GetType(), target, methodName, paramTypes, parameters);
            return new MethodInvocationEmitter_(callInfo, cache).Execute<TReturn>();
        }

        public MethodInvoker DelegateForInvoke(Type targetType, string methodName)
        {
            return DelegateForInvoke(targetType, methodName, Type.EmptyTypes);
        }

        public MethodInvoker DelegateForInvoke(Type targetType, string methodName, Type[] paramTypes)
        {
            CallInfo_ callInfo = CallInfo_.CreateMethodCallInfo(targetType, null, methodName, paramTypes, null);
            return (MethodInvoker)new MethodInvocationEmitter_(callInfo, cache).GetDelegate();
        }

        #endregion

        #region Indexers

        public Reflector SetIndexer(object target, Type[] paramTypes, object[] parameters)
        {
            CallInfo_ callInfo = CallInfo_.CreateIndexerSetCallInfo(target.GetType(), target, paramTypes, parameters);
            new MethodInvocationEmitter_(callInfo, cache).Execute();
            return this;
        }

        public TReturn GetIndexer<TReturn>(object target, Type[] paramTypes, object[] parameters)
        {
            CallInfo_ callInfo = CallInfo_.CreateIndexerGetCallInfo(target.GetType(), target, paramTypes, parameters);
            return new MethodInvocationEmitter_(callInfo, cache).Execute<TReturn>();
        }

        public MethodInvoker DelegateForSetIndexer(Type targetType, Type[] paramTypes)
        {
            CallInfo_ callInfo = CallInfo_.CreateIndexerSetCallInfo(targetType, null, paramTypes, null);
            return (MethodInvoker)new MethodInvocationEmitter_(callInfo, cache).GetDelegate();
        }

        public MethodInvoker DelegateForGetIndexer(Type targetType, Type[] paramTypes)
        {
            CallInfo_ callInfo = CallInfo_.CreateIndexerGetCallInfo(targetType, null, paramTypes, null);
            return (MethodInvoker)new MethodInvocationEmitter_(callInfo, cache).GetDelegate();
        }

        #endregion
    }
}
