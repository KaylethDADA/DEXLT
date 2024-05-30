using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll([FromServices] PersonService personService)
        {
            var persons = personService.GetAll();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id, [FromServices] PersonService personService)
        {
            var person = personService.GetById(id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] PersonCreateRequest personCreateRequest, [FromServices] PersonService personService)
        {
            var createdPerson = personService.Create(personCreateRequest);
            //return CreatedAtAction(nameof(GetById), new { id = createdPerson.Id }, createdPerson);
            if (createdPerson == null)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] PersonUpdateRequest personUpdateRequest, [FromServices] PersonService personService)
        {
            if (id != personUpdateRequest.Id)
                return BadRequest();

            var updatedPerson = personService.Update(personUpdateRequest);
            return Ok(updatedPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id, [FromServices] PersonService personService)
        {
            var deleted = personService.Delete(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpGet("{id}/CustomFields")]
        public IActionResult GetCustomFields(Guid id, [FromServices] PersonService personService)
        {
            var customFields = personService.GetCustomFields(id);
            return Ok(customFields);
        }
    }
}
