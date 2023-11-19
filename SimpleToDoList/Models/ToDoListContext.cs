using Microsoft.EntityFrameworkCore;
namespace SimpleToDoList.Models
{
    public class ToDoListContext : DbContext
    {

        public DbSet<ToDoTask> ToDoList => Set<ToDoTask>();
        public ToDoListContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ToDoList.db");
        }

    }
}
