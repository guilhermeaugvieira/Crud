using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneDto
    {
        public int BusinessEntityId { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeId { get; set; }
    }
}
