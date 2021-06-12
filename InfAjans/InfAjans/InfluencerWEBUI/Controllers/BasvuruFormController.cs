using Influencer.Entities.Entity;
using Influencer.Entities.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace InfluencerWEBUI.Controllers
{
    public class BasvuruFormController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        // GET: BasvuruForm
        #region TR
        public ActionResult TR()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageName == "Başvuru Formu").FirstOrDefault();
            return View();
        }
        [HttpPost]
        [Route("tr/basvuru-formu")]
        public ActionResult TR(ApplicationForm applicationForm, HttpPostedFileBase FilePath)
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageName == "Başvuru Formu").FirstOrDefault();
            if (ModelState.IsValid)
            {
                try
                {
                    SmtpClient client = new SmtpClient("mail.influencerajans.com", 587);
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("info@influencerajans.com", "Espr12345++?");
                    client.EnableSsl = false;
                    client.Credentials = credentials;
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("info@influencerajans.com", "Influencer Ajans İletişim");
                    mailMessage.Subject = applicationForm.Subject;
                    if (FilePath != null)
                    {
                        string fileName = Path.GetFileName(FilePath.FileName);
                        var url = Path.Combine(Server.MapPath("~/File/ApplicationForms/" + fileName));
                        FilePath.SaveAs(url);
                        applicationForm.FilePath = fileName;
                        mailMessage.Attachments.Add(new Attachment(FilePath.InputStream, fileName));
                    }
                    mailMessage.Subject = applicationForm.Subject;
                    mailMessage.Body = "<h3>https://influencerajans.com<br> Yukarıda belirtilen siteden size bir mail gelmişitir.<hr></h3><p>Mail içeriği aşağıda size verilen bilgiler doğrultuusnda maili kimin gönderdiği hangi mail adresi ile gönderdi bunların hepsi site tarafında mevcut olarak bulunmaktadır.</p><hr><h5><b>Mail Gönderinin Adı Soyadı : </b></h5>" + applicationForm.Name + " " + applicationForm.Surname + "<hr><h5><b>İlgili Kişinin Bulunduğu İl : </b></h5>" + applicationForm.City + "<hr><h5><b>İlgili Kişinin Bulunduğu İlçe :  </b></h5>" + applicationForm.District + "<hr><h5><b>Mail Gönderenin Konusu : </b></h5>" + applicationForm.Subject + "<hr><h5><b>Mail Gönderen Kişinin Mesajı : </b></h5>" + applicationForm.Message;
                    mailMessage.IsBodyHtml = true;
                    applicationForm.LastDateTime = DateTime.Now;
                    applicationForm.IsActive = true;
                    db.ApplicationForms.Add(applicationForm);
                    db.SaveChanges();
                    client.Send(mailMessage);
                    ViewBag.Mesaj = "Mailiniz bize ulaştı, size en kısa sürede dönüş yapılacaktır.";
                }
                catch
                {
                    ViewBag.Hata = "Mail gönderilirken bir hata oluştu lütfen tekrar deneyiniz.";
                }
            }
            return View(applicationForm);
        }
        #endregion
        #region EN
        public ActionResult EN()
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageName == "Application Form").FirstOrDefault();
            return View();
        }
        [HttpPost]
        [Route("en/application-form")]
        public ActionResult EN(ApplicationForm applicationForm, HttpPostedFileBase FilePath)
        {
            ViewBag.Seo = db.MainGoogleSeos.Where(x => x.IsActive == true && x.PageName == "Application Form").FirstOrDefault();
            if (ModelState.IsValid)
            {
                try
                {
                    SmtpClient client = new SmtpClient("mail.influencerajans.com", 587);
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("info@influencerajans.com", "Espr12345++?");
                    client.EnableSsl = false;
                    client.Credentials = credentials;
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("info@influencerajans.com", "Influencer Ajans İletişim");
                    mailMessage.Subject = applicationForm.Subject;
                    if (FilePath != null)
                    {
                        string fileName = Path.GetFileName(FilePath.FileName);
                        var url = Path.Combine(Server.MapPath("~/File/ApplicationForms/" + fileName));
                        FilePath.SaveAs(url);
                        applicationForm.FilePath = fileName;
                        mailMessage.Attachments.Add(new Attachment(FilePath.InputStream, fileName));
                    }
                    mailMessage.Subject = applicationForm.Subject;
                    mailMessage.Body = "<h3>https://influencerajans.com<br> You have received an e-mail from the above-mentioned site.<hr></h3><p>The content of the mail is in accordance with the information given below, who sent the mail with which mail address, all of these are available on the site.</p><hr><h5><b>Contact Person Name Surname : </b></h5>" + applicationForm.Name + " " + applicationForm.Surname + "<hr><h5><b>Province of the Relevant Person : </b></h5>" + applicationForm.City + "<hr><h5><b>District where the person concerned is located :  </b></h5>" + applicationForm.District + "<hr><h5><b>Related Mail Subject : </b></h5>" + applicationForm.Subject + "<hr><h5><b>Related Mail Message : </b></h5>" + applicationForm.Message;
                    mailMessage.IsBodyHtml = true;
                    applicationForm.LastDateTime = DateTime.Now;
                    applicationForm.IsActive = true;
                    db.ApplicationForms.Add(applicationForm);
                    db.SaveChanges();
                    client.Send(mailMessage);
                    ViewBag.Mesaj = "Your mail has reached us, we will get back to you as soon as possible.";
                }
                catch
                {
                    ViewBag.Hata = "An error occurred while sending the mail, please try again.";
                }
            }
            return View(applicationForm);
        }
        #endregion
    }
}