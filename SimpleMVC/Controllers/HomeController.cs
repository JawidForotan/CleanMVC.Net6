using Microsoft.AspNetCore.Mvc;
using SimpleMVC.Interfaces;

namespace SimpleMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService _messageService;
        public HomeController(IMessageService messageService)
        {
            _messageService = messageService;
        }


        public IActionResult Home()
        {
            return View();
        }
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            _messageService.Send(message);
            TempData["AlertMessage"] = "Thanks! Your Message Sent Successfully";
            return RedirectToAction(nameof(Home));

        }
    }
}
