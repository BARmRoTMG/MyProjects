using System;
using System.Collections.Generic;
using BookLibraryAdvanced.DAL;
using BookLibraryAdvanced.Models;
using BookLibraryAdvanced.Enums;

namespace BookLibraryAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var data = new Repository())
            {
                //data.Books.Add(new Book { Title = "My First Book", Author = "Bar Mashiach", Genre = Genre.Adventure, PublishDate = DateTime.Now});
                //data.SaveChanges();
                //data.Books.ToList();
            }
        }
    }
}
