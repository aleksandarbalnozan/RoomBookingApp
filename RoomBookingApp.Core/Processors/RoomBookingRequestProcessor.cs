using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Core.Domain;
using RoomBookingApp.Core.Models;

namespace RoomBookingApp.Core.Processors
{
    public class RoomBookingRequestProcessor
    {
        private readonly IRoomBookingSerivce _roomBookingSerivce;

        public RoomBookingRequestProcessor(IRoomBookingSerivce roomBookingSerivce)
        {
            _roomBookingSerivce = roomBookingSerivce;
        }

        public RoomBookingResult BookRoom(RoomBookingRequest bookingRequest)
        {
            if (bookingRequest is null)
            {
                throw new ArgumentNullException(nameof(bookingRequest));
            }

            _roomBookingSerivce.Save(CreateRoomBookingObject<RoomBooking>(bookingRequest));

            return CreateRoomBookingObject<RoomBookingResult>(bookingRequest);
        }

        private TRoomBooking CreateRoomBookingObject<TRoomBooking>(RoomBookingRequest bookingRequest) where TRoomBooking
            : RoomBookingBase, new()
        {
            return new TRoomBooking
            {
                FullName = bookingRequest.FullName,
                Email = bookingRequest.Email,
                Date = bookingRequest.Date
            };
        }
    }
}