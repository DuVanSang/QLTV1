﻿using System;

namespace quanlisach.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishDate { get; set; }
        public string Category { get; set; }
    }
}

