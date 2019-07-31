function GetInput(idFolderRoute, fileNameKey) {

  $.ajax({
    type: "GET",
    cache: false,
    url: `api/home/?id=${idFolderRoute}&fileNameKey=${fileNameKey}`,
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (data) {
      var response = JSON.parse(data);
      window.location = response;
    },
    error: function (xhr, status, p3, p4) {
      var err = "Error " + " " + status + " " + p3 + " " + p4;
      if (xhr.responseText && xhr.responseText[0] == "{")
        err = JSON.parse(xhr.responseText).Message;
      console.log(err);
    }
  });
}
