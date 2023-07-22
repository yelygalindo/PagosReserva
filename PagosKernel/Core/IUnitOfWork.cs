namespace PagosKernel.Core;

public interface IUnitOfWork
{
    Task Commit();
}
