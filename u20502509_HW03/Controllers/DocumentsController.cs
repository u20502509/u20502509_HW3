using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using u20502509_HW03.Models;

namespace u20502509_HW03.Controllers
{
    public class DocumentsController
    {
        // GET: Document
        public ActionResult Document()
        {
            //create a new list of documents using the file model and stores them. Loops through each file in the specified folder and then stores them in the list using a foreach.
            List<FileModel> FilesObj = new List<FileModel>();
            foreach (string strfile in Directory.GetFiles(Server.MapPath("~/Media/Documents")))
            {
                FileInfo fileInfo = new FileInfo(strfile);
                FileModel obj = new FileModel();
                obj.FileName = fileInfo.Name;

                FilesObj.Add(obj);
            }

            return View(FilesObj);
        }

        //uses path combine to get the file from the specified location and then creates a path to download the file from 
        public FileResult DownloadFile(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Media/Document"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

        }

        //reads the selected files location and then removes the file from the specified folder
        public ActionResult DeleteFile(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/Media/Document"), fileName);
            FileInfo file = new FileInfo(fullPath);
            System.IO.File.Delete(fileName);
            file.Delete();
            return RedirectToAction("Document");
        }
    }
}