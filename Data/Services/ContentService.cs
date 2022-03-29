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
        public async Task AddVideoAsync(string link, string description)
        {
            var target = new VideoContent { Id = Guid.NewGuid().ToString(), Path = link, Description = description };
            await _context.AddAsync(target);
            await _context.SaveChangesAsync(); 
        }
        public async Task AddImageAsync(string link, string description)
        {
            var target = new ImageContent { Id = Guid.NewGuid().ToString(), Path = link, Description = description };
            await _context.AddAsync(target);
            await _context.SaveChangesAsync(); 
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
        public async Task RemoveVideo(string id)
        {
            var target = _context.Videos.FirstOrDefault(v => v.Id == id);
            if(target != null) _context.Videos.Remove(target);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveImage(string id)
        {
            var target = _context.Photos.FirstOrDefault(i => i.Id == id);
            if(target != null) _context.Remove(target);
            await _context.SaveChangesAsync();
        }
    }
}