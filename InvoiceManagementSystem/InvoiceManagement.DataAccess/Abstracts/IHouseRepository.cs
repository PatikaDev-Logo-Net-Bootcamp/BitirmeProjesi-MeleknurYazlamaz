using InvoiceManagement.Core.DataAccess;
using InvoiceManagement.Entities.Concretes;
using InvoiceManagement.Entities.Dtos;
using System.Collections.Generic;

namespace InvoiceManagement.DataAccess.Abstracts
{
    public interface IHouseRepository : IEntityRepository<House>
    {
        IEnumerable<HouseDto> GetAllHouseDetail();
        HouseDto GetHouseDetail(int id);
        Apartment GetApartment(int apartmentId);
    }
}
