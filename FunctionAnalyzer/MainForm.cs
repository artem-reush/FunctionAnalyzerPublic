using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunctionAnalyzer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ///УДАЛИТЬ
            this.unfixedVariableBox.Text = "X";
            this.fixedValueVariableBox.Text = "2";
            this.accuracyBox.Text = "0,1";
            ///
        }
        private List<Node> tree;
        private string lastParsedExpression;
        private void writeExpressionButton_Click(object sender, System.EventArgs e)
        {
            string exp = expressionBox.Text;
            if (string.IsNullOrEmpty(exp) || string.IsNullOrWhiteSpace(exp))
            {
                MessageBox.Show("Некорректное выражение", "Ошибка");
            }
            else
            {
                try
                {
                    StreamWriter sw = new StreamWriter(@"..\..\..\Resources\expression.txt");
                    sw.WriteLine(exp);
                    sw.Flush();
                    sw.Close();
                }
                catch
                {
                    MessageBox.Show("Не удалось записать в файл", "Ошибка");
                }
            }
        }

        private void readExpressionButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(@"..\..\..\Resources\expression.txt");
                string exp = sr.ReadLine();
                expressionBox.Text = exp;
                sr.Close();
            }
            catch
            {
                MessageBox.Show("Не удалось прочесть файл", "Ошибка");
            }
        }

        private void analyzeExpressionButton_Click(object sender, EventArgs e)
        {
            string exp = expressionBox.Text;
            try
            {
                if (Tree.IsValidBracketExpression(exp))
                {
                    tree = Tree.CreateTree(exp);
                    lastParsedExpression = exp;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка");
                return;
            }
        }
        private void printGraphButton_Click(object sender, EventArgs e)
        {
            if (expressionBox.Text == lastParsedExpression && !String.IsNullOrEmpty(fixedValueVariableBox.Text) &&
                !String.IsNullOrEmpty(unfixedVariableBox.Text))
            {
                Tree.PrintGraph(tree, unfixedVariableBox.Text, fixedValueVariableBox.Text);
            }
            else
            {
                MessageBox.Show("Выражение не проанализировано или не все поля заполнены", "Ошибка");
            }
        }
        private void findRootButton_Click(object sender, EventArgs e)
        {
            bool rootIsFound = false;
            if (expressionBox.Text == lastParsedExpression && !String.IsNullOrEmpty(fixedValueVariableBox.Text) &&
                !String.IsNullOrEmpty(unfixedVariableBox.Text) && !String.IsNullOrEmpty(accuracyBox.Text) &&
                !String.IsNullOrEmpty(aBox.Text) && !String.IsNullOrEmpty(bBox.Text))
            {
                double root;
                try
                {
                    root = Tree.FindRoot(tree, unfixedVariableBox.Text, fixedValueVariableBox.Text, accuracyBox.Text, aBox.Text, bBox.Text, out rootIsFound);
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так", "Ошибка");
                    return;
                }
                if (rootIsFound)
                {
                    resultBox.Text = Convert.ToString(root);
                }
                else
                {
                    resultBox.Text = Convert.ToString("Не найдено");
                }
            }
            else
            {
                MessageBox.Show("Выражение не проанализировано или не все поля заполнены", "Ошибка");
            }
        }
        private void printTreeButton_Click(object sender, EventArgs e)
        {
            if (expressionBox.Text == lastParsedExpression)
            {
                Tree.DisplayTree(tree);
            }
            else
            {
                MessageBox.Show("Выражение не проанализировано", "Ошибка");
            }
        }
    }
}
