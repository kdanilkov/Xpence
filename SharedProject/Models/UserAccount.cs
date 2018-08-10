namespace XpenceShared.Models
{
    public class UserAccount : BaseModelPersonal
    {
        public UserAccount()
        {
            FirstName = LastName = Phone = Email = string.Empty;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Provider { get; set; }
        public string Device { get; set; }
    }
}