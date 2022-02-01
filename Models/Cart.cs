using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class Cart
    {
        public List<Item> Items { get; set; }

        public int Discount { get; set; }

        public double DiscountMultiplier { get; set; }
    }
}