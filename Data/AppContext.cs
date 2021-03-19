using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Threading.Tasks;

namespace Data
{
    public class AppContext:DbContext, IAppContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Result> Results { get; set; }

        public AppContext(DbContextOptions<AppContext> options) : base(options) { }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}