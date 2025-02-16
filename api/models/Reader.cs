using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Reader
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public List<Book> Books {get; set;} = new List<Book>();
        
    }
}