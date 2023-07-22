using Pagos.Domain.ValueObjects;
using PagosKernel.Core;

namespace Pagos.Domain.Model.Transaciones
{
    public class TransaccionItem : Entity
    {
        public Guid ItemId { get; private set; }
        public CantidadTransaccion Cantidad { get; private set; }
        public CostoValue CostoUnitario { get; private set; }
        public CostoValue CostoTotal  { get; private set; }

        internal TransaccionItem(Guid itemId, int cantidad, decimal costoUnitario)
        {
            ItemId = itemId;
            Cantidad = cantidad;
            CostoUnitario = costoUnitario;
            CostoTotal = cantidad * costoUnitario;
        }
    }
}
