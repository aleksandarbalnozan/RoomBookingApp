using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;
using Xunit;

namespace RoomBookingApp.Core.Tests
{
    public class RoomBookingRequestProcessorTest
    {
        private RoomBookingRequestProcessor _processor;

        public RoomBookingRequestProcessorTest()
        {
            _processor = new RoomBookingRequestProcessor();
        }

        [Fact]
        public void Should_Return_Room_Booking_Response_With_Request_Values()
        {
            // Arrange
            var request = new RoomBookingRequest
            {
                FullName = "Test Name",
                Email = "test@test.com",
                Date = new DateTime(2021, 10, 20)
            };

            // Act
            RoomBookingResult result = _processor.BookRoom(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(request.FullName, result.FullName);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.Date, result.Date);
        }

        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.BookRoom(null));

            Assert.Equal("bookingRequest", exception.ParamName);
        }
    }
}
