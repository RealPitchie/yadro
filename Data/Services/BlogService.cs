using Microsoft.EntityFrameworkCore;
using yadro.Data.Models;

namespace yadro.Data.Services
{
    public class BlogService
    {
        IWebHostEnvironment _env;
        DataContext _context;
        public BlogService(IWebHostEnvironment env, DataContext context)
        {
            _context = context;
            _env = env;
        }
        public async Task<Post> AddAsync(Post post)
        {
            await _context.AddAsync(post);
            await _context.SaveChangesAsync();

            return post;
        }
        public async Task<Comment> AddCommentAsync(Comment comment)
        {
            await _context.AddAsync(comment);
            await _context.SaveChangesAsync();

            return comment;
        }
        public async Task<List<Post>> GetAsync()
        {
            return await _context.Posts.Include(p => p.Comments).ToListAsync();
        }
        public async Task<Post> GetAsync(string postId)
        {
            #nullable disable
            return await _context.Posts.Where(p => p.Id == postId).Include(p => p.Comments).FirstOrDefaultAsync();
        } 
    }
}