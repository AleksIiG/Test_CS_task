using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Book;
using api.Helpers;
using api.models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces
{
    public interface IBookRepository
    {
        public Task<List<Book>> GetAllAsync(QueryObjectBook query);
        public Task<Book?> GetByIdAsunc(int id);
        public Task<Book?> CreateAsync(CreateBookDto bookDto);
        public Task<Book?> UpdateAsync(int id, UpdateBookDto bookDto);
        public Task<Book?> DeleteAsync(int id);
    }
}