using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Analyzer
{
  public class ClassBuilderService<T>
  {
    Dictionary<string, List<string>> documentStructureDictionary;

    public ClassBuilderService()
    {
      documentStructureDictionary = new Dictionary<string, List<string>>();
    }

    public string BuildClasses(List<TreeNode<T>> rootTreeNodes, string namespaceName)
    {
      StringBuilder fileContent = new StringBuilder();

      fileContent.AppendLine("using System;\nusing System.Collections.Generic; \n");
      fileContent.AppendLine($"namespace {namespaceName} \n{{");

      foreach (var node in rootTreeNodes)
      {
        PopulateDocumentStructureRecursively(node);
      }

      foreach (var classStructure in documentStructureDictionary)
      {
        fileContent.Append(BuildClassWithMembers(classStructure.Key, classStructure.Value, "\t"));
        fileContent.AppendLine("\n");
      }

      fileContent.AppendLine("\n}");

      return fileContent.ToString();
    }

    public void PopulateDocumentStructureRecursively(TreeNode<T> node)
    {
      if (!documentStructureDictionary.ContainsKey(node.Value.ToString()))
      {
        documentStructureDictionary.Add(node.Value.ToString(), new List<string>());
      }

      if (node.Children.Any())
      {
        foreach (var child in node.Children)
        {
          documentStructureDictionary[node.Value.ToString()].Add(child.Value.ToString());
          PopulateDocumentStructureRecursively(child);
        }
      }
    }

    public string BuildClassWithMembers(string className, List<string> members, string precedingIndentation)
    {
      string classDefinition = $"public class {className}";

      StringBuilder result = new StringBuilder($"{precedingIndentation}{classDefinition} \n{precedingIndentation}{{");

      foreach (var member in members)
      {
        string memberName = $"m_{member}";
        string memberType = member;
        string memberAccessibility = "public";

        if (members.Count(x => x.Equals(member)) > 1) // duplicate
        {
          memberType = $"List<{memberType}>";
          if (result.ToString().Contains(memberType))
          {
            continue;
          }
        }

        result.Append($"\n\t{precedingIndentation}{memberAccessibility} {memberType} {memberName} {{ get; set; }}");
      }

      result.Append($"\n{precedingIndentation}}}");

      return result.ToString();
    }
  }
}
