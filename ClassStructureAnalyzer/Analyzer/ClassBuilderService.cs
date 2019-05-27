using System;
using System.Collections.Generic;
using System.Text;

namespace Analyzer
{
  public class ClassBuilderService<T>
  {
    public string BuildClasses(List<TreeNode<T>> treeNodes)
    {
      StringBuilder fileContent = new StringBuilder();

      // root class

      foreach (var node in treeNodes)
      {
        fileContent.AppendLine($"public class {node.Value.ToString()} {{");
        foreach (var childNode in node.Children)
        {
          string memberType = childNode.Value.ToString();

          fileContent.AppendLine($"\tpublic {memberType} m_{memberType.ToLower()} {{ get; set; }}");

        }
        fileContent.AppendLine("}\n");
      }

      return fileContent.ToString();
    }
  }
}
