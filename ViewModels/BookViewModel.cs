public class BookViewModel
{
    public int BookId { get; set; }
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public int PublishedDate { get; set; }
    public string? AuthorName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? BranchName { get; set; }
    public long ISBN { get; set; }
    public string IsAvailable { get; set; } = "No";
    public string? Edition { get; set; }
    public int? BranchId{get; set;}

}