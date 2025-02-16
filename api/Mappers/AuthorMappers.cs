using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Author;
using api.models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.Mappers
{
    public static class AuthorMappers
    {
        public static AuthorDto ToAuthorDto(this Author author)
        {
            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Books = author.Books.Select(b => b.ToBookDto()).ToList()
            };
        }

        public static Author FromCreateToAuthor(this CreateAuthorRequestDto authorDto)
        {
            return new Author
            {
                Name = authorDto.Name
            };
        }
    }
}