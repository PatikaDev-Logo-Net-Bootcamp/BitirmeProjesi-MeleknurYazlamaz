using AutoMapper;
using InvoiceManagement.CreditCardService.Applications.Payment;
using InvoiceManagement.CreditCardService.Models.Payment;
using InvoiceManagement.CreditCardService.MongoDbDataAccess.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagement.CreditCardService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreatePaymentViewModel model)
        {
            CreatePayment payment = new CreatePayment(_paymentRepository, _mapper);
            payment.Model = model;
            var result = payment.Handle();
            return Ok(result);
        }

        [HttpGet("[action]/{companyId}")]
        public IActionResult GetCompanyId(string companyId)
        {
            GetPayments payments = new GetPayments(_paymentRepository, _mapper);
            payments.CompanyId = companyId;
            var result = payments.Handle();
            return Ok(result);
        }

    }
}
