using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Reader;
using api.Interfaces;
using api.Mappers;
using api.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly ApplicationDBContext _context;
        public ReaderRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Reader>> GetAllAsync()
        {
            return await _context.Readers.Include(r => r.Books).ToListAsync();
        }

        public async Task<Reader?> GetByIdAsync(int id)
        {
            var bookModel = await _context.Readers.Include(r => r.Books).FirstOrDefaultAsync(r => r.Id == id);
            if(bookModel == null)
            {
                return null;
            }
            return bookModel;
        }

        public async Task<Reader> CreateAsync(CreateReaderDto readerDto)
        {
            var reader = readerDto.FromCreateToReader();
            await _context.Readers.AddAsync(reader);
            await _context.SaveChangesAsync();
            return reader;
        }

        public async Task<Reader?> UpdateAsync(int id, UpdateReaderDto readerDto)
        {
            var readerModel = await _context.Readers.FirstOrDefaultAsync(r => r.Id == id);
            if(readerModel == null)
            {
                return null;
            }
            readerModel.Name = readerDto.Name;
            await _context.SaveChangesAsync();
            return readerModel;
        }

        public async Task<Reader?> DeleteAsync(int id)
        {
            var readerModel = await _context.Readers.FirstOrDefaultAsync(r => r.Id == id);
            if(readerModel == null)
            {
                return null;
            }
            _context.Remove(readerModel);
            await _context.SaveChangesAsync();
            return readerModel;
        }

        public async Task<bool> ReaderExist(int id)
        {
            return await _context.Readers.AnyAsync(r => r.Id == id);
        }
    }
}