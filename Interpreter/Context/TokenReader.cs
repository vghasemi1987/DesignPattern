﻿using System.Collections.Generic;
using System.Linq;
using Interpreter.Expression;

namespace Interpreter.Context
{
    public class TokenReader
    {
        //"+ - 10 2 3"
        public IExpression ReadToken(List<string> tokenList)
        {
            return ReadNextToken(tokenList);
        }

        private IExpression ReadNextToken(List<string> tokenList)
        {
            if (int.TryParse(tokenList.First(), out var i))  //if the token is integer (terminal)
            {
                tokenList.RemoveAt(0);   //process terminal expression
                return new NumberExpression(i);
            }

            return ReadNonTerminal(tokenList);  //process nonTerminal expression
        }

        private IExpression ReadNonTerminal(List<string> tokenList)
        {
            string token = tokenList.First();
            tokenList.RemoveAt(0);   //read the symbol

            IExpression left = ReadNextToken(tokenList); //read left expression
            IExpression right = ReadNextToken(tokenList);  //read right expression

            if (token == "+") return new AddExpression(left, right);

            if (token == "-") return new SubtractExpression(left, right);

            return null;
        }
    }
}