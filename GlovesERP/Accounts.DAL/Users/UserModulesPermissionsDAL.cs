using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounts.EL;
using System.Data.SqlClient;
using System.Data;
using Accounts.Common;

namespace Accounts.DAL
{
    public class UserModulesPermissionsDAL
    {
        IDataReader objReader;
        public EntityoperationInfo AssignPermissions(List<UserModulesPermissionsEL> oelUserModulesPermissionCollection, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlTransaction objTran = objConn.BeginTransaction();
            try
            {
                for (int i = 0; i < oelUserModulesPermissionCollection.Count; i++)
                {
                    if (oelUserModulesPermissionCollection[i].ModuleAction == "Assign")
                    {                        
                        infoResult.IsSuccess = CreateUsersModulesPermission(oelUserModulesPermissionCollection[i], objConn, objTran);
                    }
                    else if (oelUserModulesPermissionCollection[i].ModuleAction == "Update")
                    {
                        infoResult.IsSuccess = UpdateUsersModulesPermission(oelUserModulesPermissionCollection[i], objConn, objTran);
                    }
                }
                objTran.Commit();
                return infoResult;
            }
            catch (Exception ex)
            {
                objTran.Rollback();
                throw ex;
            }
        }
        public bool CreateUsersModulesPermission(UserModulesPermissionsEL oelUserModulesPermissions, SqlConnection objConn, SqlTransaction objTran)
        {
            if (!(GetUserModulePermissionById(oelUserModulesPermissions.IdMoudlePermission, objConn, objTran)))
            {
                SqlCommand cmdUserModulesPermissions = new SqlCommand("[Users].[Proc_CreateModulesPermission]", objConn, objTran);

                cmdUserModulesPermissions.CommandType = CommandType.StoredProcedure;

                cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@IdModulePermission", DbType.Guid)).Value = oelUserModulesPermissions.IdMoudlePermission;
                cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@IdModule", DbType.Guid)).Value = oelUserModulesPermissions.IdModule;
                cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelUserModulesPermissions.UserId;
                cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@Adding", DbType.Boolean)).Value = oelUserModulesPermissions.Saving;
                cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@Updating", DbType.Boolean)).Value = oelUserModulesPermissions.Updating;
                cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@Deleting", DbType.Boolean)).Value = oelUserModulesPermissions.Deleting;
                cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@Viewing", DbType.Boolean)).Value = oelUserModulesPermissions.Viewing;
                cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@Posting", DbType.Boolean)).Value = oelUserModulesPermissions.Posting;
                cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@Printing", DbType.Boolean)).Value = oelUserModulesPermissions.Printing;
                cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelUserModulesPermissions.CreatedDateTime;

                cmdUserModulesPermissions.ExecuteNonQuery();
            }
            return true;
        }
        public bool UpdateUsersModulesPermission(UserModulesPermissionsEL oelUserModulesPermissions, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdUserModulesPermissions = new SqlCommand("[Users].[Proc_UpdateModulesPermission]", objConn, objTran);

            cmdUserModulesPermissions.CommandType = CommandType.StoredProcedure;

            cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@IdModulePermission", DbType.Guid)).Value = oelUserModulesPermissions.IdMoudlePermission;
            cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@IdModule", DbType.Guid)).Value = oelUserModulesPermissions.IdModule;
            cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelUserModulesPermissions.UserId;
            cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@Adding", DbType.Boolean)).Value = oelUserModulesPermissions.Saving;
            cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@Updating", DbType.Boolean)).Value = oelUserModulesPermissions.Updating;
            cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@Deleting", DbType.Boolean)).Value = oelUserModulesPermissions.Deleting;
            cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@Viewing", DbType.Boolean)).Value = oelUserModulesPermissions.Viewing;
            cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@Posting", DbType.Boolean)).Value = oelUserModulesPermissions.Posting;
            cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@Printing", DbType.Boolean)).Value = oelUserModulesPermissions.Printing;
            cmdUserModulesPermissions.Parameters.Add(new SqlParameter("CreatedDateTime", DbType.DateTime)).Value = oelUserModulesPermissions.CreatedDateTime;

            cmdUserModulesPermissions.ExecuteNonQuery();

            return true;
        }
        public EntityoperationInfo DeleteUserModulesPermissions(Guid? IdPermission, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdUserModulesPermissions = new SqlCommand("[Users].[Proc_DeleteModulesPermission]", objConn))
            {
                cmdUserModulesPermissions.CommandType = CommandType.StoredProcedure;

                cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@IdModulePermission", DbType.Guid)).Value = IdPermission.Value;

                if (cmdUserModulesPermissions.ExecuteNonQuery() > 0)
                {
                    infoResult.IsSuccess = true;
                }
                else
                {
                    infoResult.IsSuccess = false;
                }

            }
            return infoResult;
        }
        public bool GetUserModulePermissionById(Guid? IdModulePermission, SqlConnection objConn,SqlTransaction objTran)
        {
            bool status = false;
            
            SqlCommand cmdUserModulesPermissions = new SqlCommand("[Users].[Proc_GetUserPermissionById]", objConn, objTran);

            cmdUserModulesPermissions.CommandType = CommandType.StoredProcedure;

            cmdUserModulesPermissions.Parameters.Add(new SqlParameter("@IdModulePermission", DbType.Guid)).Value = IdModulePermission.Value;

            objReader = cmdUserModulesPermissions.ExecuteReader();
            while (objReader.Read())
            {
                status = true;
                break;
            }
            objReader.Close();
            return status;
        }
        public List<UserModulesPermissionsEL> GetUserModulePermissionsById(Guid? Id, SqlConnection objConn)
        {
            List<UserModulesPermissionsEL> list = new List<UserModulesPermissionsEL>();
            SqlCommand cmdUserModules = new SqlCommand("[Users].[Proc_GetUserPermissionsById]", objConn);

            cmdUserModules.CommandType = CommandType.StoredProcedure;

            cmdUserModules.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = Id.Value;

            objReader = cmdUserModules.ExecuteReader();
            while (objReader.Read())
            {
                UserModulesPermissionsEL oelUserModuelPermission = new UserModulesPermissionsEL();
                oelUserModuelPermission.IdMoudlePermission = Validation.GetSafeGuid(objReader["ModulePermission_Id"]);
                oelUserModuelPermission.IdUserModule = Validation.GetSafeGuid(objReader["UserModule_Id"]);
                oelUserModuelPermission.IdModule = Validation.GetSafeGuid(objReader["Module_Id"]);
                oelUserModuelPermission.ModuleName = Validation.GetSafeString(objReader["Module_Name"]);
                oelUserModuelPermission.Saving = Validation.GetSafeBooleanNullable(objReader["Adding"]);
                oelUserModuelPermission.Updating = Validation.GetSafeBooleanNullable(objReader["Updating"]);
                oelUserModuelPermission.Deleting = Validation.GetSafeBooleanNullable(objReader["Deleting"]);
                oelUserModuelPermission.Viewing = Validation.GetSafeBooleanNullable(objReader["Viewing"]);
                oelUserModuelPermission.Posting = Validation.GetSafeBooleanNullable(objReader["Posting"]);
                oelUserModuelPermission.Printing = Validation.GetSafeBooleanNullable(objReader["Printing"]);


                list.Add(oelUserModuelPermission);
            }
            return list;
        }
        public List<UserModulesPermissionsEL> GetUserModulePermissionsByUserAndModuleId(Guid? IdUser,Guid? IdModule, SqlConnection objConn)
        {
            List<UserModulesPermissionsEL> list = new List<UserModulesPermissionsEL>();
            SqlCommand cmdUserModules = new SqlCommand("[Users].[Proc_GetUserPermissionsOnModule]", objConn);

            cmdUserModules.CommandType = CommandType.StoredProcedure;

            cmdUserModules.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = IdUser.Value;
            cmdUserModules.Parameters.Add(new SqlParameter("@IdModule", DbType.Guid)).Value = IdModule.Value;

            objReader = cmdUserModules.ExecuteReader();
            while (objReader.Read())
            {
                UserModulesPermissionsEL oelUserModuelPermission = new UserModulesPermissionsEL();
                oelUserModuelPermission.Saving = Validation.GetSafeBooleanNullable(objReader["Adding"]);
                oelUserModuelPermission.Updating = Validation.GetSafeBooleanNullable(objReader["Updating"]);
                oelUserModuelPermission.Deleting = Validation.GetSafeBooleanNullable(objReader["Deleting"]);
                oelUserModuelPermission.Viewing = Validation.GetSafeBooleanNullable(objReader["Viewing"]);
                oelUserModuelPermission.Posting = Validation.GetSafeBooleanNullable(objReader["Posting"]);
                oelUserModuelPermission.Printing = Validation.GetSafeBooleanNullable(objReader["Printing"]);


                list.Add(oelUserModuelPermission);
            }
            return list;
        }
    }
}
