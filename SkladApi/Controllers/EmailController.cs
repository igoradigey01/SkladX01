
using EmailService;
using Microsoft.AspNetCore.Authorization;
using X01.Dto;
using Microsoft.AspNetCore.Mvc;

namespace SkladApi.Controllers
{



    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private readonly IEmailSender _emailSender;

        public EmailController(
           IEmailSender emailSender
            )
        {
            _emailSender = emailSender;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post(EmailMessageDto mess)
        {


            // {"кому"} ,"тема письма" ,"содержание письма"
            var message = new Message(new string[] { mess.To }, mess.Subject, mess.Content, null);
            _emailSender.SendEmail(message);

            return Ok();

        }
    }
}
