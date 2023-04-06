namespace RoomBookingApp.Domain.DomainModels
{
    public abstract class RoomBookingBase
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public DateTime Date { get; set; }
    }
}