using AutoMapper;
using System.Collections.Generic;
using InvoiceManagement.Business.Services.Abstracts;
using InvoiceManagement.Core.Utilities.Results;
using InvoiceManagement.DataAccess.Abstracts;
using InvoiceManagement.Entities.Concretes;
using InvoiceManagement.Entities.Dtos;

namespace InvoiceManagement.Business.Services.Concretes
{
    public class HouseManager : IHouseService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IMapper _mapper;
        public HouseManager(IHouseRepository houseRepository,IMapper mapper)
        {
            _houseRepository = houseRepository;
            _mapper = mapper;
        }
        public IResult Create(House entity)
        {
            var house = _houseRepository.Get(x =>
                x.ApartmentId == entity.ApartmentId && x.DoorNumber == entity.DoorNumber && x.Floor == entity.Floor );
            if (!(house == null))
                return new Result("Bu ev zaten mevcut!", false);

            var apartment = _houseRepository.GetApartment(entity.ApartmentId);
            if (apartment.TotalFloors < entity.Floor)
                return new Result("Seçtiğiniz apartmanın toplam kat sayısının üstünde kat numarası girdiniz!", false);

            _houseRepository.Add(entity);

            var result = _houseRepository.SaveChanges();
            if (result==0) 
                return new Result("Veri tabanına kaydederken bir hata oluştu!", false);
            return new Result("Kayıt başarılı.", true);
        }

        public IResult Delete(int id)
        {
            var house = _houseRepository.Get(x => x.Id == id);
            if (house is null)
                return new Result("Ev bulunamadı!", false);
            _houseRepository.Delete(house);
            var result = _houseRepository.SaveChanges();
            if (result == 0)
                return new Result("Veri tabanına kaydederken bir hata oluştu!", false);
            return new Result("Veri silindi.", true);
        }

        public IResult Update(int id, House entity)
        {
            var house = _houseRepository.Get(x => x.Id == id);
            if (house is null)
                return new Result("Ev bulunamadı!", false);
            house.ApartmentId = entity.ApartmentId == default ? house.ApartmentId : entity.ApartmentId;
            house.DoorNumber = entity.DoorNumber == default ? house.DoorNumber : entity.DoorNumber;
            house.Floor = entity.Floor == default ? house.Floor : entity.Floor;
            house.FlatTypeId = entity.FlatTypeId == default ? house.FlatTypeId : entity.FlatTypeId;

            var apartment = _houseRepository.GetApartment(entity.ApartmentId);
            if (apartment.TotalFloors < entity.Floor)
                return new Result("Seçtiğiniz apartmanın kat sayısının üstünde kat numarası girdiniz!", false);

            var result = _houseRepository.SaveChanges();
            if (result == 0)
                return new Result("Veri tabanına kaydederken bir hata oluştu!", false);
            return new Result("Veri güncellendi.", true);

        }

        public IDataResult<House> GetById(int id)
        {
            var house = _houseRepository.Get(x => x.Id == id);
            if (house is null)
                return new DataResult<House>(null,"Ev bulunamadı!", false);
            return new DataResult<House>(house, true);
        }

        public IDataResult<IEnumerable<House>> GetAll()
        {
            var houses = _houseRepository.GetList();
            if (houses is null)
                return new DataResult<IEnumerable<House>>(null, "Evler bulunamadı!", false);
            return new DataResult<IEnumerable<House>>(houses, true);
        }

        public IDataResult<IEnumerable<HouseDto>> GetAllHouseDetail()
        {
            var houses = _houseRepository.GetAllHouseDetail();
            if (houses is null)
                return new DataResult<IEnumerable<HouseDto>>(null, "Evler bulunamadı!", false);
            return new DataResult<IEnumerable<HouseDto>>(houses, true);
        }

        public IDataResult<HouseDto> GetHouseDetail(int id)
        {
            var house = _houseRepository.GetHouseDetail(id);
            if (house is null)
                return new DataResult<HouseDto>(null, "Ev bulunamadı!", false);
            return new DataResult<HouseDto>(house, true);
        }
    }
}
