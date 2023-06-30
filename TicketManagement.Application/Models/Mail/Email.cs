using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagement.Application.Models.Mail
{
    /// <summary>
    /// Not a domain entity. It is an model to be used in a external service.
    /// </summary>
    public class Email
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
