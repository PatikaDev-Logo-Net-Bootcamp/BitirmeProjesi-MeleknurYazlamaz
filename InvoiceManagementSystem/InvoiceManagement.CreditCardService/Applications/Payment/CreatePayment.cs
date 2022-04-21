using System.Net;
using AutoMapper;
using InvoiceManagement.CreditCardService.Models.Payment;
using InvoiceManagement.CreditCardService.Entities;
using InvoiceManagement.CreditCardService.MongoDbDataAccess.Abstracts;
using InvoiceManagement.CreditCardService.Utilities.Results;

namespace InvoiceManagement.CreditCardService.Applications.Payment
{
    public class CreatePayment
    {
        public CreatePaymentViewModel Model { get; set; }
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public CreatePayment(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }
        public IResult Handle()
        {
            var payment = _mapper.Map<Entities.Payment>(Model);
            payment.CreditCard = _mapper.Map<CreditCard>(Model);
            _paymentRepository.Insert(payment);
            return new Result(true, (int)HttpStatusCode.Created, $"{payment.Amount} TL ödeme alındı.");
        }
    }

}
