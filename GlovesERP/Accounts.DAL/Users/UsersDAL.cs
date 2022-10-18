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
    public class UsersDAL
    {
        IDataReader objReader;
        public EntityoperationInfo CreateUsers(UsersEL oelUser, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdUsers = new SqlCommand("[Users].[Proc_CeateUsers]", objConn))
            {
                cmdUsers.CommandType = CommandType.StoredProcedure;

                cmdUsers.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelUser.UserId;
                cmdUsers.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelUser.IdCompany;
                cmdUsers.Parameters.Add(new SqlParameter("@UserName", DbType.String)).Value = oelUser.UserName;
                cmdUsers.Parameters.Add(new SqlParameter("@Password", DbType.String)).Value = oelUser.Password;
                cmdUsers.Parameters.Add(new SqlParameter("@FirstName", DbType.String)).Value = oelUser.FirstName;
                cmdUsers.Parameters.Add(new SqlParameter("@LastName", DbType.String)).Value = oelUser.LastName;
                cmdUsers.Parameters.Add(new SqlParameter("@Contact", DbType.String)).Value = oelUser.Contact;
                cmdUsers.Parameters.Add(new SqlParameter("@Cnic", DbType.String)).Value = oelUser.Cnic;
                cmdUsers.Parameters.Add(new SqlParameter("@Address", DbType.String)).Value = oelUser.Address;
                cmdUsers.Parameters.Add(new SqlParameter("@IsActive", DbType.Boolean)).Value = oelUser.IsActive;
                cmdUsers.Parameters.Add(new SqlParameter("@CreationDateTime", DbType.DateTime)).Value = oelUser.CreatedDateTime;

                if (cmdUsers.ExecuteNonQuery() > 0)
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
        public EntityoperationInfo UpdateUsers(UsersEL oelUser, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            using (SqlCommand cmdUsers = new SqlCommand("[Users].[Proc_UpdateUsers]", objConn))
            {
                cmdUsers.CommandType = CommandType.StoredProcedure;

                cmdUsers.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelUser.UserId;
                cmdUsers.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelUser.IdCompany;
                cmdUsers.Parameters.Add(new SqlParameter("@UserName", DbType.String)).Value = oelUser.UserName;
                cmdUsers.Parameters.Add(new SqlParameter("@Password", DbType.String)).Value = oelUser.Password;
                cmdUsers.Parameters.Add(new SqlParameter("@FirstName", DbType.String)).Value = oelUser.FirstName;
                cmdUsers.Parameters.Add(new SqlParameter("@LastName", DbType.String)).Value = oelUser.LastName;
                cmdUsers.Parameters.Add(new SqlParameter("@Contact", DbType.String)).Value = oelUser.Contact;
                cmdUsers.Parameters.Add(new SqlParameter("@Cnic", DbType.String)).Value = oelUser.Cnic;
                cmdUsers.Parameters.Add(new SqlParameter("@Address", DbType.String)).Value = oelUser.Address;
                cmdUsers.Parameters.Add(new SqlParameter("@IsActive", DbType.Boolean)).Value = oelUser.IsActive;
                cmdUsers.Parameters.Add(new SqlParameter("@CreatedDateTime", DbType.DateTime)).Value = oelUser.CreatedDateTime;

                //cmdUsers.ExecuteNonQuery();
                if (cmdUsers.ExecuteNonQuery() > 0)
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
        public List<UsersEL> GetAllUsers(SqlConnection oConn)
        {
            List<UsersEL> oelUsersCollection = new List<UsersEL>();
            using (SqlCommand cmdUsers = new SqlCommand("[Users].[Proc_GetAllUsers]", oConn))
            {
                cmdUsers.CommandType = CommandType.StoredProcedure;
                objReader = cmdUsers.ExecuteReader();
                while (objReader.Read())
                {
                    UsersEL oelUser = new UsersEL();
                    oelUser.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
                    oelUser.IdCompany = Validation.GetSafeGuid(objReader["Company_Id"]);
                    oelUser.CompanyName = Validation.GetSafeString(objReader["Company_Name"]);
                    oelUser.UserName = Validation.GetSafeString(objReader["UserName"]);
                    oelUser.Password = Validation.GetSafeString(objReader["Password"]);
                    oelUser.FirstName = Validation.GetSafeString(objReader["First_Name"]);
                    oelUser.LastName = Validation.GetSafeString(objReader["Last_Name"]);
                    oelUser.Contact = Validation.GetSafeString(objReader["Contact"]);
                    oelUser.Cnic = Validation.GetSafeString(objReader["Cnic"]);
                    oelUser.Address = Validation.GetSafeString(objReader["Address"]);
                    oelUser.IsActive = Convert.ToBoolean(objReader["IsActive"]);
                    oelUser.CreatedDateTime = Convert.ToDateTime(objReader["Created_DateTime"]);
                    oelUsersCollection.Add(oelUser);
                }
            }
            return oelUsersCollection;
        }
        public List<UsersEL> GetUserByCompanyId(Guid IdCompany, SqlConnection objConn)
        {
            List<UsersEL> oelUsersCollection = new List<UsersEL>();
            using (SqlCommand cmdUsers = new SqlCommand("[Users].[Proc_GetUserByCompanyId]", objConn))
            {
                cmdUsers.CommandType = CommandType.StoredProcedure;
                cmdUsers.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                objReader = cmdUsers.ExecuteReader();
                while (objReader.Read())
                {
                    UsersEL oelUser = new UsersEL();
                    oelUser.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
                    oelUser.IdCompany = Validation.GetSafeGuid(objReader["Company_Id"]);
                    oelUser.CompanyName = Validation.GetSafeString(objReader["Company_Name"]);
                    oelUser.UserName = Validation.GetSafeString(objReader["UserName"]);
                    oelUser.Password = Validation.GetSafeString(objReader["Password"]);
                    oelUser.FirstName = Validation.GetSafeString(objReader["First_Name"]);
                    oelUser.LastName = Validation.GetSafeString(objReader["Last_Name"]);
                    oelUser.Contact = Validation.GetSafeString(objReader["Contact"]);
                    oelUser.Cnic = Validation.GetSafeString(objReader["Cnic"]);
                    oelUser.Address = Validation.GetSafeString(objReader["Address"]);
                    oelUser.IsActive = Convert.ToBoolean(objReader["IsActive"]);
                    oelUser.CreatedDateTime = Convert.ToDateTime(objReader["Created_DateTime"]);
                    oelUsersCollection.Add(oelUser);
                }
            }
            return oelUsersCollection;
        }
        public List<UsersEL> GetUserById(Guid IdUser, SqlConnection objConn)
        {
            List<UsersEL> oelUsersCollection = new List<UsersEL>();
            using (SqlCommand cmdUsers = new SqlCommand("[Users].[Proc_GetUserById]", objConn))
            {
                cmdUsers.CommandType = CommandType.StoredProcedure;
                cmdUsers.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = IdUser;
                objReader = cmdUsers.ExecuteReader();
                while (objReader.Read())
                {
                    UsersEL oelUser = new UsersEL();
                    oelUser.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
                    oelUser.IdCompany = Validation.GetSafeGuid(objReader["Company_Id"]);
                    oelUser.CompanyName = Validation.GetSafeString(objReader["Company_Name"]);
                    oelUser.UserName = Validation.GetSafeString(objReader["UserName"]);
                    oelUser.Password = Validation.GetSafeString(objReader["Password"]);
                    oelUser.FirstName = Validation.GetSafeString(objReader["First_Name"]);
                    oelUser.LastName = Validation.GetSafeString(objReader["Last_Name"]);
                    oelUser.Contact = Validation.GetSafeString(objReader["Contact"]);
                    oelUser.Cnic = Validation.GetSafeString(objReader["Cnic"]);
                    oelUser.Address = Validation.GetSafeString(objReader["Address"]);
                    oelUser.IsActive = Convert.ToBoolean(objReader["IsActive"]);
                    oelUser.CreatedDateTime = Convert.ToDateTime(objReader["Created_DateTime"]);
                    oelUsersCollection.Add(oelUser);
                }
            }
            return oelUsersCollection;
        }
        public List<UsersEL> verifyUser(UsersEL oelUsers, SqlConnection oConnection)
        {
            List<UsersEL> oelUsersCollection = new List<UsersEL>();
            using (SqlCommand cmdVerifyUser = new SqlCommand("[Users].[Proc_VerifyUser]"))
            {

                cmdVerifyUser.CommandType = CommandType.StoredProcedure;
                cmdVerifyUser.Connection = oConnection;
                cmdVerifyUser.Parameters.Add(new SqlParameter("@IdCompany", SqlDbType.UniqueIdentifier)).Value = oelUsers.IdCompany;
                cmdVerifyUser.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar)).Value = oelUsers.UserName;
                cmdVerifyUser.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar)).Value = oelUsers.Password;
                objReader = cmdVerifyUser.ExecuteReader();


                while (objReader.Read())
                {
                    UsersEL oelUser = new UsersEL();
                    oelUser.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
                    
                    oelUser.IdCompany = Validation.GetSafeGuid(objReader["Company_Id"]);
                    oelUser.IdRole = Validation.GetSafeGuid(objReader["Role_Id"]);
                    //oelUser.CompanyName = Validation.GetSafeString(objReader["Company_Name"]);
                    oelUser.UserName = Validation.GetSafeString(objReader["UserName"]);
                    oelUser.Password = Validation.GetSafeString(objReader["Password"]);
                    oelUser.FirstName = Validation.GetSafeString(objReader["First_Name"]);
                    oelUser.LastName = Validation.GetSafeString(objReader["Last_Name"]);
                    oelUser.Contact = Validation.GetSafeString(objReader["Contact"]);
                    oelUser.Cnic = Validation.GetSafeString(objReader["Cnic"]);
                    oelUser.Address = Validation.GetSafeString(objReader["Address"]);
                    oelUser.BookNo = Validation.GetSafeLong(objReader["BookNo"]);
                    oelUser.BookPeriod = Validation.GetSafeString(objReader["BookPeriod"]);
                    oelUser.IsActive = Convert.ToBoolean(objReader["IsActive"]);
                    oelUser.CreatedDateTime = Convert.ToDateTime(objReader["Created_DateTime"]);
                    oelUsersCollection.Add(oelUser);
                }
            }

            return oelUsersCollection;
        }
        //public List<UserRolesEL> verifyUser(UserRolesEL oelUsers, SqlConnection oConnection)
        //{
        //    List<UserRolesEL> oelUsersCollection = new List<UserRolesEL>();
        //    using (SqlCommand cmdVerifyUser = new SqlCommand("[Users].[Proc_VerifyUser]"))
        //    {

        //        cmdVerifyUser.CommandType = CommandType.StoredProcedure;
        //        cmdVerifyUser.Connection = oConnection;
        //        cmdVerifyUser.Parameters.Add(new SqlParameter("@IdCompany", SqlDbType.UniqueIdentifier)).Value = oelUsers.IdCompany;
        //        cmdVerifyUser.Parameters.Add(new SqlParameter("@UserName", SqlDbType.VarChar)).Value = oelUsers.UserName;
        //        cmdVerifyUser.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar)).Value = oelUsers.Password;
        //        objReader = cmdVerifyUser.ExecuteReader();


        //        while (objReader.Read())
        //        {
        //            UserRolesEL oelUser = new UserRolesEL();
        //            oelUser.UserId = Validation.GetSafeGuid(objReader["User_Id"]);

        //            oelUser.IdCompany = Validation.GetSafeGuid(objReader["Company_Id"]);
        //            oelUser.IdRole = Validation.GetSafeGuid(objReader["Role_Id"]);
        //            //oelUser.CompanyName = Validation.GetSafeString(objReader["Company_Name"]);
        //            oelUser.UserName = Validation.GetSafeString(objReader["UserName"]);
        //            oelUser.Password = Validation.GetSafeString(objReader["Password"]);
        //            oelUser.FirstName = Validation.GetSafeString(objReader["First_Name"]);
        //            oelUser.LastName = Validation.GetSafeString(objReader["Last_Name"]);
        //            oelUser.Contact = Validation.GetSafeString(objReader["Contact"]);
        //            oelUser.Cnic = Validation.GetSafeString(objReader["Cnic"]);
        //            oelUser.Address = Validation.GetSafeString(objReader["Address"]);
        //            oelUser.IsActive = Convert.ToBoolean(objReader["IsActive"]);
        //            oelUser.CreatedDateTime = Convert.ToDateTime(objReader["Created_DateTime"]);
        //            oelUsersCollection.Add(oelUser);
        //        }
        //    }

        //    return oelUsersCollection;
        //}
        public EntityoperationInfo DeleteUsers(UsersEL oelUser, SqlConnection objConn)
        {
            EntityoperationInfo DeleteInfo = new EntityoperationInfo();
            using (SqlCommand cmdUsers = new SqlCommand("[Users].[Proc_DeleteUsers]", objConn))
            {
                cmdUsers.CommandType = CommandType.StoredProcedure;
                cmdUsers.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelUser.UserId;
                if (cmdUsers.ExecuteNonQuery() > 0)
                {
                    DeleteInfo.IsSuccess = true;
                }
                else
                {
                    DeleteInfo.IsSuccess = false;
                }

            }
            return DeleteInfo;
        }

    }
}
