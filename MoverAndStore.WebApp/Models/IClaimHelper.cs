namespace MoverAndStore.WebApp.Models
{
    public interface IClaimHelper
    {
        int UserId { get; }
        string Name { get; }
        string Role { get; }
        int UserType { get; }
        string Gender { get; }
    }
}
