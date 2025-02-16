using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Author;
using api.Interfaces;
using api.Mappers;
using api.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDBContext _context;
        public AuthorRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AuthorExist(int id)
        {
            return await _context.Authors.AnyAsync(a => a.Id == id);
        }

        public async Task<Author> CreateAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author?> DeleteAsync(int id)
        {
            var authorModel = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if(authorModel == null)
            {
                return null;
            }
            _context.Authors.Remove(authorModel);
            await _context.SaveChangesAsync();
            return authorModel;
        }

        public async Task<List<Author>> GetAllAsync()
        {
            var authorsModel = await _context.Authors.Include(a => a.Books).ToListAsync();
            return authorsModel;
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            var authorModel = await _context.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
            if(authorModel == null)
            {
                return null;
            }
            return authorModel;
        }

        public async Task<Author?> UpdateAsync(int id, UpdateAuthorDto authorDto)
        {
            var authorModel = await _context.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if(authorModel == null)
            {
                return null;
            }
            authorModel.Name = authorDto.Name;
            await _context.SaveChangesAsync();
            return authorModel;
        }
    }
}