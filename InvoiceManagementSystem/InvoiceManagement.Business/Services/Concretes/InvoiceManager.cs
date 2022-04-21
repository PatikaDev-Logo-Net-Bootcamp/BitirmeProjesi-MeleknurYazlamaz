using System.Collections.Generic;
using AutoMapper;
using InvoiceManagement.Business.Services.Abstracts;
using InvoiceManagement.Core.Utilities.Results;
using InvoiceManagement.DataAccess.Abstracts;
using InvoiceManagement.Entities.Concretes;
using InvoiceManagement.Entities.Dtos;

namespace InvoiceManagement.Business.Services.Concretes
{
    public class InvoiceManager : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceManager(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public IResult Create(Invoice entity)
        {
            _invoiceRepository.Add(entity);
            var result = _invoiceRepository.SaveChanges();
            if (result == 0)
                return new Result("Veri tabanına kaydederken bir hata oluştu!", false);
            return new Result("Kayıt başarılı.",true);
        }

        public IResult Delete(int id)
        {
            var invoice = _invoiceRepository.Get(x => x.Id == id);
            if (invoice is null)
                return new Result("Fatura bulunamadı!", false);
            _invoiceRepository.Delete(invoice);
            var result = _invoiceRepository.SaveChanges();
            if (result == 0)
                return new Result("Veri tabanına kaydederken bir hata oluştu!", false);
            return new Result("Fatura silindi.", true);
        }

        public IResult Update(int id, Invoice entity)
        {
            var invoice = _invoiceRepository.Get(x => x.Id == id);
            if (invoice is null)
                return new Result("Fatura bulunamadı!", false);

            invoice.HouseId = entity.HouseId == default ? invoice.HouseId : entity.HouseId;
            invoice.InvoiceTypeId = entity.InvoiceTypeId == default ? invoice.InvoiceTypeId : entity.InvoiceTypeId;
            invoice.Amount = entity.Amount == default ? invoice.Amount : entity.Amount;
            invoice.InvoiceDate = entity.InvoiceDate == default ? invoice.InvoiceDate : entity.InvoiceDate;
            invoice.Status = entity.Status == default ? invoice.Status : entity.Status;

            var result = _invoiceRepository.SaveChanges();
            if (result == 0)
                return new Result("Veri tabanına kaydederken bir hata oluştu!", false);
            return new Result("Fatura güncellendi.", true);
        }

        public IDataResult<Invoice> GetById(int id)
        {
            var invoice = _invoiceRepository.Get(x => x.Id == id);
            if (invoice is null)
                return new DataResult<Invoice>(null,"Fatura bulunamadı!", false);
            return new DataResult<Invoice>(invoice, true);
        }

        public IDataResult<IEnumerable<Invoice>> GetAll()
        {
            var invoices = _invoiceRepository.GetList();
            return new DataResult<IEnumerable<Invoice>>(invoices, true);
        }

        public IDataResult<IEnumerable<InvoiceDto>> GetAllDetails()
        {
            var invoices = _invoiceRepository.GetAllInvoiceDetail();
            return new DataResult<IEnumerable<InvoiceDto>>(invoices, true);
        }

        public IDataResult<IEnumerable<InvoiceDto>> GetAllUserInvoiceDetail(int userId)
        {
            var invoices = _invoiceRepository.GetAllUserInvoiceDetail(userId);
            return new DataResult<IEnumerable<InvoiceDto>>(invoices, true);
        }

        public IDataResult<InvoiceDto> GetByIdDetail(int id)
        {
            var invoice = _invoiceRepository.GetInvoiceDetail(id);
            if (invoice is null)
                return new DataResult<InvoiceDto>(null, "Fatura bulunamadı!", false);
            return new DataResult<InvoiceDto>(invoice, true);
        }

        public IResult PaySuccess(int id)
        {
            var invoice = _invoiceRepository.Get(x => x.Id == id);
            if (invoice is null)
                return new Result("Fatura bulunamadı!", false);

            invoice.Status = false;

            var result = _invoiceRepository.SaveChanges();
            if (result == 0)
                return new Result("Veri tabanına kaydederken bir hata oluştu", false);
            return new Result("Fatura ödendi.", true);
        }
    }
}
