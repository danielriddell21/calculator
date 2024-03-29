﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public static class EquationHelper
    {
        public static string RemoveWhitespace(string _input)
        {
            return _input = _input.Replace(" ", string.Empty);
        }

        public static bool IsCharacterIn(char _input, IEnumerable<char> characterArray) => characterArray.Contains(_input);

        public static bool IsCharacterNumber(char _input) => IsCharacterIn(_input,
            new char[11] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.'});

        public static List<char> orderedOperators = new List<char>() { '-', '+', '*', '/', '^' };

        public static bool IsCharacterOperator(char _input) => IsCharacterIn(_input, orderedOperators);

        public static bool IsCharacterBracket(char _input) => IsCharacterIn(_input,
            new char[2] { '(', ')' });

        public static bool IsStringNumber(string _input) => !_input.Any(c => !IsCharacterNumber(c));

        public static bool IsWholeEquationWithinBrackets(string _input)
        {
            if (_input[0] == '(' && _input[_input.Length - 1] == ')') return true;
            return false;
        }

        public  static bool EquationContainsAnUnbracketedOperator(string _input)
        {
            foreach (var op in orderedOperators)
            {
                var bracketCounter = 0;
                for (int i = 0; i < _input.Length; i++)
                {
                    if (_input[i] == '(') bracketCounter++;
                    else if (_input[i] == ')') bracketCounter--;

                    if (_input[i] == op && bracketCounter == 0) return false;
                }
            }
            return true;
        }

        public static bool IsBracketsValid(string _input, bool IsCharacterBracket)
        {
            if (IsCharacterBracket)
            {
                int bracketCounter = 0;
                for (int i = 0; i < _input.Length; i++)
                {
                    if (_input.Length != 2)
                    {
                        if (_input[i] == '(') bracketCounter++;
                        else if (_input[i] == ')') bracketCounter--;
                    }
                    else
                    {
                        return false;
                    }
                }
                if (bracketCounter == 0) return true;
                return false;
            }
            return true;
        }
        public static bool IsNumberMultipleDecimal(string _input)
        {
            var numberBuilder = new StringBuilder();
            foreach (var _character in _input)
            {
                if (numberBuilder.ToString() == ".")
                {
                    return true;
                }
                if (_character == '.')
                {
                    numberBuilder.Append(_character);
                }
                if(IsCharacterBracket(_character) || IsCharacterOperator(_character))
                {
                    numberBuilder.Clear();
                }
            }
            return false;
        }

        public static bool IsOperatorDuplicated(string _input)
        {
            var operatorCheck = new StringBuilder();
            foreach (var _op in orderedOperators)
            {
                for (int i = 0; i < _input.Length; i++)
                {
                    if (_input[i] == _op)
                    {
                        operatorCheck.Append(_input[i]);
                        if (operatorCheck.Length == 2) return true;
                    }
                    else operatorCheck.Clear();
                }
            }
            return false;
        }
        public static bool IsLastCharacterAOperator(string _input)
        {
            char lastChar = _input.Substring(_input.Length - 1)[0];
            if (IsCharacterOperator(lastChar)) return true;
            return false;
        }
    }
}
