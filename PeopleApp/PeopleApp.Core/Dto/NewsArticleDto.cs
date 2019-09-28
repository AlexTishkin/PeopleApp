using System;

namespace PeopleApp.Core.Dto
{
    public class NewsArticleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}