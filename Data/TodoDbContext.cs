using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }
        public DbSet<Todo> Todos => Set<Todo>();
    }

    public class TodoDbReadContext : DbContext
    {
        public TodoDbReadContext(DbContextOptions<TodoDbReadContext> options) : base(options) { }
        public DbSet<Todo> Todos => Set<Todo>();
    }
}