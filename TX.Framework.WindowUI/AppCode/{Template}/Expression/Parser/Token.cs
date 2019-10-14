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
    internal class Token
    {
        private readonly TokenDefinition _tokenDefinition;
        private readonly string _text;
        internal int NumTerms = 0;
        private Token _alternate;

        internal Token(TokenDefinition tokenDefinition, string text)
        {
            _text = text;
            _tokenDefinition = tokenDefinition;

            switch (tokenDefinition.Type)
            {
                case TokenType.TernaryOperator: NumTerms = 3; break;
                case TokenType.UnaryOperator: NumTerms = 1; break;
                case TokenType.Operator: NumTerms = 2; break;
            }

            if (_tokenDefinition.Alternate != null)
                _alternate = new Token(_tokenDefinition.Alternate, text);
        }

        internal TokenType TokenType
        {
            get { return _tokenDefinition.Type; }
        }

        internal OperatorAssociativity Associativity
        {
            get { return _tokenDefinition.Associativity; }
        }

        internal int Precedence
        {
            get { return _tokenDefinition.Precedence; }
        }

        internal string Text
        {
            get { return _text; }
        }

        internal TokenEvaluator TokenEvaluator
        {
            get { return _tokenDefinition.Evaluator; }
        }

        internal bool IsOperator
        {
            get { return (TokenType == TokenType.Operator) || (TokenType == TokenType.UnaryOperator); }
        }

        internal bool IsTerm
        {
            get { return (TokenType == TokenType.Term); }
        }

        internal bool IsUnary
        {
            get { return (TokenType == TokenType.UnaryOperator); }
        }

        internal bool IsFunction
        {
            get { return (TokenType == TokenType.FunctionCall); }
        }

        internal bool IsLeftParen
        {
            get { return (TokenType == TokenType.LeftParen); }
        }

        internal bool IsRightParen
        {
            get { return (TokenType == TokenType.RightParen); }
        }

        internal bool IsArgumentSeparator
        {
            get { return TokenType == TokenType.ArgumentSeparator; }
        }

        public bool IsPartial
        {
            get { return _tokenDefinition.IsPartial; }
        }

        public Token Alternate
        {
            get { return _alternate; }
            set { _alternate = value; }
        }

        public TokenDefinition Root
        {
            get { return _tokenDefinition.Root; }
        }

        public override string ToString()
        {
            return _text;
        }
    }
}
