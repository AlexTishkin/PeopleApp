using System;

namespace PeopleApp.Core.Entity
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Author Author { get; set; }
        public Guid AuthorId { get; set; }
    }
}
