namespace Bytepad_3._0.Models
{
    public interface ILogin
    {
        string Password { get; set; }
        string Username { get; set; }

        bool isValidCredentials(Login data);
     
    }
}