using BackpackerOfLife.Blog.API.Model;

namespace BackpackerOfLife.Blog.API.AppServices.IAppServices
{
    public interface IMainAppService
    {
        Task<IEnumerable<Content>> Get(CancellationToken cancellationToken);
        Task<Content> GetById(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Content>> GetByTitle(string name, CancellationToken cancellationToken);
        Task Create(Content content, CancellationToken cancellationToken);
        Task Update(int id, Content content, CancellationToken cancellationToken);
        Task Delete(Content content, CancellationToken cancellationToken);
    }
}
