using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorProject.Models.Repo
{
    public class AuthorRepository : IBookStorRepository<Author>
    {
        IList<Author> authors;

        public AuthorRepository()
        {
            authors = new List<Author>()
            {
                new Author
                {
                    Id=1, FullName="Mohammad Ahmad"
                },
                new Author
                {
                    Id=2, FullName="Islam Raslan"
                },
                new Author
                {
                    Id=3, FullName="Ammer Foqha"
                }
            };
        }
        public void Add(Author entity)
        {
            entity.Id = authors.Max(auth => auth.Id) + 1;
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);
        }

        public Author Find(int id)
        {
            var author = authors.SingleOrDefault(auth => auth.Id == id);
            return author;
        }

        public IList<Author> List()
        {
            return authors;
        }

        public List<Author> Search(string term)
        {
            return authors.Where(a => a.FullName.Contains(term)).ToList();
        }

        public void Update(int id, Author newAuthor)
        {
            var author = Find(id);
            author.FullName = newAuthor.FullName;
        }
    }
}
