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
    internal class SetNode : ExpressionNode
    {
        private string _Variable;

        public SetNode(TokenMatch tokenMatch)
            : base(tokenMatch)
        {
            _Variable = tokenMatch.SubMatches["variable"];
        }

        public override void Evaluate(IExpressionParser parser, ITemplateContext context, StringBuilder output)
        {
            IValueType value = parser.Parse(this.Expression).Evaluate(context);
            context.Add(_Variable, value.Value, value.Type);
        }

        public static explicit operator SetNode(TokenMatch tokenMatch)
        {
            return new SetNode(tokenMatch);
        }

        public string Variable
        {
            get { return this._Variable; }
            set { this._Variable = value; }
        }
    }
}
