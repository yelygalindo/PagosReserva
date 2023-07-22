using PagosKernel.Core;

namespace Pagos.Domain.ValueObjects;

public record AmountValue : ValueObject
{
    public decimal Value { get; init; }
    
    public AmountValue(decimal value)
    {
        if(value < 0)
        {
            throw new ArgumentException("El monto debe ser mayor que cero.");
        }

        Value = value;
    }

    public static implicit operator decimal(AmountValue costo) => costo.Value;

    public static implicit operator AmountValue(decimal value) => new(value);
}
