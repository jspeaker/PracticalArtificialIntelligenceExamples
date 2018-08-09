using System.Collections.Generic;
using System.Linq;

namespace LogicAndAi
{
    public class BinaryDecisionTree
    {
        private BinaryDecisionTree _leftChild;
        private BinaryDecisionTree _rightChild;
        private int _value;

        public BinaryDecisionTree(int value)
        {
            _value = value;
        }

        public BinaryDecisionTree(int value, BinaryDecisionTree leftChild, BinaryDecisionTree rightChild)
        {
            _value = value;
            _leftChild = leftChild;
            _rightChild = rightChild;
        }

        public static BinaryDecisionTree FromFormula(Formula formula)
        {
            return TreeBuilder(formula, 0, "");
        }

        private static BinaryDecisionTree TreeBuilder(Formula formula, int treeLevel, string path)
        {
            ICollection<Variable> variables = formula.Variables().ToList();
            if (!string.IsNullOrEmpty(path)) formula.Variables().ElementAt(treeLevel - 1).Value = path[path.Length - 1] != 0;

            if (treeLevel == variables.Count) return new BinaryDecisionTree(formula.Evaluate() ? 1 : 0);

            return new BinaryDecisionTree(treeLevel, TreeBuilder(formula, treeLevel + 1, path + "0"), TreeBuilder(formula, treeLevel + 1, path + "1"));
        }
    }
}