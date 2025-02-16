using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Author;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepo;
        public AuthorController(IAuthorRepository author)
        {
            _authorRepo = author;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorRepo.GetAllAsync();
            var authorsDto = authors.Select(a => a.ToAuthorDto());
            return Ok(authorsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id )
        {
            var authorModel = await _authorRepo.GetByIdAsync(id);
            if(authorModel == null)
            {
                return NotFound();
            }
            
            return Ok(authorModel.ToAuthorDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorRequestDto authorRequestDto)
        {
            var authorModel = authorRequestDto.FromCreateToAuthor();
            authorModel = await _authorRepo.CreateAsync(authorModel);
            return CreatedAtAction(nameof(GetById), new {id = authorModel.Id}, authorModel.ToAuthorDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAuthorDto authorDto)
        {
            var authorModel = await _authorRepo.UpdateAsync(id, authorDto);
            if(authorModel == null)
            {
                return NotFound("This author does not exist");
            }
            return Ok(authorModel);

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var authorModel = await _authorRepo.DeleteAsync(id);
            if(authorModel == null)
            {
                return NotFound("This author does not exist");
            }
            return NoContent();
        }
        
    }
}