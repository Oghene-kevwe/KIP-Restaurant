using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Entities
{
    public class Address
    {
        public string? CityName { get; set; }
        public string? StreetName { get; set; }  
        public string? PostalCode { get; set; }
    }
}
