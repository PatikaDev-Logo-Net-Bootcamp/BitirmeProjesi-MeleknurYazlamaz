using InvoiceManagement.DataAccess.Abstracts;
using InvoiceManagement.Entities.Concretes;
using InvoiceManagement.Entities.Dtos;
using InvoiceManagement.Core.DataAccess.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceManagement.DataAccess.Concretes.EntityFramework
{
    public class EfInvoiceDal : EfEntityRepositoryBase<Invoice, InvoiceManagementDbContext>, IInvoiceRepository
    {
        public EfInvoiceDal(InvoiceManagementDbContext context) : base(context)
        {
        }

        public IEnumerable<InvoiceDto> GetAllUserInvoiceDetail(int UserId)
        {
            var result = from i in Context.Invoices
                join it in Context.InvoiceTypes on i.InvoiceTypeId equals it.Id
                join h in Context.Houses on i.HouseId equals h.Id
                join a in Context.Apartments on h.ApartmentId equals a.Id
                join res in Context.Residents on h.Id equals res.HouseId
                where res.UserId == UserId
                select new InvoiceDto()
                {
                    Id = i.Id,
                    House = $"{a.Name} no: {h.DoorNumber}",
                    InvoiceType = it.Name,
                    Amount = i.Amount,
                    InvoiceDate = i.InvoiceDate,
                    Status = i.Status
                };
            return result;
        }

        public IEnumerable<InvoiceDto> GetAllInvoiceDetail()
        {
            var result = from i in Context.Invoices
                join it in Context.InvoiceTypes on i.InvoiceTypeId equals it.Id
                join h in Context.Houses on i.HouseId equals h.Id
                join a in Context.Apartments on h.ApartmentId equals a.Id
                select new InvoiceDto()
                {
                    Id = i.Id,
                    House = $"{a.Name} no: {h.DoorNumber}",
                    InvoiceType = it.Name,
                    Amount = i.Amount,
                    InvoiceDate = i.InvoiceDate,
                    Status = i.Status
                };
            return result;
        }

        public InvoiceDto GetInvoiceDetail(int id)
        {
            var result = from i in Context.Invoices
                join it in Context.InvoiceTypes on i.InvoiceTypeId equals it.Id
                join h in Context.Houses on i.HouseId equals h.Id
                join a in Context.Apartments on h.ApartmentId equals a.Id
                where i.Id == id
                select new InvoiceDto()
                {
                    Id = i.Id,
                    House = $"{a.Name} no: {h.DoorNumber}",
                    InvoiceType = it.Name,
                    Amount = i.Amount,
                    InvoiceDate = i.InvoiceDate,
                    Status = i.Status
                };
            return result.SingleOrDefault();
        }
    }
}
