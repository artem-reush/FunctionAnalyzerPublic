using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FunctionAnalyzer
{
    public class Tree
    {
        private struct FieldStatus
        {
            public static readonly int DoesNotExist = -1; //Пока не существует
            public static readonly int CannotExist = -2; //Не может существовать
        }
        private static int GetPriorityOperation(Lexeme lexeme)
        {
            switch (lexeme.Token)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                case "^":
                    return 3;
                case "sin":
                case "cos":
                case "tan":
                case "ctg":
                case "log":
                case "ln":
                case "sqrt":
                    return 4;
                default:
                   return -1; //Недостижимо при корректном входном выражении
            }
        }
        private static int GetIndexMostLowestPriorityToken(List<Lexeme> lexemes)
        {
            int minimumPriority = int.MaxValue;
            int requiredIndex = -1; //Изначальная инициализация, значение обязательно должно измениться
            int countOfLeftBracket = 0;
            for(int i = 0; i < lexemes.Count; i++)
            {
                if(lexemes[i].Id == TypeLexeme.leftBracket)
                {
                    countOfLeftBracket++;
                    continue;
                }
                if(lexemes[i].Id == TypeLexeme.rightBracket)
                {
                    countOfLeftBracket--;
                    continue;
                }
                if(countOfLeftBracket > 0)
                {
                    continue;
                }
                else
                {
                    if (lexemes[i].Id == TypeLexeme.operation)
                    {
                        int priorityCurrentOperation = GetPriorityOperation(lexemes[i]);
                        if (priorityCurrentOperation <= minimumPriority)
                        {
                            minimumPriority = priorityCurrentOperation;
                            requiredIndex = i;
                        }
                    }
                }
            }
            return requiredIndex;
        }
        private static bool ExistUnprocessedExpressions(List<Node> tree, int startIndex)
        {
            for(int i = startIndex; i < tree.Count; i++)
            {
                if(tree[i].Lexemes.Count > 1)
                {
                    return true;
                }
            }
            return false;
        }
        private static bool ThisNodeIsNotProcessed(List<Lexeme> lexemes)
        {
            if(lexemes.Count == 1)
            {
                return false;
            }
            return true;
        }
        public static List<Node> CreateTree(string exp)
        {
            List<Lexeme> lexemes = Lexeme.SplitIntoTokens(exp);
            List<Node> tree = new List<Node>();
            tree.Add(new Node(FieldStatus.CannotExist, FieldStatus.DoesNotExist, FieldStatus.DoesNotExist, lexemes));
            int currentIndexTree = 0;
            do
            {
                if (ThisNodeIsNotProcessed(tree[currentIndexTree].Lexemes))
                {
                    int targetLexemeIndex = GetIndexMostLowestPriorityToken(tree[currentIndexTree].Lexemes);
                    if(targetLexemeIndex == 0)
                    {
                        List<Lexeme> targetLexeme = Lexeme.SubLexemes(tree[currentIndexTree].Lexemes, targetLexemeIndex, 1);
                        List<Lexeme> leftLexemes = Lexeme.SubLexemes(tree[currentIndexTree].Lexemes, 1, tree[currentIndexTree].Lexemes.Count - targetLexemeIndex - 1);
                        tree[currentIndexTree].Lexemes = targetLexeme;
                        int leftIndex = tree.Count;
                        tree.Add(new Node(currentIndexTree, FieldStatus.CannotExist, FieldStatus.CannotExist, leftLexemes));
                        tree[currentIndexTree].Left = leftIndex;
                        tree[currentIndexTree].Right = FieldStatus.CannotExist;
                    }
                    else
                    {
                        List<Lexeme> targetLexeme = Lexeme.SubLexemes(tree[currentIndexTree].Lexemes, targetLexemeIndex, 1);
                        List<Lexeme> leftLexemes = Lexeme.SubLexemes(tree[currentIndexTree].Lexemes, 0, targetLexemeIndex);
                        List<Lexeme> rightLexemes = Lexeme.SubLexemes(tree[currentIndexTree].Lexemes, targetLexemeIndex + 1, tree[currentIndexTree].Lexemes.Count - targetLexemeIndex - 1);
                        tree[currentIndexTree].Lexemes = targetLexeme;
                        int leftIndex = tree.Count;
                        tree.Add(new Node(currentIndexTree, FieldStatus.CannotExist, FieldStatus.CannotExist, leftLexemes));
                        int rightIndex = tree.Count;
                        tree.Add(new Node(currentIndexTree, FieldStatus.CannotExist, FieldStatus.CannotExist, rightLexemes));
                        tree[currentIndexTree].Left = leftIndex;
                        tree[currentIndexTree].Right = rightIndex;
                    }
                }
                currentIndexTree++;
            } while (ExistUnprocessedExpressions(tree, currentIndexTree));
            return tree;
        }
        public static double GetValue(List<Node> tree, string unfixedVariable, string valueFixedVariables, double variableValue)
        {
            double result;
            for(int i = 0; i < tree.Count; i++)
            {
                if(tree[i].Lexemes[0].Id == TypeLexeme.variable)
                {
                    if(tree[i].Lexemes[0].Token == unfixedVariable)
                    {
                        tree[i].Lexemes[0].Token = Convert.ToString(variableValue);
                        tree[i].Lexemes[0].Id = TypeLexeme.number;
                    }
                    else
                    {
                        tree[i].Lexemes[0].Token = valueFixedVariables;
                        tree[i].Lexemes[0].Id = TypeLexeme.number;
                    }
                }
            }
            result = Calculate(CloningTree(tree), 0);
            return result;
        }
        public static List<Node> CloningTree(List<Node> tree)
        {
            List<Node> newTree = new List<Node>();
            for(int i = 0; i < tree.Count; i++)
            {
                List<Lexeme> newLexemes = new List<Lexeme>();
                for(int j = 0; j < tree[i].Lexemes.Count; j++)
                {
                    newLexemes.Add(new Lexeme(tree[i].Lexemes[j].Token, tree[i].Lexemes[j].Id));
                }
                newTree.Add(new Node(tree[i].Parent, tree[i].Left, tree[i].Right, newLexemes));
            }
            return newTree;
        }
        private static double Calculate(List<Node> tree, int index)
        {
            if(tree[index].Lexemes[0].Id == TypeLexeme.number)
            {
                return Convert.ToDouble(tree[index].Lexemes[0].Token);
            }
            switch (tree[index].Lexemes[0].Token)
            {
                case "+":
                    if (tree[index].Right == FieldStatus.CannotExist)
                    {
                        return Calculate(tree, tree[index].Left);
                    }
                    else
                    {
                        return Calculate(tree, tree[index].Left) + Calculate(tree, tree[index].Right);
                    }
                case "-":
                    if(tree[index].Right == FieldStatus.CannotExist)
                    {
                        return -Calculate(tree, tree[index].Left);
                    }
                    else
                    {
                        return Calculate(tree, tree[index].Left) - Calculate(tree, tree[index].Right);
                    }
                case "*":
                    return Calculate(tree, tree[index].Left) * Calculate(tree, tree[index].Right);
                case "/":
                    return Calculate(tree, tree[index].Left) / Calculate(tree, tree[index].Right);
                case "^":
                    return Math.Pow(Calculate(tree, tree[index].Left), Calculate(tree, tree[index].Right));
                case "sqrt":
                    return Math.Sqrt(Calculate(tree, tree[index].Left));
                case "log":
                    return Math.Log10(Calculate(tree, tree[index].Left));
                case "ln":
                    return Math.Log(Calculate(tree, tree[index].Left));
                case "sin":
                    return Math.Sin(Calculate(tree, tree[index].Left));
                case "cos":
                    return Math.Cos(Calculate(tree, tree[index].Left));
                case "tan":
                    return Math.Tan(Calculate(tree, tree[index].Left));
                case "ctg":
                    return 1.0 / Math.Tan(Calculate(tree, tree[index].Left));
            }
            return 0;
        }
        private static PointF[] GetPointsArray(List<Node> tree, string unfixedVariable, string valueFixedVariables)
        {
            const int multipler = 10;//чем больше, тем чаще берутся значения для X
            PointF[] points = new PointF[784*multipler];
            const double deltaX = 19.6 / (392 * multipler);
            double x = -19.6;
            for(int i = 0; i < 784*multipler; i++)
            {
                double y = GetValue(CloningTree(tree), unfixedVariable, valueFixedVariables, x);
                float xOnScreen = i/(float)multipler;
                float yOnScreen = 230 - (float)y * 20;
                points[i] = new PointF(xOnScreen, yOnScreen);
                x += deltaX;
            }
            return points;
        }
        public static void PrintGraph(List<Node> tree, string unfixedVariable, string valueFixedVariables)
        {
            PointF[] points = GetPointsArray(tree, unfixedVariable, valueFixedVariables);
            Graph graphForm = new Graph(points);
            graphForm.Show();

        }
        public static double FindRoot(List<Node> tree, string unfixedVariable, string valueFixedVariables, string accuracy, string a, string b, out bool status)
        {
            double left, right, e, x;
            const int maxIteration = 1000;
            status = false;
            left = Convert.ToDouble(a);
            right = Convert.ToDouble(b);
            e = Convert.ToDouble(accuracy);
            x = default;
            if(GetValue(CloningTree(tree), unfixedVariable, valueFixedVariables, left)*GetValue(CloningTree(tree), unfixedVariable, valueFixedVariables, right) < 0)
            {
                for(int i = 0; i < maxIteration; i++)
                {
                    x = (left + right) / 2.0;
                    if (Math.Abs(GetValue(CloningTree(tree), unfixedVariable, valueFixedVariables, x)) < e)//GetValue(CloningTree(tree), unfixedVariable, valueFixedVariables, x)
                    {
                        status = true;
                        break;
                    }
                    if (GetValue(CloningTree(tree), unfixedVariable, valueFixedVariables, left) * GetValue(CloningTree(tree), unfixedVariable, valueFixedVariables, x) < 0)
                    {
                        right = x;
                    }
                    else
                    {
                        left = x;
                    }
                }
            }
            return x;
        }
        public static void DisplayTree(List<Node> tree)
        {
            DisplayTree displayTree = new DisplayTree(tree);
        }
        public static void TreeViewGeneration(List<Node> tree, TreeNodeCollection treeView, int index)
        {
            
            int left = tree[index].Left;
            int right = tree[index].Right;
            if (left != FieldStatus.CannotExist)
            {
                treeView.Add(tree[left].Lexemes[0].Token);
            }
            if (right != FieldStatus.CannotExist)
            {
                treeView.Add(tree[right].Lexemes[0].Token);
            }
            if (left != FieldStatus.CannotExist)
            {
                TreeViewGeneration(tree, treeView[0].Nodes, left);
            }
            if(right != FieldStatus.CannotExist)
            {
                TreeViewGeneration(tree, treeView[1].Nodes, right);//ОШИБКА
            }
        }
        public static bool IsValidBracketExpression(string exp)
        {
            int coutntOfBracket = 0;
            for(int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == '(')
                {
                    coutntOfBracket++;
                }
                else if(exp[i] == ')')
                {
                    coutntOfBracket--;
                }
                if(coutntOfBracket < 0)
                {
                    return false;
                }
            }
            if(coutntOfBracket == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
