using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public List<PersonPhoneDto> Phones { get; set; }
    }
}
