using System;

namespace PeopleApp.Core.Entity
{
    public class NewsArticle
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}