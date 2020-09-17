using System.Threading;
using System.Threading.Tasks;
using ServicioPrueba.Domain.SeedWork;
using ServicioPrueba.Infrastructure.Database;
using ServicioPrueba.Infrastructure.Processing;

namespace ServicioPrueba.Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BDContext _bdcontext;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;

        public UnitOfWork(
            BDContext bdcontext, 
            IDomainEventsDispatcher domainEventsDispatcher)
        {
            this._bdcontext = bdcontext;
            this._domainEventsDispatcher = domainEventsDispatcher;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this._domainEventsDispatcher.DispatchEventsAsync();
            return await this._bdcontext.SaveChangesAsync(cancellationToken);
        }
    }
}