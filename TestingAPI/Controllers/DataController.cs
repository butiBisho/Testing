using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestingAPI.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public JsonResult SaveFiles(string description, string hotelName)
        //{
        //    string Message, fileName, actualFileName;
        //    Message = fileName = actualFileName = string.Empty;
        //    bool flag = false;
        //    if (Request.Files != null)
        //    {
        //        var file = Request.Files[0];
        //        actualFileName = file.FileName;
        //        fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        //        int size = file.ContentLength;

        //        try
        //        {
        //            file.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), fileName));

        //            Gallery f = new Gallery
        //            {
        //                FileName = actualFileName,
        //                FilePath = fileName,
        //                Description = description,
        //                FileSize = size,
        //                HotelName = hotelName
        //            };
        //            using (BootCampEntities dc = new BootCampEntities())
        //            {
        //                dc.Galleries.Add(f);
        //                dc.SaveChanges();
        //                Message = "File uploaded successfully";
        //                flag = true;
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            Message = "File upload failed! Please try again";
        //        }

        //    }
        //    return new JsonResult { Data = new { Message = Message, Status = flag } };
        //}
    }
}