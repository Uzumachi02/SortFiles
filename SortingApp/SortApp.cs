using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SortingApp
{
  class SortApp
  {
    public List<string> Files { get; set; }
    public List<string> IgnoreFiles { get; set; }
    public string Path { get; set; }

    public SortApp() { }

    public SortApp(string path)
    {
      SetPath(path);
    }

    public bool SetPath(string path)
    {
      if( !Directory.Exists(path) ) {
        throw new Exception("Path not found");
      }

      this.Path = path;
      return true;
    }

    public void AddIgnoreFile(string fileName)
    {
      if( IgnoreFiles == null )
        IgnoreFiles = new List<string>();

      IgnoreFiles.Add(fileName);
    }

    public string GetPath()
    {
      if( string.IsNullOrWhiteSpace(Path) )
        Path = Directory.GetCurrentDirectory();

      return Path;
    }
    public List<string> GetFiles() {
      return Directory.GetFiles(GetPath()).ToList();
    }

    public void RunSorter()
    {
      Files = GetFiles();
      if( Files.Count == 0 ) {
        Console.WriteLine("Files not found");
        return;
      }

      foreach( string file in Files ) {
        string fileName = System.IO.Path.GetFileName(file);
        string fileExt = System.IO.Path.GetExtension(fileName);

        bool notFileAndExt = string.IsNullOrWhiteSpace(fileName) || string.IsNullOrWhiteSpace(fileExt);
        Console.WriteLine("notFileAndExt: {0}", notFileAndExt);
        if( notFileAndExt )
          continue;
        bool isIgnoreFile = IgnoreFiles != null && IgnoreFiles.Contains(fileName);
        Console.WriteLine("isIgnoreFile: {0}", isIgnoreFile);
        if( notFileAndExt )
          continue;
        
        if( notFileAndExt || isIgnoreFile )
          continue;

        Console.WriteLine("{0} - {1}", fileName, fileExt);
        string pathToMove = GetDirPathToMove(fileExt);
        string pathSource = System.IO.Path.Combine(pathToMove, fileName);
        pathSource = CheckSourcePath(pathSource);
        Console.WriteLine("{0} was moved to {1}.", file, pathSource);
        File.Move(file, pathSource);
      }
    }

    private string GetDirPathToMove(string dirName)
    {
      string dirPath = System.IO.Path.Combine(Path, dirName);
      if( !Directory.Exists(dirPath) ) {
        Directory.CreateDirectory(dirPath);
      }

      return dirPath;
    }

    private string CheckSourcePath(string srcPath, int recurs = 1) {
      if( File.Exists(srcPath) ) {
        string dirName = System.IO.Path.GetDirectoryName(srcPath);
        string fileName = System.IO.Path.GetFileNameWithoutExtension(srcPath);
        string fileExt = System.IO.Path.GetExtension(srcPath);

        string newNameFile = string.Format("{0} (d-{1}){2}", fileName, recurs++, fileExt);
        srcPath = System.IO.Path.Combine(dirName, newNameFile);
        return CheckSourcePath(srcPath, recurs);
      }

      return srcPath;
    } 
  }
}
