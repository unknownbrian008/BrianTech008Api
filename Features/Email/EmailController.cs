using System;
using System.Threading.Tasks;
using BrianTech008Api.Features;
using BrianTech008Api.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrianTech008Api.Features.Email
{
    public class EmailController: BaseController
    {
     private readonly IMailService mailService;
        public EmailController(IMailService mailService)
        {
            this.mailService = mailService;
        }

        [HttpPost("Send")]
        public async Task<IActionResult> Send([FromForm] MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


    }
}