using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Accounts.DAL;
using Accounts.EL;
using Accounts.Common;
using System.Data.SqlClient;

namespace Accounts.BLL
{
    public class ProcessesBLL
    {
        ProcessesDAL dal;
        EntityoperationInfo infoResult;
        public ProcessesBLL()
        {
            dal = new ProcessesDAL();
        }
        public EntityoperationInfo InsertProcesses(ProcessesEL oelProcess)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                infoResult = dal.InsertProcesses(oelProcess, objConn);
            }
            catch
            {
                objConn.Close();
                objConn.Dispose();
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
            return infoResult;
        }
        public EntityoperationInfo UpdateProcesses(ProcessesEL oelProcess)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                infoResult = dal.UpdateProcesses(oelProcess, objConn);
            }
            catch
            {
                objConn.Close();
                objConn.Dispose();
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
            return infoResult;
        }
        public EntityoperationInfo DeleteProcesses(Guid IdProcess)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                infoResult = dal.DeleteProcesses(IdProcess, objConn);
            }
            catch(Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
            return infoResult;
        }
        public Int64 GetMaxProcessCode()
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetMaxProcessCode(objConn);
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
        public List<ProcessesEL> GetAllProcesses()
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetAllProcesses(objConn);
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
        public List<ProcessesEL> GetAllDepartmentsByType(Int32 Id)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetAllDepartmentsByType(Id, objConn);
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
        public List<ProcessesEL> GetProcessById(Guid? Id)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetProcessById(Id, objConn);
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
    }
}
