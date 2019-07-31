function DeleteFile(idFolderRoute, fileNameKey) {

  $.ajax({
    type: "DELETE",
    cache: false,
    url: `api/home/?idFolderRoute=${idFolderRoute}&fileNameKey=${fileNameKey}`,
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (data) {
      var response = JSON.parse(data);
      console.log(response);
    },
    error: function (xhr, status, p3, p4) {
      var err = "Error " + " " + status + " " + p3 + " " + p4;
      if (xhr.responseText && xhr.responseText[0] == "{")
        err = JSON.parse(xhr.responseText).Message;
      console.log(err);
    },
    complete: function (event, request, settings) {
      GetData(idFolderRoute);
    }
  });
}