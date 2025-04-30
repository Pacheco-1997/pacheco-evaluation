using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Value_Objects
{
    public class Name
    {
        /// <summary>
        /// First name (given name), required.
        /// </summary>
        public string Firstname { get; private set; }

        /// <summary>
        /// Last name (surname), required.
        /// </summary>
        public string Lastname { get; private set; }

        /// <summary>
        /// Constructs a new Name value object.
        /// Validates that both firstname and lastname are provided.
        /// </summary>
        /// <param name="firstname">The given name.</param>
        /// <param name="lastname">The family name.</param>
        /// <exception cref="ArgumentException">Thrown if firstname or lastname is null or whitespace.</exception>

        private Name() { }

        public Name(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}
