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
    public class GarmentsRequisitionBLL
    {
        GarmentsRequisitionDAL dal;
        public GarmentsRequisitionBLL()
        {
            dal = new GarmentsRequisitionDAL();
        }

        public bool CreateGarmentsRequisiton(RequisitionEL oelRequisition, List<RequisitionDetailEL> oelRequisitioinDetail)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.CreateGarmentsRequisiton(oelRequisition, oelRequisitioinDetail, objConn);
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
        public bool UpdateGarmentsRequisiton(RequisitionEL oelRequisition, List<RequisitionDetailEL> oelRequisitioinDetail)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.UpdateGarmentsRequisiton(oelRequisition, oelRequisitioinDetail, objConn);
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
        public string GetMaxRequisitionNumber(Int32 RequisitionType, Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetMaxRequisitionNumber(RequisitionType, IdCompany, objConn);
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