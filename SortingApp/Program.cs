using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SortingApp
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.OutputEncoding = Encoding.UTF8;
      Console.WriteLine("Start App");
      var app = new SortApp(@"C:\Users\Uzumachi\Downloads");

      Console.WriteLine("Path: {0}", app.Path);
      app.RunSorter();
      Console.WriteLine("Finish App");
      Console.ReadLine();
    }
  }
}
