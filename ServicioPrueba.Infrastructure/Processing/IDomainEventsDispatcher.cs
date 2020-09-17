using System.Threading.Tasks;

namespace ServicioPrueba.Infrastructure.Processing
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync();
    }
}