using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Accounts.DAL;
using Accounts.Common;
using Accounts.EL;
using System.Data.SqlClient;

namespace Accounts.BLL
{
    public class GarmentsRequisitionDetailBLL
    {
        GarmentsRequisitionDetailDAL dal;
        public GarmentsRequisitionDetailBLL()
        {
            dal = new GarmentsRequisitionDetailDAL();
        }
        public List<RequisitionDetailEL> GetGarmentsRequisitionArticles(Int64 ReqNo, Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetGarmentsRequisitionArticles(ReqNo, IdCompany, objConn);
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
        public List<RequisitionDetailEL> GetGarmentsRequisitionDetailsArticles(Guid IdArticle, Guid IdRequisition)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetGarmentsRequisitionDetailsArticles(IdArticle, IdRequisition, objConn);
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
