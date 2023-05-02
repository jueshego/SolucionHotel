using Hotels.Application.DTO.Request;
using Hotels.Application.DTO.Response;
using Hotels.Domain.Contracts;
using Hotels.Domain.Contracts.Repositories;
using Hotels.Domain.Contracts.Services;
using Hotels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Services
{
    public class HotelService : IGetService<DTOHotelGet>,
        IGetByIdService<DTOHotelGet>,
        ICreateService<DTOHotelNew>,
        IUpdateService<DTOHotelEdit>,
        IDeleteService
    {
        private readonly IGenericRepository<Hotel> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public HotelService(IGenericRepository<Hotel> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<DTOHotelGet>> GetAll()
        {
            var allHotels = await _repository.GetAll();
            var dtoHotels = allHotels.Select(h => new DTOHotelGet 
            { 
                Id = h.Id, 
                Name = h.Name, 
                Address = h.Address, 
                PhoneNumber = h.PhoneNumber, 
                Stars = h.Stars 
            });

            return dtoHotels.ToList();
        }

        public async Task Insert(DTOHotelNew dtoHotel)
        {
            if (dtoHotel == null)
            {
                throw new ArgumentNullException("Hotel cannot be null");
            }

            var hotel = new Hotel
            {
                Name = dtoHotel.Name,
                Address = dtoHotel.Address,
                PhoneNumber = dtoHotel.PhoneNumber,
                Stars = dtoHotel.Stars
            };

            await _repository.Insert(hotel);
            await _unitOfWork.SaveAllChanges();
        }

        public async Task Update(DTOHotelEdit dtoHotel)
        {
            if (dtoHotel == null)
            {
                throw new ArgumentNullException("Hotel cannot be null");
            }

            var hotel = await _repository.GetById(dtoHotel.Id);

            hotel.Name = dtoHotel.Name;
            hotel.Address = dtoHotel.Address;
            hotel.PhoneNumber = dtoHotel.PhoneNumber;
            hotel.Stars = dtoHotel.Stars;

            await _repository.Update(hotel);
            await _unitOfWork.SaveAllChanges();
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
            await _unitOfWork.SaveAllChanges();
        }

        public async Task<DTOHotelGet> GetById(Guid Id)
        {
            var hotel = await _repository.GetById(Id);
            var dtoHotel = new DTOHotelGet
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Address = hotel.Address,
                PhoneNumber = hotel.PhoneNumber,
                Stars = hotel.Stars
            };

            return dtoHotel;
        }
    }
}
