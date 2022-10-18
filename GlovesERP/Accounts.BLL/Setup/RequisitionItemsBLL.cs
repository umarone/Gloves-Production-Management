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
    public class RequisitionItemsBLL
    {
        RequisitionItemsDAL dal;
        public RequisitionItemsBLL()
        {
            dal = new RequisitionItemsDAL();
        }
        public bool InsertRequisitionItems(List<ItemFormulaEL> oelItems)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.InsertRequisitionItems(oelItems, objConn);
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
        public bool DeleteItemsByArticle(Guid IdArticle, Guid IdItem)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.DeleteItemsByArticle(IdArticle, IdItem, objConn);
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
        public List<ItemFormulaEL> GetItemsByAritcle(Guid IdArticle)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetItemsByAritcle(IdArticle, objConn);
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
