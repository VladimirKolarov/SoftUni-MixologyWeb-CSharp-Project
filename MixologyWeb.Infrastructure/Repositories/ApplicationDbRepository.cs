using MixologyWeb.Infrastructure.Data;
using MixologyWeb.Infrastructure.Data.Common;

namespace MixologyWeb.Infrastructure.Repositories
{
    public class ApplicationDbRepository : Repository, IApplicationDbRepository
    {
        public ApplicationDbRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }
    }
}
