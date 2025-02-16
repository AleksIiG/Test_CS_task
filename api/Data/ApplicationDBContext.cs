using System;
using System.Collections.Generic;
using System.Linq;
using api.models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) :
        base(options)
        {

        }
        public DbSet<Author> Authors {get; set;}
        public DbSet<Book> Books {get; set;}
        public DbSet<Reader> Readers {get; set;}

        
    }

    
}