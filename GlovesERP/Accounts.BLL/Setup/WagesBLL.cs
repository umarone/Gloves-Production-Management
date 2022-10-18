using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounts.DAL;
using Accounts.Common;
using Accounts.EL;
using System.Data.SqlClient;
using System.Data;


namespace Accounts.BLL
{
    public class WagesBLL
    {
        WagesDAL dal;
        public WagesBLL()
        {
            dal = new WagesDAL();
        }
        public bool CreateWages(List<WagesEL> oelWages)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.CreateWages(oelWages, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == System.Data.ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        public List<WagesEL> GetWagesByProcess(string ProcessName)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetWagesByProcess(ProcessName, objConn);
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
