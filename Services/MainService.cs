using BackpackerOfLife.Blog.API.Context;
using BackpackerOfLife.Blog.API.Model;
using BackpackerOfLife.Blog.API.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace BackpackerOfLife.Blog.API.Services
{
    public class MainService : IMainService
    {
        private readonly BlogDbContext _context;
        public MainService(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Content>> Get(CancellationToken cancellationToken)
        {
            return await _context.Contents.ToListAsync(cancellationToken);
        }

        public async Task<Content> GetById(int id, CancellationToken cancellationToken)
        {
            var content = await _context.Contents.FindAsync(id, cancellationToken);
            return content;
        }

        public async Task<IEnumerable<Content>> GetByTitle(string name, CancellationToken cancellationToken)
        {
            var content = await _context.Contents.Where(c => name.Contains(c.Title)).ToListAsync(cancellationToken);
            return content;
        }

        public async Task Update(int id, Content content, CancellationToken cancellationToken)
        {
            if (content.Id == id)
            {
                _context.Entry(content).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Entry(content).State = EntityState.Unchanged;
            }
        }

        public async Task Create(Content content, CancellationToken cancellationToken)
        {
            _context.Contents.Add(content);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Content content, CancellationToken cancellationToken)
        {
            _context.Contents.Remove(content);
            await _context.SaveChangesAsync();
        }
    }
}
