using PagosKernel.Core;

namespace Pagos.Domain.ValueObjects;

public record PaymentDate : ValueObject
{
    public DateTime Date { get; }

    public PaymentDate(DateTime date)
    {
        if (date > DateTime.Now)
        {
            throw new ArgumentException("La fecha del pago no puede ser en el futuro.", nameof(date));
        }

        Date = date.Date; 
    }
}
