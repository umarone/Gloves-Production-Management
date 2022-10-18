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
    public class GlovesRequisitionDetailBLL
    {
        GlovesRequisitionDetailDAL dal;
        public GlovesRequisitionDetailBLL()
        {
            dal = new GlovesRequisitionDetailDAL();
        }
        public List<RequisitionDetailEL> GetGlovesRequisitionDetailsArticles(Guid IdArticle, Guid IdRequisition)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetGlovesRequisitionDetailsArticles(IdArticle, IdRequisition, objConn);
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
