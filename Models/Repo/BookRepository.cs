using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorProject.Models.Repo
{
    public class BookRepository : IBookStorRepository<Book>
    {
        List<Book> books;

        public BookRepository()
        {
            books = new List<Book>()
            {
                new Book
                {
                    Id=1,
                    Title="C# Programming",
                    Description="No description",
                    ImageUrl="joker.png",
                    Author = new Author()
                },
                
                new Book
                {
                    Id=2,
                    Title="Java Programming",
                    Description="No description",
                    ImageUrl="mobile design3.png",
                    Author = new Author()
                },

                new Book
                {
                    Id=3,
                    Title="Python Programming",
                    Description="No description",
                    ImageUrl="simba.png",
                    Author = new Author()
                },
            };
        }
        public void Add(Book entity)
        {
            entity.Id = books.Max(b => b.Id) + 1;
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = Find(id);
            books.Remove(book);
        }

        public Book Find(int id)
        {
            var book = books.SingleOrDefault(b => b.Id == id);
            return book;
        }

        public IList<Book> List()
        {
            return books;
        }

        public void Update(int id, Book newBook)
        {
            var book = Find(id);
            book.Title = newBook.Title;
            book.Description = newBook.Description;
            book.Author = newBook.Author;
            book.ImageUrl = newBook.ImageUrl;
        }
    }
}
