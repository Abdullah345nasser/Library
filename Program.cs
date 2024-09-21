using System.Reflection.Metadata.Ecma335;

namespace Libray_Project
{

    class Book {


      public  string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Available { get; set; }

        public Book(string title, string author, string iSBN, bool available=true)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            Available = available;
        }
    }

    class Library
    {
        List<Book> books = new List<Book>();


        public bool AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine("Book Add Succefully");
            return true;

        }

        public Book SearchBook(string title) {
    
            foreach (Book book in books) {

              if (book.Title == title)
                {
                    return book;
                    
                }  

            }


            return new Book("", "", "", false);  

        }

        public void BorrowBook(string title) { 
            Book book = SearchBook(title);
            if (book.Available == true)
            {
                Console.WriteLine("You can Borrow this book");
                book.Available = false;
                return;
            }

           Console.WriteLine("You can not borrow this book");
        }

        public void ReturnBook (Book book)
        {
            if (book.Available == true)
            {
                Console.WriteLine("This Book does not borrow it");
            }

            else
            {
                book.Available = true;
                Console.WriteLine("Returned Book succefully");
            }
        }
        /*
         * */
        //Another Way to Search for book
        public bool SearchBook(Book book)
        {

            foreach (Book book2 in books) { 

                if (book.Title ==  book2.Title || book.Author == book2.Author) return true;
            }

            return false;
        }

        //Another Way to Borrow book
        public bool BorrowBook(Book book)
        {
            if (SearchBook(book))
            {
                book.Available = false;
                Console.WriteLine("You can Borrow this Book");
                return true;

            }
            return false;

        }
          
        public void Return(Book book) {

            if (!SearchBook(book)) {
                book.Available = true;
                Console.WriteLine("Return Book succefully");
                return;
            }
            Console.WriteLine("Book is already exists");
         }
         
       


        
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));
            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

           Book book = new Book("The Great Gatsby", "Scott Fitzgerald", "9780743273565");
            library.AddBook(book);
            library.SearchBook(book);
            library.ReturnBook(book);
        }
    }
}
