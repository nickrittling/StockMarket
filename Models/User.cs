using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stock_Market.Models
{
    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public double Funds { get; set; }

    }
}