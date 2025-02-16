using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Book
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public string Genre {get; set;} = string.Empty;
        public int AuthorId {get; set;}
        public int ReaderId {get; set;}
        public Author? Author {get; set;} = null!;
        public Reader? Reader {get; set;} = null!;
        
    }
}