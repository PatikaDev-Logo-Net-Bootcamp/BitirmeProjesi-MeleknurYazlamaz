using AutoMapper;
using InvoiceManagement.CreditCardService.Models.Company;
using InvoiceManagement.CreditCardService.Applications.Company;
using InvoiceManagement.CreditCardService.MongoDbDataAccess.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagement.CreditCardService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreateCompanyViewModel model)
        {
            CreateCompany company = new CreateCompany(_companyRepository, _mapper);
            company.Model = model;
            company.Handle();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            GetCompanies companies = new GetCompanies(_companyRepository, _mapper);
            
            var result = companies.Handle();
            return Ok(result);
        }
    }
}
