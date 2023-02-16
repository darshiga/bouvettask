using Bouvet_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace Bouvet_Task.Data
{
    public class TaskAPIDbContext : DbContext
    {
        public TaskAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskDetails> TaskDetails { get; set; }
    }
}
