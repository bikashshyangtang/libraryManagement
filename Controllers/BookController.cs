using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc;

public class BookController : Controller
{
    private readonly AppDbContext _context;

    public BookController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var books = _context.Books.ToList();
        List<BookViewModel> bookViewModel = new List<BookViewModel>();
        foreach (var book in books)
        {
            BookViewModel bookViewModelItem = new BookViewModel()
            {
                BookId = book.BookId,
                Title = book.Title,
                Genre = book.Genre,
                PublishedDate = book.PublishedDate,
                BranchName = _context.Branches.FirstOrDefault(b => b.BranchId == book.BranchId)?.BranchName,
                ISBN = book.ISBN,
                AuthorName = _context.Authors.FirstOrDefault(a => a.AuthorId == book.AuthorId)?.FirstName + " " + _context.Authors.FirstOrDefault(a => a.AuthorId == book.AuthorId)?.LastName,
                IsAvailable = book.IsAvailable == true ? "Yes" : "No",
            };
            bookViewModel.Add(bookViewModelItem);
        }
        
        return View(bookViewModel);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(BookViewModel bookViewModel)
    {
        if (ModelState.IsValid)
        {
            var book = new Book()
            {
                Title = bookViewModel.Title,
                Genre = bookViewModel.Genre,
                PublishedDate = bookViewModel.PublishedDate,
                AuthorId = _context.Authors.FirstOrDefault(a => a.FirstName + " " + a.LastName == bookViewModel.AuthorName)?.AuthorId ?? null,
                BranchId = _context.Branches.FirstOrDefault(b => b.BranchName == bookViewModel.BranchName)?.BranchId ?? null,
                ISBN = bookViewModel.ISBN,
            };
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(bookViewModel);
    }

    [HttpGet]
    public IActionResult Edit(int bookId)
    {
        var book = _context.Books.FirstOrDefault(b => b.BookId == bookId);
        if (book != null)
        {
            var bookViewModel = new BookViewModel()
            {
                Title = book.Title,
                BookId = book.BookId,
                BranchName = _context.Branches.FirstOrDefault(b => b.BranchId == book.BranchId)?.BranchName ?? String.Empty,
                BranchId = book.BranchId,
                FirstName = _context.Authors.FirstOrDefault(a => a.AuthorId == book.AuthorId)?.FirstName ?? String.Empty,
                LastName =_context.Authors.FirstOrDefault(a => a.AuthorId == book.AuthorId)?.LastName ?? String.Empty,
                Genre = book.Genre,
                PublishedDate = book.PublishedDate,
                ISBN = book.ISBN
            };
            bookViewModel.AuthorName = bookViewModel.FirstName + " " + bookViewModel.LastName;
            return View(bookViewModel);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Edit(BookViewModel bookViewModel)
    {
        if (ModelState.IsValid)
        {
            var book = new Book()
            {
                BookId = bookViewModel.BookId,
                Title = bookViewModel.Title,
                Genre = bookViewModel.Genre,
                PublishedDate = bookViewModel.PublishedDate,
                AuthorId = _context.Authors.FirstOrDefault(a => a.FirstName + " " + a.LastName == bookViewModel.AuthorName)?.AuthorId ?? null,
                BranchId = _context.Branches.FirstOrDefault(b => b.BranchName == bookViewModel.BranchName)?.BranchId ?? null,
                ISBN = bookViewModel.ISBN,
            };
            _context.Books.Update(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(bookViewModel);
    }

    [HttpPost]
    public IActionResult Delete(int? bookId)
    {
        if (bookId == null)
        {
            return Json(new {success = false, message = "BookId is required"});
        }
        else
        {
            var book = _context.Books.FirstOrDefault(b => b.BookId == bookId);
            if (book == null)
            {
                return Json(new {success = false, message = "Book not found in database"});
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Json(new{success = true, message = "Book is deleted"});
        }
    }
}