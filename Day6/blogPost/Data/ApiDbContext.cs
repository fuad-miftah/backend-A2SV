using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogpost.Models;
using Microsoft.EntityFrameworkCore;


namespace blogpost.Data;

public class ApiDbContext : DbContext
{
    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Comment>(entity => {
            entity.HasOne(p => p.Post)
                .WithMany(c => c.Comments)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict);
                
        });
    }
}