using HotelHub.Data.Models.Booking;
using Microsoft.AspNetCore.Identity;

namespace HotelHub.Data.Models.Auth {
    public class ApplicationUser : IdentityUser<Guid> {
        public Person? Person { get; set; }
    }
}
