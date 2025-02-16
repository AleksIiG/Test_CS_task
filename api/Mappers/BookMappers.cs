using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Book;
using api.models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Identity.Client;

namespace api.Mappers
{
    public static class BookMappers
    {
        public static BookDto ToBookDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Name = book.Name,
                Genre = book.Genre,
                AuthorId = book.AuthorId,
                ReaderId = book.ReaderId
            };
        }

        public static Book FromCreateToBook(this CreateBookDto bookDto)
        {
            return new Book
            {
                Name = bookDto.Name,
                AuthorId = bookDto.AuthorId,
                Genre = bookDto.Genre,
                ReaderId = bookDto.ReaderId
            };
        }

        public static Book FromUpdateToBook(this CreateBookDto bookDto)
        {
            return new Book
            {
                Name = bookDto.Name,
                AuthorId = bookDto.AuthorId,
                Genre = bookDto.Genre,
                ReaderId = bookDto.ReaderId
            };
        }
    }
}