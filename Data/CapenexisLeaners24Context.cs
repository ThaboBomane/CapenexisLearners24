using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CapenexisLearners24.Models;

namespace CapenexisLeaners24.Data
{
    public class CapenexisLeaners24Context : DbContext
    {
        public CapenexisLeaners24Context (DbContextOptions<CapenexisLeaners24Context> options)
            : base(options)
        {
        }

        public DbSet<CapenexisLearners24.Models.Courses> Courses { get; set; } = default!;

        public DbSet<CapenexisLearners24.Models.Facilitators> Facilitators { get; set; } = default!;

        public DbSet<CapenexisLearners24.Models.Learners> Learners { get; set; } = default!;
    }
}
