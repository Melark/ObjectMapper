using System;
using System.Collections.Generic;
using System.Text;

namespace Analyzer
{
  public class TreeNode<T>
  {
    public int Level { get; set; }
    public List<TreeNode<T>> Children { get; set; }
    public TreeNode<T> Parent { get; set; }

    public T Value { get; set; }

    public static TreeNode<T> FindPreceedingNode(TreeNode<T> node, int level)
    {
      if (node.Level == level)
        return node;

      return FindPreceedingNode(node.Parent, level);
    }
  }
}
