using System;
using System.Collections.Generic;

namespace PeopleApp.Core.Dto
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual IList<BookDto> Books { get; set; }
    }
}
