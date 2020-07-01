using Microsoft.EntityFrameworkCore;
using MvcSM.Models;

namespace MvcSM.Data
{
  public class MvcSMContext : DbContext
  {
    public MvcSMContext (DbContextOptions<MvcSMContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Student { get; set; }
    public DbSet<User> User { get; set; }

  }
}