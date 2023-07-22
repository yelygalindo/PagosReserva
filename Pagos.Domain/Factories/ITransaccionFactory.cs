using Pagos.Domain.Model.Transaciones;

namespace Pagos.Domain.Factories
{
    public interface ITransaccionFactory
    {
        Transaccion CrearTransaccionIngreso();
        Transaccion CrearTransaccionSalida();
    }
}
