using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using PersonalLibrary.Models;
using System.Threading.Tasks;
using System;

namespace PersonalLibrary.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HomeController : ControllerBase
  {
    private readonly IHostingEnvironment _env;
    //private readonly Book _book;

    public HomeController(IHostingEnvironment env) => _env = env;

    //public HomeController(Book book) => _book = book;

    private readonly LibraryInfo _libraryInfo = new LibraryInfo();

    #region ShowFilesController
    [HttpGet("{idFolderRoute}")]
    public IActionResult GetFiles(int idFolderRoute)
    {
      var directoryName = _libraryInfo.LibraryRoute.Values.ElementAt(idFolderRoute);
      var webRoot = _env.WebRootPath;
      var path = Path.Combine(webRoot, $"MyLibraryFiles\\{directoryName}");

      if (Directory.Exists(path) == false) Directory.CreateDirectory(path);

      var filePaths = Directory.GetFiles(path);
      var fileNames = LibraryInfo.GetFileNames(filePaths);

      return Ok(new { fileNames, idFolderRoute, directoryName, filePaths });
    }
    #endregion

    #region UploadFileController
    [HttpPost("{id}")]
    public async Task<IActionResult> UploadHomeReport(int id)
    {
      try
      {
        foreach (var file in Request.Form.Files)
        {
          var directoryName = _libraryInfo.LibraryRoute.Values.ElementAt(id);
          var webRoot = _env.WebRootPath;
          var path = Path.Combine(webRoot, $"MyLibraryFiles\\{directoryName}");

          if (Directory.Exists(path) == false) Directory.CreateDirectory(path);

          if (file != null && file.Length > 0)
          {
            var fileName = Path.GetFileName(file.FileName);
            var pathFile = Path.Combine(path, fileName);

            using (var fileStream = new FileStream(pathFile, FileMode.Create))
            {
              await file.CopyToAsync(fileStream);
            }
          }
        }
      }
      catch (InvalidOperationException exc)
      {
        return BadRequest(exc.Message);
      }

      return Ok("FileUpload");
    }
    #endregion

    #region DeleteFileController
    [HttpDelete]
    public ActionResult DeleteFile(int idFolderRoute, int fileNameKey)
    {
      var directoryName = _libraryInfo.LibraryRoute.Values.ElementAt(idFolderRoute);
      var webRoot = _env.WebRootPath;
      var path = Path.Combine(webRoot, $"MyLibraryFiles\\{directoryName}");
      var filePaths = Directory.GetFiles(path);
      var targetFile = LibraryInfo.GetFileNames(filePaths)[fileNameKey];
      var fullPath = Path.Combine(path, targetFile);

      try
      {
        System.IO.File.Delete(fullPath);
        return Ok("The file has been deleted.");
      }
      catch(DirectoryNotFoundException)
      {
        return BadRequest("File not found.");
      }
    }
    #endregion
  }
}
