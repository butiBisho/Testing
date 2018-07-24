using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public JsonResult UserLogin(LoginData d)
        {
            using (BootCampEntities dc = new BootCampEntities())
            {
                var user = dc.Clients.Where(a => a.Email.Equals(d.Email) && a.Password.Equals(d.Password)).FirstOrDefault();
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public JsonResult AdminLogin(LoginData d)
        {
            using (BootCampEntities dc = new BootCampEntities())
            {
                var user = dc.Administrators.Where(a => a.Email.Equals(d.Email) && a.Password.Equals(d.Password)).FirstOrDefault();
                return new JsonResult { Data = user, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        public JsonResult GetAllClients()
        {
            List<Client> client = new List<Client>();
            using (BootCampEntities dc = new BootCampEntities())
            {
                client = dc.Clients.OrderBy(a => a.FirstName).ToList();
            }

            return new JsonResult { Data = client, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult Register(Client u)
        {
            string message = "";
            //Here we will save data to the database
            if (ModelState.IsValid)
            {
                using (BootCampEntities dc = new BootCampEntities())
                {
                    //check username available
                    var user = dc.Clients.Where(a => a.Email.Equals(u.Email)).FirstOrDefault();
                    if (user == null)
                    {
                        //Save here
                        dc.Clients.Add(u);
                        dc.SaveChanges();
                        message = "Success";
                    }
                    else
                    {
                        message = "Username not available!";
                    }
                }
            }
            else
            {
                message = "Failed!";
            }
            return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult AdminRegister(Administrator u)
        {
            string message = "";
            //Here we will save data to the database
            if (ModelState.IsValid)
            {
                using (BootCampEntities dc = new BootCampEntities())
                {
                    //check username available
                    var user = dc.Administrators.Where(a => a.Email.Equals(u.Email)).FirstOrDefault();
                    if (user == null)
                    {
                        //Save here
                        dc.Administrators.Add(u);
                        dc.SaveChanges();
                        message = "Success";
                    }
                    else
                    {
                        message = "Username not available!";
                    }
                }
            }
            else
            {
                message = "Failed!";
            }
            return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult AddTraveller(Traveller u)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                using (BootCampEntities dc = new BootCampEntities())
                {
                    var user = dc.Travellers.Where(a => a.FirstName.Equals(u.FirstName) && a.Surname.Equals(u.Surname)).FirstOrDefault();
                    if (user == null)
                    {
                        dc.Travellers.Add(u);
                        dc.SaveChanges();
                        message = "Success";
                    }
                    else
                    {
                        message = "Traveller not available!";
                    }
                }
            }
            else
            {
                message = "Failed!";
            }
            return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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

        //            UploadedFile f = new UploadedFile
        //            {
        //                FileName = actualFileName,
        //                FilePath = fileName,
        //                Description = description,
        //                FileSize = size.ToString(),
        //                HotelName = hotelName
        //            };
        //            using (BootCampEntities dc = new BootCampEntities())
        //            {
        //                dc.UploadedFiles.Add(f);
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

        public JsonResult GetImageByRoomNumberName()
        {
            using (BootCampEntities dc = new BootCampEntities())
            {
                var img = dc.RoomImages.Where(a => a.RoomNumber.Equals("we32")).FirstOrDefault();
                return new JsonResult { Data = img, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveRoomFiles(string description, string roomNumber)
        {
            string Message, fileName, actualFileName;
            Message = fileName = actualFileName = string.Empty;
            bool flag = false;
            if (Request.Files != null)
            {
                var file = Request.Files[0];
                actualFileName = file.FileName;
                fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                int size = file.ContentLength;

                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), fileName));

                    RoomImage f = new RoomImage
                    {
                        FileName = actualFileName,
                        FilePath = fileName,
                        Description = description,
                        FileSize = size,
                        RoomNumber = roomNumber
                    };
                    using (BootCampEntities dc = new BootCampEntities())
                    {
                        dc.RoomImages.Add(f);
                        dc.SaveChanges();
                        Message = "File uploaded successfully";
                        flag = true;
                    }
                }
                catch (Exception)
                {
                    Message = "File upload failed! Please try again";
                }

            }
            return new JsonResult { Data = new { Message = Message, Status = flag } };
        }

        [HttpPost]
        public JsonResult SaveCarFiles(string description, string carName)
        {
            string Message, fileName, actualFileName;
            Message = fileName = actualFileName = string.Empty;
            bool flag = false;
            if (Request.Files != null)
            {
                var file = Request.Files[0];
                actualFileName = file.FileName;
                fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                int size = file.ContentLength;

                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), fileName));

                    CarImage f = new CarImage
                    {
                        FileName = actualFileName,
                        FilePath = fileName,
                        Description = description,
                        FileSize = size,
                        CarName = carName
                    };
                    using (BootCampEntities dc = new BootCampEntities())
                    {
                        dc.CarImages.Add(f);
                        dc.SaveChanges();
                        Message = "File uploaded successfully";
                        flag = true;
                    }
                }
                catch (Exception)
                {
                    Message = "File upload failed! Please try again";
                }

            }
            return new JsonResult { Data = new { Message = Message, Status = flag } };
        }

        public JsonResult SendMailToUser(string mailAddress,string subject,string emailBody)
        {
            bool result = false;
            result = SendMail(mailAddress, subject, emailBody);
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public bool SendMail(string toEmail, string subject, string emailBody)
        {
            try
            {
                string senderEmail = System.Configuration.ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = System.Configuration.ConfigurationManager.AppSettings["SenderPassword"].ToString();

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, emailBody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                return false;                
            }
        }


    }
}