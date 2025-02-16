using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Author;
using api.models;

namespace api.Interfaces
{
    public interface IAuthorRepository
    {
        public Task<List<Author>> GetAllAsync();
        public Task<Author?> GetByIdAsync(int id);
        public Task<Author> CreateAsync(Author authorRequestDto);
        public Task<bool> AuthorExist(int id);
        public Task<Author?> UpdateAsync(int id, UpdateAuthorDto authorDto);
        public Task<Author?> DeleteAsync(int id);
    }
}