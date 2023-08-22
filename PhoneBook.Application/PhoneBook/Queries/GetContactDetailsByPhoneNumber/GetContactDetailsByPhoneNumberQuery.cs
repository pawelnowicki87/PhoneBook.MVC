using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.PhoneBook.Queries.GetContactDetailsByPhoneNumber
{
    public class GetContactDetailsByPhoneNumberQuery :IRequest<PhoneBookDto>
    {
        public string PhoneNumber { get; set; }
        public GetContactDetailsByPhoneNumberQuery(string phonenumber)
        {
            PhoneNumber = phonenumber;
        }
    }
}
