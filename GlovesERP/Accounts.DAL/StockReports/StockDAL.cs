using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Accounts.EL;
using System.Data.SqlClient;
using System.Data;
using Accounts.Common;

namespace Accounts.DAL
{
    public class StockDAL
    {
        IDataReader objReader;
        ItemsDAL dal;
        public StockDAL()
        {
            dal = new ItemsDAL();
        }
        public bool InsertUpdateStock(List<StockReceiptEL> oelStockReceiptCollectioin, SqlConnection objConn)
        {
            try
            {
                using (SqlTransaction oTran = objConn.BeginTransaction())
                {
                    SqlCommand cmdStockReceipt = new SqlCommand("sp_InsertStockReceipt", objConn);
                    cmdStockReceipt.CommandType = CommandType.StoredProcedure;
                    cmdStockReceipt.Transaction = oTran;
                    for (int j = 0; j < oelStockReceiptCollectioin.Count; j++)
                    {
                        //cmdStockReceipt.Parameters.Add(new SqlParameter("@IdStockReceipt", DbType.Guid)).Value = oelStockReceiptCollectioin[j].IdStockReceipt;
                        cmdStockReceipt.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelStockReceiptCollectioin[j].IdUser;
                        //cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelOpeningStockCollection[j].VoucherNo;
                        cmdStockReceipt.Parameters.Add(new SqlParameter("@ItemNo", DbType.String)).Value = oelStockReceiptCollectioin[j].ItemNo;
                        cmdStockReceipt.Parameters.Add(new SqlParameter("@units", DbType.Int64)).Value = oelStockReceiptCollectioin[j].Units;
                        cmdStockReceipt.Parameters.Add(new SqlParameter("@ActionType", DbType.Int64)).Value = oelStockReceiptCollectioin[j].ActionType;
                        //cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@RemainingUnits", DbType.Int64)).Value = oelOpeningStockCollection[j].RemainingUnits;
                        //cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelOpeningStockCollection[j].Amount;
                        //cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@stockdate", DbType.DateTime)).Value = oelOpeningStockCollection[j].StockDate;
                        cmdStockReceipt.ExecuteNonQuery();
                        cmdStockReceipt.Parameters.Clear();
                    }
                    oTran.Commit();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public bool UpdateStock(List<StockReceiptEL> oelStockReceiptCollectioin, SqlTransaction oTran, SqlConnection objConn)
        {
            try
            {
                SqlCommand cmdStockReceipt = new SqlCommand("sp_InsertStockReceipt", objConn);
                cmdStockReceipt.CommandType = CommandType.StoredProcedure;
                cmdStockReceipt.Transaction = oTran;
                for (int j = 0; j < oelStockReceiptCollectioin.Count; j++)
                {
                    //cmdStockReceipt.Parameters.Add(new SqlParameter("@IdStockReceipt", DbType.Guid)).Value = oelStockReceiptCollectioin[j].IdStockReceipt;
                    cmdStockReceipt.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelStockReceiptCollectioin[j].IdUser;
                    //cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelOpeningStockCollection[j].VoucherNo;
                    cmdStockReceipt.Parameters.Add(new SqlParameter("@ItemNo", DbType.String)).Value = oelStockReceiptCollectioin[j].ItemNo;
                    cmdStockReceipt.Parameters.Add(new SqlParameter("@units", DbType.Int64)).Value = oelStockReceiptCollectioin[j].Units;
                    cmdStockReceipt.Parameters.Add(new SqlParameter("@ActionType", DbType.Int64)).Value = oelStockReceiptCollectioin[j].ActionType;
                    //cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@RemainingUnits", DbType.Int64)).Value = oelOpeningStockCollection[j].RemainingUnits;
                    //cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelOpeningStockCollection[j].Amount;
                    //cmdStockReceiptDetail.Parameters.Add(new SqlParameter("@stockdate", DbType.DateTime)).Value = oelOpeningStockCollection[j].StockDate;
                    cmdStockReceipt.ExecuteNonQuery();
                    cmdStockReceipt.Parameters.Clear();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
        public List<StockReceiptEL> GetTotalStockReport(Guid IdCategory, Guid IdCompany, SqlConnection objConn)
        {
            List<StockReceiptEL> list = new List<StockReceiptEL>();
            SqlCommand cmdStock = new SqlCommand("[Reports].[Proc_GetTotalStock]", objConn);
            cmdStock.CommandType = CommandType.StoredProcedure;
            cmdStock.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
            cmdStock.Parameters.Add("@IdCategory", SqlDbType.UniqueIdentifier).Value = IdCategory;
            objReader = cmdStock.ExecuteReader();
            while (objReader.Read())
            {
                StockReceiptEL oelStockReceipt = new StockReceiptEL();
                oelStockReceipt.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                oelStockReceipt.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelStockReceipt.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);                
                oelStockReceipt.Opening = Validation.GetSafeLong(objReader["OpeningUnits"]);
                oelStockReceipt.Purchases = Validation.GetSafeLong(objReader["PurchaseIn"]);
                oelStockReceipt.PurchasesReturn = Validation.GetSafeLong(objReader["PurchaseOut"]);
                //oelStockReceipt.Returns = Validation.GetSafeLong(objReader["ReturnedUnits"]);
                //oelStockReceipt.Samples = Validation.GetSafeLong(objReader["SampleUnits"]);
                //oelStockReceipt.SamplesReturn = Validation.GetSafeLong(objReader["SampleReturnedUnits"]);
                oelStockReceipt.Sales = Validation.GetSafeDecimal(objReader["SoldOut"]);
                oelStockReceipt.SoldIn = Validation.GetSafeDecimal(objReader["SoldIn"]);
                oelStockReceipt.RubberingIn = Validation.GetSafeDecimal(objReader["RubberingIn"]);
                oelStockReceipt.RubberingOut = Validation.GetSafeDecimal(objReader["RubberingOut"]);
                oelStockReceipt.RubberingSideCutting = Validation.GetSafeDecimal(objReader["RubberingSideCutting"]);
                oelStockReceipt.ProductionIn = Validation.GetSafeDecimal(objReader["ProductionIn"]);
                oelStockReceipt.ProductionOut = Validation.GetSafeDecimal(objReader["ProductionOut"]);
                oelStockReceipt.TanneryUsed = Validation.GetSafeDecimal(objReader["ChemOut"]);
                oelStockReceipt.Closing = Validation.GetSafeDecimal(objReader["Closing"]);
                oelStockReceipt.Amount = Validation.GetSafeDecimal(objReader["Amount"]); //Validation.GetSafeDecimal(objReader["Amount"]);
                //if (oelStockReceipt.Opening + oelStockReceipt.SoldIn + oelStockReceipt.RubberingIn + oelStockReceipt.ProductionIn + oelStockReceipt.Purchases == 0)
                //{
                //    oelStockReceipt.Amount = 0;
                //}
                //else
                //{
                //    if (oelStockReceipt.Closing == 0)
                //    {
                //        oelStockReceipt.Amount = 0;
                //    }
                //    else
                //    oelStockReceipt.Amount = ((Validation.GetSafeDecimal(objReader["OpeningAmount"]) + Validation.GetSafeDecimal(objReader["PurchaseAmount"]) +
                //                             Validation.GetSafeDecimal(objReader["RubberingAmount"]) + Validation.GetSafeDecimal(objReader["ProductionAmount"]))
                //                             / (oelStockReceipt.Closing)) * (oelStockReceipt.Closing); 
                //}
                

                list.Add(oelStockReceipt);
            }

            return list;
        }
        public List<StockReceiptEL> GetTanneryTotalStockReport(Guid IdCategory, Guid IdCompany, SqlConnection objConn)
        {
            List<StockReceiptEL> list = new List<StockReceiptEL>();
            SqlCommand cmdStock = new SqlCommand("[Reports].[Proc_GetTanneryTotalStock]", objConn);
            cmdStock.CommandType = CommandType.StoredProcedure;
            cmdStock.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
            cmdStock.Parameters.Add("@IdCategory", SqlDbType.UniqueIdentifier).Value = IdCategory;
            objReader = cmdStock.ExecuteReader();
            while (objReader.Read())
            {
                StockReceiptEL oelStockReceipt = new StockReceiptEL();
                oelStockReceipt.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                oelStockReceipt.AccountName = Validation.GetSafeString(objReader["ItemName"]);
                oelStockReceipt.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                oelStockReceipt.Opening = Validation.GetSafeLong(objReader["OpeningUnits"]);
                oelStockReceipt.Purchases = Validation.GetSafeLong(objReader["PurchaseIn"]);
                oelStockReceipt.PurchasesReturn = Validation.GetSafeLong(objReader["PurchaseOut"]);
                //oelStockReceipt.Returns = Validation.GetSafeLong(objReader["ReturnedUnits"]);
                //oelStockReceipt.Samples = Validation.GetSafeLong(objReader["SampleUnits"]);
                //oelStockReceipt.SamplesReturn = Validation.GetSafeLong(objReader["SampleReturnedUnits"]);
                oelStockReceipt.Sales = Validation.GetSafeDecimal(objReader["SoldOut"]);
                oelStockReceipt.SoldIn = Validation.GetSafeDecimal(objReader["SoldIn"]);
                oelStockReceipt.RubberingIn = Validation.GetSafeDecimal(objReader["RubberingIn"]);
                oelStockReceipt.RubberingOut = Validation.GetSafeDecimal(objReader["RubberingOut"]);
                oelStockReceipt.ProductionIn = Validation.GetSafeDecimal(objReader["ProductionIn"]);
                oelStockReceipt.ProductionOut = Validation.GetSafeDecimal(objReader["ProductionOut"]);
                oelStockReceipt.TanneryUsed = Validation.GetSafeDecimal(objReader["ChemOut"]);
                if(objReader["Cutting"] != null)
                {
                    oelStockReceipt.CuttingQuantity = Validation.GetSafeDecimal(objReader["Cutting"]);
                }
                oelStockReceipt.Closing = Validation.GetSafeDecimal(objReader["Closing"]);
                if (oelStockReceipt.Closing + oelStockReceipt.Opening + oelStockReceipt.SoldIn + oelStockReceipt.RubberingIn + oelStockReceipt.ProductionIn + oelStockReceipt.Purchases == 0)
                {
                    oelStockReceipt.Amount = 0;
                }
                else
                {
                    if (oelStockReceipt.Closing == 0)
                    {
                        oelStockReceipt.Amount = 0;
                    }
                    else
                        oelStockReceipt.Amount = (((Validation.GetSafeDecimal(objReader["OpeningAmount"]) + Validation.GetSafeDecimal(objReader["PurchaseAmount"])) - (Validation.GetSafeDecimal(objReader["ChemoutValue"])) +
                                             Validation.GetSafeDecimal(objReader["RubberingAmount"]) + Validation.GetSafeDecimal(objReader["ProductionAmount"]))
                                             / (oelStockReceipt.Closing)); //* (oelStockReceipt.Closing);
                }


                list.Add(oelStockReceipt);
            }

            return list;
        }
        public List<StockReceiptEL> GetTradingWiseTotalStock(Guid IdTrading, Guid IdCompany, SqlConnection objConn)
        {
            List<StockReceiptEL> list = new List<StockReceiptEL>();
            SqlCommand cmdStock = new SqlCommand("[Reports].[Proc_GetTradingWiseTotalStock]", objConn);
            cmdStock.CommandType = CommandType.StoredProcedure;
            cmdStock.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
            cmdStock.Parameters.Add("@IdTrading", SqlDbType.UniqueIdentifier).Value = IdTrading;
            objReader = cmdStock.ExecuteReader();
            while (objReader.Read())
            {
                StockReceiptEL oelStockReceipt = new StockReceiptEL();
                oelStockReceipt.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                oelStockReceipt.AccountName = Validation.GetSafeString(objReader["ItemName"]);
                oelStockReceipt.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                //oelStockReceipt.BatchNo = Validation.GetSafeString(objReader["BatchNo"]);
                oelStockReceipt.Opening = Validation.GetSafeLong(objReader["OpeningUnits"]);
                oelStockReceipt.Purchases = Validation.GetSafeLong(objReader["PurchaseUnits"]);
                oelStockReceipt.Returns = Validation.GetSafeLong(objReader["ReturnedUnits"]);
                oelStockReceipt.Samples = Validation.GetSafeLong(objReader["SampleUnits"]);
                oelStockReceipt.SamplesReturn = Validation.GetSafeLong(objReader["SampleReturnedUnits"]);
                oelStockReceipt.Sales = Validation.GetSafeLong(objReader["SoldUnits"]);
                //oelStockReceipt.JvIn = Validation.GetSafeLong(objReader["JvIn"]);
                //oelStockReceipt.JvOut = Validation.GetSafeLong(objReader["JvOut"]);
                oelStockReceipt.Closing = Validation.GetSafeLong(objReader["Closing"]);
                oelStockReceipt.Amount = Validation.GetSafeDecimal(objReader["RemainingBalance"]);

                list.Add(oelStockReceipt);
            }

            return list;
        }
        public List<StockReceiptEL> GetDateWiseTotalStockReport(Guid IdCategory, Guid IdCompany, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<StockReceiptEL> list = new List<StockReceiptEL>();
            SqlCommand cmdStock = new SqlCommand("[Reports].[Proc_GetDateWiseTotalStock]", objConn);
            cmdStock.CommandType = CommandType.StoredProcedure;
            
            cmdStock.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
            //cmdStock.Parameters.Add("@TradingCode", SqlDbType.VarChar).Value = TradingCo;
            cmdStock.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
            cmdStock.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
            cmdStock.Parameters.Add("@IdCategory", SqlDbType.UniqueIdentifier).Value = IdCategory;
            
            objReader = cmdStock.ExecuteReader();
            while (objReader.Read())
            {
                StockReceiptEL oelStockReceipt = new StockReceiptEL();
                oelStockReceipt.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                oelStockReceipt.AccountName = Validation.GetSafeString(objReader["ItemName"]);
                oelStockReceipt.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                oelStockReceipt.BatchNo = Validation.GetSafeString(objReader["BatchNo"]);
                oelStockReceipt.Opening = Validation.GetSafeLong(objReader["OpeningUnits"]);
                oelStockReceipt.Purchases = Validation.GetSafeLong(objReader["PurchaseUnits"]);
                oelStockReceipt.Returns = Validation.GetSafeLong(objReader["ReturnedUnits"]);
                oelStockReceipt.Sales = Validation.GetSafeLong(objReader["SoldUnits"]);
                //oelStockReceipt.JvIn = Validation.GetSafeLong(objReader["JvIn"]);
                //oelStockReceipt.JvOut = Validation.GetSafeLong(objReader["JvOut"]);
                oelStockReceipt.Closing = Validation.GetSafeLong(objReader["Closing"]);
                oelStockReceipt.Amount = Validation.GetSafeDecimal(objReader["OpeningBalance"]) -  Validation.GetSafeDecimal(objReader["RemainingBalance"]);

                list.Add(oelStockReceipt);

                //list.Add(oelStockReceipt);
            }

            return list;
        }
        public List<StockReceiptEL> GetDateAndTradingWiseTotalStockReport(Guid IdTrading, Guid IdCompany, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<StockReceiptEL> list = new List<StockReceiptEL>();
            SqlCommand cmdStock = new SqlCommand("[Reports].[Proc_GetDateAndTradingWiseTotalStock]", objConn);
            cmdStock.CommandType = CommandType.StoredProcedure;

            cmdStock.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
            //cmdStock.Parameters.Add("@TradingCode", SqlDbType.VarChar).Value = TradingCo;
            cmdStock.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
            cmdStock.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
            cmdStock.Parameters.Add("@IdTrading", SqlDbType.UniqueIdentifier).Value = IdTrading;

            objReader = cmdStock.ExecuteReader();
            while (objReader.Read())
            {
                StockReceiptEL oelStockReceipt = new StockReceiptEL();
                oelStockReceipt.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                oelStockReceipt.AccountName = Validation.GetSafeString(objReader["ItemName"]);
                oelStockReceipt.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                oelStockReceipt.BatchNo = Validation.GetSafeString(objReader["BatchNo"]);
                oelStockReceipt.Opening = Validation.GetSafeLong(objReader["OpeningUnits"]);
                oelStockReceipt.Purchases = Validation.GetSafeLong(objReader["PurchaseUnits"]);
                oelStockReceipt.Returns = Validation.GetSafeLong(objReader["ReturnedUnits"]);
                oelStockReceipt.Sales = Validation.GetSafeLong(objReader["SoldUnits"]);
                //oelStockReceipt.JvIn = Validation.GetSafeLong(objReader["JvIn"]);
                //oelStockReceipt.JvOut = Validation.GetSafeLong(objReader["JvOut"]);
                oelStockReceipt.Closing = Validation.GetSafeLong(objReader["Closing"]);
                oelStockReceipt.Amount = Validation.GetSafeDecimal(objReader["OpeningBalance"]) - Validation.GetSafeDecimal(objReader["RemainingBalance"]);

                list.Add(oelStockReceipt);

                //list.Add(oelStockReceipt);
            }

            return list;
        }


        public List<StockReceiptEL> GetRawMaterialTotalStock(Guid IdCategory, Guid IdCompany, SqlConnection objConn)
        {
            List<StockReceiptEL> list = new List<StockReceiptEL>();
            SqlCommand cmdStock = new SqlCommand("[Reports].[Proc_GetRawMaterialTotalStock]", objConn);
            cmdStock.CommandType = CommandType.StoredProcedure;
            cmdStock.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
            cmdStock.Parameters.Add("@IdCategory", SqlDbType.UniqueIdentifier).Value = IdCategory;
            objReader = cmdStock.ExecuteReader();
            while (objReader.Read())
            {
                StockReceiptEL oelStockReceipt = new StockReceiptEL();
                oelStockReceipt.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                oelStockReceipt.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelStockReceipt.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                oelStockReceipt.Opening = Validation.GetSafeDecimal(objReader["OPU"]);
                oelStockReceipt.Purchases = Validation.GetSafeDecimal(objReader["PU"]);
                oelStockReceipt.PurchasesReturn = Validation.GetSafeDecimal(objReader["PRU"]);
                //oelStockReceipt.Returns = Validation.GetSafeLong(objReader["ReturnedUnits"]);
                //oelStockReceipt.Samples = Validation.GetSafeLong(objReader["SampleUnits"]);
                //oelStockReceipt.SamplesReturn = Validation.GetSafeLong(objReader["SampleReturnedUnits"]);
                oelStockReceipt.Sales = Validation.GetSafeDecimal(objReader["SU"]);
                oelStockReceipt.SalesReturn = Validation.GetSafeDecimal(objReader["SRU"]);
                oelStockReceipt.RubberingIn = Validation.GetSafeDecimal(objReader["SideINRubbering"]);
                oelStockReceipt.RubberingOut = Validation.GetSafeDecimal(objReader["ROut"]);
                //oelStockReceipt.RubberingSideCutting = Validation.GetSafeDecimal(objReader["RubberingSideCutting"]);
                oelStockReceipt.ProductionIn = Validation.GetSafeDecimal(objReader["PIN"]);
                oelStockReceipt.ProductionOut = Validation.GetSafeDecimal(objReader["POut"]);
                oelStockReceipt.DyingUnits = Validation.GetSafeDecimal(objReader["DyingOut"]);
                //oelStockReceipt.TanneryUsed = Validation.GetSafeDecimal(objReader["ChemOut"]);
                oelStockReceipt.Closing = Validation.GetSafeDecimal(objReader["ClosingStock"]);
                oelStockReceipt.AVR = Validation.GetSafeDecimal(objReader["AVR"]);
                oelStockReceipt.NVR = Validation.GetSafeDecimal(objReader["NVR"]);


                list.Add(oelStockReceipt);
            }

            return list;
        }
        public List<StockReceiptEL> GetDateWiseRawMaterialTotalStock(Guid IdCategory, Guid IdCompany, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<StockReceiptEL> list = new List<StockReceiptEL>();
            SqlCommand cmdStock = new SqlCommand("[Reports].[Proc_GetDateWiseRawMaterialTotalStock]", objConn);
            cmdStock.CommandType = CommandType.StoredProcedure;
            cmdStock.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
            cmdStock.Parameters.Add("@IdCategory", SqlDbType.UniqueIdentifier).Value = IdCategory;
            cmdStock.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
            cmdStock.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
            objReader = cmdStock.ExecuteReader();
            while (objReader.Read())
            {
                StockReceiptEL oelStockReceipt = new StockReceiptEL();
                oelStockReceipt.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                oelStockReceipt.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelStockReceipt.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                oelStockReceipt.Opening = Validation.GetSafeDecimal(objReader["OPU"]);
                oelStockReceipt.Purchases = Validation.GetSafeDecimal(objReader["PU"]);
                oelStockReceipt.PurchasesReturn = Validation.GetSafeDecimal(objReader["PRU"]);
                //oelStockReceipt.Returns = Validation.GetSafeLong(objReader["ReturnedUnits"]);
                //oelStockReceipt.Samples = Validation.GetSafeLong(objReader["SampleUnits"]);
                //oelStockReceipt.SamplesReturn = Validation.GetSafeLong(objReader["SampleReturnedUnits"]);
                oelStockReceipt.Sales = Validation.GetSafeDecimal(objReader["SU"]);
                oelStockReceipt.SalesReturn = Validation.GetSafeDecimal(objReader["SRU"]);
                //oelStockReceipt.RubberingIn = Validation.GetSafeDecimal(objReader["RubberingIn"]);
                oelStockReceipt.RubberingOut = Validation.GetSafeDecimal(objReader["ROut"]);
                //oelStockReceipt.RubberingSideCutting = Validation.GetSafeDecimal(objReader["RubberingSideCutting"]);
                oelStockReceipt.ProductionIn = Validation.GetSafeDecimal(objReader["PIN"]);
                oelStockReceipt.ProductionOut = Validation.GetSafeDecimal(objReader["POut"]);
                oelStockReceipt.DyingUnits = Validation.GetSafeDecimal(objReader["DyingOut"]);
                //oelStockReceipt.TanneryUsed = Validation.GetSafeDecimal(objReader["ChemOut"]);
                oelStockReceipt.Closing = Validation.GetSafeDecimal(objReader["ClosingStock"]);
                oelStockReceipt.AVR = Validation.GetSafeDecimal(objReader["AVR"]);
                oelStockReceipt.NVR = Validation.GetSafeDecimal(objReader["NVR"]);


                list.Add(oelStockReceipt);
            }

            return list;
        }
        public List<StockReceiptEL> GetGlovesSemiFinishMaterialTotalStock(Guid IdCategory, Guid IdCompany, SqlConnection objConn)
        {
            List<StockReceiptEL> list = new List<StockReceiptEL>();
            SqlCommand cmdStock = new SqlCommand("[Reports].[Proc_GetGlovesSemiFinishTotalStock]", objConn);
            cmdStock.CommandType = CommandType.StoredProcedure;
            cmdStock.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
            cmdStock.Parameters.Add("@IdCategory", SqlDbType.UniqueIdentifier).Value = IdCategory;
            objReader = cmdStock.ExecuteReader();
            while (objReader.Read())
            {
                StockReceiptEL oelStockReceipt = new StockReceiptEL();
                oelStockReceipt.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                oelStockReceipt.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelStockReceipt.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                oelStockReceipt.Opening = Validation.GetSafeDecimal(objReader["OPU"]);
                oelStockReceipt.Purchases = Validation.GetSafeDecimal(objReader["PU"]);
                oelStockReceipt.PurchasesReturn = Validation.GetSafeDecimal(objReader["PRU"]);
                //oelStockReceipt.Returns = Validation.GetSafeLong(objReader["ReturnedUnits"]);
                //oelStockReceipt.Samples = Validation.GetSafeLong(objReader["SampleUnits"]);
                //oelStockReceipt.SamplesReturn = Validation.GetSafeLong(objReader["SampleReturnedUnits"]);
                oelStockReceipt.Sales = Validation.GetSafeDecimal(objReader["SU"]);
                oelStockReceipt.SalesReturn = Validation.GetSafeDecimal(objReader["SRU"]);
                //oelStockReceipt.RubberingIn = Validation.GetSafeDecimal(objReader["RubberingIn"]);
                oelStockReceipt.RubberingIn = Validation.GetSafeDecimal(objReader["RIn"]);
                //oelStockReceipt.RubberingSideCutting = Validation.GetSafeDecimal(objReader["RubberingSideCutting"]);
                oelStockReceipt.ProductionIn = Validation.GetSafeDecimal(objReader["PIN"]);
                oelStockReceipt.ProductionOut = Validation.GetSafeDecimal(objReader["POut"]);
                oelStockReceipt.RubberingSideCutting = Validation.GetSafeDecimal(objReader["SideStock"]);
                //oelStockReceipt.TanneryUsed = Validation.GetSafeDecimal(objReader["ChemOut"]);
                oelStockReceipt.Closing = Validation.GetSafeDecimal(objReader["ClosingStock"]);
                oelStockReceipt.AVR = Validation.GetSafeDecimal(objReader["AVR"]);


                list.Add(oelStockReceipt);
            }

            return list;
        }
        public List<StockReceiptEL> GetDateWiseGlovesSemiFinishMaterialTotalStock(Guid IdCategory, Guid IdCompany, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<StockReceiptEL> list = new List<StockReceiptEL>();
            SqlCommand cmdStock = new SqlCommand("[Reports].[Proc_GetDateWiseGlovesSemiFinishTotalStock]", objConn);
            cmdStock.CommandType = CommandType.StoredProcedure;
            cmdStock.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
            cmdStock.Parameters.Add("@IdCategory", SqlDbType.UniqueIdentifier).Value = IdCategory;
            cmdStock.Parameters.Add("@StartDate", SqlDbType.UniqueIdentifier).Value = StartDate;
            cmdStock.Parameters.Add("@EndDate", SqlDbType.UniqueIdentifier).Value = EndDate;
            objReader = cmdStock.ExecuteReader();
            while (objReader.Read())
            {
                StockReceiptEL oelStockReceipt = new StockReceiptEL();
                oelStockReceipt.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                oelStockReceipt.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelStockReceipt.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                oelStockReceipt.Opening = Validation.GetSafeDecimal(objReader["OPU"]);
                oelStockReceipt.Purchases = Validation.GetSafeDecimal(objReader["PU"]);
                oelStockReceipt.PurchasesReturn = Validation.GetSafeDecimal(objReader["PRU"]);
                //oelStockReceipt.Returns = Validation.GetSafeLong(objReader["ReturnedUnits"]);
                //oelStockReceipt.Samples = Validation.GetSafeLong(objReader["SampleUnits"]);
                //oelStockReceipt.SamplesReturn = Validation.GetSafeLong(objReader["SampleReturnedUnits"]);
                oelStockReceipt.Sales = Validation.GetSafeDecimal(objReader["SU"]);
                oelStockReceipt.SalesReturn = Validation.GetSafeDecimal(objReader["SRU"]);
                //oelStockReceipt.RubberingIn = Validation.GetSafeDecimal(objReader["RubberingIn"]);
                oelStockReceipt.RubberingIn = Validation.GetSafeDecimal(objReader["RIn"]);
                //oelStockReceipt.RubberingSideCutting = Validation.GetSafeDecimal(objReader["RubberingSideCutting"]);
                oelStockReceipt.ProductionIn = Validation.GetSafeDecimal(objReader["PIN"]);
                oelStockReceipt.ProductionOut = Validation.GetSafeDecimal(objReader["POut"]);
                oelStockReceipt.RubberingSideCutting = Validation.GetSafeDecimal(objReader["SideStock"]);
                //oelStockReceipt.TanneryUsed = Validation.GetSafeDecimal(objReader["ChemOut"]);
                oelStockReceipt.Closing = Validation.GetSafeDecimal(objReader["ClosingStock"]);
                oelStockReceipt.AVR = Validation.GetSafeDecimal(objReader["AVR"]);

                list.Add(oelStockReceipt);
            }

            return list;
        }

    }
}
