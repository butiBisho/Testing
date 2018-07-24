using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Testing.Controllers
{
    public class TestController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        [HttpPost]
        [Route("api/UploadFile")]
        public IHttpActionResult Upload()
        {
            int uploadCount = 0;
            string sPath = System.Web.Hosting.HostingEnvironment.MapPath("/Test/");

            System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                System.Web.HttpPostedFile file = files[i];

                string fileName = new FileInfo(file.FileName).Name;

                if (file.ContentLength > 0)
                {
                    Guid id = Guid.NewGuid();

                    string modifiedFileName = id.ToString() + "_" + fileName;

                    if (!File.Exists(sPath + Path.GetFileName(modifiedFileName)))
                    {
                        file.SaveAs(sPath + Path.GetFileName(modifiedFileName));
                        uploadCount++;
                        db.Tests.Add(new Test() { FileName = "/Test/" + modifiedFileName, Title = fileName });
                    }
                }
            }
            if (uploadCount > 0)
            {
                db.SaveChanges();
                return Ok("Uploaded Successfully");
            }
            return InternalServerError();
        }

        // GET: api/Test       
        public IEnumerable<Test> Get()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Tests;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
