using Microsoft.EntityFrameworkCore;
using MinasBank.Areas.Devs.Models;
using MinasBank.Shared.Data;

namespace MinasBank.Areas.Devs.Repository
{
    public class DevRepository : GenericRepository<Dev>, IDevRepository
    {
        private readonly DbContext _dbContext;

        public DevRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void AtualizarSemFoto(Dev dev)
        {
            Update(dev);
            _dbContext.Entry(dev).Property(x => x.FotoUrl).IsModified = false;
        }
    }
}
