using Application.Contracts;
using Application.DTO;
using Pagos.Domain.Contract;
using Pagos.Domain.Entities;
using Pagos.Domain.Model;
using Pagos.Domain.ValueObjects;

namespace Application.Services
{
    public class WorkPaymentService : IWorkPaymentService
    {
        private readonly IWorkPayment _workPayment;
        public WorkPaymentService(IWorkPayment workPayment)
        {
            _workPayment = workPayment;
        }

        public async Task<PaymentResult> ProcessPayment(PaymentParam paymentParam)
        {
            var paymentRequest = new 
                Transaction(
                paymentParam.Customer, 
                paymentParam.Provider, 
                string.Empty, 
                new AmountValue(paymentParam.Amount),
                TransactionType.Payment, 
                paymentParam.Currency,
                paymentParam.CardToken
                );

            var result = await _workPayment.Process(paymentRequest);
            var paymentResult = new PaymentResult(result.Customer, result.ProviderName, result.TransactionId, result.Amount.Value, result.IsSuccessfull);
            return paymentResult;
        }

        public async Task<PaymentResult> ProcessRefound(PaymentParam paymentParam)
        {
            var paymentRequest = new
               Transaction(
               paymentParam.Customer,
               paymentParam.Provider,
               string.Empty,
               new AmountValue(paymentParam.Amount),
               TransactionType.Withdrawal,
               paymentParam.Currency,
               paymentParam.CardToken
               );

            var result = await _workPayment.Process(paymentRequest);
            var paymentResult = new PaymentResult(result.Customer, result.ProviderName, result.TransactionId, result.Amount.Value, result.IsSuccessfull);
            return paymentResult;
        }
    }
}
