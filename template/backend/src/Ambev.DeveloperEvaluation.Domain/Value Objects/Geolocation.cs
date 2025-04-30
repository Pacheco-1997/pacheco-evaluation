using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Value_Objects
{
    public class Geolocation
    {
       public Geolocation() { }

       public string Lat { get; set; }
       public string Long { get; set; }
    }
}
