using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationAPI;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace WebApplicationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MLPController : ControllerBase
    {
        _Application excel = new _Excel.Application();
        _Workbook wb;
        Worksheet ws;
        [HttpGet]
       public string[] Get()
        {
            
            //string Path = @"c:\WikiRef-input.xlsx";


            //readExel c = new readExel(Path);
            //c.read();

            return new string[] { "jkj", "jkjk", "uiuiui" };

        }

    
    }
}
