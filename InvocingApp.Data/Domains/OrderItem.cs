using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvocingApp.Data.Domains
{
    public class OrderItem : BaseEntity
    {
        public Guid OrdereditemId { get; set; }
        public long CartItemId { get; set; }
    }
}
