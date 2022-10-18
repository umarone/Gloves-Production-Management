using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using Accounts.DAL;
using Accounts.Common;
using Accounts.EL;

namespace Accounts.BLL
{
    public class UsersBLL
    {
        UsersDAL dal;
        public UsersBLL()
        {
            dal = new UsersDAL();
        }
        public EntityoperationInfo CreateUsers(UsersEL oelUser)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                if (oelUser.UserId == Guid.Empty)
                {
                    oelUser.UserId = Guid.NewGuid();
                }
                return dal.CreateUsers(oelUser, objConn);
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
        public EntityoperationInfo UpdateUsers(UsersEL oelUser)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.UpdateUsers(oelUser, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }            
        }
        public List<UsersEL> GetAllUsers()
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            List<UsersEL> oelUsersCollection = null;
            try
            {
                objConn.Open();
                oelUsersCollection = dal.GetAllUsers(objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
            return oelUsersCollection;
        }
        public List<UsersEL> GetUserByCompanyId(Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetUserByCompanyId(IdCompany,objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public List<UsersEL> GetUserById(Guid IdUser)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetUserById(IdUser, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public List<UsersEL> verifyUser(UsersEL oelUsers)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);            
            try
            {
                objConn.Open();
                return dal.verifyUser(oelUsers, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }            
        }
        //public List<UserRolesEL> verifyUser(UserRolesEL oelUsers, SqlConnection oConnection)
        //{
        //    SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
        //    try
        //    {
        //        objConn.Open();
        //        return dal.verifyUser(oelUsers, objConn);
        //    }
        //    catch (Exception ex)
        //    {
        //        objConn.Close();
        //        objConn.Dispose();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (objConn.State == System.Data.ConnectionState.Open)
        //        {
        //            objConn.Close();
        //            objConn.Dispose();
        //        }
        //    }    
        //}
        public EntityoperationInfo DeleteUsers(UsersEL oelUser)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                if (oelUser.UserId == Guid.Empty)
                {
                    oelUser.UserId = Guid.NewGuid();
                }
                return dal.DeleteUsers(oelUser, objConn);
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
