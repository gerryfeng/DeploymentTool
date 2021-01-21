using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.Api.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        public string Barcode { get; set; }

        public string Title { get; set; }

        public double SellingPrice { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
