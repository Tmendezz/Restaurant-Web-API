using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class Address
    {
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Street { get; set; }
    }
}
