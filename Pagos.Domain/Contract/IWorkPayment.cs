using Pagos.Domain.Entities;
namespace Pagos.Domain.Contract
{
    public  interface IWorkPayment
    {
        Task<Transaction> Process(Transaction paymentRequest);       
    }
}
