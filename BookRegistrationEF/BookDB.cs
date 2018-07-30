using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationEF {
    static class BookDB {
        public static List<Book> GetAllBooks() {
            var context = new BookContext();

            List<Book> allBooks = (from b in context.Book
                                                   select b).ToList();

            return allBooks;
        }

        /// <summary>
        /// Adds a book to the database
        /// </summary>
        /// <param name="novel"> The book the user wants added </param>
        public static void Add(Book novel) { // BookDB.Add()
            BookContext context = new BookContext();

            // Assuming book is valid
            context.Book.Add(novel);

            //Save changes to DB
            context.SaveChanges();
        }
    }
}
