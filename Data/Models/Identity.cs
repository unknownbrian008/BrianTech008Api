namespace BrianTech008Api.Data.Models
{
    public class Identity : BaseEntity
    {
        public string UserName { get; set; }
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
        public string  Gender { get; set; }
        public string  UserTypeId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
