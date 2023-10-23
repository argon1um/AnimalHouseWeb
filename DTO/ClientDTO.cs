namespace AnimalHouseRestAPI.ModelsDTO
{
    public class ClientDTO
    { 
        public string Login { get; set; }
        public string Password { get; set; }

        public ClientDTO(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
