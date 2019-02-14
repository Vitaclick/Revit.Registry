using System;
using System.Collections.Generic;
using System.Text;

namespace Reg.Logic
{
  public class AppSettings
  {
    public string ConnectionString { get; set; }
    public string GoogleApiKey { get; set; }
    public AppSettings()
    {
      // set up default values
    }
  }
}
