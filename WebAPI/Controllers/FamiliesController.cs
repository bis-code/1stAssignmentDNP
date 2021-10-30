using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstAssignmentDNP.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamiliesController : ControllerBase
    {
        private readonly IFamiliesData FamiliesData;

        public FamiliesController(IFamiliesData familiesData) 
        {
            FamiliesData = familiesData;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Family>>> GetFamilies()
        {
            try
            {
                IList<Family> families = await FamiliesData.GetFamiliesAsync();
                return Ok(families);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        public async Task<ActionResult<Family>> GetFamily([FromQuery] int IdFamily)
        {
            try
            {
                Family family = await FamiliesData.GetFamilyAsync(IdFamily);

                return Ok(family);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        public async Task<ActionResult<Adult>> GetAdult([FromQuery] int IdFamily, [FromQuery] int IdAdult)
        {
            try
            {
                Adult adult = await FamiliesData.GetAdultAsync(IdFamily, IdAdult);

                return Ok(adult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<Child>> GetChild([FromQuery] int IdFamily, [FromQuery] int IdChild)

        {
            try
            {
                Child child = await FamiliesData.GetChildAsync(IdFamily, IdChild);
                return Ok(child);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        public async Task<ActionResult<Pet>> GetPet([FromQuery] int IdFamily, [FromQuery] int IdPet)
        {
            try
            {
                Pet pet = await FamiliesData.GetPetAsync(IdFamily,IdPet);

                return Ok(pet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Family family, [FromBody] Adult adult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Adult added = await FamiliesData.AddAdultToFamilyAsync(family, adult);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<Child>> AddChild([FromBody] Family family, [FromBody] Child child)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Child added = await FamiliesData.AddChildToFamilyAsync(family, child);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<Family>> AddFamily([FromBody] Family family)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Family added = await FamiliesData.AddFamilyAsync(family);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        [Route("{IdFamily:int}")]
        public async Task<ActionResult<Interest>> AddInterest([FromRoute] int IdFamily, [FromBody] Child child, [FromBody] Interest interest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Interest added = await FamiliesData.AddInterestAsync(IdFamily, child, interest);
                return Created($"/{added.Type}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        [Route("{IdFamily:int}")]
        public async Task<ActionResult<Pet>> AddInterest([FromBody] Family family, [FromBody] Child? child, [FromBody] Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (child != null)
                {
                    Pet added = await FamiliesData.AddPetForFamilyAsync(family, child, pet);
                    return Created($"/{added.Name}", added);
                }
                else
                {
                    Pet added = await FamiliesData.AddPetForFamilyAsync(family, null, pet);
                    return Created($"/{added.Name}", added);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}