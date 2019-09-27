using System;

namespace PeopleApp.Core.Dto
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid AuthorId { get; set; }
    }
}
