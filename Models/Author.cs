public class Author
{
    public int AuthorId{get; set;}
    public string? FirstName{get; set;}
    public string? LastName{get; set;}
    public string? MiddleName{get; set;}
    public string? Email{get; set;}
    public bool IsAwardWinner{get; set;}
    public bool IsBestSeller{get; set;}
    public List<Book>? Books{get; set;}

}