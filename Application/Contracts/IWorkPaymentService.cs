using Application.DTO;

namespace Application.Contracts
{
    public interface IWorkPaymentService
    {
        Task<PaymentResult> ProcessPayment(PaymentParam paymentRequest);
        Task<PaymentResult> ProcessRefound(PaymentParam paymentRequest);
    }
}