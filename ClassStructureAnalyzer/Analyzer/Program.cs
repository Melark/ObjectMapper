using System;
using System.Collections.Generic;

namespace Analyzer
{
  class Program
  {
    static void Main(string[] args)
    {
      TextFileService textFileService = new TextFileService();
      var fileContent = textFileService.ReadFile();

      TreeBuilderService treeBuilderService = new TreeBuilderService();
      List<TreeNode<string>> treenodes = treeBuilderService.BuildTree(fileContent);

      string classStructure = new ClassBuilderService<string>().BuildClasses(treenodes, "Analyzer");

      textFileService.WriteCSharpClassFile(classStructure);

      Console.WriteLine(classStructure);
      Console.ReadLine();
    }
  }

  




}

