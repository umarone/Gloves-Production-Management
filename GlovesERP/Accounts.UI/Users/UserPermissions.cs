using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Accounts.EL;
using Accounts.Common;
using Accounts.BLL;

namespace Accounts.UI
{
    class UserPermissions
    {
        public static Guid IdModule { get; set; }
       public static List<UserModulesPermissionsEL> GetUserModulePermissionsByUserAndModuleId(Guid? IdUser)
       {
           List<UserModulesPermissionsEL> PermissionsList = new List<UserModulesPermissionsEL>();
           if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.CheifExecutive) || Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
           {
               if (IdModule != Guid.Empty)
               {
                   UserModulesPermissionsBLL Manager = new UserModulesPermissionsBLL();
                   PermissionsList = Manager.GetUserModulePermissionsByUserAndModuleId(IdUser, IdModule);
               }
           }
           return PermissionsList;
       }
    }
}
