using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IIIDC.Models;
using IIIDC.Services;

namespace IIIDC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailSender _EmailSender;

        public HomeController(IEmailSender emailSender)
        {
            _EmailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [HttpGet("~/Contact-us")]
        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact";
            var succes = (string)TempData["success"];
            var failure = (string)TempData["Failure"];

            if (!string.IsNullOrEmpty(succes))
            {
                ViewBag.UserMessage = succes;
            }

            if (!string.IsNullOrEmpty(failure))
            {
                ModelState.AddModelError("", failure);
            }

            return View();
        }
        [HttpPost("~/Contact-us")]
        public async Task<IActionResult> Contact(ContactViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _EmailSender.SendEmailAsync(model.Email, model.Subject, model.Name, model.Content,
                        model.Telephone);

                    TempData["success"] = "Message Sent";
                }
                else if(model == null || !ModelState.IsValid)
                {
                    TempData["Failure"] = "the message can't no be sended";
                }
            }
            catch (Exception e)
            {
                TempData["Failure"] = "the message can't no be sended";
            }


            return RedirectToAction("Contact");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
