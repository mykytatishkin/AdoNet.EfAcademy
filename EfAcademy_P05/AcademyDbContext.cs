using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfAcademy_P05
{
    public class AcademyDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public AcademyDbContext(DbContextOptions<AcademyDbContext> options) : base(options)
        {
            
            Database.EnsureCreated();
        }
    }
}
