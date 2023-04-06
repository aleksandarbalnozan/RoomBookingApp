using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Domain;

namespace RoomBookingApp.Persistance.Repositories
{
    public class RoomBookingService : IRoomBookingSerivce
    {
        private readonly RoomBookingAppDbContext _context;

        public RoomBookingService(RoomBookingAppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Room> GetAvailableRooms(DateTime date)
        {
            return _context.Rooms.Where(q => !q.RoomBookings.Any(x => x.Date == date)).ToList();
        }

        public void Save(RoomBooking roomBooking)
        {
            _context.RoomBookings.Add(roomBooking);
            _context.SaveChanges();
        }
    }
}
