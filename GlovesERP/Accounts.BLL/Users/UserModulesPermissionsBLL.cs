using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Accounts.Common;
using Accounts.EL;
using Accounts.DAL;
using System.Data.SqlClient;

namespace Accounts.BLL
{
    public class UserModulesPermissionsBLL
    {
        UserModulesPermissionsDAL dal;
        public UserModulesPermissionsBLL()
        {
            dal = new UserModulesPermissionsDAL();
        }
        public EntityoperationInfo AssignPermissions(List<UserModulesPermissionsEL> oelUserModulesPermissionCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.AssignPermissions(oelUserModulesPermissionCollection, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                throw ex;
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
        }
        //public EntityoperationInfo CreateUsersModulesPermission(UserModulesPermissionsEL oelUserModulesPermissions)
        //{
        //    SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
        //    try
        //    {
        //        objConn.Open();
        //        return dal.CreateUsersModulesPermission(oelUserModulesPermissions, objConn);
        //    }
        //    catch (Exception ex)
        //    {
        //        objConn.Close();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        objConn.Close();
        //        objConn.Dispose();
        //    }
        //}
        //public EntityoperationInfo UpdateUsersModulesPermission(UserModulesPermissionsEL oelUserModulesPermissions)
        //{
        //    SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
        //    try
        //    {
        //        objConn.Open();
        //        return dal.UpdateUsersModulesPermission(oelUserModulesPermissions, objConn);
        //    }
        //    catch (Exception ex)
        //    {
        //        objConn.Close();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        objConn.Close();
        //        objConn.Dispose();
        //    }
        //}
        public EntityoperationInfo DeleteUserModulesPermissions(Guid? Id)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.DeleteUserModulesPermissions(Id, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                throw ex;
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
        }
        public List<UserModulesPermissionsEL> GetUserModulePermissionsById(Guid? Id)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetUserModulePermissionsById(Id, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                throw ex;
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
        }
        public List<UserModulesPermissionsEL> GetUserModulePermissionsByUserAndModuleId(Guid? IdUser, Guid? IdModule)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetUserModulePermissionsByUserAndModuleId(IdUser, IdModule, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                throw ex;
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
            }
        }
    }
}
