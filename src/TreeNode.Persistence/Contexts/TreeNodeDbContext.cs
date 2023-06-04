using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TreeNode.Domain.Entities;

namespace TreeNode.Persistence.Contexts;

public class TreeNodeDbContext: DbContext
{
    public TreeNodeDbContext(DbContextOptions<TreeNodeDbContext> options): base(options)
    { }
    
    public DbSet<Node> Nodes => Set<Node>();
    public DbSet<ExceptionRecord> ExceptionRecords => Set<ExceptionRecord>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
    
}