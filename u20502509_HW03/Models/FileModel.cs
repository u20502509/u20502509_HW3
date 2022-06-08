using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u20502509_HW03.Models
{
    public class FileModel
    {
        public IEnumerable<HttpPostedFileBase> Files { get; set; }

        public string FileName { get; set; }

        public string FileType { get; set; }
    }
}