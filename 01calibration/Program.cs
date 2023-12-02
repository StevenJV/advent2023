using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using CustomExtensions;

internal class Program
{
  private static void Main(string[] args)
  {
    Console.WriteLine("Advent of Code day 1 puzzle 1");


    int overAll = 0;

    try
    {
      var fileloc = "input.txt";
      using (StreamReader read = new(fileloc))
      {
        string? line;
        while ((line = read.ReadLine()) != null)
        {
          Console.WriteLine(line);
          int first = line.firstNumber();
          int last = line.lastNumber();
          if (first > 0 && last > 0)
          {
            string together = $"{first}{last}";
            Console.Write(together);
            if (int.TryParse(together, out int thisValue))
            {
              overAll += thisValue;
              Console.WriteLine($" : {thisValue}");
            }
            else { Console.WriteLine("--- ERROR ---"); };
          }
        }
      };
      Console.WriteLine($"overall total: {overAll}");
    }
    catch (IOException e)
    {
      Console.WriteLine("The file could not be read:");
      Console.WriteLine(e.Message);
    }
  }

}