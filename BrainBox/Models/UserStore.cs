namespace BrainBox.Models
{
    public static class UserStore
    {
        public static List<User> Admins { get; } = new List<User>
    {
        new User { Username = "admin1", Password = "admin123", Role = "Admin" },
        new User { Username = "sarah", Password = "12345", Role = "Admin" }
    };

        public static List<User> Clients { get; } = new List<User>
    {
        new User { Username = "abdelrhman", Password = "123", Role = "Client" },
        new User { Username = "client2", Password = "client456", Role = "Client" }
    };
    }

}
