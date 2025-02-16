using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Book;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace api.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IAuthorRepository _authorRepo;
        public BookRepository(ApplicationDBContext context, IAuthorRepository author)
        {
            _context = context;
            _authorRepo = author;
        }

        public async Task<Book?> CreateAsync(CreateBookDto bookDto)
        {
            var bookModel = bookDto.FromCreateToBook();
            if(!await _authorRepo.AuthorExist(bookDto.AuthorId))
            {
                return null;
            }
            
            await _context.Books.AddAsync(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<Book?> DeleteAsync(int id)
        {
            var bookModel = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if(bookModel == null)
            {
                return null;
            }
            _context.Books.Remove(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<List<Book>> GetAllAsync(QueryObjectBook query)
        {
            var books = _context.Books.AsQueryable();
            if(!string.IsNullOrWhiteSpace(query.Genre))
            {
                books = books.Where(b => b.Genre == query.Genre);
            }
            if(!string.IsNullOrWhiteSpace(query.Name))
            {
                books = books.Where(b => b.Name == query.Name);
            }
            return await books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsunc(int id)
        {
            var bookModel = await _context.Books.FindAsync(id);
            if(bookModel == null)
            {
                return null;
            }
            return bookModel;
        }

        public async Task<Book?> UpdateAsync(int id , UpdateBookDto bookDto)
        {
            var bookModel = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if(bookModel == null)
            {
                return null;
            }
            if(!await _authorRepo.AuthorExist(bookDto.AuthorId))
            {
                return null;
            }
            bookModel.AuthorId = bookDto.AuthorId;
            bookModel.Genre = bookDto.Genre;
            bookModel.Name = bookDto.Name;
            bookModel.ReaderId = bookDto.ReaderId;
            await _context.SaveChangesAsync();
            return bookModel;
        }

        
    }
}