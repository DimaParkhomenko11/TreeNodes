using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TreeNode.Domain.Entities;
using TreeNode.Persistence.Contexts;
using TreeNode.Persistence.Exceptions;

namespace TreeNode.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly TreeNodeDbContext _context;

    public ApplicationDbContextInitialiser(
        TreeNodeDbContext context,
        ILogger<ApplicationDbContextInitialiser> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public async Task SeedAsync()
    {
        await InitialiseAsync();
        
        if (!_context.Nodes.Any())
        {
            _context.Nodes.Add(new Node
            {
                Name = "Root"
            });
        
            await _context.SaveChangesAsync();
        }
    }
    
    private async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsNpgsql())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw new DBException("An error occurred while initialising the database.");
        }
    }
}