using System.Collections.Generic;
using AutoMapper;
using InvoiceManagement.Business.Services.Abstracts;
using InvoiceManagement.Core.Utilities.Results;
using InvoiceManagement.DataAccess.Abstracts;
using InvoiceManagement.Entities.Concretes;
using InvoiceManagement.Entities.Dtos;

namespace InvoiceManagement.Business.Services.Concretes
{
    public class ResidentManager : IResidentService
    {
        private readonly IResidentRepository _residentRepository;
        private readonly IMapper _mapper;

        public ResidentManager(IResidentRepository residentRepository, IMapper mapper)
        {
            _residentRepository = residentRepository;
            _mapper = mapper;
        }
        public IResult Create(Resident entity)
        {
            entity.CarPlate.ToUpper();
            _residentRepository.Add(entity);
            var result = _residentRepository.SaveChanges();
            if (result == 0)
                return new Result("Veri tabanına kaydederken bir hata oluştu", false);
            return new Result("Kayıt Başarılı!", true);
        }

        public IResult Delete(int id)
        {
            var resident = _residentRepository.Get(x => x.UserId == id);
            if (resident is null)
                return new Result("Kullanıcı bulunamadı!", false);
            _residentRepository.Delete(resident);
            var result = _residentRepository.SaveChanges();
            if (result == 0)
                return new Result("Veri tabanına kaydederken bir hata oluştu", false);
            return new Result("Silindi!", true);
        }

        public IResult Update(int id, Resident entity)
        {
            var resident = _residentRepository.Get(x => x.UserId == id);
            if (resident is null)
                return new Result("Kullanıcı bulunamadı!", false);

            resident.HouseId = entity.HouseId == default ? resident.HouseId : entity.HouseId;
            resident.CarPlate = entity.CarPlate == default ? resident.CarPlate : entity.CarPlate.ToUpper();
            resident.IsHirer = entity.IsHirer == default ? resident.IsHirer : entity.IsHirer;
            resident.IsOwner = entity.IsOwner == default ? resident.IsOwner : entity.IsOwner;
            var result = _residentRepository.SaveChanges();
            if (result == 0)
                return new Result("Veri tabanına kaydederken bir hata oluştu", false);
            return new Result("Güncellendi!", true);
        }

        public IDataResult<Resident> GetById(int id)
        {
            var resident = _residentRepository.Get(x => x.UserId == id);
            if (resident is null)
                return new DataResult<Resident>(null,"Kullanıcı bulunamadı!", false);
            return new DataResult<Resident>(resident, true);
        }

        public IDataResult<IEnumerable<Resident>> GetAll()
        {
            var residents = _residentRepository.GetList();
            return new DataResult<IEnumerable<Resident>>(residents, true);
        }

        public IDataResult<IEnumerable<ResidentDto>> GetAllDetails()
        {
            var residents = _residentRepository.GetAllDetails();
            return new DataResult<IEnumerable<ResidentDto>>(residents, true);
        }
    }
}
