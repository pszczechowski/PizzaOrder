namespace PizzaPortal.Infrastructure
{
    public class User : Person

    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; }
    }
}