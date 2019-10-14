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
    internal abstract class AttributeEmitter : BaseEmitter_
    {
        protected AttributeEmitter(CallInfo_ callInfo, DelegateCache cache)
            : base(callInfo, cache)
        {
        }

        protected MethodInfo GetPropertyGetMethod()
        {
            return GetPropertyMethod("get_", "Getter");
        }

        protected MethodInfo GetPropertySetMethod()
        {
            return GetPropertyMethod("set_", "Setter");
        }

        private MethodInfo GetPropertyMethod(string infoPrefix, string errorPrefix)
        {
            MethodInfo setMethod = CallInfo.TargetType.GetMethod(infoPrefix + CallInfo.Name, BindingFlags.Public | BindingFlags.NonPublic | ScopeFlag);
            if (setMethod == null)
            {
                throw new MissingMemberException(errorPrefix + " method for property " + CallInfo.Name + " does not exist");
            }
            return setMethod;
        }

        protected MemberInfo GetAttribute(CallInfo_ call)
        {
            if (call.MemberTypes == MemberTypes.Property)
            {
                PropertyInfo member = call.TargetType.GetProperty(call.Name, BindingFlags.NonPublic | BindingFlags.Public | ScopeFlag);
                if (member != null)
                {
                    return member;
                }
                throw new MissingMemberException((call.IsStatic ? "Static property" : "Property") + " '" + call.Name + "' does not exist");
            }
            if (call.MemberTypes == MemberTypes.Field)
            {
                FieldInfo field = call.TargetType.GetField(call.Name, BindingFlags.NonPublic | BindingFlags.Public | ScopeFlag);
                if (field != null)
                {
                    return field;
                }
                throw new MissingFieldException((call.IsStatic ? "Static field" : "Field") + " '" + call.Name + "' does not exist");
            }
            throw new ArgumentException(call.MemberTypes + " is not supported");
        }
    }
}
