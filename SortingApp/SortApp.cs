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
    public List<string> Dirs { get; set; }
    public List<string> Files { get; set; }
    public string Path { get; set; }

    public SortApp()
    {
      Init();
    }

    public SortApp(string path)
    {
      this.Path = path;
      Init();
    }

    public void Init() {
      Files = GetFiles();
      Dirs = GetDirs();
    }

    public string GetCurPath()
    {
      if( string.IsNullOrWhiteSpace(Path) )
        Path = Directory.GetCurrentDirectory();

      return Path;
    }

    public List<string> GetDirs() {
      return Directory.GetDirectories(GetCurPath()).ToList();
    }
    public List<string> GetFiles() {
      return Directory.GetFiles(GetCurPath()).ToList();
    }

    public void RunSorter()
    {
      foreach( string file in Files ) {
        string fileName = System.IO.Path.GetFileName(file);
        string fileExt = System.IO.Path.GetExtension(fileName);

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
