using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreeNode.Domain.Entities;

namespace TreeNode.Persistence.Configurations;

public class NodeConfiguration : IEntityTypeConfiguration<Node>
{
    public void Configure(EntityTypeBuilder<Node> builder)
    {
        builder.HasKey(n => n.Id);

        builder.Property(n => n.Name)
            .IsRequired();

        builder
            .HasOne(n => n.ParentNode)
            .WithMany(n => n.Children)
            .HasForeignKey(n => n.ParentNodeId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        
    }
}