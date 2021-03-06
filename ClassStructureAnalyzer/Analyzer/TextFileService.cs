﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Analyzer
{
  public class TextFileService
  {
    public List<string> ReadFile()
    {
      try
      {
        List<string> fileContent = new List<string>();
        string filename = "Structure.txt";

        using (StreamReader reader = new StreamReader(filename))
        {
          while (!reader.EndOfStream)
          {
            string line = reader.ReadLine();
            fileContent.Add(line);
          }
        }

        return fileContent;
      }
      catch (Exception ee)
      {
        Console.WriteLine(ee.Message);
        return null;
      }
    }

    public void WriteCSharpClassFile(string content)
    {
      try
      {
        List<string> fileContent = new List<string>();
        string filename = "Output.cs";

        using (FileStream fileStream = new FileStream(filename, FileMode.OpenOrCreate))
        using (StreamWriter writer = new StreamWriter(fileStream))
        {
          writer.WriteLine(content);
        }
      }
      catch (Exception ee)
      {
        Console.WriteLine(ee.Message);
      }
    }
  }
}
