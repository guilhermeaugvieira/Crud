using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IPersonService person;

        public PhoneController(IPersonService personService)
        {
            person = personService;
        }

        [HttpGet("{id}")]
        public async Task<PersonDto> GetPersonByIdAsync([FromRoute]long id)
        {
            var query = await person.FindPersonById(id);

            if (query == null) return null;

            return query;
        }

        [HttpPut]
        public async Task<ActionResult> SavePersonById([FromBody] PersonDto personDto)
        {
            await person.SavePerson(personDto);

            return Ok();
        }
    }
}
