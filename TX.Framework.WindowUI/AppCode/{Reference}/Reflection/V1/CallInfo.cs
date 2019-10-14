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

namespace System.Reflection.Emit
{
    internal class CallInfo_
    {
        private static readonly Type[] _EmptyTypeArray = new Type[0];

        public CallInfo_(Type targetType, MemberTypes memberTypes, string name)
            : this(targetType, memberTypes, name, _EmptyTypeArray)
        {
        }

        public CallInfo_(Type targetType, MemberTypes memberTypes, string name, Type[] paramTypes)
        {
            TargetType = targetType;
            MemberTypes = memberTypes;
            Name = name;
            ParamTypes = paramTypes;
        }

        #region CallInfo Construction

        public static CallInfo_ CreateStaticSetCallInfo(Type targetType, MemberTypes memberTypes, string fieldOrProperty, object value)
        {
            return new CallInfo_(targetType, memberTypes, fieldOrProperty, Constants.ArrayOfObjectType)
            {
                IsStatic = true,
                Parameters = new[] { value }
            };
        }

        public static CallInfo_ CreateStaticGetCallInfo(Type targetType, MemberTypes memberTypes, string fieldOrPropertyName)
        {
            return new CallInfo_(targetType, memberTypes, fieldOrPropertyName) { IsStatic = true };
        }

        public static CallInfo_ CreateSetCallInfo(Type targetType, object target, MemberTypes memberTypes, string fieldOrProperty, object value)
        {
            return new CallInfo_(targetType, memberTypes, fieldOrProperty, Constants.ArrayOfObjectType)
            {
                Target = target,
                Parameters = new[] { value }
            };
        }

        public static CallInfo_ CreateGetCallInfo(Type targetType, object target, MemberTypes memberTypes, string fieldOrPropertyName)
        {
            return new CallInfo_(targetType, memberTypes, fieldOrPropertyName) { Target = target };
        }

        public static CallInfo_ GetConstructorCallInfo(Type targetType, Type[] paramTypes, object[] parameters)
        {
            return new CallInfo_(targetType, MemberTypes.Constructor, targetType.Name, paramTypes) { Parameters = parameters };
        }

        public static CallInfo_ CreateIndexerSetCallInfo(Type targetType, object target, Type[] paramTypes, object[] parameters)
        {
            return new CallInfo_(targetType, MemberTypes.Method, Constants.IndexerSetterName, paramTypes)
            {
                Parameters = parameters,
                Target = target
            };
        }

        public static CallInfo_ CreateIndexerGetCallInfo(Type targetType, object target, Type[] paramTypes, object[] parameters)
        {
            return new CallInfo_(targetType, MemberTypes.Method, Constants.IndexerGetterName, paramTypes)
            {
                Parameters = parameters,
                Target = target
            };
        }

        public static CallInfo_ CreateStaticMethodCallInfo(Type targetType, string methodName, Type[] paramTypes, object[] parameters)
        {
            return new CallInfo_(targetType, MemberTypes.Method, methodName, paramTypes)
            {
                IsStatic = true,
                Parameters = parameters
            };
        }

        public static CallInfo_ CreateMethodCallInfo(Type targetType, object target, string methodName, Type[] paramTypes, object[] parameters)
        {
            return new CallInfo_(targetType, MemberTypes.Method, methodName, paramTypes)
            {
                Parameters = parameters,
                Target = target
            };
        }

        #endregion

        /// <summary>
        /// Two <code>CallInfo</code> instances are considered equaled if the following properties
        /// are equaled: <code>TargetType</code>, <code>MemberTypes</code>, <code>Name</code>,
        /// and <code>ParamTypes</code>.
        /// </summary>
        public override bool Equals(object obj)
        {
            var other = obj as CallInfo_;
            if (other == null) return false;
            if (other == this) return true;
            if (other.TargetType != TargetType ||
                other.MemberTypes != MemberTypes ||
                other.Name != Name ||
                other.ParamTypes.Length != ParamTypes.Length)
            {
                return false;
            }
            for (int i = 0; i < ParamTypes.Length; i++)
            {
                if (ParamTypes[i] != other.ParamTypes[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = 7;
            hashCode = 31 * hashCode + TargetType.GetHashCode();
            hashCode = 31 * hashCode + Name.GetHashCode();
            for (int i = 0; i < ParamTypes.Length; i++)
                hashCode = 31 * hashCode + ParamTypes[i].GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// 
        /// </summary>
        public Type TargetType { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public MemberTypes MemberTypes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type[] ParamTypes { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsStatic { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Target { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object[] Parameters { get; set; }
    }
}
