using Microsoft.EntityFrameworkCore;
using yadro.Data.Models;

namespace yadro.Data.Services
{
    public class ContentService
    {
        DataContext _context;
        public ContentService(DataContext context)
        {
            _context = context;
        }
        public async Task AddVideoAsync(string link)
        {
            var target = new VideoContent { Id = Guid.NewGuid().ToString(), Path = link, Description = string.Empty };
            await _context.AddAsync(target);
            await _context.SaveChangesAsync(); 
        }
        public async Task<ImageContent> AddImageAsync(string link)
        {
            var target = new ImageContent { Id = Guid.NewGuid().ToString(), Path = link, Description = string.Empty };
            await _context.AddAsync(target);
            await _context.SaveChangesAsync();
            return target;
        }
        public async Task<List<VideoContent>> GetVideosAsync()
        {
            var videos = await _context.Videos.ToListAsync();
            return videos.DistinctBy(v => v.Path).ToList();
        }
        public async Task<List<ImageContent>> GetImagesAsync()
        {
            return await _context.Photos.ToListAsync();
        }
    }
}