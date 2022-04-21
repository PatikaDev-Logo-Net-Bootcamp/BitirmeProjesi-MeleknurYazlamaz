using System;
using System.Linq;
using AutoMapper;
using InvoiceManagement.CreditCardService.Models.Company;
using InvoiceManagement.CreditCardService.MongoDbDataAccess.Abstracts;

namespace InvoiceManagement.CreditCardService.Applications.Company { 
    public class CreateCompany
    {
        public CreateCompanyViewModel Model { get; set; }
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CreateCompany(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public void Handle()
        {
            var company = _companyRepository.SearchFor(x => x.TaxNumber == Model.TaxNumber).SingleOrDefault();
            if (!(company == null))
                throw new InvalidOperationException($"{Model.TaxNumber} vergi numaralı kayıt bulunmaktadır.");
            company = _mapper.Map<Entities.Company>(Model);
            _companyRepository.Insert(company);
        }

    }
}
