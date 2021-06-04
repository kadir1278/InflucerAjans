using Influencer.Entities.Entity;
using Influencer.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace InfluencerWEBUI.Controllers
{
    public class IletisimController : Controller
    {
        InfluencerContext db = new InfluencerContext();
        // GET: Iletisim
        #region TR
        public ActionResult TR()
        {
            return View();
        }
        [HttpPost]
        [Route("tr/iletisim")]
        public ActionResult TR(ContactMail contactMail)
        {
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
                    mailMessage.Subject = contactMail.Subject;
                    mailMessage.Body = "<h3>https://influencerajans.com<br> Yukarıda belirtilen siteden size bir mail gelmişitir.<hr></h3><p>Mail içeriği aşağıda size verilen bilgiler doğrultuusnda maili kimin gönderdiği hangi mail adresi ile gönderdi bunların hepsi site tarafında mevcut olarak bulunmaktadır.</p><hr><h5><b>Mail Gönderinin Adı Soyadı : </b></h5>" + contactMail.NameSurname + "<hr><h5><b>Mail Gönderenin Mail Adresi : </b></h5>" + contactMail.Email + "<hr><h5><b>Mail Gönderenin Telefon Bilgisi :  </b></h5>" + contactMail.Phone + "<hr><h5><b>Mail Gönderenin Konusu : </b></h5>" + contactMail.Subject + "<hr><h5><b>Mail Gönderen Kişinin Mesajı : </b></h5>" + contactMail.Content;
                    mailMessage.IsBodyHtml = true;
                    contactMail.LastDateTime = DateTime.Now;
                    contactMail.IsActive = true;
                    db.ContactMails.Add(contactMail);
                    db.SaveChanges();
                    client.Send(mailMessage);
                    ViewBag.Mesaj = "Mailiniz bize ulaştı, size en kısa sürede dönüş yapılacaktır.";
                }
                catch
                {
                    ViewBag.Hata = "Mail gönderirken bir hata oluştu.";
                }

            }
            return View(contactMail);
        }
        public ActionResult PartialContact()
        {
            return PartialView(db.Contacts.Where(x => x.IsActive == true).FirstOrDefault());
        }
        #endregion
        #region EN
        public ActionResult EN()
        {
            return View();
        }
        [HttpPost]
        [Route("en/contacts")]
        public ActionResult EN(ContactMail contactMail)
        {
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
                    mailMessage.From = new MailAddress("info@influencerajans.com", "Influencer Agency Contact");
                    mailMessage.Subject = contactMail.Subject;
                    mailMessage.Body = "<h3>https://influencerajans.com<br>You have received an e-mail from the above-mentioned site.<hr></h3><p>The content of the e-mail is in accordance with the information given below, and who sent the e-mail with which e-mail address, all of these are available on the site.</p><hr><h5><b>Contact Person : </b></h5>" + contactMail.NameSurname + "<hr><h5><b>Contact Person Mail : </b></h5>" + contactMail.Email + "<hr><h5><b>Contact Person Phone Information :  </b></h5>" + contactMail.Phone + "<hr><h5><b>Contact Message Subject : </b></h5>" + contactMail.Subject + "<hr><h5><b>Email Sender's Message : </b></h5>" + contactMail.Content;
                    mailMessage.IsBodyHtml = true;
                    contactMail.LastDateTime = DateTime.Now;
                    contactMail.IsActive = true;
                    db.ContactMails.Add(contactMail);
                    db.SaveChanges();
                    client.Send(mailMessage);
                    ViewBag.Mesaj = "Your mail has reached us, the size will be returned as soon as possible.";
                }
                catch
                {
                    ViewBag.Hata = "An error occurred while sending mail.";
                }

            }
            return View(contactMail);
        }
        public ActionResult ENPartialContact()
        {
            return PartialView(db.Contacts.Where(x => x.IsActive == true).FirstOrDefault());
        }
        #endregion
    }
}