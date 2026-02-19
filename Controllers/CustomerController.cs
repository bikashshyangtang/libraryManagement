using Microsoft.AspNetCore.Mvc;

public class CustomerController : Controller
{
    private readonly AppDbContext _context;

    public CustomerController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var customers = _context.Customers.ToList();
        List<CustomerViewModel> customerViewModels = new List<CustomerViewModel>();
        foreach (var customer in customers)
        {
            CustomerViewModel customerViewModel = new CustomerViewModel()
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                //MiddleName = customer.MiddleName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };
            customerViewModels.Add(customerViewModel);
        }
        return View(customerViewModels);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CustomerViewModel customerViewModel)
    {
        if (ModelState.IsValid)
        {
            var customer = new Customer()
            {
                CustomerId = customerViewModel.CustomerId,
                FirstName = customerViewModel.FirstName,
                //MiddleName = customerViewModel.MiddleName,
                LastName = customerViewModel.LastName,
                Email = customerViewModel.Email,
                PhoneNumber = customerViewModel.PhoneNumber
            };
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(customerViewModel);
    }

    [HttpGet]
    public IActionResult Edit(int? customerId)
    {
        if(customerId == null)
        {
            return RedirectToAction("Index");
        }
        var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        var viewModel = new CustomerViewModel()
        {
            FirstName = customer?.FirstName,
            //MiddleName = customer?.MiddleName,
            LastName = customer?.LastName,
            Email = customer?.Email,
            PhoneNumber = customer?.PhoneNumber
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Edit(CustomerViewModel customerViewModel)
    {
        if(customerViewModel != null)
        {
            var customer = new Customer()
            {
                CustomerId = customerViewModel.CustomerId,
                FirstName = customerViewModel.FirstName,
                //MiddleName = customerViewModel.MiddleName,
                LastName = customerViewModel.LastName,
                Email = customerViewModel.Email,
                PhoneNumber = customerViewModel.PhoneNumber
            };
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(customerViewModel);
    }

    [HttpPost]
    public IActionResult Delete(int? customerId)
    {
        if(customerId == null)
        {
            return Json(new {success = false, message = "CustomerId is required."});
        }
        else
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customer == null)
            {
                return Json(new {success = false, message = "Customer not found."});
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Json(new{success = true, message = "Customer is deleted."});
        }
    }
}