namespace CodeLineHealthCareCenter.Models
{
    internal class bookingService
    {
        // Updates the status of a specific booking
        internal static void UpdateBookingStatus(int bookingId, string newStatus)
        {
            var booking = Booking.Bookings.FirstOrDefault(b => b.BookingId == bookingId);
            if (booking == null)
            {
                Console.WriteLine("❌ Booking not found.");
                return;
            }

            booking.AppointmentType = newStatus;
            Console.WriteLine($"Booking status updated to {newStatus}.");
        }
    }
}
