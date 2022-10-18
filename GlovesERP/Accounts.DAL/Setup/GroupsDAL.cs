using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using Accounts.EL;
using Accounts.Common;

namespace Accounts.DAL
{
    public class GroupsDAL
    {
        IDataReader objReader;
        public EntityoperationInfo CreateGroup(GroupsEL oelGroup, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdGroup = new SqlCommand("[Setup].[Proc_CreateGroups]", objConn))
            {
                cmdGroup.CommandType = CommandType.StoredProcedure;
                cmdGroup.Parameters.Add(new SqlParameter("@IdGroup", DbType.Guid)).Value = oelGroup.IdGroup;
                cmdGroup.Parameters.Add(new SqlParameter("@GroupCode", DbType.Int64)).Value = oelGroup.GroupCode;
                cmdGroup.Parameters.Add(new SqlParameter("@GroupName", DbType.String)).Value = oelGroup.GroupName;
                cmdGroup.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelGroup.IdCompany;
                cmdGroup.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelGroup.UserId;
                cmdGroup.Parameters.Add(new SqlParameter("@IsMandatory", DbType.Boolean)).Value = oelGroup.IsMandatory;
                cmdGroup.Parameters.Add(new SqlParameter("@IsActive", DbType.Boolean)).Value = oelGroup.IsActive;
                cmdGroup.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelGroup.CreatedDateTime;

                //if (cmdItems.ExecuteNonQuery() > -1 && cmdAccounts.ExecuteNonQuery() > -1)
                if (cmdGroup.ExecuteNonQuery() > -1)
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
        public EntityoperationInfo UpdateGroup(GroupsEL oelGroup, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdGroup = new SqlCommand("[Setup].[Proc_UpdateGroups]", objConn))
            {
                cmdGroup.CommandType = CommandType.StoredProcedure;
                cmdGroup.Parameters.Add(new SqlParameter("@IdGroup", DbType.Guid)).Value = oelGroup.IdGroup;
                cmdGroup.Parameters.Add(new SqlParameter("@BrandCode", DbType.Int64)).Value = oelGroup.GroupCode;
                cmdGroup.Parameters.Add(new SqlParameter("@GroupName", DbType.String)).Value = oelGroup.GroupName;
                cmdGroup.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelGroup.IdCompany;
                cmdGroup.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelGroup.UserId;
                cmdGroup.Parameters.Add(new SqlParameter("@IsMandatory", DbType.Boolean)).Value = oelGroup.IsMandatory;
                cmdGroup.Parameters.Add(new SqlParameter("@IsActive", DbType.Boolean)).Value = oelGroup.IsActive;
                cmdGroup.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelGroup.CreatedDateTime;

                //if (cmdItems.ExecuteNonQuery() > -1 && cmdAccounts.ExecuteNonQuery() > -1)
                if (cmdGroup.ExecuteNonQuery() > -1)
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
        public bool DeleteGroups(Guid IdGroup, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            try
            {
                SqlCommand cmdItems = new SqlCommand("[Setup].[Proc_DeleteGroup]", objConn);

                cmdItems.CommandType = CommandType.StoredProcedure;
                cmdItems.Parameters.Add(new SqlParameter("@IdGroup", DbType.Guid)).Value = IdGroup;

                cmdItems.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                objConn.Dispose();
            }
            return true;
        }
        public bool UpdateItemsByGroup(Guid? IdGroup, List<ItemsEL> oelItems, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlTransaction objTran = objConn.BeginTransaction();
            try
            {
                SqlCommand cmdItems = new SqlCommand("[Setup].[Proc_UpdateItemsByGroup]", objConn, objTran);

                cmdItems.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < oelItems.Count; i++)
                {
                    cmdItems.Parameters.Add(new SqlParameter("@IdGroup", DbType.Guid)).Value = IdGroup;
                    cmdItems.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelItems[i].IdItem;

                    cmdItems.ExecuteNonQuery();
                    cmdItems.Parameters.Clear();
                }
                objTran.Commit();              
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                objTran.Dispose();
                objConn.Dispose();
            }
            return true;
        }
        public Int64 GetMaxGroupCode(Guid IdCompany, SqlConnection objConn)
        {
            SqlCommand cmdAccount = new SqlCommand("[Setup].[Proc_GetMaxGroupCode]", objConn);
            cmdAccount.CommandType = CommandType.StoredProcedure;
            cmdAccount.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            return Validation.GetSafeLong(cmdAccount.ExecuteScalar());

        }
        public List<GroupsEL> GetGroupById(Guid IdGroup, SqlConnection objConn)
        {
            List<GroupsEL> list = new List<GroupsEL>();
            SqlCommand cmdBrand = new SqlCommand("[Setup].[Proc_GetGroupById]", objConn);

            cmdBrand.Parameters.Add("@IdGroup", SqlDbType.UniqueIdentifier).Value = IdGroup;

            cmdBrand.CommandType = CommandType.StoredProcedure;
            objReader = cmdBrand.ExecuteReader();
            while (objReader.Read())
            {
                GroupsEL oelGroup = new GroupsEL();
                oelGroup.IdGroup = Validation.GetSafeGuid(objReader["Group_Id"]);
                oelGroup.GroupCode = Validation.GetSafeString(objReader["Group_Code"]);
                oelGroup.GroupName = Validation.GetSafeString(objReader["Group_Name"]);
                oelGroup.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
                oelGroup.IsMandatory = Validation.GetSafeBooleanNullable(objReader["IsMandatory"]);
                oelGroup.IsActive = Validation.GetSafeBooleanNullable(objReader["IsActive"]);
                oelGroup.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);
                list.Add(oelGroup);
            }
            return list;
        }
        public List<GroupsEL> GetAllGroups(Guid IdCompany, SqlConnection objConn)
        {
            List<GroupsEL> list = new List<GroupsEL>();
            SqlCommand cmdBrand = new SqlCommand("[Setup].[Proc_GetAllGroups]", objConn);
            cmdBrand.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdBrand.CommandType = CommandType.StoredProcedure;
            objReader = cmdBrand.ExecuteReader();
            while (objReader.Read())
            {
                GroupsEL oelGroup = new GroupsEL();
                oelGroup.IdGroup = Validation.GetSafeGuid(objReader["Group_Id"]);
                oelGroup.GroupCode = Validation.GetSafeString(objReader["Group_Code"]);
                oelGroup.GroupName = Validation.GetSafeString(objReader["Group_Name"]);
                oelGroup.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
                oelGroup.IsMandatory = Validation.GetSafeBooleanNullable(objReader["IsMandatory"]);
                oelGroup.IsActive = Validation.GetSafeBooleanNullable(objReader["IsActive"]);
                oelGroup.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);
                list.Add(oelGroup);
            }
            return list;
        }
        public List<ItemsEL> GetItemsByGroup(Guid IdGroup, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdItem = new SqlCommand("[Setup].[Proc_GetItemsByGroup]", objConn);

            cmdItem.Parameters.Add("@IdGroup", SqlDbType.UniqueIdentifier).Value = IdGroup;

            cmdItem.CommandType = CommandType.StoredProcedure;
            SqlDataReader oReader = cmdItem.ExecuteReader();
            while (oReader.Read())
            {
                ItemsEL oelItems = new ItemsEL();
                oelItems.IdItem = Validation.GetSafeGuid(oReader["Item_Id"]);
                oelItems.AccountNo = Validation.GetSafeString(oReader["ItemNo"]);
                oelItems.ItemNo = Validation.GetSafeString(oReader["ItemNo"]);
                oelItems.ItemName = Validation.GetSafeString(oReader["ItemName"]);
                if (oReader["packingsize"] != DBNull.Value)
                {
                    oelItems.PackingSize = Validation.GetSafeString(oReader["packingsize"]);
                }
                else
                {
                    oelItems.PackingSize = "N/A";
                }
                list.Add(oelItems);
            }
            return list;
        }
    }
}
