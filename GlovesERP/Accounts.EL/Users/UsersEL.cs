using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
        public class UsersEL : CompanyEL
        {
            public Guid UserId
            {
                get;
                set;
            }
            public Guid IdRole
            {
                get;
                set;
            }
            public string FirstName
            {
                get;
                set;
            }
            public string LastName
            {
                get;
                set;
            }
            public string UserName
            {
                get;
                set;
            }
            public string Password
            {
                get;
                set;
            }
            public string Contact
            {
                get;
                set;
            }
            public string Cnic
            {
                get;
                set;

            }
            public string Address
            {
                get;
                set;
            }

        }
}
