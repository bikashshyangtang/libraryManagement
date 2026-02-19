using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Customer> Customers { get; set; }
    private readonly IConfiguration _configuration;
    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;   
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(
    new Customer { CustomerId = 1, FirstName = "Bikash", LastName = "Shyangtang", Email = "bikash@student.fdu.edu", PhoneNumber = "6045550101" },
    new Customer { CustomerId = 2, FirstName = "Alice", LastName = "Thompson", Email = "alice.t@email.com", PhoneNumber = "6045550102" },
    new Customer { CustomerId = 3, FirstName = "Bob", LastName = "Henderson", Email = "bob.h@yahoo.com", PhoneNumber = "7785550103" },
    new Customer { CustomerId = 4, FirstName = "Chloe", LastName = "Vance", Email = "cvance@outlook.com", PhoneNumber = "6045550104" },
    new Customer { CustomerId = 5, FirstName = "Daniel", LastName = "Park", Email = "d.park@gmail.com", PhoneNumber = "7785550105" },
    new Customer { CustomerId = 6, FirstName = "Elena", LastName = "Rodriguez", Email = "elena.rod@provider.net", PhoneNumber = "6045550106" },
    new Customer { CustomerId = 7, FirstName = "Felix", LastName = "Wright", Email = "fwright@techmail.com", PhoneNumber = "6045550107" },
    new Customer { CustomerId = 8, FirstName = "Grace", LastName = "Kim", Email = "g.kim@vancouver.ca", PhoneNumber = "7785550108" },
    new Customer { CustomerId = 9, FirstName = "Henry", LastName = "Miller", Email = "hmiller@business.com", PhoneNumber = "6045550109" },
    new Customer { CustomerId = 10, FirstName = "Isabella", LastName = "Chen", Email = "izzy.chen@gmail.com", PhoneNumber = "6045550110" },
    new Customer { CustomerId = 11, FirstName = "Jack", LastName = "Peterson", Email = "jack.p@outlook.com", PhoneNumber = "7785550111" },
    new Customer { CustomerId = 12, FirstName = "Katherine", LastName = "Ross", Email = "k.ross@web.com", PhoneNumber = "6045550112" },
    new Customer { CustomerId = 13, FirstName = "Liam", LastName = "Murray", Email = "liam.m@email.org", PhoneNumber = "6045550113" },
    new Customer { CustomerId = 14, FirstName = "Mia", LastName = "Foster", Email = "foster.mia@gmail.com", PhoneNumber = "7785550114" },
    new Customer { CustomerId = 15, FirstName = "Noah", LastName = "Brooks", Email = "n.brooks@provider.com", PhoneNumber = "6045550115" },
    new Customer { CustomerId = 16, FirstName = "Olivia", LastName = "Grant", Email = "o.grant@service.net", PhoneNumber = "6045550116" },
    new Customer { CustomerId = 17, FirstName = "Peter", LastName = "Walsh", Email = "p.walsh@icloud.com", PhoneNumber = "7785550117" },
    new Customer { CustomerId = 18, FirstName = "Quinn", LastName = "Taylor", Email = "q.taylor@gmail.com", PhoneNumber = "6045550118" },
    new Customer { CustomerId = 19, FirstName = "Ryan", LastName = "Singh", Email = "ryan.s@vpl.ca", PhoneNumber = "6045550119" },
    new Customer { CustomerId = 20, FirstName = "Sophie", LastName = "Bennett", Email = "s.bennett@mail.com", PhoneNumber = "7785550120" }
);
    }
}