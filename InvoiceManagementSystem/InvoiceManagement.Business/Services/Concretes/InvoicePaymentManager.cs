using System;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Services.OutsideService.PaymentService;
using InvoiceManagement.Core.Utilities.Results;
using InvoiceManagement.Business.Services.OtherServices.PaymentService;
using InvoiceManagement.Business.Services.Abstracts;
using InvoiceManagement.DataAccess.Abstracts;
using InvoiceManagement.Entities.Dtos;
using InvoiceManagement.Entities.Concretes;

namespace InvoiceManagement.Business.Services.Concretes
{
    public class InvoicePaymentManager : IInvoicePaymentService
    {
        private readonly IInvoicePaymentRepository _paymentRepository;
        private readonly IPaymentService _paymentService;
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public InvoicePaymentManager(IInvoicePaymentRepository paymentRepository, IPaymentService paymentService, IInvoiceService invoiceService, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _paymentService = paymentService;
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        public async Task<IResult> PayInvoice(int userId, PayOrderDto payOrder)
        {
            PaymentOrder paymentOrder = _mapper.Map<PaymentOrder>(payOrder);
            var psResult = await _paymentService.PayOrder(paymentOrder);
            if (!psResult.Status)
            {
                return new Result($"{psResult.StatusCode} - {psResult.Message}", psResult.Status);
            }
            InvoicePayment pip = new InvoicePayment
            {
                UserId = userId,
                InvoiceId = payOrder.InvoiceId,
                PayingAmount = payOrder.Amount
            };
            _paymentRepository.Add(pip);
            var result = _paymentRepository.SaveChanges();
            if (result == 0)
                return new Result("Ödeme, veri tabanına kaydedilirken bir hata oluştu!", false);
            var inResult = _invoiceService.PaySuccess(payOrder.InvoiceId);
            if (!inResult.Success)
                return new Result("Fatura bilgisi güncellenirken bir hata oluştu!", false);
            return new Result(psResult.Message, psResult.Status);

        }

        public IDataResult<InvoicePayment> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<InvoicePayment>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
