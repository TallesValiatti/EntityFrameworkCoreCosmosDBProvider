using App.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Data.Repositories
{
	public class FolderRepository : IFolderRepository
	{
        private readonly CosmosContext _cosmosContext;

        public FolderRepository(CosmosContext cosmosContext)
        {
            _cosmosContext = cosmosContext;
        }

        public async Task AddAsync(Folder folder)
        {
            await _cosmosContext.AddAsync(folder);
            //_cosmosContext.Folders.RemoveRange(_cosmosContext.Folders);
            await _cosmosContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Folder>> GetllAllAsync()
        {
            return await _cosmosContext.Folders.ToListAsync();
        }
    }
}

