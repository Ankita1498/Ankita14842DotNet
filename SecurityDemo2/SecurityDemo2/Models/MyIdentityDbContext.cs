using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SecurityDemo2.Models
{
    public class MyIdentityDbContext: IdentityDbContext<MyIdentityUser,MyIdentityRole,string>
    {
        public MyIdentityDbContext(DbContextOptions<MyIdentityDbContext>options):base (options)
        {

        }
    }
}
