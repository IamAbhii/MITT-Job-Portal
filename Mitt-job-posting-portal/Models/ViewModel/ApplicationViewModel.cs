using System.Web;

namespace Mitt_job_posting_portal.Models.ViewModel
{
  public class ApplicationViewModel
  {
    public int Id { get; set; }
    public string Skills { get; set; }
    public string Message { get; set; }
    public string FilePath { get; set; }
    public int JobPostId { get; set; }
    public HttpPostedFileBase File { get; set; }
  }
}