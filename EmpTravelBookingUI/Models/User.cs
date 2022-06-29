namespace EmpTravelBookingUI.Models
{
    public class User
    {
        public string UserId { get; set; } = null!;
        public string LoginId { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string ManagerUserId { get; set; } = null!;
        public string UserTypeId { get; set; } = null!;
    }
}
