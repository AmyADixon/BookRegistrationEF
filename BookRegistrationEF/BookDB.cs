using System;
using System.Collections.Generic;
using System.Data.Entity; // Added to use EntityState
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

        /* Less efficient method */
        public static void Update2(Book novel) {
            BookContext context = new BookContext();

            // Get book from DB
            Book originalBook = context.Book.Find(novel.ISBN);

            // Updating everything by ISBN which is a primary key
            originalBook.Price = novel.Price;
            originalBook.Title = novel.Title;

            // Saving changes
            context.SaveChanges();
        }

        /// <summary>
        /// Alters an existing book in the DB
        /// </summary>
        /// <param name="novel"> The book that the user wants to change </param>
        public static void Update(Book novel) {
            var context = new BookContext();

            // Add book object to current context
            context.Book.Add(novel);

            // Let entity framework know that the book already exists and is just being modified
            context.Entry(novel).State = EntityState.Modified;

            // Save changes
            context.SaveChanges();
        }

        /// <summary>
        ///  Allows the user to remove a book from the database
        /// </summary>
        /// <param name="novel"> The book to be removed </param>
        public static void Delete(Book novel) {
            var context = new BookContext();

            // Add book to the context
            context.Book.Add(novel);

            // Mark book as deleted
            context.Entry(novel).State = EntityState.Deleted;

            // Sends query and saves changes
            context.SaveChanges();
        }

        /* Uses Connected Scenario where the db context tracks the entities in memory */
        public static void Delete(string isbn) {
            var context = new BookContext();

            // Select the book out of the database
            // by searching with primary key;
            // entity framework will track it
            Book deletedBook = context.Book.Find(isbn);

            // Remove book, marks book as deleted
            context.Book.Remove(deletedBook);

            // Sends delete quary to database and saves changes
            context.SaveChanges();
        }
    }
}
