using Microsoft.EntityFrameworkCore;

namespace StudentPerformanceServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<StudySession> StudySessions { get; set; }
        public DbSet<Break> Break { get; set; }
        public DbSet<Progress> Progress { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
