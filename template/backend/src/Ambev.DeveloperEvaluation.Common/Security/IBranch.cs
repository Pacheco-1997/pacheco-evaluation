using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Ambev.DeveloperEvaluation.Common.Security
{
    public interface IBranch
    {
        Guid Id { get; }
        string Name { get; }
    }
}
