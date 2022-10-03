using BookLibraryAdvanced.Enums;
using System;
using System.Collections.Generic;

namespace BookLibraryAdvanced.Models
{
    public class Journal
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public Double Price { get; set; }
        public ICollection<Journal> Journals { get; set; }
    }
}
