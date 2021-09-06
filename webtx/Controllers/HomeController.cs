using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webtx.EF;

namespace webtx.Controllers
{
    public class HomeController : Controller
    {
        WebTX db = new WebTX();      
        // GET: Home
        public ActionResult Index()
        {        
            var ndtinnhan = db.boxchats.ToList();
            return View(ndtinnhan);
        }
        public void Add(long iduser, string noidung, string status)
        {
            boxchat boxchat = new boxchat();
            boxchat.iduser = iduser;
            boxchat.noidung = noidung;
            boxchat.createddate = DateTime.Now;
            boxchat.status = status;
            db.boxchats.Add(boxchat);
            db.SaveChanges();
        }
        [HttpPost]
        public JsonResult sendimage( HttpPostedFileBase file)
        {
            string returnImagePath = string.Empty;
            string fileName;
            string Extension;
            string imageName;
            string imageSavePath;
            if (file != null)
            {

                fileName = Path.GetFileNameWithoutExtension(file.FileName);
                Extension = Path.GetExtension(file.FileName);
                imageName = fileName + DateTime.Now.ToString("yyyyMMddHHmmss");
                imageSavePath = Server.MapPath("/Images/") + imageName + Extension;
                file.SaveAs(imageSavePath);
                returnImagePath = "/Images/" + imageName + Extension;                

            }

            return Json(Convert.ToString(returnImagePath), JsonRequestBehavior.AllowGet);
            

        }
    }
}