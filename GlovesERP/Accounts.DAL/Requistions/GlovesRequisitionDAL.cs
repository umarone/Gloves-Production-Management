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
    public class GlovesRequisitionDAL
    {
        IDataReader objReader;
        GlovesRequisitionDetailDAL dal;
        public GlovesRequisitionDAL()
        {
            dal = new GlovesRequisitionDetailDAL();
        }
        public bool CreateGlovesRequisiton(RequisitionEL oelRequisition, List<RequisitionDetailEL> oelRequisitioinDetail, SqlConnection objConn)
        {

            SqlTransaction objTran = objConn.BeginTransaction();
            try
            {
                SqlCommand cmdCreateGarmentsRequisition = new SqlCommand("[Production].[Proc_CreateGarmentsRequisition]", objConn, objTran);

                cmdCreateGarmentsRequisition.CommandType = CommandType.StoredProcedure;

                cmdCreateGarmentsRequisition.Parameters.Add(new SqlParameter("@IdRequisition", DbType.Guid)).Value = oelRequisition.IdRequisition;
                cmdCreateGarmentsRequisition.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelRequisition.IdCompany;
                cmdCreateGarmentsRequisition.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelRequisition.IdUser;
                cmdCreateGarmentsRequisition.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelRequisition.BookNo;
                cmdCreateGarmentsRequisition.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = oelRequisition.IdOrder;
                cmdCreateGarmentsRequisition.Parameters.Add(new SqlParameter("@IdBrand", DbType.Int64)).Value = oelRequisition.IdBrand;
                cmdCreateGarmentsRequisition.Parameters.Add(new SqlParameter("@PoNumber", DbType.String)).Value = oelRequisition.CustomerPo;
                cmdCreateGarmentsRequisition.Parameters.Add(new SqlParameter("@RequisitionNo", DbType.Int64)).Value = oelRequisition.ReqNo;
                cmdCreateGarmentsRequisition.Parameters.Add(new SqlParameter("@RequisitionType", DbType.Int32)).Value = oelRequisition.ReqType;
                cmdCreateGarmentsRequisition.Parameters.Add(new SqlParameter("@RequisitionDate", DbType.Date)).Value = oelRequisition.ReqDate;

                cmdCreateGarmentsRequisition.ExecuteNonQuery();

                dal.CreateGlovesRequisitionDetail(oelRequisitioinDetail, objConn, objTran);

                objTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                objTran.Rollback();
                throw ex;
            }

        }
        public bool UpdateGlovesRequisiton(RequisitionEL oelRequisition, List<RequisitionDetailEL> oelRequisitioinDetail, SqlConnection objConn)
        {

            SqlTransaction objTran = objConn.BeginTransaction();
            try
            {
                SqlCommand cmdRequisition = new SqlCommand("[Production].[Proc_UpdateGarmentsRequisition]", objConn, objTran);

                cmdRequisition.CommandType = CommandType.StoredProcedure;

                cmdRequisition.Parameters.Add(new SqlParameter("@IdRequisition", DbType.Guid)).Value = oelRequisition.IdRequisition;
                cmdRequisition.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelRequisition.IdCompany;
                cmdRequisition.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelRequisition.IdUser;
                cmdRequisition.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelRequisition.BookNo;
                cmdRequisition.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = oelRequisition.IdOrder;
                cmdRequisition.Parameters.Add(new SqlParameter("@IdBrand", DbType.Int64)).Value = oelRequisition.IdBrand;
                cmdRequisition.Parameters.Add(new SqlParameter("@PoNumber", DbType.String)).Value = oelRequisition.CustomerPo;
                cmdRequisition.Parameters.Add(new SqlParameter("@RequisitionNo", DbType.Int64)).Value = oelRequisition.ReqNo;
                cmdRequisition.Parameters.Add(new SqlParameter("@RequisitionType", DbType.Int32)).Value = oelRequisition.ReqType;
                cmdRequisition.Parameters.Add(new SqlParameter("@RequisitionDate", DbType.Date)).Value = oelRequisition.ReqDate;

                cmdRequisition.ExecuteNonQuery();
                dal.UpdateGlovesRequisitionDetail(oelRequisitioinDetail, objConn, objTran);
                objTran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                objTran.Rollback();
                throw ex;
            }

        }
        public List<RequisitionDetailEL> GetRequisitionDetailByOrder(Guid IdOrder, SqlConnection objConn)
        {
            List<RequisitionDetailEL> list = new List<RequisitionDetailEL>();
            using (SqlCommand cmdRequisition = new SqlCommand("[Production].[Proc_GetRequisitionDetailByOrder]", objConn))
            {
                cmdRequisition.CommandType = CommandType.StoredProcedure;
                cmdRequisition.CommandTimeout = 0;
                cmdRequisition.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = IdOrder;
                objReader = cmdRequisition.ExecuteReader();
                while (objReader.Read())
                {
                    RequisitionDetailEL oelRequisition = new RequisitionDetailEL();
                    oelRequisition.IdRequisition = Validation.GetSafeGuid(objReader["Requisition_Id"]);

                    list.Add(oelRequisition);
                }
            }
            return list;
        }
        public string GetMaxRequisitionNumber(Int32 RequisitionType, Guid IdCompany, SqlConnection objConn)
        {
            using (SqlCommand cmdRequisition = new SqlCommand("[Production].[Proc_GetMaxRequisitionNoByRequisitionType]", objConn))
            {
                cmdRequisition.CommandType = CommandType.StoredProcedure;
                cmdRequisition.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdRequisition.Parameters.Add("@RequisitionType", SqlDbType.NVarChar).Value = RequisitionType;
                return cmdRequisition.ExecuteScalar().ToString();
            }
        }
    }
}
