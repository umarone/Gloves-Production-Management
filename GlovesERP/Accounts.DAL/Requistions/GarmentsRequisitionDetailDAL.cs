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
    public class GarmentsRequisitionDetailDAL
    {
        IDataReader objReader;
        public bool CreateGarmentsRequisitionDetail(List<RequisitionDetailEL> oelRequisitionDetailCollection, SqlConnection objConn, SqlTransaction oTran)
        {
            SqlCommand cmdGarment = new SqlCommand("[Production].[Proc_CreateGarmentsRequisitionDetail]",objConn);
            cmdGarment.CommandType = CommandType.StoredProcedure;
            cmdGarment.CommandTimeout = 0;
            cmdGarment.Transaction = oTran;
            for (int i = 0; i < oelRequisitionDetailCollection.Count; i++)
            {
                cmdGarment.Parameters.Add(new SqlParameter("@IdRequisitionDetail", DbType.Guid)).Value = oelRequisitionDetailCollection[i].IdRequisitionDetail;
                cmdGarment.Parameters.Add(new SqlParameter("@IdRequisition", DbType.Guid)).Value = oelRequisitionDetailCollection[i].IdRequisition;
                cmdGarment.Parameters.Add(new SqlParameter("@IdArticle", DbType.Guid)).Value = oelRequisitionDetailCollection[i].IdArticle;
                cmdGarment.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelRequisitionDetailCollection[i].IdItem;
                cmdGarment.Parameters.Add(new SqlParameter("@Small", DbType.Int64)).Value = oelRequisitionDetailCollection[i].Small;
                cmdGarment.Parameters.Add(new SqlParameter("@Medium", DbType.Int64)).Value = oelRequisitionDetailCollection[i].Medium;
                cmdGarment.Parameters.Add(new SqlParameter("@Large", DbType.Int64)).Value = oelRequisitionDetailCollection[i].Large;
                cmdGarment.Parameters.Add(new SqlParameter("@XLarge", DbType.Int64)).Value = oelRequisitionDetailCollection[i].XLarge;
                cmdGarment.Parameters.Add(new SqlParameter("@2XLarge", DbType.Int64)).Value = oelRequisitionDetailCollection[i].DoubleXLarge;
                cmdGarment.Parameters.Add(new SqlParameter("@3XLarge", DbType.Int64)).Value = oelRequisitionDetailCollection[i].TripleXLarge;
                cmdGarment.Parameters.Add(new SqlParameter("@4xLarge", DbType.Int64)).Value = oelRequisitionDetailCollection[i].FourthXLarge;
                cmdGarment.Parameters.Add(new SqlParameter("@5XLarge", DbType.Int64)).Value = oelRequisitionDetailCollection[i].FifthXLarge;
                cmdGarment.Parameters.Add(new SqlParameter("@Total", DbType.Int64)).Value = oelRequisitionDetailCollection[i].TotalBreakup;
                cmdGarment.Parameters.Add(new SqlParameter("@Dying", DbType.Decimal)).Value = oelRequisitionDetailCollection[i].Dying;
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
        public bool UpdateGarmentsRequisitionDetail(List<RequisitionDetailEL> oelRequisitionDetailCollection, SqlConnection objConn, SqlTransaction oTran)
        {
            SqlCommand cmdGarment = new SqlCommand("[Production].[Proc_UpdateGarmentsRequisitionDetail]", objConn);
            cmdGarment.CommandType = CommandType.StoredProcedure;
            cmdGarment.CommandTimeout = 0;
            cmdGarment.Transaction = oTran;
            for (int i = 0; i < oelRequisitionDetailCollection.Count; i++)
            {
                if (oelRequisitionDetailCollection[i].IsNew)
                {
                    cmdGarment.CommandText = "[Production].[Proc_CreateGarmentsRequisitionDetail]";
                }
                else
                {
                    cmdGarment.CommandText = "[Production].[Proc_UpdateGarmentsRequisitionDetail]";
                }

                cmdGarment.Parameters.Add(new SqlParameter("@IdRequisitionDetail", DbType.Guid)).Value = oelRequisitionDetailCollection[i].IdRequisitionDetail;
                cmdGarment.Parameters.Add(new SqlParameter("@IdRequisition", DbType.Guid)).Value = oelRequisitionDetailCollection[i].IdRequisition;
                cmdGarment.Parameters.Add(new SqlParameter("@IdArticle", DbType.Guid)).Value = oelRequisitionDetailCollection[i].IdArticle;
                cmdGarment.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelRequisitionDetailCollection[i].IdItem;
                cmdGarment.Parameters.Add(new SqlParameter("@Small", DbType.Int64)).Value = oelRequisitionDetailCollection[i].Small;
                cmdGarment.Parameters.Add(new SqlParameter("@Medium", DbType.Int64)).Value = oelRequisitionDetailCollection[i].Medium;
                cmdGarment.Parameters.Add(new SqlParameter("@Large", DbType.Int64)).Value = oelRequisitionDetailCollection[i].Large;
                cmdGarment.Parameters.Add(new SqlParameter("@XLarge", DbType.Int64)).Value = oelRequisitionDetailCollection[i].XLarge;
                cmdGarment.Parameters.Add(new SqlParameter("@2XLarge", DbType.Int64)).Value = oelRequisitionDetailCollection[i].DoubleXLarge;
                cmdGarment.Parameters.Add(new SqlParameter("@3XLarge", DbType.Int64)).Value = oelRequisitionDetailCollection[i].TripleXLarge;
                cmdGarment.Parameters.Add(new SqlParameter("@4xLarge", DbType.Int64)).Value = oelRequisitionDetailCollection[i].FourthXLarge;
                cmdGarment.Parameters.Add(new SqlParameter("@5XLarge", DbType.Int64)).Value = oelRequisitionDetailCollection[i].FifthXLarge;
                cmdGarment.Parameters.Add(new SqlParameter("@Total", DbType.Int64)).Value = oelRequisitionDetailCollection[i].TotalBreakup;
                cmdGarment.Parameters.Add(new SqlParameter("@Dying", DbType.Decimal)).Value = oelRequisitionDetailCollection[i].Dying;
                cmdGarment.Parameters.Add(new SqlParameter("@CurrentStock", DbType.Int64)).Value = oelRequisitionDetailCollection[i].CurrentStock;
                cmdGarment.Parameters.Add(new SqlParameter("@RequiredQty", DbType.Decimal)).Value = oelRequisitionDetailCollection[i].RequiredQty;
                cmdGarment.Parameters.Add(new SqlParameter("@AvgRate", DbType.Decimal)).Value = oelRequisitionDetailCollection[i].AvgRate;
                cmdGarment.Parameters.Add(new SqlParameter("@TotalAvgRate", DbType.Decimal)).Value = oelRequisitionDetailCollection[i].TotalAvgRate;
                cmdGarment.Parameters.Add(new SqlParameter("@ReqDetailType", DbType.Int64)).Value = oelRequisitionDetailCollection[i].ReqDetailType;

                cmdGarment.ExecuteNonQuery();
                cmdGarment.Parameters.Clear();

            }
            return true;

        }
        public List<RequisitionDetailEL> GetGarmentsRequisitionArticles(Int64 ReqNo, Guid IdCompany, SqlConnection objConn)
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
        public List<RequisitionDetailEL> GetGarmentsRequisitionDetailsArticles(Guid IdArticle, Guid IdRequisition, SqlConnection objConn)
        {
            List<RequisitionDetailEL> list = new List<RequisitionDetailEL>();
            using (SqlCommand cmdRequisition = new SqlCommand("[Production].[Proc_GetGarmentsRequistionByArticle]", objConn))
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
                    oelRequisition.IdRequisitionDetail = Validation.GetSafeGuid(objReader["RequisitionDetail_Id"]);
                    oelRequisition.ReqNo = Validation.GetSafeLong(objReader["RequisitionNo"]);
                    oelRequisition.CustomerPo = Validation.GetSafeString(objReader["PoNumber"]);
                    oelRequisition.ReqType = Validation.GetSafeInteger(objReader["RequisitionType"]);
                    oelRequisition.ReqDate = Validation.GetSafeDateTime(objReader["RequisitionDate"]);
                    
                    oelRequisition.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelRequisition.ItemName = Validation.GetSafeString(objReader["ItemName"]);

                    oelRequisition.Small = Validation.GetSafeLong(objReader["Small"]);
                    oelRequisition.Medium = Validation.GetSafeLong(objReader["Medium"]);
                    oelRequisition.Large = Validation.GetSafeLong(objReader["Large"]);
                    oelRequisition.XLarge = Validation.GetSafeLong(objReader["XLarge"]);
                    oelRequisition.DoubleXLarge = Validation.GetSafeLong(objReader["2XLarge"]);
                    oelRequisition.TripleXLarge = Validation.GetSafeLong(objReader["3XLarge"]);
                    oelRequisition.FourthXLarge = Validation.GetSafeLong(objReader["4XLarge"]);
                    oelRequisition.FifthXLarge = Validation.GetSafeLong(objReader["5XLarge"]);
                    oelRequisition.TotalBreakup = Validation.GetSafeLong(objReader["Total"]);
                    oelRequisition.Dying = Validation.GetSafeDecimal(objReader["Dying"]);
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