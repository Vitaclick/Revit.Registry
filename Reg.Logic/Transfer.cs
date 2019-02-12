using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using Google.Apis.Services;

namespace Revit.Registry
{
  public class Transfer {
    private string[] _scopes = { SheetsService.Scope.Spreadsheets };
    public string _appName = "Project monitor";
    public string _spreadsheetId;
    private SheetsService _service;
    private GoogleCredential _credential;
    private UserCredential _userCredential;
    
    public Transfer()
    {
      _spreadsheetId = "1aZ0m29YyUqaJVbd18VidKItf0ubwPBOFPN15hFUkxl4";

      var connectionSecret = Path.Combine(Directory.GetCurrentDirectory(), "secret.json");
      using (var stream = new FileStream("secret_debug.json", FileMode.Open, FileAccess.Read))
      {
        string credentialPath = "token.json";
        _userCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
          GoogleClientSecrets.Load(stream).Secrets, 
          _scopes,
          "user",
          CancellationToken.None,
          new FileDataStore(credentialPath, true)).Result;
      }

      _credential = GoogleCredential.FromJson(connectionSecret);

      _service = new SheetsService(new BaseClientService.Initializer(){
        HttpClientInitializer = _credential,
        ApplicationName = _appName
      });

    }

    public void WriteData(string range, List<IList<object>> data)
    {
      var valueRange = new ValueRange();
      valueRange.Values = data;
      var appendRequest = _service.Spreadsheets.Values.Append(valueRange, _spreadsheetId, range);
      appendRequest.ValueInputOption =
        SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
      var appendResponse = appendRequest.Execute();
    }
  }
}
