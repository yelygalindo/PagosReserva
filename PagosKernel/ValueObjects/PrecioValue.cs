﻿
using PagosKernel.Core;

namespace PagosKernel.ValueObjects;

public record PrecioValue : ValueObject
{
    public decimal Value { get; }
    public PrecioValue(decimal value)
    {
        if (value < 0)
        {
            throw new BussinessRuleValidationException("Price value cannot be negative");
        }
        Value = value;
    }

    public static implicit operator decimal(PrecioValue value)
    {
        return value.Value;
    }

    public static implicit operator PrecioValue(decimal value)
    {
        return new PrecioValue(value);
    }
}
