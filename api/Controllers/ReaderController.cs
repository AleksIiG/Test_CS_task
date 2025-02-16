using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Book;
using api.Dtos.Reader;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/readers")]
    [ApiController]
    public class ReaderController : ControllerBase
    {
       private readonly IReaderRepository _readerRepo;
       public ReaderController(IReaderRepository reader) 
       {
            _readerRepo = reader;
       }

       [HttpGet]
       public async Task<IActionResult> GetAll()
       {
            var readers = await _readerRepo.GetAllAsync();
            var readersDto = readers.Select(r => r.ToReaderDto());
            return Ok(readersDto);
       }
       [HttpGet("{id:int}")]
       public async Task<IActionResult> GetById([FromRoute] int id)
       {
            var readerModel = await _readerRepo.GetByIdAsync(id);
            if(readerModel == null)
            {
                return NotFound("Reader Does not exist");
            }
            return CreatedAtAction(nameof(GetById), new {id = readerModel.Id}, readerModel.ToReaderDto());
       }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReaderDto readerDto)
        {
            var readerModel = await _readerRepo.CreateAsync(readerDto);
            return Ok(readerModel.ToReaderDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateReaderDto readerDto)
        {
            var readerModel = await _readerRepo.UpdateAsync(id, readerDto);
            if(readerModel == null)
            {
                return NotFound();
            }
            return Ok(readerModel.ToReaderDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var readerModel = await _readerRepo.DeleteAsync(id);
            if(readerModel == null)
            {
                return NotFound("Reader does not exist");
            }
            return Ok(readerModel.ToReaderDto());
        }
    }
}