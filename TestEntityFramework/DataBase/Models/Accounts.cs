namespace TestEntityFramework
{
    public class Accounts
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Accounts()
        {
            
        }

        public Accounts(string login, string email, string password)
        {
            this.Login = login;
            this.Email = email;
            this.Password = password;
        }
    }
}