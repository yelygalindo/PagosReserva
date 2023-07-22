using PagosKernel.Core;

namespace Pagos.Domain.Events
{
    public record TransaccionConfirmada : DomainEvent
    {
        public Guid TransaccionId { get; init; }
        public ICollection<DetalleTransaccionConfirmada> Detalle { get; init; }
        public TransaccionConfirmada(Guid transaccionId, 
            ICollection<DetalleTransaccionConfirmada> detalle) : base(DateTime.Now)
        {
            TransaccionId = transaccionId;
            Detalle = detalle;
        }

        public record DetalleTransaccionConfirmada(Guid ItemId, int Cantidad, decimal CostoUnitario);

    }
}
