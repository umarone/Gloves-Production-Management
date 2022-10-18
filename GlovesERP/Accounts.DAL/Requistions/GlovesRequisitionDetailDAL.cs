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
    public class GlovesRequisitionDetailDAL
    {
        public GlovesRequisitionDetailDAL()
        { 
            
        }
         IDataReader objReader;
        public bool CreateGlovesRequisitionDetail(List<RequisitionDetailEL> oelRequisitionDetailCollection, SqlConnection objConn, SqlTransaction oTran)
        {
            SqlCommand cmdGarment = new SqlCommand("[Production].[Proc_CreateGlovesRequisitionDetail]", objConn);
            cmdGarment.CommandType = CommandType.StoredProcedure;
            cmdGarment.CommandTimeout = 0;
            cmdGarment.Transaction = oTran;
            for (int i = 0; i < oelRequisitionDetailCollection.Count; i++)
            {
                cmdGarment.Parameters.Add(new SqlParameter("@IdRequisitionDetail", DbType.Guid)).Value = oelRequisitionDetailCollection[i].IdRequisitionDetail;
                cmdGarment.Parameters.Add(new SqlParameter("@IdRequisition", DbType.Guid)).Value = oelRequisitionDetailCollection[i].IdRequisition;
                cmdGarment.Parameters.Add(new SqlParameter("@IdArticle", DbType.Guid)).Value = oelRequisitionDetailCollection[i].IdArticle; 
                cmdGarment.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelRequisitionDetailCollection[i].IdItem;
                cmdGarment.Parameters.Add(new SqlParameter("@IdColor", DbType.Int64)).Value = oelRequisitionDetailCollection[i].IdColor;
                cmdGarment.Parameters.Add(new SqlParameter("@TaliBariSize", DbType.Int64)).Value = oelRequisitionDetailCollection[i].TalliBariSize;
                cmdGarment.Parameters.Add(new SqlParameter("@Width", DbType.Int64)).Value = oelRequisitionDetailCollection[i].TalliBariWidth;
                cmdGarment.Parameters.Add(new SqlParameter("@CuffTaliSize", DbType.Int64)).Value = oelRequisitionDetailCollection[i].TotalCuffs;
                cmdGarment.Parameters.Add(new SqlParameter("@CalculatedQty", DbType.Int64)).Value = oelRequisitionDetailCollection[i].CalculatedQty;
                cmdGarment.Parameters.Add(new SqlParameter("@CurrentStock", DbType.Int64)).Value = oelRequisitionDetailCollection[i].CurrentStock;
                cmdGarment.Parameters.Add(new SqlParameter("@RequiredQty", DbType.Int64)).Value = oelRequisitionDetailCollection[i].RequiredQty;
                cmdGarment.Parameters.Add(new SqlParameter("@AvgRate", DbType.Decimal)).Value = oelRequisitionDetailCollection[i].AvgRate;
                cmdGarment.Parameters.Add(new SqlParameter("@TotalAvgRate", DbType.Decimal)).Value = oelRequisitionDetailCollection[i].TotalAvgRate;
                cmdGarment.Parameters.Add(new SqlParameter("@ReqDetailType", DbType.Int64)).Value = oelRequisitionDetailCollection[i].ReqDetailType;

                cmdGarment.ExecuteNonQuery();
                cmdGarment.Parameters.Clear();

            }
            return true;

        }
        public bool UpdateGlovesRequisitionDetail(List<RequisitionDetailEL> oelRequisitionDetailCollection, SqlConnection objConn, SqlTransaction oTran)
        {
            SqlCommand cmdGarment = new SqlCommand("[Production].[Proc_UpdateGlovesRequisitionDetail]", objConn);
            cmdGarment.CommandType = CommandType.StoredProcedure;
            cmdGarment.CommandTimeout = 0;
            cmdGarment.Transaction = oTran;
            for (int i = 0; i < oelRequisitionDetailCollection.Count; i++)
            {
                if (oelRequisitionDetailCollection[i].IsNew)
                {
                    cmdGarment.CommandText = "[Production].[Proc_CreateGlovesRequisitionDetail]";
                }
                else
                {
                    cmdGarment.CommandText = "[Production].[Proc_UpdateGlovesRequisitionDetail]";
                }

                cmdGarment.Parameters.Add(new SqlParameter("@IdRequisitionDetail", DbType.Guid)).Value = oelRequisitionDetailCollection[i].IdRequisitionDetail;
                cmdGarment.Parameters.Add(new SqlParameter("@IdRequisition", DbType.Guid)).Value = oelRequisitionDetailCollection[i].IdRequisition;
                cmdGarment.Parameters.Add(new SqlParameter("@IdArticle", DbType.Guid)).Value = oelRequisitionDetailCollection[i].IdArticle;
                cmdGarment.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelRequisitionDetailCollection[i].IdItem;
                cmdGarment.Parameters.Add(new SqlParameter("@IdColor", DbType.Int64)).Value = oelRequisitionDetailCollection[i].IdColor;
                cmdGarment.Parameters.Add(new SqlParameter("@TaliBariSize", DbType.Int64)).Value = oelRequisitionDetailCollection[i].TalliBariSize;
                cmdGarment.Parameters.Add(new SqlParameter("@Width", DbType.Int64)).Value = oelRequisitionDetailCollection[i].TalliBariWidth;
                cmdGarment.Parameters.Add(new SqlParameter("@CuffTaliSize", DbType.Int64)).Value = oelRequisitionDetailCollection[i].TotalCuffs;
                cmdGarment.Parameters.Add(new SqlParameter("@CalculatedQty", DbType.Int64)).Value = oelRequisitionDetailCollection[i].CalculatedQty;
                cmdGarment.Parameters.Add(new SqlParameter("@CurrentStock", DbType.Int64)).Value = oelRequisitionDetailCollection[i].CurrentStock;
                cmdGarment.Parameters.Add(new SqlParameter("@RequiredQty", DbType.Int64)).Value = oelRequisitionDetailCollection[i].RequiredQty;
                cmdGarment.Parameters.Add(new SqlParameter("@AvgRate", DbType.Decimal)).Value = oelRequisitionDetailCollection[i].AvgRate;
                cmdGarment.Parameters.Add(new SqlParameter("@TotalAvgRate", DbType.Decimal)).Value = oelRequisitionDetailCollection[i].TotalAvgRate;
                cmdGarment.Parameters.Add(new SqlParameter("@ReqDetailType", DbType.Int64)).Value = oelRequisitionDetailCollection[i].ReqDetailType;

                cmdGarment.ExecuteNonQuery();
                cmdGarment.Parameters.Clear();

            }
            return true;

        }       
        public List<RequisitionDetailEL> GetGlovesRequisitionArticles(Int64 ReqNo, Guid IdCompany, SqlConnection objConn)
        {
            List<RequisitionDetailEL> list = new List<RequisitionDetailEL>();
            using (SqlCommand cmdRequisition = new SqlCommand("[Production].[Proc_GetGarmentsRequisitionArticles]", objConn))
            {
                cmdRequisition.CommandType = CommandType.StoredProcedure;
                cmdRequisition.CommandTimeout = 0;
                cmdRequisition.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                cmdRequisition.Parameters.Add(new SqlParameter("@RequisitionNo", DbType.Int64)).Value = ReqNo;
                objReader = cmdRequisition.ExecuteReader();
                while (objReader.Read())
                {
                    RequisitionDetailEL oelRequisition = new RequisitionDetailEL();
                    oelRequisition.IdRequisition = Validation.GetSafeGuid(objReader["Requisition_Id"]);
                    oelRequisition.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelRequisition.ItemName = Validation.GetSafeString(objReader["ItemName"]);

                    list.Add(oelRequisition);
                }
            }
            return list;
        }
        public List<RequisitionDetailEL> GetGlovesRequisitionDetailsArticles(Guid IdArticle, Guid IdRequisition, SqlConnection objConn)
        {
            List<RequisitionDetailEL> list = new List<RequisitionDetailEL>();
            using (SqlCommand cmdRequisition = new SqlCommand("[Production].[Proc_GetGlovesRequistionDetailByArticle]", objConn))
            {
                cmdRequisition.CommandType = CommandType.StoredProcedure;
                cmdRequisition.CommandTimeout = 0;
                cmdRequisition.Parameters.Add(new SqlParameter("@IdArtcile", DbType.Guid)).Value = IdArticle;
                cmdRequisition.Parameters.Add(new SqlParameter("@IdRequisition", DbType.Int64)).Value = IdRequisition;
                objReader = cmdRequisition.ExecuteReader();
                while (objReader.Read())
                {
                    RequisitionDetailEL oelRequisition = new RequisitionDetailEL();
                    oelRequisition.IdRequisition = Validation.GetSafeGuid(objReader["Requisition_Id"]);
                    oelRequisition.IdOrder = Validation.GetSafeGuid(objReader["Order_Id"]);
                    oelRequisition.IdRequisitionDetail = Validation.GetSafeGuid(objReader["RequisitionDetail_Id"]);
                    oelRequisition.ReqNo = Validation.GetSafeLong(objReader["RequisitionNo"]);
                    oelRequisition.CustomerPo = Validation.GetSafeString(objReader["PoNumber"]);
                    oelRequisition.ReqType = Validation.GetSafeInteger(objReader["RequisitionType"]);
                    oelRequisition.ReqDate = Validation.GetSafeDateTime(objReader["RequisitionDate"]);

                    oelRequisition.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelRequisition.ItemName = Validation.GetSafeString(objReader["ItemName"]);

                    oelRequisition.TalliBariSize = Validation.GetSafeDecimal(objReader["TalliBariSize"]);
                    oelRequisition.TalliBariWidth = Validation.GetSafeDecimal(objReader["Width"]);
                    oelRequisition.TotalCuffs = Validation.GetSafeDecimal(objReader["CuffTaliSize"]);
                    oelRequisition.CalculatedQty = Validation.GetSafeDecimal(objReader["CalculatedQty"]);
                    oelRequisition.CurrentStock = Validation.GetSafeLong(objReader["CurrentStock"]);
                    oelRequisition.RequiredQty = Validation.GetSafeDecimal(objReader["RequiredQty"]);
                    oelRequisition.AvgRate = Validation.GetSafeDecimal(objReader["AvgRate"]);
                    oelRequisition.TotalAvgRate = Validation.GetSafeDecimal(objReader["TotalAvgRate"]);
                    oelRequisition.ReqDetailType = Validation.GetSafeInteger(objReader["ReqDetailType"]);

                    list.Add(oelRequisition);
                }
            }
            return list;
        }
    }
}
