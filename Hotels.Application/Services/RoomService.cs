using Hotels.Application.DTO.Request;
using Hotels.Application.DTO.Response;
using Hotels.Domain.Contracts.Repositories;
using Hotels.Domain.Contracts.Services;
using Hotels.Domain.Contracts;
using Hotels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Application.Services
{
    public class RoomService : IGetListByIdService<DTORoomGet>,
        IGetByIdService<DTORoomGet>,
        ICreateService<DTORoomNew>,
        IUpdateService<DTORoomEdit>,
        IDeleteService
    {
        private readonly IGenericRepository<Room> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly HotelService _hotelService;

        public RoomService(IGenericRepository<Room> repository, IUnitOfWork unitOfWork, HotelService hotelService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _hotelService = hotelService;
        }

        public async Task<ICollection<DTORoomGet>> GetListByIdService(Guid id)
        {
            var allRooms = await _repository.GetAll();
            var dtoRoomsByHotelId = allRooms.Where(h => h.HotelId == id).Select(h => new DTORoomGet
            {
                Id = h.Id,
                Name = h.Name,
                MaxGuests = h.MaxGuests,
                HotelId = h.HotelId,
                Hotel = _hotelService.GetById(h.HotelId).Result
            });

            return dtoRoomsByHotelId.ToList();
        }

        public async Task Insert(DTORoomNew dtoroom)
        {
            if (dtoroom == null)
            {
                throw new ArgumentNullException("Room cannot be null");
            }

            var room = new Room
            {
                Name = dtoroom.Name,
                MaxGuests = dtoroom.MaxGuests,
                HotelId = dtoroom.HotelId 
            };

            await _repository.Insert(room);
            await _unitOfWork.SaveAllChanges();
        }

        public async Task Update(DTORoomEdit dtoRoom)
        {
            if (dtoRoom == null)
            {
                throw new ArgumentNullException("Room cannot be null");
            }

            var room = await _repository.GetById(dtoRoom.Id);

            room.Name = dtoRoom.Name;
            room.MaxGuests = dtoRoom.MaxGuests;
            room.HotelId = dtoRoom.HotelId;

            await _repository.Update(room);
            await _unitOfWork.SaveAllChanges();
        }
        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
            await _unitOfWork.SaveAllChanges();
        }

        public async Task<DTORoomGet> GetById(Guid Id)
        {
            var room = await _repository.GetById(Id);
            var dtoRoom = new DTORoomGet
            {
                Id = room.Id,
                Name = room.Name,
                MaxGuests= room.MaxGuests,
                HotelId = room.HotelId
            };

            return dtoRoom;
        }
    }
}
