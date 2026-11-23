using System.Security.Claims;
using HotelHub.Data;

namespace HotelHub.Web.Infrastructure {
    public class HttpCurrentUser(IHttpContextAccessor accessor) : ICurrentUser {
        public Guid? UserId =>
            Guid.TryParse(accessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier), out var id)
                ? id : null;
    }
}
