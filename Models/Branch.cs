public class Branch
{
    public int BranchId{get; set;}
    public string? BranchName{get; set;}
    public string? Location{get; set;}
    public string? ContactNumber{get; set;}
    public string? Librarian{get; set;}
    public List<Book>? Books { get; set; }
}