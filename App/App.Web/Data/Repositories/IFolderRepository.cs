using App.Web.Models;

namespace App.Web.Data.Repositories
{
	public interface IFolderRepository
	{
		Task<IEnumerable<Folder>> GetllAllAsync();

		Task AddAsync(Folder folder);
    }
}

