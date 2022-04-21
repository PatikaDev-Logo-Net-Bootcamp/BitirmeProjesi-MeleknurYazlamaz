using System.Collections.Generic;
using AutoMapper;
using InvoiceManagement.CreditCardService.Models.Company;
using InvoiceManagement.CreditCardService.MongoDbDataAccess.Abstracts;

namespace InvoiceManagement.CreditCardService.Applications.Company
{
    public class GetCompanies
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetCompanies(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public IEnumerable<GetCompaniesViewModel> Handle()
        {
            var companies = _companyRepository.GetAll();
            var vmModel = _mapper.Map<IEnumerable<GetCompaniesViewModel>>(companies);
            return vmModel;
        }
    }
}
