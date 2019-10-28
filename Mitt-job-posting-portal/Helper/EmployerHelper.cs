using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mitt_job_posting_portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mitt_job_posting_portal.Helper
{
    public class EmployerHelper
    {
        UserManager<User> userManager;
        RoleManager<IdentityRole> roleManager;
        ApplicationDbContext context;

        public EmployerHelper(ApplicationDbContext context)
        {
            this.context = context;
            userManager= new UserManager<User>(new UserStore<User>(context));
            roleManager= new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        }
    }
}