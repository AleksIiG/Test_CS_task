using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Book;
using api.models;

namespace api.Dtos.Author
{
    public class AuthorDto
    {
        public int Id {get; set;}
        public string Name { get; set; } = string.Empty;
        public List<BookDto> Books {get; set;} = new List<BookDto>();
    }
}