namespace linq
{
    public class Book
    {
        public required string Title {get;set;}
        public required int PageCount {get;set;}
        public required string Status {get;set;}
        public required DateTime PublishedDate {get;set;}
        public required string[] Authors {get;set;}
        public required string[] Categories {get;set;}
    }
}