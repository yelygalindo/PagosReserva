using Pagos.Domain.Model.Transaciones;

namespace Pagos.Domain.Factories
{
    public class TransacctionFactory : ITransaccionFactory
    {
        public Transaccion CrearTransaccionIngreso()
        {
            return new Transaccion(TipoTransaccion.Ingreso);
        }

        public Transaccion CrearTransaccionSalida()
        {
            return new Transaccion(TipoTransaccion.Salida);
        }
    }
}
