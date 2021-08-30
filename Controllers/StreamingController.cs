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
                   //��� �������� ������ ���� ������ ������� ������ �� ����� ������� ���� �input
                   //��� ������� � lable ����� ���� �� isrefqk
                 //predica.Prediction(inputm);
                   
                        // Some browsers send file names with full path.
                        // We are only interested in the file name.
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                    //��� ���� ����� �� ����� ������� �������� ����� ���������� �� ��� ������� �������� ���� ���� ���� ������� �� ������� ����� ����� ������ ��� ���� �� �� ������ ������� �
                    //��� isrefqa ����
                    // ������ ����� �� �� �������� ��� ����� �� ������� ������ ��� �� ��� ��� ������
                    // ������ ������ ����� ��� ����� �� ������� ��� �� ��� ����� ����� ���� ���� �����
                    //����� ������ ����� ����� ���� ��� ���� ���� ���� ��
                    //����� �� ��������� ����� ���� ����� �����  ������� �������� �� ����� ����� ����  ����� ���


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