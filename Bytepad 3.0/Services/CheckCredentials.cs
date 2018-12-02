using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bytepad_3._0.Models;

namespace Bytepad_3._0.Services
{
    public class CheckCredentials : ICheckCredentials
    {
        private ILogin _login = null;
        public CheckCredentials(ILogin login)
        {
            _login = login;
        }

        public bool validateUser(Login user)
        {
            return _login.isValidCredentials(user);
        }
    }
}