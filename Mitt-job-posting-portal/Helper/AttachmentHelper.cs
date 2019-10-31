using System;
using System.Configuration;
using System.IO;
using System.Web;

namespace Mitt_job_posting_portal.Helper
{
  public class AttachmentHelper
  {
    public string saveFile(HttpPostedFileBase file)
    {
      string fileName = Path.GetFileNameWithoutExtension(file.FileName);
      string FileExtension = Path.GetExtension(file.FileName);
      fileName = DateTime.Now.ToString("yyyyMMdd") + "-" + fileName.Trim() + FileExtension;
      string UploadPath = ConfigurationManager.AppSettings["AttachmentPath"].ToString();
      string filePath = UploadPath + fileName;
      file.SaveAs(filePath);
      return filePath;
    }
  }
}