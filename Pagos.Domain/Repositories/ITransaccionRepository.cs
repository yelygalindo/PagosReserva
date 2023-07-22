using Pagos.Domain.Model.Transaciones;
using PagosKernel.Core;

namespace Pagos.Domain.Repositories;

public interface ITransaccionRepository : IRepository<Transaccion, Guid>
{
    Task UpdateAsync(Transaccion transaccion);
}
