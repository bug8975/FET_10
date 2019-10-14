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

namespace System.Text.Template
{
    public class CoalesceExpression : Expression
    {
        private readonly Expression _value;
        private readonly Expression _valueIfNull;

        public CoalesceExpression(Expression value, Expression valueIfNull)
        {
            _value = value;
            _valueIfNull = valueIfNull;
        }

        public override ValueExpression Evaluate(ITemplateContext context)
        {
            ValueExpression result = _value.Evaluate(context);

            if (result.Value == null)
                return _valueIfNull.Evaluate(context);

            return result;
        }

        public override string ToString()
        {
            return "(" + _value + " ?? " + _valueIfNull + ")";
        }
    }
}
