using BackpackerOfLife.Blog.API.AppServices.IAppServices;
using BackpackerOfLife.Blog.API.Model;
using BackpackerOfLife.Blog.API.Services.IServices;

namespace BackpackerOfLife.Blog.API.AppServices
{
    public class MainAppService : IMainAppService
    {
        private readonly IMainService _mainService;
        public MainAppService(IMainService mainService)
        {
            _mainService = mainService;
        }

        public async Task<IEnumerable<Content>> Get(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mainService.Get(cancellationToken);
                return result;
            }
            catch (OperationCanceledException ex)
            {
                return Enumerable.Empty<Content>();
            }
        }

        public async Task<Content> GetById(int id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mainService.GetById(id, cancellationToken);
                return result;
            }
            catch (OperationCanceledException ex)
            {
                return new Content();
            }
        }

        public async Task<IEnumerable<Content>> GetByTitle(string name, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mainService.GetByTitle(name, cancellationToken);
                return result;
            }
            catch (OperationCanceledException ex)
            {
                return Enumerable.Empty<Content>();
            }
        }

        public async Task Create(Content content, CancellationToken cancellationToken)
        {
            try
            {
                await _mainService.Create(content, cancellationToken);
            }
            catch (OperationCanceledException ex)
            {

            }
        }

        public async Task Update(int id, Content content, CancellationToken cancellationToken)
        {
            try
            {
                await _mainService.Update(id, content, cancellationToken);
            }
            catch (OperationCanceledException ex)
            {

            }
        }

        public async Task Delete(Content content, CancellationToken cancellationToken)
        {
            try
            {
                await _mainService.Delete(content, cancellationToken);
            }
            catch (OperationCanceledException ex)
            {

            }
        }
    }
}
