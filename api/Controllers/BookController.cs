using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Book;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        public readonly IBookRepository _bookRepo;
        
        public BookController(IBookRepository book)
        {
            _bookRepo = book;
        }
        [HttpGet]

        public async Task<IActionResult> GetAll([FromQuery] QueryObjectBook query)
        {
            var books = await _bookRepo.GetAllAsync(query);
            var bookDto = books.Select(b => b.ToBookDto());
            return Ok(bookDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByID([FromRoute]int id)
        {
            var book = await _bookRepo.GetByIdAsunc(id);
            if(book == null)
            {
                return NotFound("Book does not exist");
            }
            return Ok(book.ToBookDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookDto bookDto)
        {
            var bookModel = await _bookRepo.CreateAsync(bookDto);
            if(bookModel == null)
            {
                return NotFound();
            }
            return Ok(bookModel.ToBookDto());
        }

        [HttpPut("{id:int}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookDto bookDto)
        {
            var bookModel = await _bookRepo.UpdateAsync(id, bookDto);
            if(bookModel == null)
            {
                return NotFound();
            }
            return Ok(bookModel.ToBookDto());
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var bookModel = await _bookRepo.DeleteAsync(id);
            if(bookModel == null)
            {
                return NotFound("Book does not exist");
            }
            return Ok(bookModel.ToBookDto());
        }
    }
}