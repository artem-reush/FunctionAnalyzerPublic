using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionAnalyzer
{
    public class Node
    {
        private int parent;
        private int left;
        private int right;
        private List<Lexeme> lexemes;
        public override string ToString()
        {
            return "Par: " + Parent + " L: " + Left + " R: " + Right + " Lex[0]: " + lexemes[0];
        }
        public int Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }
        public int Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }
        public int Right
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
            }
        }
        public List<Lexeme> Lexemes
        {
            get
            {
                return lexemes;
            }
            set
            {
                lexemes = value;
            }
        }
        public Node(int parent, int left, int right, List<Lexeme> lexemes)
        {
            this.parent = parent;
            this.left = left;
            this.right = right;
            this.lexemes = lexemes;
        }
    }
}
