using System;
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
  }
}
