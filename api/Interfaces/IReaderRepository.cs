using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Reader;
using api.models;

namespace api.Interfaces
{
    public interface IReaderRepository
    {
        public Task<List<Reader>> GetAllAsync();
        public Task<Reader?> GetByIdAsync(int id);
        public Task<Reader> CreateAsync(CreateReaderDto readerDto);
        public Task<Reader?> UpdateAsync(int id, UpdateReaderDto readerDto);
        public Task<Reader?> DeleteAsync(int id);
        public Task<bool> ReaderExist(int id);
    }
}