using System;
using System.Collections.Generic;
using System.Text;

namespace Analyzer
{
  public class TreeBuilderService
  {
    public List<TreeNode<string>> BuildTree(List<string> fileContent)
    {
      List<TreeNode<string>> rootNodes = new List<TreeNode<string>>();
      TreeNode<string> lastParentNode = null;

      for (int lineNumber = 0; lineNumber < fileContent.Count; lineNumber++)
      {
        TreeNode<string> currentNode = new TreeNode<string>();
        fileContent[lineNumber].TrimEnd(); // Remove spaces at the end :)
        int spaceCounter = fileContent[lineNumber].LastIndexOf(' ') + 1;
        currentNode.Value = fileContent[lineNumber].Trim();
        currentNode.Level = spaceCounter;
        currentNode.Children = new List<TreeNode<string>>();

        if (spaceCounter == 0)
        {
          currentNode.Parent = null;
          rootNodes.Add(currentNode);
        }
        else if (spaceCounter == lastParentNode.Level + 1) 
        {
          currentNode.Parent = lastParentNode;
          lastParentNode.Children.Add(currentNode);
        }
        else if (spaceCounter == lastParentNode.Level) // On same level as previous node
        {
          currentNode.Parent = lastParentNode.Parent;
          lastParentNode.Parent.Children.Add(currentNode);
        }
        else
        {
          var parentNode = TreeNode<string>.FindPreceedingNode(lastParentNode, spaceCounter - 1);
          currentNode.Parent = parentNode;
          parentNode.Children.Add(currentNode);
        }

        lastParentNode = currentNode;
      }

      return rootNodes;
    }





  }
}
