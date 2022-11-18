using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Market.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public string Symbol { get; set; }  
        public double CurrentPrice { get; set; }

    }
}