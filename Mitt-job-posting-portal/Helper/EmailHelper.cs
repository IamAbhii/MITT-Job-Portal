using Mitt_job_posting_portal.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Mitt_job_posting_portal.Helper
{
  public class EmailHelper
  {
    public void sendNotification(string reciverEmail, JobPost jobPost)
    {
      try
      {
        var senderEmail = new MailAddress("internshipmitt@gmail.com", "MITT");
        var receiverEmail = new MailAddress(reciverEmail, "Receiver");
        var password = "Enter your password here.";
        var sub = "MITT job notification";
        var body = GetBody(jobPost);
        var smtp = new SmtpClient
        {
          Host = "smtp.gmail.com",
          Port = 587,
          EnableSsl = true,
          DeliveryMethod = SmtpDeliveryMethod.Network,
          UseDefaultCredentials = false,
          Credentials = new NetworkCredential(senderEmail.Address, password)
        };
        var mess = new MailMessage(senderEmail, receiverEmail)
        {
          Subject = sub,
          Body = body,
        };
        mess.IsBodyHtml = true;
        smtp.Send(mess);
      }
      catch (Exception e)
      {

      }

    }

    public string GetBody(JobPost jobPost)
    {
      StringBuilder htmlBuilder = new StringBuilder();
      var hr = "<hr />";
      var div = "<div style=\"width: 100 %; border: 1px solid orange; padding: 5px; \">";
      htmlBuilder.Append(div);
      var jobTitle = "<h1>" + jobPost.Title + "</h1>";
      htmlBuilder.Append(jobTitle);
      htmlBuilder.Append(hr);
      var description = "<h2>Description</h2>";
      htmlBuilder.Append(description);
      var descriptionDetail = "<p>" + jobPost.Description + "</p>";
      htmlBuilder.Append(descriptionDetail);
      htmlBuilder.Append(hr);
      var Employer = "<h2>" + jobPost.Employer.CompanyName + "</h2>";
      var EmployerLocation = "<p>" + jobPost.Location + "</p>";
      htmlBuilder.Append(Employer);
      htmlBuilder.Append(EmployerLocation);
      div = "</div>";
      htmlBuilder.Append(div);
      return htmlBuilder.ToString();
    }
  }
}