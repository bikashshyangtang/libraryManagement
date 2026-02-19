using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;

public class AuthorController : Controller
{
    private readonly AppDbContext _context;

    public AuthorController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var authors = _context.Authors.ToList();
        List<AuthorViewModel> authorViewModels = new List<AuthorViewModel>();
        foreach (var author in authors)
        {
            AuthorViewModel authorViewModel = new AuthorViewModel()
            {
                AuthorId = author.AuthorId,
                FirstName = author.FirstName,
                LastName = author.LastName,
                IsAwardWinner = author.IsAwardWinner ? "Yes" : "No",
                IsBestSeller = author.IsBestSeller ? "Yes" : "No",
                Email = author.Email
            };
            authorViewModels.Add(authorViewModel);
        }
        return View(authorViewModels);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(AuthorViewModel authorViewModel)
    {
        if (ModelState.IsValid)
        {
            var author = new Author()
            {
                FirstName = authorViewModel.FirstName,
                LastName = authorViewModel.LastName,
                Email = authorViewModel.Email,
                IsAwardWinner = authorViewModel.IsAwardWinner?.ToUpper() == "YES" ? true : false,
                IsBestSeller = authorViewModel.IsBestSeller?.ToUpper() == "YES" ? true : false
            };
            _context.Authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(authorViewModel);
    }

    [HttpGet]
    public IActionResult Edit(int authId)
    {
        var author = _context.Authors.FirstOrDefault(a => a.AuthorId == authId);
        if(author != null)
        {
            var authorViewModel = new AuthorViewModel()
            {
                AuthorId = author.AuthorId,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Email = author.Email,
                IsAwardWinner = author.IsAwardWinner == true ? "Yes" : "No",
                IsBestSeller = author.IsBestSeller == true ?  "Yes" : "No"
            };
            return View(authorViewModel);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Edit(AuthorViewModel authorViewModel)
    {
        if (ModelState.IsValid)
        {
            var author = new Author()
            {
                AuthorId = authorViewModel.AuthorId,
                FirstName = authorViewModel.FirstName,
                LastName = authorViewModel.LastName,
                Email = authorViewModel.Email,
                IsAwardWinner = authorViewModel.IsAwardWinner?.ToUpper() == "YES" ? true : false,
                IsBestSeller = authorViewModel.IsBestSeller?.ToUpper() == "YES" ? true : false
            };
            _context.Authors.Update(author);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(authorViewModel);
    }

    [HttpPost]
    public IActionResult Delete(int? authorId)
    {
         if (authorId == null)
        {
            return Json(new {success = false, message = "AuthorId is required"});
        }
        else
        {
            var author = _context.Authors.FirstOrDefault(b => b.AuthorId == authorId);
            if (author == null)
            {
                return Json(new {success = false, message = "Author not found in database"});
            }
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return Json(new{success = true, message = "Author is deleted"});
        }
    }
}