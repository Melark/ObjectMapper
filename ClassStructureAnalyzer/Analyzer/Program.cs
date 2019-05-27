using System;
using System.Collections.Generic;

namespace Analyzer
{
  class Program
  {
    static void Main(string[] args)
    {
      TextFileService textFileService = new TextFileService();
      var a = textFileService.ReadFile();

      TreeBuilderService treeBuilderService = new TreeBuilderService();
      List<TreeNode<string>> treenodes = treeBuilderService.BuildTree(a);

      string classStructure = new ClassBuilderService<string>().BuildClasses(treenodes);
      Console.WriteLine(classStructure);

      Console.ReadLine();
    }
  }
}
