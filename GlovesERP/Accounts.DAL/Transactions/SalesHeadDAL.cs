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
    public class SalesHeadDAL
    {
        #region Variables
        IDataReader objReader;
        SaleDetailDAL dal;
        TransactionsDAL Tdal;
        StockDAL stockdal;
        public SalesHeadDAL()
        {
            dal = new SaleDetailDAL();
            Tdal = new TransactionsDAL();
            stockdal = new StockDAL();
        }
        #endregion
        #region Sales
        public Int64 GetMaxSaleInvoiceNumberBySaleType(int InvoiceType, Guid IdCompany, SqlConnection objConn)
        {
            using (SqlCommand cmdVouchers = new SqlCommand("[Transactions].[Proc_GetMaxSaleInvoiceNumber]", objConn))
            {
                cmdVouchers.CommandType = CommandType.StoredProcedure;
                cmdVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdVouchers.Parameters.Add("@InvoiceType", SqlDbType.NVarChar).Value = InvoiceType;
                return Validation.GetSafeLong(cmdVouchers.ExecuteScalar());
            }
        }
        public bool InsertSales(VouchersEL oelVoucher, List<VoucherDetailEL> oelSaleCollection, List<VoucherDetailEL> oelSalesTransactionsCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
        {
            lock (this)
            {
                SqlTransaction objTran = objConn.BeginTransaction();
                try
                {
                    //// Insert Sale Voucher
                    SqlCommand cmdSales = new SqlCommand("[Transactions].[Proc_CreateSalesHead]", objConn);

                    cmdSales.CommandType = CommandType.StoredProcedure;
                    cmdSales.Transaction = objTran;
                    cmdSales.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelVoucher.IdVoucher;
                    cmdSales.Parameters.Add(new SqlParameter("@IdCompany", DbType.Int64)).Value = oelVoucher.IdCompany;
                    cmdSales.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = oelVoucher.IdOrder;
                    cmdSales.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdSales.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdSales.Parameters.Add(new SqlParameter("@SystemInvoiceNo", DbType.String)).Value = oelVoucher.SystemInvoiceNo;
                    cmdSales.Parameters.Add(new SqlParameter("@SampleNo", DbType.Int64)).Value = oelVoucher.SampleNo;
                    cmdSales.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelVoucher.BookNo;
                    cmdSales.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.VDate;
                    cmdSales.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdSales.Parameters.Add(new SqlParameter("@LinkAccountNo", DbType.String)).Value = oelVoucher.LinkAccountNo;
                    cmdSales.Parameters.Add(new SqlParameter("@TransactionAccountNo", DbType.String)).Value = oelVoucher.TransactionAccountNo;
                    cmdSales.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelVoucher.SubAccountNo;
                    cmdSales.Parameters.Add(new SqlParameter("@VDiscription", DbType.String)).Value = oelVoucher.VDiscription;
                    cmdSales.Parameters.Add(new SqlParameter("@MemoSaleNo", DbType.Int64)).Value = oelVoucher.MemoSaleNo;
                    cmdSales.Parameters.Add(new SqlParameter("@OutWardGatePassNo", DbType.String)).Value = oelVoucher.OutWardGatePassNo;
                    cmdSales.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = oelVoucher.VehicalNo;
                    cmdSales.Parameters.Add(new SqlParameter("@HeadSeller", DbType.Int32)).Value = oelVoucher.HeadSeller;
                    cmdSales.Parameters.Add(new SqlParameter("@ShortCode", DbType.String)).Value = oelVoucher.ShortCode;
                    cmdSales.Parameters.Add(new SqlParameter("@BillType", DbType.String)).Value = oelVoucher.BillType;
                    cmdSales.Parameters.Add(new SqlParameter("@BillNumber", DbType.String)).Value = oelVoucher.BillNumber;
                    cmdSales.Parameters.Add(new SqlParameter("@BillDate", DbType.DateTime)).Value = oelVoucher.BillDate;
                    cmdSales.Parameters.Add(new SqlParameter("@FormE", DbType.String)).Value = oelVoucher.FormE;
                    cmdSales.Parameters.Add(new SqlParameter("@FormDate", DbType.DateTime)).Value = oelVoucher.FormDate;
                    cmdSales.Parameters.Add(new SqlParameter("@Incoterms", DbType.String)).Value = oelVoucher.IncoTerms;
                    cmdSales.Parameters.Add(new SqlParameter("@OrderDestination", DbType.String)).Value = oelVoucher.OrderDestination;
                    cmdSales.Parameters.Add(new SqlParameter("@DischargePort", DbType.String)).Value = oelVoucher.DischargePort;
                    cmdSales.Parameters.Add(new SqlParameter("@WearType", DbType.Int32)).Value = oelVoucher.WearType;
                    cmdSales.Parameters.Add(new SqlParameter("@TotalCartons", DbType.Int64)).Value = oelVoucher.TotalCartons;
                    cmdSales.Parameters.Add(new SqlParameter("@ForeignAmount", DbType.Decimal)).Value = oelVoucher.ForeignAmount;

                    cmdSales.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                    cmdSales.Parameters.Add(new SqlParameter("@VAT", DbType.Decimal)).Value = oelVoucher.VAT;
                    cmdSales.Parameters.Add(new SqlParameter("@VATAmount", DbType.Decimal)).Value = oelVoucher.VATAmount;
                    cmdSales.Parameters.Add(new SqlParameter("@CreditDays", DbType.Int32)).Value = oelVoucher.Transactiondays;
                    cmdSales.Parameters.Add(new SqlParameter("@IsImport", DbType.Boolean)).Value = oelVoucher.IsImport;
                    cmdSales.Parameters.Add(new SqlParameter("@IsRecieved", DbType.Boolean)).Value = oelVoucher.IsRecieved;
                    //cmdVoucher.Parameters.Add(new SqlParameter("@Discount", DbType.Decimal)).Value = oelVoucher.Discount;
                    //cmdVoucher.Parameters.Add(new SqlParameter("@TotalDiscount", DbType.Decimal)).Value = oelVoucher.TotalDiscount;
                    //cmdVoucher.Parameters.Add(new SqlParameter("@NetSale", DbType.Decimal)).Value = oelVoucher.NetSaleAmount;
                    cmdSales.Parameters.Add(new SqlParameter("@Seller", DbType.Int32)).Value = oelVoucher.Seller;
                    cmdSales.Parameters.Add(new SqlParameter("@SaleType", DbType.Int32)).Value = oelVoucher.SaleType;
                    cmdSales.Parameters.Add(new SqlParameter("@InvoiceType", DbType.Int32)).Value = oelVoucher.InvoiceType;
                    cmdSales.Parameters.Add(new SqlParameter("@IsNetTransaction", DbType.Boolean)).Value = oelVoucher.IsNetTransaction;
                    cmdSales.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdSales.ExecuteNonQuery();

                    //// Insert Detail Sales In Sale Record
                    dal.InsertSaleDetail(oelSaleCollection, objConn, objTran);

                    //// Insert Sales Transactions
                    dal.InsertSalesTransactionsDetail(oelSalesTransactionsCollection, objConn, objTran);

                    /// Insert Transactions
                    Tdal.InsertTransactions(oelTransactionsCollection, objConn, objTran);


                    objTran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }   
            }          
        }
        public bool UpdateSales(VouchersEL oelVoucher, List<VoucherDetailEL> oelSaleCollection, List<VoucherDetailEL> oelSalesTransactionsCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
        {
            lock (this)
            {
                SqlTransaction objTran = objConn.BeginTransaction();
                try
                {
                    SqlCommand cmdSales = new SqlCommand("[Transactions].[Proc_UpdateSalesHead]", objConn);
                    cmdSales.CommandType = CommandType.StoredProcedure;
                    cmdSales.Transaction = objTran;

                    cmdSales.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelVoucher.IdVoucher;
                    cmdSales.Parameters.Add(new SqlParameter("@IdCompany", DbType.Int64)).Value = oelVoucher.IdCompany;
                    cmdSales.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = oelVoucher.IdOrder;
                    cmdSales.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdSales.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdSales.Parameters.Add(new SqlParameter("@SystemInvoiceNo", DbType.String)).Value = oelVoucher.SystemInvoiceNo;
                    cmdSales.Parameters.Add(new SqlParameter("@SampleNo", DbType.Int64)).Value = oelVoucher.SampleNo;
                    cmdSales.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelVoucher.BookNo;
                    cmdSales.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.VDate;
                    cmdSales.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdSales.Parameters.Add(new SqlParameter("@LinkAccountNo", DbType.String)).Value = oelVoucher.LinkAccountNo;
                    cmdSales.Parameters.Add(new SqlParameter("@TransactionAccountNo", DbType.String)).Value = oelVoucher.TransactionAccountNo;
                    cmdSales.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelVoucher.SubAccountNo;
                    cmdSales.Parameters.Add(new SqlParameter("@VDiscription", DbType.String)).Value = oelVoucher.VDiscription;
                    cmdSales.Parameters.Add(new SqlParameter("@MemoSaleNo", DbType.Int64)).Value = oelVoucher.MemoSaleNo;
                    cmdSales.Parameters.Add(new SqlParameter("@OutWardGatePassNo", DbType.String)).Value = oelVoucher.OutWardGatePassNo;
                    cmdSales.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = oelVoucher.VehicalNo;
                    cmdSales.Parameters.Add(new SqlParameter("@HeadSeller", DbType.Int32)).Value = oelVoucher.HeadSeller;
                    cmdSales.Parameters.Add(new SqlParameter("@ShortCode", DbType.String)).Value = oelVoucher.ShortCode;
                    cmdSales.Parameters.Add(new SqlParameter("@BillType", DbType.String)).Value = oelVoucher.BillType;
                    cmdSales.Parameters.Add(new SqlParameter("@BillNumber", DbType.String)).Value = oelVoucher.BillNumber;
                    cmdSales.Parameters.Add(new SqlParameter("@BillDate", DbType.DateTime)).Value = oelVoucher.BillDate;
                    cmdSales.Parameters.Add(new SqlParameter("@FormE", DbType.String)).Value = oelVoucher.FormE;
                    cmdSales.Parameters.Add(new SqlParameter("@FormDate", DbType.DateTime)).Value = oelVoucher.FormDate;
                    cmdSales.Parameters.Add(new SqlParameter("@Incoterms", DbType.String)).Value = oelVoucher.IncoTerms;
                    cmdSales.Parameters.Add(new SqlParameter("@OrderDestination", DbType.String)).Value = oelVoucher.OrderDestination;
                    cmdSales.Parameters.Add(new SqlParameter("@DischargePort", DbType.String)).Value = oelVoucher.DischargePort;
                    cmdSales.Parameters.Add(new SqlParameter("@WearType", DbType.Int32)).Value = oelVoucher.WearType;
                    cmdSales.Parameters.Add(new SqlParameter("@TotalCartons", DbType.Int64)).Value = oelVoucher.TotalCartons;
                    cmdSales.Parameters.Add(new SqlParameter("@ForeignAmount", DbType.Decimal)).Value = oelVoucher.ForeignAmount;

                    cmdSales.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                    cmdSales.Parameters.Add(new SqlParameter("@VAT", DbType.Decimal)).Value = oelVoucher.VAT;
                    cmdSales.Parameters.Add(new SqlParameter("@VATAmount", DbType.Decimal)).Value = oelVoucher.VATAmount;
                    cmdSales.Parameters.Add(new SqlParameter("@CreditDays", DbType.Int32)).Value = oelVoucher.Transactiondays;
                    cmdSales.Parameters.Add(new SqlParameter("@IsImport", DbType.Boolean)).Value = oelVoucher.IsImport;
                    cmdSales.Parameters.Add(new SqlParameter("@IsRecieved", DbType.Boolean)).Value = oelVoucher.IsRecieved;
                    //cmdVoucher.Parameters.Add(new SqlParameter("@Discount", DbType.Decimal)).Value = oelVoucher.Discount;
                    //cmdVoucher.Parameters.Add(new SqlParameter("@TotalDiscount", DbType.Decimal)).Value = oelVoucher.TotalDiscount;
                    //cmdVoucher.Parameters.Add(new SqlParameter("@NetSale", DbType.Decimal)).Value = oelVoucher.NetSaleAmount;
                    cmdSales.Parameters.Add(new SqlParameter("@Seller", DbType.Int32)).Value = oelVoucher.Seller;
                    cmdSales.Parameters.Add(new SqlParameter("@SaleType", DbType.Int32)).Value = oelVoucher.SaleType;
                    cmdSales.Parameters.Add(new SqlParameter("@InvoiceType", DbType.Int32)).Value = oelVoucher.InvoiceType;
                    cmdSales.Parameters.Add(new SqlParameter("@IsNetTransaction", DbType.Boolean)).Value = oelVoucher.IsNetTransaction;
                    cmdSales.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdSales.ExecuteNonQuery();

                    //// Insert And Update Sales In Sale Record
                    dal.UpdateSaleDetail(oelSaleCollection, objConn, objTran);

                    //// Insert And Update Sales Transactions
                    dal.UpdateSalesTransactionsDetail(oelSalesTransactionsCollection, objConn, objTran);
                    ///
                    Tdal.UpdateTransactions(oelTransactionsCollection, objConn, objTran);


                    objTran.Commit();
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }
                finally
                {

                }
                return true;   
            }          
        }
        public List<VoucherDetailEL> GetSalesByVoucher(Int64 VoucherNo, Guid IdCompany, int InvoiceType, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdVouchers = new SqlCommand("[Transactions].[Proc_GetSalesByVoucher]", objConn))
            {
                cmdVouchers.CommandType = CommandType.StoredProcedure;
                cmdVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdVouchers.Parameters.Add("@VoucherNo", SqlDbType.BigInt).Value = VoucherNo;
                cmdVouchers.Parameters.Add("@InvoiceType", SqlDbType.Int).Value = InvoiceType;
                objReader = cmdVouchers.ExecuteReader();
                while (objReader.Read())
                {
                    //// Getting Sales Voucher Header Here...
                    VoucherDetailEL oelVoucher = new VoucherDetailEL();
                    oelVoucher.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                    oelVoucher.IdOrder = Validation.GetSafeGuid(objReader["Order_Id"]);
                    oelVoucher.BookNo = Validation.GetSafeLong(objReader["BookNo"]);
                    oelVoucher.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelVoucher.SystemInvoiceNo = Validation.GetSafeString(objReader["SystemInvoiceNo"]);
                    oelVoucher.SampleNo = Validation.GetSafeLong(objReader["SampleNo"]);
                    oelVoucher.BillNumber = Validation.GetSafeString(objReader["BillNumber"]);
                    //oelVoucher.Purchaser = Validation.GetSafeInteger(objReader["Purchaser"]);
                    oelVoucher.FirstName = Validation.GetSafeString(objReader["AccountName"]);
                    oelVoucher.Contact = Validation.GetSafeString(objReader["Contact"]);

                    oelVoucher.VDate = Validation.GetSafeNullableDateTime(objReader["VDate"]);
                    oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelVoucher.LinkAccountNo = Validation.GetSafeString(objReader["LinkAccountNo"]);
                    oelVoucher.TransactionAccountNo = Validation.GetSafeString(objReader["TransactionAccountNo"]);
                    oelVoucher.VDiscription = Validation.GetSafeString(objReader["VDiscription"]);
                    oelVoucher.OutWardGatePassNo = Validation.GetSafeString(objReader["OutWardGatePassNo"]);
                    oelVoucher.HeadSeller = Validation.GetSafeInteger(objReader["HeadSeller"]);
                    oelVoucher.ShortCode = Validation.GetSafeString(objReader["ShortCode"]);
                    oelVoucher.BillType = Validation.GetSafeInteger(objReader["BillType"]);
                    oelVoucher.BillNumber = Validation.GetSafeString(objReader["BillNumber"]);
                    oelVoucher.BillDate = Validation.GetSafeNullableDateTime(objReader["BillDate"]);
                    oelVoucher.FormE = Validation.GetSafeString(objReader["FormE"]);
                    oelVoucher.FormDate = Validation.GetSafeNullableDateTime(objReader["FormDate"]);
                    oelVoucher.IncoTerms = Validation.GetSafeString(objReader["IncoTerms"]);
                    oelVoucher.OrderDestination = Validation.GetSafeString(objReader["OrderDestination"]);
                    oelVoucher.DischargePort = Validation.GetSafeString(objReader["DischargePort"]);
                    oelVoucher.WearType = Validation.GetSafeInteger(objReader["WearType"]);
                    oelVoucher.TotalCartons = Validation.GetSafeLong(objReader["TotalCartons"]);
                    
                    oelVoucher.Transactiondays = Validation.GetSafeLong(objReader["CreditDays"]);
                    oelVoucher.IsRecieved = Validation.GetSafeBooleanNullable(objReader["IsRecieved"]);
                    oelVoucher.Seller = Validation.GetSafeInteger(objReader["Seller"]);
                    oelVoucher.SaleType = Validation.GetSafeInteger(objReader["SaleType"]);
                    oelVoucher.Posted = Convert.ToBoolean(objReader["Posted"]);
                    oelVoucher.ForeignAmount = Validation.GetSafeDecimal(objReader["ForeignAmount"]);
                    oelVoucher.TotalAmount = Convert.ToInt64(objReader["TotalAmount"]);
                    //oelVoucher.VAT = Validation.GetSafeLong(objReader["VAT"]);
                    //oelVoucher.VATAmount = Validation.GetSafeLong(objReader["VATTotalAmount"]);
                    oelVoucher.ClosingBalance = Validation.GetSafeDecimal(objReader["ClosingBalance"]);


                    //// Getting Sales VoucherDetail Here...
                    oelVoucher.IdVoucherDetail = Validation.GetSafeGuid(objReader["VoucherDetail_Id"]);
                    oelVoucher.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                    oelVoucher.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelVoucher.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelVoucher.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                    oelVoucher.CurrentStock = Validation.GetSafeLong(objReader["CurrentStock"]);
                    oelVoucher.TotalCartons = Validation.GetSafeLong(objReader["TotalCartons"]);
                    //oelVoucher.BatchNo = Validation.GetSafeString(objReader["BatchNo"]);
                    //oelVoucher.Expiry = Validation.GetSafeString(objReader["Expiry"]);

                    oelVoucher.Units = Validation.GetSafeDecimal(objReader["Units"]);
                    oelVoucher.UnitPrice = Validation.GetSafeDecimal(objReader["UnitPrice"]);
                    oelVoucher.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                    oelVoucher.Discount = Validation.GetSafeDecimal(objReader["DiscPercentage"]);
                    oelVoucher.DiscountAmount = Validation.GetSafeDecimal(objReader["Discount"]);
                    oelVoucher.NetAmount = Validation.GetSafeDecimal(objReader["NetAmount"]);

                    oelVoucher.IsNetTransaction = Validation.GetSafeBoolean(objReader["IsNetTransaction"]);
                    oelVoucher.Posted = Validation.GetSafeBoolean(objReader["Posted"]);
                    oelVoucher.IsDeleted = Validation.GetSafeBooleanNullable(objReader["IsDeleted"]);

                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public List<VoucherDetailEL> GetSalesOrderDetailByOrderId(Guid IdOrder, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdVouchers = new SqlCommand("[Transactions].[Proc_GetSalesOrderDetailByOrderId]", objConn))
            {
                cmdVouchers.CommandType = CommandType.StoredProcedure;
                cmdVouchers.Parameters.Add("@IdOrder", SqlDbType.UniqueIdentifier).Value = IdOrder;
                objReader = cmdVouchers.ExecuteReader();
                while (objReader.Read())
                {
                    //// Getting Sales Voucher Header Here...
                    VoucherDetailEL oelVoucher = new VoucherDetailEL();
                    oelVoucher.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                    oelVoucher.IdOrder = Validation.GetSafeGuid(objReader["Order_Id"]);
                    oelVoucher.BookNo = Validation.GetSafeLong(objReader["BookNo"]);
                    oelVoucher.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelVoucher.VDate = Validation.GetSafeNullableDateTime(objReader["VDate"]);
                    oelVoucher.Posted = Validation.GetSafeBoolean(objReader["Posted"]);
                    oelVoucher.IsDeleted = Validation.GetSafeBooleanNullable(objReader["IsDeleted"]);

                    //// Getting Sales VoucherDetail Here...
                    oelVoucher.IdVoucherDetail = Validation.GetSafeGuid(objReader["VoucherDetail_Id"]);                    
                    oelVoucher.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelVoucher.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelVoucher.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                    oelVoucher.TotalCartons = Validation.GetSafeLong(objReader["TotalCartons"]);
                    //oelVoucher.BatchNo = Validation.GetSafeString(objReader["BatchNo"]);
                    //oelVoucher.Expiry = Validation.GetSafeString(objReader["Expiry"]);

                    oelVoucher.Units = Validation.GetSafeDecimal(objReader["Units"]);
                    oelVoucher.UnitPrice = Validation.GetSafeLong(objReader["UnitPrice"]);
                    oelVoucher.Discount = Validation.GetSafeLong(objReader["Discount"]);
                    oelVoucher.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public bool DeleteSales(Guid IdVoucher, SqlConnection objConn)
        {
            try
            {
                SqlCommand cmdDelete = new SqlCommand("[Transactions].[Proc_DeletedSales]", objConn);
                cmdDelete.CommandType = CommandType.StoredProcedure;
                cmdDelete.Parameters.Add("@IdVoucher", SqlDbType.UniqueIdentifier).Value = IdVoucher;

                cmdDelete.ExecuteNonQuery();
                cmdDelete.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }
        #endregion
        #region Sales Return
        public bool InsertSalesReturn(VouchersEL oelVoucher, List<VoucherDetailEL> oelSaleCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
        {
            lock (this)
            {
                SqlTransaction objTran = objConn.BeginTransaction();

                try
                {
                    //// Insert SalesReturn Voucher
                    SqlCommand cmdSalesReturn = new SqlCommand("[Transactions].[Proc_CreateSalesReturnHead]", objConn);

                    cmdSalesReturn.CommandType = CommandType.StoredProcedure;
                    cmdSalesReturn.Transaction = objTran;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelVoucher.IdVoucher;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@IdCompany", DbType.Int64)).Value = oelVoucher.IdCompany;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelVoucher.BookNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.VDate;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@AccountNo", DbType.Int64)).Value = oelVoucher.AccountNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@LinkAccountNo", DbType.String)).Value = oelVoucher.LinkAccountNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelVoucher.SubAccountNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelVoucher.Discription;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@MemoSaleNo", DbType.Int64)).Value = oelVoucher.MemoSaleNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@InWardGatePassNo", DbType.String)).Value = oelVoucher.InWardGatePassNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@OutWardGatePassNo", DbType.String)).Value = oelVoucher.OutWardGatePassNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelVoucher.Amount;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@VAT", DbType.Decimal)).Value = oelVoucher.VAT;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@VATAmount", DbType.Decimal)).Value = oelVoucher.VATAmount;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@IsImport", DbType.Boolean)).Value = oelVoucher.IsImport;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@ReturnType", DbType.Decimal)).Value = oelVoucher.ReturnType;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdSalesReturn.ExecuteNonQuery();

                    //// Insert SalesReturn In SaleReturn Record
                    dal.InsertSalesReturnDetail(oelSaleCollection, objConn, objTran);

                    /// Insert Stock Transactions
                    Tdal.InsertTransactions(oelTransactionsCollection, objConn, objTran);

                    objTran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }
            }
        }
        public bool UpdateSalesReturn(VouchersEL oelVoucher, List<VoucherDetailEL> oelSaleCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
        {
            lock (this)
            {
                SqlTransaction objTran = objConn.BeginTransaction();
                try
                {
                    SqlCommand cmdSalesReturn = new SqlCommand("[Transactions].[Proc_UpdateSalesReturnHead]", objConn);
                    cmdSalesReturn.CommandType = CommandType.StoredProcedure;
                    cmdSalesReturn.Transaction = objTran;

                    cmdSalesReturn.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelVoucher.IdVoucher;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelVoucher.IdCompany;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelVoucher.BookNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.VDate;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@LinkAccountNo", DbType.String)).Value = oelVoucher.LinkAccountNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelVoucher.SubAccountNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@Discription", DbType.String)).Value = oelVoucher.Discription;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@MemoSaleNo", DbType.Int64)).Value = oelVoucher.MemoSaleNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@InWardGatePassNo", DbType.String)).Value = oelVoucher.InWardGatePassNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@OutWardGatePassNo", DbType.String)).Value = oelVoucher.OutWardGatePassNo;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelVoucher.Amount;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@VAT", DbType.Decimal)).Value = oelVoucher.VAT;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@VATAmount", DbType.Decimal)).Value = oelVoucher.VATAmount;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@ReturnType", DbType.Decimal)).Value = oelVoucher.ReturnType;
                    cmdSalesReturn.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdSalesReturn.ExecuteNonQuery();

                    //// Insert And Update Sales In Sale Record
                    dal.UpdateSalesReturnDetail(oelSaleCollection, objConn, objTran);

                    /// Insert and Update Sales Return Transactions
                    Tdal.UpdateTransactions(oelTransactionsCollection, objConn, objTran);

                    objTran.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }
            }
        }
        #endregion
        public bool UpdateSamplesHeadForSales(Guid? IdVoucher, bool IsSold, SqlConnection objConn)
        {
            try
            {
                SqlCommand cmdSample = new SqlCommand("[Transactions].[Proc_UpdateSampleHeadForSale]", objConn);
                cmdSample.CommandType = CommandType.StoredProcedure;
               
                cmdSample.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = IdVoucher;
                cmdSample.Parameters.Add(new SqlParameter("@IsSold", DbType.Boolean)).Value = IsSold;
                cmdSample.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
               
                throw ex;
            }
            finally
            {

            }
            return true;


        }       
        public bool CheckSales(Guid IdCompnay,Int64 VoucherNo, SqlConnection objConn)
        {
            List<VouchersEL> oelSaleCollection = new List<VouchersEL>();
            bool IsExists = false;
            using (SqlCommand cmdCheckSales = new SqlCommand("[Transactions].[Proc_CheckSale]", objConn))
            {
                cmdCheckSales.CommandType = CommandType.StoredProcedure;

                cmdCheckSales.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompnay;
                cmdCheckSales.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = VoucherNo;
                
                IDataReader objReader = cmdCheckSales.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelSaleMaster = new VouchersEL();
                    oelSaleMaster.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelSaleCollection.Add(oelSaleMaster);
                }
            }
            if (oelSaleCollection.Count > 0)
            {
                IsExists = true;
            }
            return IsExists;
        }
        public List<VouchersEL> GetSaleDays(Guid IdCompany, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Transactions].[Proc_GetSaleDays]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();
                    oelVoucher.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelVoucher.Date = Convert.ToDateTime(objReader["VDate"]);
                    oelVoucher.Transactiondays = Validation.GetSafeInteger(objReader["CreditDays"]);
                    oelVoucher.RemainingDays = Validation.GetSafeInteger(objReader["RemainingDays"]);

                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public List<VouchersEL> GetSaleDaysByDate(Guid IdCompany, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Transactions].[Proc_GetSaleDaysByDate]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSales.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdSales.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();
                    oelVoucher.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelVoucher.Date = Convert.ToDateTime(objReader["VDate"]);
                    oelVoucher.Transactiondays = Validation.GetSafeInteger(objReader["CreditDays"]);
                    oelVoucher.RemainingDays = Validation.GetSafeInteger(objReader["RemainingDays"]);

                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public List<VouchersEL> GetSaleDaysByEmployees(Guid IdCompany, string EmpCode, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Transactions].[Proc_GetSaleDaysByEmployee]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSales.Parameters.Add("@EmpCode", SqlDbType.VarChar).Value = EmpCode;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();
                    oelVoucher.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelVoucher.Date = Convert.ToDateTime(objReader["VDate"]);
                    oelVoucher.Transactiondays = Validation.GetSafeInteger(objReader["CreditDays"]);
                    oelVoucher.RemainingDays = Validation.GetSafeInteger(objReader["RemainingDays"]);

                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public List<VouchersEL> GetSaleDaysByEmployeesByDate(Guid IdCompany, string EmpCode,DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Transactions].[Proc_GetSaleDaysByEmployeeByDate]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSales.Parameters.Add("@EmpCode", SqlDbType.VarChar).Value = EmpCode;
                cmdSales.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdSales.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();
                    oelVoucher.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelVoucher.Date = Convert.ToDateTime(objReader["VDate"]);
                    oelVoucher.Transactiondays = Validation.GetSafeInteger(objReader["CreditDays"]);
                    oelVoucher.RemainingDays = Validation.GetSafeInteger(objReader["RemainingDays"]);

                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public List<VouchersEL> GetDateWiseSalesReport(Guid IdCompany, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Reports].[Proc_GetDateWiseSales]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSales.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdSales.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();                   
                    oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelVoucher.TotalSales = Validation.GetSafeLong(objReader["TotalSales"]);
                    oelVoucher.TotalAmount = Validation.GetSafeDecimal(objReader["Amount"]);

                    list.Add(oelVoucher);
                }
            }
            return list;            
        }
        public List<VouchersEL> GetDateAndEmployeeWiseSalesReport(Guid IdCompany, string EmpCode, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Reports].[Proc_GetDateAndEmployeeWiseSales]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSales.Parameters.Add("@EmpCode", SqlDbType.UniqueIdentifier).Value = EmpCode;
                cmdSales.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdSales.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();
                    oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelVoucher.TotalSales = Validation.GetSafeLong(objReader["TotalSales"]);
                    oelVoucher.TotalAmount = Validation.GetSafeDecimal(objReader["Amount"]);

                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public List<VouchersEL> GetDateWiseClaimReturnReport(Guid IdCompany, DateTime StartDate, DateTime EndDate, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Reports].[Proc_GetDateWiseClaimReturns]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSales.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = StartDate;
                cmdSales.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = EndDate;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();
                    oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelVoucher.TotalSalesReturn = Validation.GetSafeLong(objReader["TotalClaims"]);
                    oelVoucher.TotalAmount = Validation.GetSafeDecimal(objReader["Amount"]);

                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public List<VouchersEL> GetClaimedVouchersByAccountNo(Guid IdCompany, string AccountNo, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Reports].[Proc_GetClaimedVouchersByAccountNo]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSales.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();
                    oelVoucher.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                    oelVoucher.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelVoucher.TotalAmount = Validation.GetSafeDecimal(objReader["Amount"]);

                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public List<VoucherDetailEL> GetClaimedVouchersDetail(Guid IdVoucher, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdSales = new SqlCommand("[Transactions].[Proc_GetClaimedVoucherDetail]", objConn))
            {
                cmdSales.CommandType = CommandType.StoredProcedure;
                cmdSales.Parameters.Add("@IdVoucher", SqlDbType.UniqueIdentifier).Value = IdVoucher;
                objReader = cmdSales.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL oelVoucherDetail = new VoucherDetailEL();
                    oelVoucherDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelVoucherDetail.Units = Validation.GetSafeInteger(objReader["Units"]);
                    oelVoucherDetail.UnitPrice = Validation.GetSafeDecimal(objReader["UnitPrice"]);
                    //oelVoucherDetail.Discount = Validation.GetSafeDecimal(objReader["DisCount"]);
                    oelVoucherDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                    list.Add(oelVoucherDetail);
                }
            }
            return list;
        }
    }
}
