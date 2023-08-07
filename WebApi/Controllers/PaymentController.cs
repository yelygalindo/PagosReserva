using Application.Contracts;
using Application.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/Payment/")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IWorkPaymentService _workPaymentService;

        public PaymentController(IWorkPaymentService workPaymentService) 
        {
            _workPaymentService = workPaymentService;
        }

        [HttpPost("payment")]
        public async Task<IActionResult> ProcessPaymentAsync([FromBody] PaymentData paymentData)
        {
            if (paymentData == null)
            {
                return BadRequest("Los datos de pago son requeridos.");
            }

            PaymentParam paymentParam = new(paymentData.Provider,paymentData.Amount,paymentData.Currency,paymentData.CardToken);
            var result = await _workPaymentService.ProcessPayment(paymentParam);           
            return Ok(result);           
        }

        [HttpPost("refund")]
        public async Task<IActionResult> ProcessRefundAsync([FromBody] RefoundData refundData)
        {
            if (refundData == null)
            {
                return BadRequest("Los datos de devolución son requeridos.");
            }

            PaymentParam paymentParam = new(refundData.Provider, refundData.Amount, refundData.Currency, refundData.CardToken);
            var result = await _workPaymentService.ProcessRefound(paymentParam);
            return Ok(result);            
        }
    }
}
