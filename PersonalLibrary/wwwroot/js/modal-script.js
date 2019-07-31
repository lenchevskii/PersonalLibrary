function GetData(idFolderRoute) {

  $.ajax({
    type: "GET",
    url: `/api/home/${idFolderRoute}`,
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (response) {
      ShowList(response);
    }
  });
}

function ShowList(books) {

  $('#modal-window').modal('show');
  var strResult = "<table class='table'> <thead class='thead-dark'> <th>Book List</th></thead>";
  $.each(books.fileNames, function (key, book) {
    strResult += `<tbody> <tr><td><h5>${book}</h5>` +
      `<a class="btn btn-secondary" href="\\MyLibraryFiles\\${books.directoryName}\\${book}" download >Download Book</a>` +
      `<button type="submit" class="btn btn-primary" id="deleteFile"` +
      ` onclick = "DeleteFile(${books.idFolderRoute}, ${key})" >Delete Book</button >` +
      `</tr> </tbody></td>`;
  });

  strResult += `</table>`;
  $("#modal-table").html(strResult);
  $("#exampleModalLabel").text(`${books.directoryName}`);
  strResultForUploadButton = `Check this to upload your book: ` +
    `<input type = "file" name = "uploadFile" onChange = 'GetOutput(event, ${books.idFolderRoute})'/>`
  $("#uploadFile").html(strResultForUploadButton);
}

//  <button type="submit" class="btn btn-secondary" id="downloadFile"` +
//      ` onclick = "GetInput(${books.id}, ${key})" > Download File</button >