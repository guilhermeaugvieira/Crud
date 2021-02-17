using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;

        }

        public async Task<PersonDto> FindPersonById(long id)
        {
            var query = await _personRepository.FindAllAsync().Include(x => x.Phones).Where(x => x.BusinessEntityID == id).SingleOrDefaultAsync();

            if (query == null) return null;

            return new PersonDto {
                Id = query.BusinessEntityID,
                Name = query.Name,
                Phones = query.Phones != null ? query.Phones.Select(x => new PersonPhoneDto {
                    BusinessEntityId = x.BusinessEntityID,
                    PhoneNumber = x.PhoneNumber,
                    PhoneNumberTypeId = x.PhoneNumberTypeID
                }).ToList(): null
            };
        }

        public async Task SavePerson(PersonDto person)
        {
            var qrPerson = await _personRepository.FindAllAsync().Include(x => x.Phones).Where(x => x.BusinessEntityID == person.Id).SingleOrDefaultAsync();

            qrPerson.Phones = person.Phones.Select(x => new PersonPhone
            {
                PhoneNumber = x.PhoneNumber,
                PhoneNumberTypeID = x.PhoneNumberTypeId
            }).ToList();

            await _personRepository.UpdateAsync(qrPerson);
        }
    }
}
