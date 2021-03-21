using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTest.LoginInfo
{
    public class LoginInfo
    {
        /* Creating public attributes for use in the method below */
        public string name;
        public string password;
       

        /* Method created to store the login information in the parameters */
        public LoginInfo(string name, string password)
        {
            this.name = name;
            this.password = password;
           
        }
    }
}
