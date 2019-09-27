using System;
using System.Collections.Generic;

namespace PeopleApp.Core.Entity
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Book> Books { get; set; }
    }
}