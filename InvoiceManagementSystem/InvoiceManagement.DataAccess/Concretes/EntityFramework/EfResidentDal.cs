using InvoiceManagement.Core.DataAccess.EntityFramework;
using InvoiceManagement.DataAccess.Abstracts;
using InvoiceManagement.Entities.Concretes;
using InvoiceManagement.Entities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceManagement.DataAccess.Concretes.EntityFramework
{
    public class EfResidentDal : EfEntityRepositoryBase<Resident, InvoiceManagementDbContext>, IResidentRepository
    {
        public EfResidentDal(InvoiceManagementDbContext context) : base(context)
        {
        }

        public IEnumerable<ResidentDto> GetAllDetails()
        {
            var result = from r in Context.Residents
                join p in Context.Users on r.UserId equals p.Id
                join h in Context.Houses on r.HouseId equals h.Id
                join a in Context.Apartments on h.ApartmentId equals a.Id
                select new ResidentDto()
                {
                    UserId = r.UserId,
                    UserName = p.FullName,
                    House = $"{a.Name} no:{h.DoorNumber}",
                    CarPlate = r.CarPlate,
                    IsHirer = r.IsHirer,
                    IsOwner = r.IsOwner
                };

            return result;
        }
    }
}
