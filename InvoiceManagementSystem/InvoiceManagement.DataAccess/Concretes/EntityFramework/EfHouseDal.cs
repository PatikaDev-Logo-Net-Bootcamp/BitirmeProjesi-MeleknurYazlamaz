using InvoiceManagement.DataAccess.Abstracts;
using InvoiceManagement.Entities.Concretes;
using InvoiceManagement.Entities.Dtos;
using InvoiceManagement.Core.DataAccess.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceManagement.DataAccess.Concretes.EntityFramework
{
    public class EfHouseDal : EfEntityRepositoryBase<House, InvoiceManagementDbContext>, IHouseRepository
    {
        public EfHouseDal(InvoiceManagementDbContext context) : base(context)
        {
        }

        public IEnumerable<HouseDto> GetAllHouseDetail()
        {
            var result = from h in Context.Houses
                join a in Context.Apartments on h.ApartmentId equals a.Id
                join ft in Context.FlatTypes on h.FlatTypeId equals ft.Id
                select new HouseDto
                {
                    Id = h.Id,
                    ApartmentName = a.Name,
                    DoorNumber = h.DoorNumber,
                    Floor = h.Floor,
                    FlatType =  $"{ft.RoomCount} + {ft.LivingRoomCount}"
                };
            return result;
        }
        public HouseDto GetHouseDetail(int id)
        {
            var result = from h in Context.Houses
                join a in Context.Apartments on h.ApartmentId equals a.Id
                join ft in Context.FlatTypes on h.FlatTypeId equals ft.Id
                where ft.Id == id
                select new HouseDto
                {
                    Id = h.Id,
                    ApartmentName = a.Name,
                    DoorNumber = h.DoorNumber,
                    Floor = h.Floor,
                    FlatType = $"{ft.RoomCount} + {ft.LivingRoomCount}"
                };
            return result.SingleOrDefault();
        }

        public Apartment GetApartment(int apartmentId)
        {
            var result = from a in Context.Apartments
                where a.Id == apartmentId
                select new Apartment
                {
                    Id = a.Id,
                    Name = a.Name,
                    TotalFloors = a.TotalFloors
                };
            return result.SingleOrDefault();
        }
    }
}
