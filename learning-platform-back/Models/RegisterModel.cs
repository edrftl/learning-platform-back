namespace learning_platform_back.Models
{
    public class RegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public string? PhoneNumber { get; set; }
        public int groupId { get; set; }
        public int courseId { get; set; }
    }
}
