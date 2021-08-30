using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static WebApplicationAPI.PredicationModel;

namespace WebApplicationAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class StreamingController : Controller
    {
        
            private readonly IWebHostEnvironment _webHhostingEnvironment;

            public StreamingController(IWebHostEnvironment webHostingEnvironment)
            {
                _webHhostingEnvironment = webHostingEnvironment;
            }
       
        [HttpPost]
        [Route("api/Streaming/OnPostUploadAsync")]
        public  Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
            {
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {

                    var fileContent = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition);
                    ModelOutput predica = new ModelOutput();
                    ModelInput inputm = new ModelInput();
                    //inputm.title = (string)fileContent["title"];
                   //זאת הפונקציה שמכונה בנתה בהינתן הנתונים שולחים את השדות שהגדרנו אותם כinput
                   //ומה שהגדרנו כ lable במקרה שלנו זה isrefqk
                 //predica.Prediction(inputm);
                   
                        // Some browsers send file names with full path.
                        // We are only interested in the file name.
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                    //כאן צריך לקרוא את האקסל ולהשתמש בפונקציה שבנתה אלגוריתמים על סמך הנתונים המסווגים שכלל הכנה לפני ששולחים את הנתונים דוגמה למחוק באמצעת כלי אקסל את כל השורות שהעמודה ב
                    //ריק isrefqa בשדה
                    // ובנוסף למחוק את כל הרשומוות בהם השדות לא רלוונטי לבדיקה וכל זה כדי לתת אפשרות
                    // למכונת הלמידה להכיר כמה שיותר את הנתונים שלי על מנת שאוכל לחזות ברמת דיוק גבוהה
                    //המושג מטריצת בלבול מדברת בכמה כמה חזתה נכון וכמה לא
                    //מימוש יש אלגורתמים שמקבל מערך חיזוי ןמערך  אקטואלי ובאמצעות זה יכולה לבדוק בכמה  טעיות היו


                        //var physicalPath = Path.Combine(_webHhostingEnvironment.WebRootPath, "Upload_Directory", fileName);

                        //using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                        //{
                        //    await formFile.CopyToAsync(fileStream);
                        //}
                    }
                }

                // Return an empty string to signify success
                return null;
            }

            [Route("api/Remove")]
            [HttpPost]
            public ActionResult Async_Remove(string[] fileNames)
            {
                if (fileNames != null)
                {
                    foreach (var fullName in fileNames)
                    {
                        var fileName = Path.GetFileName(fullName);
                        var physicalPath = Path.Combine(_webHhostingEnvironment.WebRootPath, "Upload_Directory", fileName);

                        // TODO: Verify user permissions

                        if (System.IO.File.Exists(physicalPath))
                        {
                            System.IO.File.Delete(physicalPath);
                        }
                    }
                }

                // Return an empty string to signify success
                return Content("");
            }
        }
}