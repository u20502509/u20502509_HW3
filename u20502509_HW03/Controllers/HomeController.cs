using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u20502509_HW03.Models;

namespace u20502509_HW03.Controllers
{
    public class HomeController : Controller
    {
        public string FileOption;
        public ActionResult Index()
        {
            return View();
        }

        //Get Filetype and return type
        public string RetrieveFileType(FormCollection filetype)
        {
            FileOption = filetype["FileType"].ToString();
            return FileOption;
        }
        public ActionResult About()
        {

            return View();
        }

        //http post request from the form. Gets the type of file to be uploaded and saves to specified path in Media folder, under the correct sub-folder
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase uploadedFile, FormCollection frm)
        {
            FileOption = frm["FileType"].ToString();
            string fileName = Path.GetFileName(uploadedFile.FileName);
            string FilePath = Path.Combine(Server.MapPath("~/FileUploads/" + FileOption), fileName);
            uploadedFile.SaveAs(FilePath);
            return RedirectToAction("Index");
        }
    }
}