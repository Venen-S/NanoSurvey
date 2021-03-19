using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data
{
    public interface IAppContext
    {
        DbSet<Answer> Answers { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<Survey> Surveys { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Interview> Interviews { get; set; }
        DbSet<Result> Results { get; set; }
        Task<int> SaveChangesAsync();
    }
}