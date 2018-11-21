using Bytepad_3._0.Models;

namespace Bytepad_3._0.Services
{
    public interface ICheckCredentials
    {
        bool validateUser(Login user);
    }
}