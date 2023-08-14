using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Entities
{
    public class PhoneBookContactDetails
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;


    }
}
