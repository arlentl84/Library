using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.BusinessLogic.Util
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string fromAddress,
        string destinationAddress,
        string subject,
        string textMessage);

    }
}
