using PagosKernel.Core;

namespace Pagos.Domain.Events
{
    public record ConfirmedPayment : DomainEvent
    {
        public Guid PaymentId { get; init; }
        public ICollection<DetalleTransaccionConfirmada> Detalle { get; init; }
        public ConfirmedPayment(Guid paymentId, ICollection<DetalleTransaccionConfirmada> detalle) : base(DateTime.Now)
        {
            PaymentId = paymentId;
            Detalle = detalle;
        }

        public record DetalleTransaccionConfirmada(Guid ItemId, int Cantidad, decimal CostoUnitario);
    }
}