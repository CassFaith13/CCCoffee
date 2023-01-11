using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCCoffee.Models.CustomerModels
{
    public class CustomerDetail
    {
        public string? CustomerId { get; set; }
        
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        public DateTime ProfileCreated { get; set; }
        public DateTime CustomerBirthday { get; set; }
    }
}