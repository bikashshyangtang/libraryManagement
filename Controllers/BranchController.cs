using Microsoft.AspNetCore.Mvc;

public class BranchController : Controller
{
    private readonly AppDbContext appDbContext;
    public BranchController(AppDbContext context)
    {
        appDbContext = context;
    }

    public IActionResult Index()
    {
        var branches = appDbContext.Branches.ToList();
        List<BranchViewModel> branchViewModels = new List<BranchViewModel>();
        foreach (var branch in branches)
        {
            BranchViewModel branchViewModel = new BranchViewModel()
            {
                BranchId = branch.BranchId,
                BranchName = branch.BranchName,
                Location = branch.Location,
                ContactNumber = branch.ContactNumber,
                Librarian = branch.Librarian
            };
            branchViewModels.Add(branchViewModel);
        }
        return View(branchViewModels);
    }

     [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(BranchViewModel branchViewModel)
    {
        if (ModelState.IsValid)
        {
            var branch = new Branch()
            {
                BranchName = branchViewModel.BranchName,
                Location = branchViewModel.Location,
                ContactNumber = branchViewModel.ContactNumber,
                Librarian = branchViewModel.Librarian
            };
            appDbContext.Branches.Add(branch);
            appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(branchViewModel);
    }

    public IActionResult Edit(int branchId)
    {
        var branch = appDbContext.Branches.FirstOrDefault(b => b.BranchId == branchId);
        if (branch != null)
        {
            var branchViewModel = new BranchViewModel()
            {
                BranchName = branch.BranchName,
                Location = branch.Location,
                ContactNumber = branch.ContactNumber,
                Librarian = branch.Librarian
            };
            return View(branchViewModel);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Edit(BranchViewModel viewModel)
    {
         if (ModelState.IsValid)
        {
            var branch = new Branch()
            {
                BranchId = viewModel.BranchId,
                BranchName = viewModel.BranchName,
                Location = viewModel.Location,
                ContactNumber = viewModel.ContactNumber,
                Librarian = viewModel.Librarian
            };
            appDbContext.Branches.Update(branch);
            appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(viewModel);
    }

    [HttpPost]
        public IActionResult Delete(int? branchId)
    {
         if (branchId == null)
        {
            return Json(new {success = false, message = "BranchId is required"});
        }
        else
        {
            var branch = appDbContext.Branches.FirstOrDefault(b => b.BranchId == branchId);
            if (branch == null)
            {
                return Json(new {success = false, message = "Branch not found in database"});
            }
            appDbContext.Branches.Remove(branch);
            appDbContext.SaveChanges();
            return Json(new{success = true, message = "Branch is deleted"});
        }
    }

}
