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
      Console.WriteLine("Hello Uzu");
      //List<string> files = Directory.GetFiles(@"C:\Users\Uzumachi\Downloads").ToList();
      //List<string> dirs = Directory.GetDirectories(@"C:\Users\Uzumachi\Downloads").ToList();
      var app = new SortApp(@"C:\Users\Uzumachi\Downloads");

      Console.WriteLine("Path: {0}", app.Path);
      foreach( string dir in app.Dirs ) {
        Console.WriteLine(dir);
      }
      app.RunSorter();
      //Directory.CreateDirectory(@"C:\Users\Uzumachi\Downloads\.xls");
      Console.ReadLine();
    }
  }
}
