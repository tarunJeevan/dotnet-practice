﻿namespace REST_API_Practice.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int YearPublished { get; set; }
        public string ISBN { get; set; } = null!;
    }
}
