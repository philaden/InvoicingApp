using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvocingApp.Data.Domains
{
    public class CartItem : BaseEntity
    {
        public Guid CartOrderedItemId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
