using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PersonalLibrary.Models
{
  public class LibraryInfo
  {
    const string patternToFindFileName = @"^(.+)\\([^\\]+)$";

    public LibraryInfo()
    {
      LibraryRoute.Add(0, "General Questions & History Of Philosophy");
      LibraryRoute.Add(1, "Individual Works");
      LibraryRoute.Add(2, "Logics");
      LibraryRoute.Add(3, "Medicine & Biology");
      LibraryRoute.Add(4, "Chemistry");
      LibraryRoute.Add(5, "Physics");
      LibraryRoute.Add(6, "Maths");
      LibraryRoute.Add(7, "Fiction");
      LibraryRoute.Add(8, "Others");
    }

    public Dictionary<int, string> LibraryRoute { get; } = new Dictionary<int, string>() { };

    public static IList<string> GetFileNames(IEnumerable<string> filePaths)
    {
      List<string> fileNames = new List<string>();

      foreach (string filePath in filePaths)
      {
        string fileName = "";

        Regex regexForFileName = new Regex(patternToFindFileName);

        fileNames.Add(fileName = regexForFileName.Replace(filePath,
            new MatchEvaluator(CorrectFileName)));
      }
      return fileNames;
    }

    private static string CorrectFileName(Match match) => Regex.Replace(match.Value, patternToFindFileName, "$2");
  }
}
