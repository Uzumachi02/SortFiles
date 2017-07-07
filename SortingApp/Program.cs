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
      Console.WriteLine(args.Length);
      string processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
      Console.WriteLine(processName);

      foreach( string arg in args ) {
        Console.WriteLine(arg);
      }

      var app = new SortApp();

      if( args.Length > 0 ) {
        string path = args[0];
        app.SetPath(path);
      }
      app.AddIgnoreFile(processName + ".exe");
      Console.WriteLine("Path: {0}", app.GetPath());
      app.RunSorter();
      Console.WriteLine("Finish App");
      Console.ReadLine();
    }
  }
}
