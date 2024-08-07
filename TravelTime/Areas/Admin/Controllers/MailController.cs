﻿using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TravelTime.Models;

namespace TravelTime.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Roles = "Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "traveltime.info1@gmail.com"); // mail gönderenin bilgileri
            mimeMessage.From.Add(mailboxAddressFrom);
            
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);  // maili alacak olanın bilgileri
            mimeMessage.To.Add(mailboxAddressTo);

            mimeMessage.Subject = mailRequest.Subject;  // mailin konusu

            var bodyBuilder = new BodyBuilder();  // mailin içerik kısmı
            bodyBuilder.TextBody= mailRequest.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();  

            SmtpClient client=new SmtpClient();
            client.Connect("smtp.gmail.com", 587,false); //mailin port numarası 587
            client.Authenticate("traveltime.info1@gmail.com", "vopigyndakkguvzc"); // mail hesabındaki uygulama şifreleri kısmına girerek aldığımız kod
            client.Send(mimeMessage);
            client.Disconnect(true);

            return RedirectToAction("Index", "Dashboard", new {area="Admin"});
        }
    }
}
