using InvoiceManagement.Core.DataAccess;
using InvoiceManagement.Entities.Concretes;
using InvoiceManagement.Entities.Dtos;
using System.Collections.Generic;

namespace InvoiceManagement.DataAccess.Abstracts
{
    public interface IResidentRepository : IEntityRepository<Resident>
    {
        IEnumerable<ResidentDto> GetAllDetails();
    }

}
