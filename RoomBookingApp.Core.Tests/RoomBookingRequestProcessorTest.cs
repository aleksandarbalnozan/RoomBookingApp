﻿using Moq;
using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Core.Domain;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;
using Xunit;

namespace RoomBookingApp.Core.Tests
{
    public class RoomBookingRequestProcessorTest
    {
        private RoomBookingRequestProcessor _processor;
        private RoomBookingRequest _request;
        private Mock<IRoomBookingSerivce> _roomBookingServiceMock;

        public RoomBookingRequestProcessorTest()
        {
            // Arrange
            _request = new RoomBookingRequest
            {
                FullName = "Test Name",
                Email = "test@test.com",
                Date = new DateTime(2021, 10, 20)
            };

            _roomBookingServiceMock = new Mock<IRoomBookingSerivce>();
            _processor = new RoomBookingRequestProcessor(_roomBookingServiceMock.Object);
        }

        [Fact]
        public void Should_Return_Room_Booking_Response_With_Request_Values()
        {
            // Act
            RoomBookingResult result = _processor.BookRoom(_request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(_request.FullName, result.FullName);
            Assert.Equal(_request.Email, result.Email);
            Assert.Equal(_request.Date, result.Date);
        }

        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.BookRoom(null));

            Assert.Equal("bookingRequest", exception.ParamName);
        }

        [Fact]
        public void Should_Save_Room_Booking_Request()
        {
            RoomBooking savedBooking = null;
            _roomBookingServiceMock.Setup(q => q.Save(It.IsAny<RoomBooking>()))
                .Callback<RoomBooking>(booking =>
            {
                savedBooking = booking;
            });

            _processor.BookRoom(_request);

            _roomBookingServiceMock.Verify(q => q.Save(It.IsAny<RoomBooking>()), Times.Once());

            Assert.NotNull(savedBooking);
            Assert.Equal(_request.FullName, savedBooking.FullName);
            Assert.Equal(_request.Email, savedBooking.Email);
            Assert.Equal(_request.Date, savedBooking.Date);
        }
    }
}
