using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Author
    {
        public int Id {get; set;}
        public string Name { get; set; } = string.Empty;
        public List<Book> Books {get; set;} = new List<Book>();
    }
}