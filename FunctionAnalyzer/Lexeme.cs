using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionAnalyzer
{
    public struct TypeLexeme
    {
        public static readonly int number = 0; //Число
        public static readonly int leftBracket = 1; //Левая скобка
        public static readonly int rightBracket = 2; //Правая скобка
        public static readonly int operation = 3; //Знак операции
        public static readonly int variable = 4; //Переменная
    }
    public class Lexeme
    {
        private string token;
        private int id;
        public string Token
        {
            get
            {
                return token;
            }
            set
            {
                token = value;
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public Lexeme(string token, int id)
        {
            this.token = token;
            this.id = id;
        }
        public override string ToString() //Служебный метод
        {
            return this.Token;
        }
        public static List<Lexeme> SplitIntoTokens(string exp)
        {
            List<Lexeme> lexemes = new List<Lexeme>();
            for(int i = 0; i < exp.Length; i++)
            {
                if(exp[i] == '+')
                {
                    lexemes.Add(new Lexeme("+", TypeLexeme.operation));
                    continue;
                }
                if (exp[i] == '-')
                {
                    lexemes.Add(new Lexeme("-", TypeLexeme.operation));
                    continue;
                }
                if (exp[i] == '*')
                {
                    lexemes.Add(new Lexeme("*", TypeLexeme.operation));
                    continue;
                }
                if (exp[i] == '/')
                {
                    lexemes.Add(new Lexeme("/", TypeLexeme.operation));
                    continue;
                }
                if (exp[i] == '^')
                {
                    lexemes.Add(new Lexeme("^", TypeLexeme.operation));
                    continue;
                }
                if (exp[i] == '(')
                {
                    lexemes.Add(new Lexeme("(", TypeLexeme.leftBracket));
                    continue;
                }
                if (exp[i] == ')')
                {
                    lexemes.Add(new Lexeme(")", TypeLexeme.rightBracket));
                    continue;
                }
                if(exp[i] >= 'A' && exp[i] <= 'Z')
                {
                    lexemes.Add(new Lexeme(Convert.ToString(exp[i]), TypeLexeme.variable));
                    continue;
                }
                if(exp[i] >= '0' && exp[i] <= '9')
                {
                    int startIndex = i;
                    int length = 0;
                    for(int j = startIndex; j < exp.Length; j++)
                    {
                        if(exp[j] == ',' || exp[j] >= '0' && exp[j] <= '9')
                        {
                            length++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    lexemes.Add(new Lexeme(exp.Substring(startIndex, length), TypeLexeme.number));
                    i += length-1;
                    continue;
                }
                if(exp.Substring(i, 2) == "ln")
                {
                    lexemes.Add(new Lexeme(exp.Substring(i, 2), TypeLexeme.operation));
                    i += 1;
                    continue;
                }
                if (exp.Substring(i, 3) == "log" || exp.Substring(i, 3) == "sin" || exp.Substring(i, 3) == "cos" 
                    || exp.Substring(i, 3) == "tan" || exp.Substring(i, 3) == "ctg")
                {
                    lexemes.Add(new Lexeme(exp.Substring(i, 3), TypeLexeme.operation));
                    i += 2;
                    continue;
                }
                if (exp.Substring(i, 4) == "sqrt")
                {
                    lexemes.Add(new Lexeme(exp.Substring(i, 4), TypeLexeme.operation));
                    i += 3;
                    continue;
                }
            }
            return lexemes;
        }
        public static List<Lexeme> SubLexemes(List<Lexeme> lexemes, int start, int length)
        {
            List<Lexeme> subLexemes = new List<Lexeme>();
            if(lexemes[start].id == TypeLexeme.leftBracket && lexemes[start+length-1].id == TypeLexeme.rightBracket)
            {
                for (int i = start + 1; i < start + length - 1; i++)
                {
                    subLexemes.Add(lexemes[i]);
                }
            }
            else
            {
                for (int i = start; i < start + length; i++)
                {
                    subLexemes.Add(lexemes[i]);
                }
            }
            return subLexemes;
        }
    }
}
