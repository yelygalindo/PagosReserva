using Pagos.Domain.Contract;
using Pagos.Domain.Entities;
using Pagos.Domain.Model;

namespace Pagos.Domain.Repositories
{
    public class WorkPayment : IWorkPayment
    {
        private readonly IPaymentProvider _paymentProvider;
        private readonly ITransaction _transaction;

        public WorkPayment(IPaymentProvider paymentProvider, ITransaction transaction)
        {
            _paymentProvider = paymentProvider;
            _transaction = transaction;
        }

        public async Task<Transaction> Process(Transaction paymentRequest)
        {
            if (paymentRequest is null)
            {
                throw new ArgumentNullException(nameof(paymentRequest));
            }
            
            Transaction resultPayment = null;

            switch (paymentRequest.TransactionType) { 
                case TransactionType.Payment:
                    resultPayment = _paymentProvider.ProcessPayment(paymentRequest);
                    break;
                case TransactionType.Withdrawal:
                    resultPayment = _paymentProvider.ProcessRefund(paymentRequest);
                    break;
            }
            if (resultPayment is null) {
                throw new Exception("no se encontro la transacción.");
            }

            Transaction result = new(paymentRequest.Customer, paymentRequest.ProviderName, resultPayment.TransactionId, 
                paymentRequest.Amount, resultPayment.TransactionType, resultPayment.Currency, resultPayment.CardToken);
            await _transaction.SavePaymentRecord(result);

            return result;
        }
    }
}
