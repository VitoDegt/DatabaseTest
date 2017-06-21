using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityFrameworkRealization
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new LibraryContext())
            {
                //context.Books.Add(new Book{Name = "Book1", Author = "Author1", Publisher = "Publisher1", Year = 1858,});
               
                //context.Users.Add(new User { Name = "First", Age = 18 });
                //context.SaveChanges();
            }
        }
        public void AddBooks(string name, string author, string publisher, int year)
        {
            using(var context = new LibraryContext())
            {
                var bookName = new SqlParameter("@Name", name);
                var bookAuthor = new SqlParameter("@Author", author);
                var bookPublisher = new SqlParameter("@Publishet", publisher);
                var bookYear = new SqlParameter("@Year", year);

                var newBook = context.Database.ExecuteSqlCommand(
                    "INSERT INTO Books (Name, Author, Publisher, Year) VALUES (@Name, @Author, @Publisher, @Year)");
                context.SaveChanges();
            }
        }
        public void RemoveBook(int idBook)
        {
            using(var context = new LibraryContext())
            {
                var delete = new Book { Id = idBook};
                context.Books.Remove(delete);
                context.SaveChanges();
            }
        }
        public void CountBooks()
        {
            using (var context = new LibraryContext())
            {
                var count = context.Database.ExecuteSqlCommand(
                    "SELECT * FROM Books WHERE Author = Author");
            }
        }
        public void FindBook(string findingName)
        {
            using (var context = new LibraryContext())
            {
                var temp = new SqlParameter(@"FoundName" ,findingName);
                var count = context.Database.ExecuteSqlCommand(
                    "SELECT * FROM Books WHERE Name = FoundName");
            }
        }
    }
}
