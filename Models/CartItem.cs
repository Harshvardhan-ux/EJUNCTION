using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class CartItem
    {
        [Key]
        public string ItemID { get; set; }
        public string CartID { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}