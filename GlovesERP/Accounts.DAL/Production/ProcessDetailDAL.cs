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
    public class ProcessDetailDAL
    {
       IDataReader objReader;       
       public bool InsertProcessDetail(List<VoucherDetailEL> oelProcessCollection, SqlConnection objConn, SqlTransaction objTran)
       {
           SqlCommand cmdPurchaseDetail = new SqlCommand("[Transactions].[Proc_CreateProcessDetail]", objConn);
           cmdPurchaseDetail.CommandType = CommandType.StoredProcedure;
           cmdPurchaseDetail.Transaction = objTran;
           for (int i = 0; i < oelProcessCollection.Count; i++)
           {
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelProcessCollection[i].IdVoucherDetail;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelProcessCollection[i].IdVoucher;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelProcessCollection[i].Seq;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelProcessCollection[i].IdItem;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdLinkItem", DbType.Guid)).Value = oelProcessCollection[i].IdLinkItem;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdSideItem", DbType.Guid)).Value = oelProcessCollection[i].IdSideItem;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@PackingSize", DbType.String)).Value = oelProcessCollection[i].PackingSize;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@ActualWidth", DbType.Decimal)).Value = oelProcessCollection[i].ActualWidth;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@OutWidth", DbType.Decimal)).Value = oelProcessCollection[i].OutWidth;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Diff", DbType.Decimal)).Value = oelProcessCollection[i].Diff;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@SideAmount", DbType.Decimal)).Value = oelProcessCollection[i].SideAmount;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Units", DbType.Int64)).Value = oelProcessCollection[i].Units;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@QtyYard", DbType.Decimal)).Value = oelProcessCollection[i].MeterYardQty;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@AVGSideRate", DbType.Decimal)).Value = oelProcessCollection[i].AVGSideRate;
               if (oelProcessCollection[0].WorkType == 1)
               {
                   cmdPurchaseDetail.Parameters.Add(new SqlParameter("@AvgRate", DbType.Decimal)).Value = oelProcessCollection[i].AvgRate;
               }
               else
               {
                   cmdPurchaseDetail.Parameters.Add(new SqlParameter("@AvgRate", DbType.Decimal)).Value = CalculateRubberizingAverageRate(oelProcessCollection[i].IdItem,oelProcessCollection[i].IdLinkItem, objConn, objTran);
               }
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelProcessCollection[i].UnitPrice;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelProcessCollection[i].Amount;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IsMarkeen", DbType.String)).Value = oelProcessCollection[i].IsMarkeen;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@WorkType", DbType.Int64)).Value = oelProcessCollection[i].WorkType;
               cmdPurchaseDetail.ExecuteNonQuery();
               cmdPurchaseDetail.Parameters.Clear();

           }
           return true;
       }
       public bool UpdateProcessDetail(List<VoucherDetailEL> oelProcessCollection, SqlConnection objConn, SqlTransaction objTran)
       {
           SqlCommand cmdPurchaseDetail = new SqlCommand();
           cmdPurchaseDetail.CommandType = CommandType.StoredProcedure;
           cmdPurchaseDetail.Connection = objConn;
           cmdPurchaseDetail.Transaction = objTran;
           for (int i = 0; i < oelProcessCollection.Count; i++)
           {
               if (oelProcessCollection[i].IsNew)
               {
                   cmdPurchaseDetail.CommandText = "[Transactions].[Proc_CreateProcessDetail]";
               }
               else
               {
                   cmdPurchaseDetail.CommandText = "[Transactions].[Proc_UpdateProcessDetail]";
               }
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelProcessCollection[i].IdVoucherDetail;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelProcessCollection[i].IdVoucher;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Seq", DbType.Int32)).Value = oelProcessCollection[i].Seq;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelProcessCollection[i].IdItem;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdLinkItem", DbType.Guid)).Value = oelProcessCollection[i].IdLinkItem;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IdSideItem", DbType.Guid)).Value = oelProcessCollection[i].IdSideItem;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@PackingSize", DbType.String)).Value = oelProcessCollection[i].PackingSize;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@ActualWidth", DbType.Decimal)).Value = oelProcessCollection[i].ActualWidth;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@OutWidth", DbType.Decimal)).Value = oelProcessCollection[i].OutWidth;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Diff", DbType.Decimal)).Value = oelProcessCollection[i].Diff;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@SideAmount", DbType.Decimal)).Value = oelProcessCollection[i].SideAmount;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Units", DbType.Int64)).Value = oelProcessCollection[i].Units;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@QtyYard", DbType.Decimal)).Value = oelProcessCollection[i].MeterYardQty;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@AVGSideRate", DbType.Decimal)).Value = oelProcessCollection[i].AVGSideRate;
               if (oelProcessCollection[0].WorkType == 1)
               {
                   cmdPurchaseDetail.Parameters.Add(new SqlParameter("@AvgRate", DbType.Decimal)).Value = oelProcessCollection[i].AvgRate;
               }
               else
               {
                   cmdPurchaseDetail.Parameters.Add(new SqlParameter("@AvgRate", DbType.Decimal)).Value = CalculateRubberizingAverageRate(oelProcessCollection[i].IdItem, oelProcessCollection[i].IdLinkItem, objConn, objTran);
               }
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelProcessCollection[i].UnitPrice;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelProcessCollection[i].Amount;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@IsMarkeen", DbType.String)).Value = oelProcessCollection[i].IsMarkeen;
               cmdPurchaseDetail.Parameters.Add(new SqlParameter("@WorkType", DbType.Int64)).Value = oelProcessCollection[i].WorkType;

               cmdPurchaseDetail.ExecuteNonQuery();
               cmdPurchaseDetail.Parameters.Clear();
           }
           return true;
       }
       private decimal CalculateRubberizingAverageRate(Guid IdItem, Guid IdLinkItem, SqlConnection objConn, SqlTransaction objTran)
       {
           decimal CalculatedAvgValue = 0;
           using (SqlCommand cmdItem = new SqlCommand("[Setup].[Proc_CalculateRubberizingItemAvgValue]", objConn, objTran))
           {
               cmdItem.CommandType = CommandType.StoredProcedure;
               cmdItem.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
               cmdItem.Parameters.Add("@IdLinkItem", SqlDbType.UniqueIdentifier).Value = IdLinkItem;
               return Validation.GetSafeDecimal(cmdItem.ExecuteScalar());
           }
           return CalculatedAvgValue;
       }
       public List<VoucherDetailEL> GetRubberizingByIssuanceTypeAndNumber(Guid IdCompany,Int64 IssuanceNo, int IssuanceType, SqlConnection objConn)
       {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdProduction = new SqlCommand("[Transactions].[Proc_GetRubberizingByIssuanceTypeAndNumber]", objConn))
            {
                cmdProduction.CommandType = CommandType.StoredProcedure;
                cmdProduction.CommandTimeout = 0;
                cmdProduction.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                cmdProduction.Parameters.Add(new SqlParameter("@IssuanceNo", DbType.Int64)).Value = IssuanceNo;
                cmdProduction.Parameters.Add(new SqlParameter("@WorkType", DbType.Int32)).Value = IssuanceType;
                objReader = cmdProduction.ExecuteReader();
                while (objReader.Read())
                {                    
                    //Add Header Record Detail
                    VoucherDetailEL oelIssuanceDetail = new VoucherDetailEL();
                    oelIssuanceDetail.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                    oelIssuanceDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelIssuanceDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelIssuanceDetail.VDate = Validation.GetSafeNullableDateTime(objReader["VDate"]);
                    oelIssuanceDetail.VDiscription = Validation.GetSafeString(objReader["VDiscription"]);
                    oelIssuanceDetail.WorkType = Validation.GetSafeInteger(objReader["WorkType"]);
                    oelIssuanceDetail.ProcessType = Validation.GetSafeInteger(objReader["ProcessType"]);
                    oelIssuanceDetail.IsClaimed = Validation.GetSafeBooleanNullable(objReader["Claimed"]);
                    oelIssuanceDetail.IsPlain = Validation.GetSafeBooleanNullable(objReader["IsPlain"]);
                    oelIssuanceDetail.Posted = Validation.GetSafeBoolean(objReader["Posted"]);
                    oelIssuanceDetail.IsDeleted = Validation.GetSafeBooleanNullable(objReader["IsDeleted"]);

                    /// Now Add Detail Record Detail
                    oelIssuanceDetail.IdVoucherDetail = Validation.GetSafeGuid(objReader["VoucherDetail_Id"]);
                    oelIssuanceDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelIssuanceDetail.IdLinkItem = Validation.GetSafeGuid(objReader["LinkItem_Id"]);
                    oelIssuanceDetail.IdSideItem = Validation.GetSafeGuid(objReader["SideItem_Id"]);
                    oelIssuanceDetail.IsMarkeen = Validation.GetSafeBooleanNullable(objReader["IsMarkeen"]);
                    //oelIssuanceDetail.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    //oelIssuanceDetail.IdUser = Validation.GetSafeGuid(objReader["User_Id"]);
                    oelIssuanceDetail.Qty = Validation.GetSafeLong(objReader["units"]);
                    oelIssuanceDetail.MeterYardQty = Validation.GetSafeDecimal(objReader["YardQty"]);
                    oelIssuanceDetail.AvgRate = Validation.GetSafeDecimal(objReader["AvgRate"]);
                    oelIssuanceDetail.PackingSize = Validation.GetSafeString(objReader["packingsize"]);
                    oelIssuanceDetail.ActualWidth = Validation.GetSafeDecimal(objReader["ActualWidth"]);
                    oelIssuanceDetail.OutWidth = Validation.GetSafeDecimal(objReader["OutWidth"]);
                    oelIssuanceDetail.Diff = Validation.GetSafeDecimal(objReader["Diff"]);
                    oelIssuanceDetail.UnitPrice = Validation.GetSafeDecimal(objReader["UnitPrice"]);
                    oelIssuanceDetail.SideAmount = Validation.GetSafeDecimal(objReader["SideAmount"]);
                    oelIssuanceDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                    oelIssuanceDetail.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);
                    oelIssuanceDetail.LinkItemName = Validation.GetSafeString(objReader["LinkedItemName"]);
                    oelIssuanceDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelIssuanceDetail.SideItemName = Validation.GetSafeString(objReader["SideItemName"]);

                    list.Add(oelIssuanceDetail);
                }
            }
            return list;
        }
       public List<VoucherDetailEL> GetRubberizingStockByParty(Guid IdCompany, string AccountNo, SqlConnection objConn)
       {
           List<VoucherDetailEL> list = new List<VoucherDetailEL>();
           using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetRubberizingStockByParty]", objConn))
           {
               cmdRequisition.CommandType = CommandType.StoredProcedure;
               cmdRequisition.CommandTimeout = 0;
               cmdRequisition.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
               cmdRequisition.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
               objReader = cmdRequisition.ExecuteReader();
               while (objReader.Read())
               {
                   VoucherDetailEL obj = new VoucherDetailEL();
                   obj.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                   obj.Date = Convert.ToDateTime(objReader["VDate"]);
                   //obj.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                   obj.ProductCode = Validation.GetSafeString(objReader["ItemCode"]);
                   obj.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                   obj.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                   obj.GatePassType = Validation.GetSafeString(objReader["WorkType"]);
                   obj.Units = Validation.GetSafeLong(objReader["YardQty"]);
                   obj.UnitPrice = Validation.GetSafeLong(objReader["UnitPrice"]);
                   obj.TotalAmount = Validation.GetSafeLong(objReader["TotalAmount"]);
                   list.Add(obj);
               }
           }
           return list;
       }
       public List<VoucherDetailEL> GetRubberizingStockByPartyAndDate(Guid IdCompany, string AccountNo,DateTime StartDate,DateTime EndDate, SqlConnection objConn)
       {
           List<VoucherDetailEL> list = new List<VoucherDetailEL>();
           using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetRubberizingStockByPartyAndDate]", objConn))
           {
               cmdRequisition.CommandType = CommandType.StoredProcedure;
               cmdRequisition.CommandTimeout = 0;
               cmdRequisition.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
               cmdRequisition.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
               cmdRequisition.Parameters.Add(new SqlParameter("@StartDate", DbType.DateTime)).Value = StartDate;
               cmdRequisition.Parameters.Add(new SqlParameter("@EndDate", DbType.DateTime)).Value = EndDate;
               objReader = cmdRequisition.ExecuteReader();
               while (objReader.Read())
               {
                   VoucherDetailEL obj = new VoucherDetailEL();
                   obj.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                   obj.Date = Convert.ToDateTime(objReader["VDate"]);
                   //obj.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                   obj.ProductCode = Validation.GetSafeString(objReader["ItemCode"]);
                   obj.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                   obj.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                   obj.GatePassType = Validation.GetSafeString(objReader["WorkType"]);
                   obj.Units = Validation.GetSafeLong(objReader["YardQty"]);
                   obj.UnitPrice = Validation.GetSafeLong(objReader["UnitPrice"]);
                   obj.TotalAmount = Validation.GetSafeLong(objReader["TotalAmount"]);
                   list.Add(obj);
               }
           }
           return list;
       }
       public List<VoucherDetailEL> GetRubberizingPartySummary(Guid IdCompany, string AccountNo, SqlConnection objConn)
       {
           List<VoucherDetailEL> list = new List<VoucherDetailEL>();
           using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetRubberizingPartySummary]", objConn))
           {
               cmdRequisition.CommandType = CommandType.StoredProcedure;
               cmdRequisition.CommandTimeout = 0;
               cmdRequisition.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
               cmdRequisition.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
               objReader = cmdRequisition.ExecuteReader();
               while (objReader.Read())
               {
                   VoucherDetailEL obj = new VoucherDetailEL();                   
                   obj.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                   obj.StockOut = Validation.GetSafeDecimal(objReader["StockOut"]);
                   obj.StockIn = Validation.GetSafeLong(objReader["StockIn"]);
                   obj.RemainingStock = Validation.GetSafeLong(objReader["Remaining"]);
                   list.Add(obj);
               }
           }
           return list;
       }
       public List<VoucherDetailEL> GetRubberizingStockByItemAndParty(Guid IdCompany, Guid IdItem, string AccountNo, SqlConnection objConn)
       {
           List<VoucherDetailEL> list = new List<VoucherDetailEL>();
           using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetRubberizingStockByItemAndPerson]", objConn))
           {
               cmdRequisition.CommandType = CommandType.StoredProcedure;
               cmdRequisition.CommandTimeout = 0;
               cmdRequisition.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
               cmdRequisition.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = IdItem;
               cmdRequisition.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
               objReader = cmdRequisition.ExecuteReader();
               while (objReader.Read())
               {
                   VoucherDetailEL obj = new VoucherDetailEL();
                   obj.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                   obj.Date = Convert.ToDateTime(objReader["VDate"]);
                   //obj.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                   obj.ProductCode = Validation.GetSafeString(objReader["ItemCode"]);
                   obj.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                   obj.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                   obj.GatePassType = Validation.GetSafeString(objReader["WorkType"]);
                   obj.Units = Validation.GetSafeLong(objReader["YardQty"]);
                   obj.UnitPrice = Validation.GetSafeLong(objReader["UnitPrice"]);
                   obj.TotalAmount = Validation.GetSafeLong(objReader["TotalAmount"]);
                   list.Add(obj);
               }
           }
           return list;
       }
       public List<VoucherDetailEL> GetRubberizingStockByItemAndDateAndParty(Guid IdCompany, Guid IdItem, string AccountNo, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
       {
           List<VoucherDetailEL> list = new List<VoucherDetailEL>();
           using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetRubberizingStockByItemAndDateAndParty]", objConn))
           {
               cmdRequisition.CommandType = CommandType.StoredProcedure;
               cmdRequisition.CommandTimeout = 0;
               cmdRequisition.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
               cmdRequisition.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = IdItem;
               cmdRequisition.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
               cmdRequisition.Parameters.Add(new SqlParameter("@StartDate", DbType.DateTime)).Value = StartDate;
               cmdRequisition.Parameters.Add(new SqlParameter("@EndDate", DbType.DateTime)).Value = EndDate;
               objReader = cmdRequisition.ExecuteReader();
               while (objReader.Read())
               {
                   VoucherDetailEL obj = new VoucherDetailEL();
                   obj.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                   obj.Date = Convert.ToDateTime(objReader["VDate"]);
                   //obj.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                   obj.ProductCode = Validation.GetSafeString(objReader["ItemCode"]);
                   obj.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                   obj.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                   obj.GatePassType = Validation.GetSafeString(objReader["WorkType"]);
                   obj.Units = Validation.GetSafeDecimal(objReader["YardQty"]);
                   obj.UnitPrice = Validation.GetSafeDecimal(objReader["UnitPrice"]);
                   obj.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);
                   list.Add(obj);
               }
           }
           return list;
       }
       public List<VoucherDetailEL> GetRubberizingStockByPartySummaryAndDate(Guid IdCompany, string AccountNo, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
       {
           List<VoucherDetailEL> list = new List<VoucherDetailEL>();
           using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetRubberizingPartySummaryAndDate]", objConn))
           {
               cmdRequisition.CommandType = CommandType.StoredProcedure;
               cmdRequisition.CommandTimeout = 0;
               cmdRequisition.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
               cmdRequisition.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
               cmdRequisition.Parameters.Add(new SqlParameter("@StartDate", DbType.DateTime)).Value = StartDate;
               cmdRequisition.Parameters.Add(new SqlParameter("@EndDate", DbType.DateTime)).Value = EndDate;
               objReader = cmdRequisition.ExecuteReader();
               while (objReader.Read())
               {
                   VoucherDetailEL obj = new VoucherDetailEL();
                   obj.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                   obj.StockOut = Validation.GetSafeDecimal(objReader["StockOut"]);
                   obj.StockIn = Validation.GetSafeLong(objReader["StockIn"]);
                   obj.RemainingStock = Validation.GetSafeLong(objReader["Remaining"]);
                   list.Add(obj);               
               }
           }
           return list;
       }
       public List<VoucherDetailEL> GetRubberizingStockByItem(Guid IdCompany, Guid IdItem, SqlConnection objConn)
       {
           List<VoucherDetailEL> list = new List<VoucherDetailEL>();
           using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetRubberizingStockByItem]", objConn))
           {
               cmdRequisition.CommandType = CommandType.StoredProcedure;
               cmdRequisition.CommandTimeout = 0;
               cmdRequisition.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
               cmdRequisition.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = IdItem;
               objReader = cmdRequisition.ExecuteReader();
               while (objReader.Read())
               {
                   VoucherDetailEL obj = new VoucherDetailEL();
                   obj.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                   obj.Date = Convert.ToDateTime(objReader["VDate"]);
                   //obj.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                   obj.ProductCode = Validation.GetSafeString(objReader["ItemCode"]);
                   obj.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                   obj.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                   obj.GatePassType = Validation.GetSafeString(objReader["WorkType"]);
                   obj.Units = Validation.GetSafeLong(objReader["YardQty"]);
                   obj.UnitPrice = Validation.GetSafeLong(objReader["UnitPrice"]);
                   obj.TotalAmount = Validation.GetSafeLong(objReader["TotalAmount"]);
                   list.Add(obj);
               }
           }
           return list;
       }
       public List<VoucherDetailEL> GetRubberizingStockByItemAndDate(Guid IdCompany, Guid IdItem, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
       {
           List<VoucherDetailEL> list = new List<VoucherDetailEL>();
           using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetRubberizingStockByItemAndDate]", objConn))
           {
               cmdRequisition.CommandType = CommandType.StoredProcedure;
               cmdRequisition.CommandTimeout = 0;
               cmdRequisition.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
               cmdRequisition.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = IdItem;
               cmdRequisition.Parameters.Add(new SqlParameter("@StartDate", DbType.DateTime)).Value = StartDate;
               cmdRequisition.Parameters.Add(new SqlParameter("@EndDate", DbType.DateTime)).Value = EndDate;
               objReader = cmdRequisition.ExecuteReader();
               while (objReader.Read())
               {
                   VoucherDetailEL obj = new VoucherDetailEL();
                   obj.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                   obj.Date = Convert.ToDateTime(objReader["VDate"]);
                   //obj.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                   obj.ProductCode = Validation.GetSafeString(objReader["ItemCode"]);
                   obj.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                   obj.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                   obj.GatePassType = Validation.GetSafeString(objReader["WorkType"]);
                   obj.Units = Validation.GetSafeDecimal(objReader["YardQty"]);
                   obj.UnitPrice = Validation.GetSafeDecimal(objReader["UnitPrice"]);
                   obj.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);
                   list.Add(obj);
               }
           }
           return list;
       }
       public List<VoucherDetailEL> GetRubberizingItemSummary(Guid IdCompany, Guid IdItem, SqlConnection objConn)
       {
           List<VoucherDetailEL> list = new List<VoucherDetailEL>();
           using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetRubberizingItemSummary]", objConn))
           {
               cmdRequisition.CommandType = CommandType.StoredProcedure;
               cmdRequisition.CommandTimeout = 0;
               cmdRequisition.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
               cmdRequisition.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = IdItem;
               objReader = cmdRequisition.ExecuteReader();
               while (objReader.Read())
               {
                   VoucherDetailEL obj = new VoucherDetailEL();
                   obj.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                   obj.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                   obj.StockOut = Validation.GetSafeDecimal(objReader["StockOut"]);
                   obj.StockIn = Validation.GetSafeDecimal(objReader["StockIn"]);
                   obj.RemainingStock = Validation.GetSafeDecimal(objReader["Remaining"]);
                   list.Add(obj);
               }
           }
           return list;
       }
       public List<VoucherDetailEL> GetRubberizingItemSummaryAndDate(Guid IdCompany, Guid IdItem, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
       {
           List<VoucherDetailEL> list = new List<VoucherDetailEL>();
           using (SqlCommand cmdRequisition = new SqlCommand("[Transactions].[Proc_GetRubberizingItemSummaryAndDate]", objConn))
           {
               cmdRequisition.CommandType = CommandType.StoredProcedure;
               cmdRequisition.CommandTimeout = 0;
               cmdRequisition.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
               cmdRequisition.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = IdItem;
               cmdRequisition.Parameters.Add(new SqlParameter("@StartDate", DbType.DateTime)).Value = StartDate;
               cmdRequisition.Parameters.Add(new SqlParameter("@EndDate", DbType.DateTime)).Value = EndDate;
               objReader = cmdRequisition.ExecuteReader();
               while (objReader.Read())
               {
                   VoucherDetailEL obj = new VoucherDetailEL();
                   obj.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                   obj.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                   obj.StockOut = Validation.GetSafeDecimal(objReader["StockOut"]);
                   obj.StockIn = Validation.GetSafeDecimal(objReader["StockIn"]);
                   obj.RemainingStock = Validation.GetSafeDecimal(objReader["Remaining"]);
                   list.Add(obj);
               }
           }
           return list;
       }
    }
}
