using linq;


LinqQueries queries = new LinqQueries();

void printValues(IEnumerable<Book> books){
    Console.WriteLine("{0,-70} {1,7} {2,11}\n", "Titulo", "N. Paginas","Fecha publicacion");

    foreach (var book in books)
    {
        Console.WriteLine("{0,-70} {1,7} {2,11}",book.Title,book.PageCount,book.PublishedDate);
    }
}

IEnumerable<Book> books = queries.GetBooksOver200PagesWithAction();

/* printValues(books); */
Console.WriteLine($"Todos los libros tienen status?: {queries.AllBooksHaveStatus()}");
Console.WriteLine($"Algun libro fue publicado en 2005? : {queries.AnyBookPublishedIn2005()}");