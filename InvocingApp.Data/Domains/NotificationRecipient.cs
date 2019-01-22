using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvocingApp.Data.Domains
{
    public class NotificationRecipient : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
        public bool Approved { get; set; }
    }
}
