﻿using Pagos.Domain.Events;
using Pagos.Domain.Exceptions;
using PagosKernel.Core;

namespace Pagos.Domain.Model.Transaciones
{
    public class Transaccion : AggregateRoot
    {
        public DateTime FechaRegistro { get; private set; }
        public DateTime? FechaConfirmacion { get; private set; }
        public DateTime? FechaAnulacion { get; private set; }

        private readonly ICollection<TransaccionItem> _items;

        public IEnumerable<TransaccionItem> Items => _items;

        public TipoTransaccion Tipo { get; private set; }

        public EstadoTransaccion Estado { get; private set; }

        internal Transaccion(TipoTransaccion tipo)
        {
            Estado = EstadoTransaccion.Registrada;
            Tipo = tipo;
            FechaRegistro = DateTime.Now;
            _items = new List<TransaccionItem>();
        }
        
        public void AgregarItem(Guid itemId, int cantidad, decimal costoUnitario)
        {
            if(_items.Any(item => item.ItemId == itemId))
            {
                throw new ArgumentException("El item ya existe en la transaccion");
            }
            TransaccionItem item = new TransaccionItem(itemId, cantidad, costoUnitario);
            _items.Add(item);
        }

        public void Confirmar()
        {
            if(Estado != EstadoTransaccion.Registrada)
            {
                throw new ConfirmationTransacctionException("La transaccion esta en estado: " + Estado.ToString());
            }
            if(_items.Count == 0)
            {
                throw new ConfirmationTransacctionException("La transaccion no tiene items");
            }

            Estado = EstadoTransaccion.Confirmada;
            FechaConfirmacion = DateTime.Now;

            int tipoMovimiento = Tipo == TipoTransaccion.Salida ? -1 : 1;

            List<TransaccionConfirmada.DetalleTransaccionConfirmada> detalle =
                _items.Select(item => new TransaccionConfirmada.DetalleTransaccionConfirmada(item.ItemId, tipoMovimiento * item.Cantidad, item.CostoUnitario.Value))
                .ToList();

            TransaccionConfirmada evento = new TransaccionConfirmada(Id, detalle);
            AddDomainEvent(evento);
        }

        public void Anular()
        {
            if (Estado != EstadoTransaccion.Registrada)
            {
                throw new ConfirmationTransacctionException("La transaccion esta en estado: " + Estado.ToString());
            }
            Estado = EstadoTransaccion.Anulada;
            FechaAnulacion = DateTime.Now;
        }
    }
}
