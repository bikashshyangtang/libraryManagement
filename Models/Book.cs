public class Book
{
    public int BookId{get; set;}
    public string? Title{get; set;}
    public string? Genre{get; set;}
    public int PublishedDate{get; set;}
    //public int AuthorId{get; set;}
    public int? BranchId{get; set;}
    public bool IsAvailable{get; set;} = true;
    public string? Edition{get; set;}
    public int CustomerId{get; set;}
    public int? AuthorId{get; set;}
    public long ISBN{get; set;}

    public Branch? Branch{get; set;}
    public Author? Author{get; set;}
}