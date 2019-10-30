using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mitt_job_posting_portal.Models;
using System.Linq;

namespace Mitt_job_posting_portal.Helper
{
  public class AccountHelper
  {
    ApplicationDbContext db;
    private RoleManager<IdentityRole> _roleManager;
    private UserManager<User> _userManager;
    public AccountHelper(ApplicationDbContext db)
    {
      this.db = db;
      _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
      _userManager = new UserManager<User>(new UserStore<User>(db));
    }
    public string GetUserRole(string userId)
    {
      return _userManager.GetRoles(userId).First();
    }
  }
}