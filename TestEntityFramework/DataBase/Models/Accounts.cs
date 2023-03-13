namespace TestEntityFramework.DataBase.Models
{
    public class Accounts
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Accounts()
        {
            
        }

        public Accounts(string name)
        {
            this.Name = name;
        }
    }
}