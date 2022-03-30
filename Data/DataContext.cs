using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using yadro.Data.Models;

namespace yadro.Data;
#nullable disable
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<VideoContent> Videos { get; set; }
    public DbSet<ImageContent> Photos { get; set; }
    public DbSet<BlogImage> BlogImages { get; set; }
    public DbSet<BlogVideo> BlogVideos { get; set; }
    public DbSet<AudioContent> Audios { get; set; }
}
