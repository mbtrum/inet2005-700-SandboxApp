using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SandboxApp.Models;

namespace SandboxApp.Data
{
    public class SandboxAppContext : DbContext
    {
        public SandboxAppContext (DbContextOptions<SandboxAppContext> options)
            : base(options)
        {
        }

        public DbSet<SandboxApp.Models.Photo> Photo { get; set; } = default!;
        public DbSet<SandboxApp.Models.Person> Person { get; set; } = default!;
    }
}
