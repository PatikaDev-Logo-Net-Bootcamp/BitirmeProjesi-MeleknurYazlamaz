using System.Collections.Generic;
using AutoMapper;
using InvoiceManagement.CreditCardService.Models.Payment;
using InvoiceManagement.CreditCardService.MongoDbDataAccess.Abstracts;

namespace InvoiceManagement.CreditCardService.Applications.Payment
{
    public class GetPayments
    {
        public string CompanyId { get; set; }

        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public GetPayments(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public IEnumerable<GetPaymentsViewModel> Handle()
        {
            var payments = _paymentRepository.SearchFor(x => x.CompanyId == CompanyId);
            IEnumerable<GetPaymentsViewModel> rtnObj = _mapper.Map<IEnumerable<GetPaymentsViewModel>>(payments);
            
            return rtnObj;
        }
    }
}
