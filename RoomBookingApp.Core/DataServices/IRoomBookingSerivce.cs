using RoomBookingApp.Domain;

namespace RoomBookingApp.Core.DataServices
{
    public interface IRoomBookingSerivce
    {
        void Save(RoomBooking roomBooking);
        IEnumerable<Room> GetAvailableRooms(DateTime date);
    }
}
