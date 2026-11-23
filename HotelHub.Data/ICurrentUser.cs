namespace HotelHub.Data {
    public interface ICurrentUser {
        // NULL = няма login (напр. seed, фонова задача)
        Guid? UserId { get; }
    }
}
