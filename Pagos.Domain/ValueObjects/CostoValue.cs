using PagosKernel.Core;

namespace Pagos.Domain.ValueObjects;

public record CostoValue : ValueObject
{
    public decimal Value { get; init; }
    
    public CostoValue(decimal value)
    {
        if(value < 0)
        {
            throw new ArgumentException("El monto debe ser mayor que cero.");
        }

        Value = value;
    }

    public static implicit operator decimal(CostoValue costo) => costo.Value;

    public static implicit operator CostoValue(decimal value) => new(value);
}
