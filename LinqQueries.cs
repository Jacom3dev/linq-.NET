namespace linq
{
    public class LinqQueries
    {
        private List<Book> books = [];
        public LinqQueries()
        {
            using(StreamReader reader = new StreamReader("books.json")){
                string json = reader.ReadToEnd();
                this.books = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions(){PropertyNameCaseInsensitive = true})??[];
            }
        }

        public IEnumerable<Book> GetBooks(){
            return this.books;
        }

        public IEnumerable<Book> GetBooksAfter2000(){
            //return this.books.Where(book => book.PublishedDate.Year>2000);

            //Query expresion
            return from book in books where book.PublishedDate.Year > 2000 select book;
        }

        public IEnumerable<Book> GetBooksOver200PagesWithAction(){
            //return this.books.Where(book => book.PageCount>20 && book.Title.Contains("in Action"));

            //Query expresion
            return from book in books where book.PageCount > 200 &&  book.Title.Contains("in Action") select book;
        }

        public bool AllBooksHaveStatus(){
            return this.books.All(book => book.Status != string.Empty);
        }

        public bool AnyBookPublishedIn2005(){
            return this.books.Any(book => book.PublishedDate.Year == 2005);
        }

        public IEnumerable<Book> GetPythonBooks(){
            //return this.books.Where(book => book.Categories.Contains("Python")).OrderBy(book=>book.Title);
            return this.books.Where(book => book.Categories.Contains("Python")).OrderByDescending(book=>book.Title);
        }

        public int /* long */ GetPythonBookCount(){
            //return this.books.Where(book => book.Categories.Contains("Python")).OrderByDescending(book=>book.Title).LongCount();
            return this.books.Count(book => book.Categories.Contains("Python"));
        }

        public DateTime GetDateTimeMin(){
            return this.books.Min(book =>book.PublishedDate);
        }


        public int GetMaxPageCount(){
            return this.books.Max(book =>book.PageCount);
        }

        public Book GetBookWithFewestPages()
        {
            return this.books.Where(book => book.PageCount > 0).MinBy(p => p.PageCount)!;
        }

        public Book GetNewestPublishedBook()
        {
            return this.books.MaxBy(book => book.PublishedDate)!;
        }

        public int GetSum0Between500(){
            return this.books.Where(book => book.PageCount>=0 && book.PageCount<=500).Sum(book =>book.PageCount);
        }

        public string GetConcatenatedTitlesAfter2015()
        {
            return this.books
                .Where(book => book.PublishedDate.Year > 2015)
                .Aggregate("", (titles, next) =>
                {
                    if (titles != string.Empty)
                        titles += " - " + next.Title;
                    else
                        titles += next.Title;

                    return titles;
                });
        }

        public double GetAverageTitleLength()
        {
            return this.books.Average(book => book.Title.Length);
        }

        public IEnumerable<IGrouping<int, Book>> GetBooksAfter2000GroupedByYear()
        {
            return this.books
                .Where(book => book.PublishedDate.Year >= 2000)
                .GroupBy(book => book.PublishedDate.Year);
        }

        public ILookup<char, Book> GetBooksGroupedByInitialLetter()
        {
            return this.books.ToLookup(book => book.Title[0], book => book);
        }


        
    }
}