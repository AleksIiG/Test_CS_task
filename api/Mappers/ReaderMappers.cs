using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Reader;
using api.models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.Mappers
{
    public static class ReaderMappers
    {
        public static ReaderDto ToReaderDto(this Reader reader)
        {
            return new ReaderDto
            {
                Id = reader.Id,
                Name = reader.Name,
                Books = reader.Books.Select(b => b.ToBookDto()).ToList()
            };
        }

        public static Reader FromCreateToReader(this CreateReaderDto readerDto)
        {
            return new Reader
            {
                Name = readerDto.Name
            };
        }
        public static Reader FromUpdateToReader(this UpdateReaderDto readerDto)
        {
            return new Reader
            {
                Name = readerDto.Name
            };
        }
    }
}