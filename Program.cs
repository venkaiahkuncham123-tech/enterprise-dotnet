using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlite("Data Source=app.db"));
var app = builder.Build();
app.MapGet("/api/tasks", async (AppDbContext db) => await db.Tasks.ToListAsync());
app.Run();
public class TodoTask { public int Id { get; set; } public string Title { get; set; } = ""; }
public class AppDbContext : DbContext {
 public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
 public DbSet<TodoTask> Tasks => Set<TodoTask>();
}