using AutoMapper;
using InvoiceManagement.Business.Services.Abstracts;
using InvoiceManagement.Core.Utilities.Results;
using InvoiceManagement.DataAccess.Abstracts;
using InvoiceManagement.Entities.Concretes;
using System.Collections.Generic;

namespace InvoiceManagement.Business.Services.Concretes
{
    public class InvoiceTypeManager : IInvoiceTypeService
    {
        private readonly IInvoiceTypeRespository _invoiceTypeRespository;
        private readonly IMapper _mapper;
        public InvoiceTypeManager(IInvoiceTypeRespository invoiceTypeRespository,IMapper mapper)
        {
            _invoiceTypeRespository = invoiceTypeRespository;
            _mapper = mapper;
        }
        public IResult Create(InvoiceType entity)
        {
            _invoiceTypeRespository.Add(entity);
            var result = _invoiceTypeRespository.SaveChanges();
            if (result == 0)
                return new Result("Veri tabanına kaydederken bir hata oluştu!", false);
            return new Result("Kayıt Başarılı!", true);
        }

        public IResult Delete(int id)
        {
            var invoiceType = _invoiceTypeRespository.Get(x => x.Id == id);
            if (invoiceType is null)
                return new Result("Veri bulunamadı!", false);
            _invoiceTypeRespository.Delete(invoiceType);
            var result = _invoiceTypeRespository.SaveChanges();
            if (result == 0)
                return new Result("Veri tabanına kaydederken bir hata oluştu!", false);
            return new Result("Başarıyla Silindi!", true);
        }

        public IResult Update(int id, InvoiceType entity)
        {
            var invoiceType = _invoiceTypeRespository.Get(x => x.Id == id);
            if (invoiceType is null)
                return new Result("Veri bulunamadı!", false);
            invoiceType.Name = entity.Name == default ? invoiceType.Name : entity.Name;
            var result = _invoiceTypeRespository.SaveChanges();
            if (result == 0)
                return new Result("Veri tabanına kaydederken bir hata oluştu!", false);
            return new Result("Başarıyla Güncellendi!", true);
        }

        public IDataResult<InvoiceType> GetById(int id)
        {
            var invoiceType = _invoiceTypeRespository.Get(x => x.Id == id);
            if (invoiceType is null)
                return new DataResult<InvoiceType>(null,"Veri bulunamadı!", false);
            return new DataResult<InvoiceType>(invoiceType, true);
        }

        public IDataResult<IEnumerable<InvoiceType>> GetAll()
        {
            var invoiceTypes = _invoiceTypeRespository.GetList();
            return new DataResult<IEnumerable<InvoiceType>>(invoiceTypes, true);
        }
    }
}
