using System;
using System.Collections.Generic;

public class Library
{
    private string name;
    private string address;
    private List<Book> books;
    private List<MediaItem> mediaItems;
    
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    public string Address
    {
        get { return address; }
        set { address = value; }
    }
    
    public List<Book> Books
    {
        get { return books; }
    }
    
    public List<MediaItem> MediaItems
    {
        get { return mediaItems; }
    }
    
    public Library(string name, string address)
    {
        this.name = name;
        this.address = address;
        books = new List<Book>();
        mediaItems = new List<MediaItem>();
    }
    
    public void AddBook(Book book)
    {
        books.Add(book);
    }
    
    public void RemoveBook(Book book)
    {
        books.Remove(book);
    }
    
    public void AddMediaItem(MediaItem item)
    {
        mediaItems.Add(item);
    }
    
    public void RemoveMediaItem(MediaItem item)
    {
        mediaItems.Remove(item);
    }
    
    public void PrintCatalog()
    {
        Console.WriteLine("Books:");
        foreach (Book book in books)
        {
            Console.WriteLine(book.ToString());
        }
        
        Console.WriteLine("Media Items:");
        foreach (MediaItem item in mediaItems)
        {
            Console.WriteLine(item.ToString());
        }
    }
}

public class Book
{
    private string title;
    private string author;
    private string isbn;
    private int publicationYear;
    
    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    
    public string Author
    {
        get { return author; }
        set { author = value; }
    }
    
    public string ISBN
    {
        get { return isbn; }
        set { isbn = value; }
    }
    
    public int PublicationYear
    {
        get { return publicationYear; }
        set { publicationYear = value; }
    }
    
    public Book(string title, string author, string isbn, int publicationYear)
    {
        this.title = title;
        this.author = author;
        this.isbn = isbn;
        this.publicationYear = publicationYear;
    }
    
    public override string ToString()
    {
        return $"Title: {title}; Author: {author}; ISBN: {isbn}; Publication Year: {publicationYear}";
    }
}

public class MediaItem
{
    private string title;
    private string mediaType;
    private int duration;
    
    public string Title
    {
        get { return title; }
        set { title = value; }
    }
    
    public string MediaType
    {
        get { return mediaType; }
        set { mediaType = value; }
    }
    
    public int Duration
    {
        get { return duration; }
        set { duration = value; }
    }
    
    public MediaItem(string title, string mediaType, int duration)
    {
        this.title = title;
        this.mediaType = mediaType;
        this.duration = duration;
    }
    
    public override string ToString()
    {
        return $"Title: {title}; Media Type: {mediaType}; Duration: {duration} minutes";
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Library library = new Library("My Library", "123 Main St.");

        Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "978-3-16-148410-0", 1925);
        Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", "978-0-06-112008-4", 1960);
        MediaItem mediaItem1 = new MediaItem("Star Wars: Episode IV - A New Hope", "DVD", 121);
        MediaItem mediaItem2 = new MediaItem("The Beatles - Abbey Road", "CD", 47);

        library.AddBook(book1);
        library.AddBook(book2);
        library.AddMediaItem(mediaItem1);
        library.AddMediaItem(mediaItem2);

        while (true)
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. Print library catalog");
            Console.WriteLine("2. Add a book to the library");
            Console.WriteLine("3. Add a media item to the library");
            Console.WriteLine("4. Remove a book from the library");
            Console.WriteLine("5. Remove a media item from the library");
            Console.WriteLine("6. Exit");

            string input = Console.ReadLine();

            try
            {
                if (input == "1")
                {
                    library.PrintCatalog();
                }
                else if (input == "2")
                {
                    Console.WriteLine("Enter the book title:");
                    string title = Console.ReadLine();

                    Console.WriteLine("Enter the book author:");
                    string author = Console.ReadLine();

                    Console.WriteLine("Enter the book ISBN:");
                    string isbn = Console.ReadLine();

                    Console.WriteLine("Enter the book publication year:");
                    int publicationYear = int.Parse(Console.ReadLine());

                    Book book = new Book(title, author, isbn, publicationYear);
                    library.AddBook(book);
                }
                else if (input == "3")
                {
                    Console.WriteLine("Enter the media item title:");
                    string title = Console.ReadLine();

                    Console.WriteLine("Enter the media item type:");
                    string mediaType = Console.ReadLine();

                    Console.WriteLine("Enter the media item duration in minutes:");
                    int duration = int.Parse(Console.ReadLine());

                    MediaItem item = new MediaItem(title, mediaType, duration);
                    library.AddMediaItem(item);
                }
                else if (input == "4")
                {
                    Console.WriteLine("Enter the book title to remove:");
                    string title = Console.ReadLine();

                    Book bookToRemove = library.Books.Find(b => b.Title == title);

                    if (bookToRemove == null)
                    {
                        throw new Exception("Book not found.");
                    }

                    library.RemoveBook(bookToRemove);
                }
                else if (input == "5")
                {
                    Console.WriteLine("Enter the media item title to remove:");
                    string title = Console.ReadLine();

                    MediaItem itemToRemove = library.MediaItems.Find(m => m.Title == title);

                    if (itemToRemove == null)
                    {
                        throw new Exception("Media item not found.");
                    }

                    library.RemoveMediaItem(itemToRemove);
                }
                else if (input == "6")
                {
                    break;
                }
                else
                {
                    throw new Exception("Invalid input. Please enter a number between 1 and 6.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
