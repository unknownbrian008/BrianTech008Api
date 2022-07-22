using System.Threading.Tasks;
using BrianTech008Api.Data.Models;

namespace BrianTech008Api.Features.Email
{
    public interface IMailService
    {
               Task SendEmailAsync(MailRequest mailRequest);   
    }
}