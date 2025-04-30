using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Value_Objects
{
    public class Address
    {
        public Address() { }

        public string City { get; set; } 
        public string Street { get; set; }
        public int Number { get; set; }
        public string Zipcode { get; set; }
        public Geolocation Geolocation { get; set; }
    }
}
