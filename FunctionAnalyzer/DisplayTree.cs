using System.Collections.Generic;
using System.Windows.Forms;

namespace FunctionAnalyzer
{
    public partial class DisplayTree : Form
    {
        public DisplayTree()
        {
            InitializeComponent();
        }
        public DisplayTree(List<Node> tree)
        {
            try
            {
                InitializeComponent();
                treeView.Nodes.Add(tree[0].Lexemes[0].Token);//База рекурсии
                Tree.TreeViewGeneration(tree, treeView.Nodes[0].Nodes, 0);
                treeView.ExpandAll();
                this.Show();
            }
            catch
            {
                this.Close();
                MessageBox.Show("Что-то пошло не так", "Ошибка");
            }
        }
    }
}
