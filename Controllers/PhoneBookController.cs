using System;
using System.Linq;
using System.Threading.Tasks;
using DotNetWebAPI.DataAccess;
using DotNetWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebAPI.Controllers
{
   
    public class PhoneBookController : ControllerBase
    {
        private readonly DataContext _context;
        public PhoneBookController(DataContext context)
        {
            _context = context;
        }

        [Route("api/register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]Person person){

           if(ModelState.IsValid){

                await _context.AddAsync(person).ConfigureAwait(false);

                await _context.SaveChangesAsync().ConfigureAwait(false);

           }else 
                return BadRequest(ModelState);

          
            return Ok(person);        

        }

        [Route("api/getall")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var phonebookList =  await _context.Person.Include(c => c.Contacts).AsNoTracking().ToListAsync();

            return Ok(phonebookList);

        }

        [Route("api/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var person =  await _context.Person.FindAsync(id);
            
            var contacts = await _context.Contacts.Where(c => EF.Property<int>(c,"PersonId") == id).ToListAsync();
            
            foreach (var contact in contacts)
            {
                 person.Contacts.Remove(contact);
            }

            _context.Person.Remove(person);

            bool isDeleted = await _context.SaveChangesAsync() > 1;

            return Ok(isDeleted);

        }

        [Route("api/update/{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody]Person person)
        {   
            var personData = await _context.Person.SingleOrDefaultAsync(d => d.Id == id);

            if(personData != null) {

                personData.FirstName = person.FirstName;

                personData.LastName = person.LastName;

                personData.Age = person.Age;    

                personData.UpdatedAt = DateTime.Now;

                if(await _context.SaveChangesAsync() > 0) 
                    return CreatedAtRoute(new { PersonData = personData }, "Successfully Updated");
            }

            throw new Exception($"Failed updating person id:  {id}");
        
        }
    }
}   