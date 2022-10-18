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
    public class PurchaseHeadDAL
    {
        #region Variables
        TransactionsDAL Tdal;
        PurchaseDetailDAL Pdal;
        IDataReader objReader;
        ItemsDAL IDal;
        public PurchaseHeadDAL()
        {
            Tdal = new TransactionsDAL();
            Pdal = new PurchaseDetailDAL();
            IDal = new ItemsDAL();
        }
        #endregion
        #region Purchase Order
        public EntityoperationInfo InsertPurchaseOrder(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseOrderDetailCollection, SqlConnection objConn)
        {
            lock (this)
            {
                EntityoperationInfo infoResult = new EntityoperationInfo();
                SqlTransaction objTran = null;
                SqlCommand cmdPurchaseHead = new SqlCommand("[Transactions].[Proc_CreatePurchaseOrderHead]", objConn);

                try
                {
                    objTran = objConn.BeginTransaction();
                    cmdPurchaseHead.Transaction = objTran;
                    cmdPurchaseHead.CommandType = CommandType.StoredProcedure;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelVoucher.IdVoucher;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelVoucher.IdCompany;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = oelVoucher.IdOrder;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdRequisition", DbType.Guid)).Value = oelVoucher.IdRequisition;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelVoucher.BookNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@PaymentTerms", DbType.String)).Value = oelVoucher.PaymentTerms;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@DeliveryTerms", DbType.String)).Value = oelVoucher.DeliveryTerms;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.VDate;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@PurchaseType", DbType.Int32)).Value = oelVoucher.PurchaseType;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDiscription", DbType.String)).Value = oelVoucher.VDiscription;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdPurchaseHead.ExecuteNonQuery();

                    // Insert Purchase Order Detail Collection...
                    Pdal.InsertPurchaseOrderDetail(oelPurchaseOrderDetailCollection, objConn, objTran);

                    objTran.Commit();
                    infoResult.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }



                return infoResult;
            }
        }
        public EntityoperationInfo UpdatePurchaseOrder(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseOrderDetailCollection, SqlConnection objConn)
        {
            lock (this)
            {
                EntityoperationInfo infoResult = new EntityoperationInfo();
                SqlTransaction objTran = null;
                SqlCommand cmdPurchaseHead = new SqlCommand("[Transactions].[Proc_UpdatePurchaseOrderHead]", objConn);
                try
                {
                    objTran = objConn.BeginTransaction();

                    cmdPurchaseHead.Transaction = objTran;
                    cmdPurchaseHead.CommandType = CommandType.StoredProcedure;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelVoucher.IdVoucher;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelVoucher.IdCompany;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = oelVoucher.IdOrder;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdRequisition", DbType.Guid)).Value = oelVoucher.IdRequisition;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelVoucher.BookNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@PaymentTerms", DbType.String)).Value = oelVoucher.PaymentTerms;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@DeliveryTerms", DbType.String)).Value = oelVoucher.DeliveryTerms;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.VDate;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@PurchaseType", DbType.Int32)).Value = oelVoucher.PurchaseType;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDiscription", DbType.String)).Value = oelVoucher.VDiscription;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdPurchaseHead.ExecuteNonQuery();




                    // Insert Purchase Order Detail Collection...
                    Pdal.UpdatePurchaseOrderDetail(oelPurchaseOrderDetailCollection, objConn, objTran);

                    objTran.Commit();
                    infoResult.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }

                return infoResult;
            }
        }
        public List<VoucherDetailEL> GetPurchaseOrderByVoucher(Int64 VoucherNo, Guid IdCompany, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdVouchers = new SqlCommand("[Transactions].[Proc_GetPurchaseOrderByVoucher]", objConn))
            {
                cmdVouchers.CommandType = CommandType.StoredProcedure;
                cmdVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdVouchers.Parameters.Add("@VoucherNo", SqlDbType.BigInt).Value = VoucherNo;
                objReader = cmdVouchers.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL oelDetail = new VoucherDetailEL();
                    oelDetail.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                    oelDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    if (objReader["Size_Id"] != DBNull.Value)
                    {
                        oelDetail.IdSize = Validation.GetSafeGuid(objReader["Size_Id"]);
                    }
                    else
                    {
                        oelDetail.IdSize = Guid.Empty;
                    }
                    oelDetail.VDate = Validation.GetSafeDateTime(objReader["VDate"]);
                    oelDetail.IdOrder = Validation.GetSafeGuid(objReader["Order_Id"]);
                    oelDetail.IdBrand = Validation.GetSafeGuid(objReader["Brand_Id"]);
                    oelDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelDetail.PaymentTerms = Validation.GetSafeString(objReader["PaymentTerms"]);
                    oelDetail.DeliveryTerms = Validation.GetSafeString(objReader["DeliveryTerms"]);
                    oelDetail.VDiscription = Validation.GetSafeString(objReader["VDiscription"]);
                    oelDetail.TransactionType = Validation.GetSafeString(objReader["PurchaseType"]);
                    oelDetail.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                    oelDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelDetail.BrandName = Validation.GetSafeString(objReader["Brand_Name"]);
                    oelDetail.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);
                    oelDetail.Posted = Validation.GetSafeBoolean(objReader["Posted"]);
                    oelDetail.IsDeleted = Validation.GetSafeBoolean(objReader["IsDeleted"]);
                    if (objReader["VoucherDetail_Id"] != DBNull.Value)
                    {

                        oelDetail.IdVoucherDetail = Validation.GetSafeGuid(objReader["VoucherDetail_Id"].ToString());
                        oelDetail.Discription = Validation.GetSafeString(objReader["Discription"]);
                        oelDetail.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                        oelDetail.Qty = Validation.GetSafeDecimal(objReader["units"]);
                        oelDetail.UnitPrice = Validation.GetSafeDecimal(objReader["UnitPrice"]);
                        oelDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                        oelDetail.PoNumber = Validation.GetSafeString(objReader["PoNumber"]);
                    }

                    list.Add(oelDetail);
                }
                return list;
            }
        }
        public bool DeletePurchaseOrder(Guid IdVoucher, SqlConnection objConn)
        {
            try
            {
                SqlCommand cmdDelete = new SqlCommand("[Transactions].[Proc_DeletedPurchaseOrder]", objConn);
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
        #region Purchasess
        public Int64 GetMaxPurchaseNumber(Guid IdCompany, bool IsNetPurchases, SqlConnection objConn)
       {
           using (SqlCommand cmdPurchases = new SqlCommand("[Transactions].[Proc_GetMaxPurchaseNumber]", objConn))
           {
               cmdPurchases.CommandType = CommandType.StoredProcedure;
               cmdPurchases.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
               //cmdPurchases.Parameters.Add("@IsNetPurchases", SqlDbType.Bit).Value = IsNetPurchases;
               return Validation.GetSafeLong(cmdPurchases.ExecuteScalar());
           }
       }
        public EntityoperationInfo InsertPurchases(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseCollection, List<TransactionsEL> oelTransactionsCollection, List<VoucherDetailEL> oelPurchaseTransactionsCollection, SqlConnection objConn)
        {
            lock (this)
            {
                EntityoperationInfo infoResult = new EntityoperationInfo();
                SqlTransaction objTran = null;
                SqlCommand cmdPurchaseHead = new SqlCommand("[Transactions].[Proc_CreatePurchaseHead]", objConn);

                try
                {
                    objTran = objConn.BeginTransaction();
                    cmdPurchaseHead.Transaction = objTran;
                    cmdPurchaseHead.CommandType = CommandType.StoredProcedure;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelVoucher.IdVoucher;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelVoucher.IdCompany;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = oelVoucher.IdOrder;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    //cmdPurchaseHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelVoucher.BookNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.VDate;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@TransactionAccountNo", DbType.String)).Value = oelVoucher.TransactionAccountNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@LinkAccountNo", DbType.String)).Value = oelVoucher.LinkAccountNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelVoucher.SubAccountNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@BillNo", DbType.String)).Value = oelVoucher.BillNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VehicalNo", DbType.String)).Value = oelVoucher.VehicalNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VehicalType", DbType.Int32)).Value = oelVoucher.VehicalType;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@Weight", DbType.Decimal)).Value = oelVoucher.Weight;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@PurchaseType", DbType.Int32)).Value = oelVoucher.PurchaseType;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDiscription", DbType.String)).Value = oelVoucher.Discription;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@BillAmount", DbType.Decimal)).Value = oelVoucher.BillAmount;

                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalDiscount", DbType.Decimal)).Value = oelVoucher.TotalDiscount;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@ExtraDiscount", DbType.Decimal)).Value = oelVoucher.ExtraDiscount;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@BillAmountAfterDiscount", DbType.Decimal)).Value = oelVoucher.BillAmountAfterDiscount;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalFreight", DbType.Decimal)).Value = oelVoucher.TotalFreight;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IsImport", DbType.Boolean)).Value = oelVoucher.IsImport;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@Purchaser", DbType.Int32)).Value = oelVoucher.Purchaser;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IsNetTransaction", DbType.Boolean)).Value = oelVoucher.IsNetTransaction;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdPurchaseHead.ExecuteNonQuery();

                    // Insert Purchase Collection...
                    Pdal.InsertPurchaseDetail(oelPurchaseCollection, objConn, objTran);

                    // Insert PurchaseTransactionsDetails
                    Pdal.InsertPurchaseTransactionsDetail(oelPurchaseTransactionsCollection, objConn, objTran);

                    // Insert Purchase Transactions...
                    Tdal.InsertTransactions(oelTransactionsCollection, objConn, objTran);

                    IDal.UpdateEvaluationPrice(oelPurchaseCollection, objTran, objConn);

                    objTran.Commit();
                    infoResult.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }



                return infoResult;
            }
        }
        public EntityoperationInfo UpdatePurchases(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseCollection, List<TransactionsEL> oelTransactionsCollection, List<VoucherDetailEL> oelPurchaseTransactionsCollection, SqlConnection objConn)
        {
            lock (this)
            {
                EntityoperationInfo infoResult = new EntityoperationInfo();
                SqlTransaction objTran = null;
                SqlCommand cmdPurchaseHead = new SqlCommand("[Transactions].[Proc_UpdatePurchaseHead]", objConn);
                try
                {
                    objTran = objConn.BeginTransaction();

                    cmdPurchaseHead.Transaction = objTran;
                    cmdPurchaseHead.CommandType = CommandType.StoredProcedure;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelVoucher.IdVoucher;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelVoucher.IdCompany;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = oelVoucher.IdOrder;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelVoucher.BookNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.VDate;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@TransactionAccountNo", DbType.String)).Value = oelVoucher.TransactionAccountNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@LinkAccountNo", DbType.String)).Value = oelVoucher.LinkAccountNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelVoucher.SubAccountNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@BillNo", DbType.String)).Value = oelVoucher.BillNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VehicalNo", DbType.String)).Value = oelVoucher.VehicalNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VehicalType", DbType.Int32)).Value = oelVoucher.VehicalType;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@Weight", DbType.Decimal)).Value = oelVoucher.Weight;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@PurchaseType", DbType.Decimal)).Value = oelVoucher.PurchaseType;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDiscription", DbType.String)).Value = oelVoucher.VDiscription;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@BillAmount", DbType.Decimal)).Value = oelVoucher.BillAmount;

                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalDiscount", DbType.Decimal)).Value = oelVoucher.TotalDiscount;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@ExtraDiscount", DbType.Decimal)).Value = oelVoucher.ExtraDiscount;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@BillAmountAfterDiscount", DbType.Decimal)).Value = oelVoucher.BillAmountAfterDiscount;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalFreight", DbType.Decimal)).Value = oelVoucher.TotalFreight;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                    //cmdPurchaseHead.Parameters.Add(new SqlParameter("@IsImport", DbType.Boolean)).Value = oelVoucher.IsImport;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@Purchaser", DbType.Int32)).Value = oelVoucher.Purchaser;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IsNetTransaction", DbType.Boolean)).Value = oelVoucher.IsNetTransaction;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdPurchaseHead.ExecuteNonQuery();


                    // Insert Purchase Collection...
                    Pdal.UpdatePurchaseDetail(oelPurchaseCollection, objConn, objTran);

                    //Update Purchases Details Collection 
                    Pdal.UpdatePurchaseTransactionsDetail(oelPurchaseTransactionsCollection, objConn, objTran);

                    // Insert Purchase Transactions...
                    Tdal.UpdateTransactions(oelTransactionsCollection, objConn, objTran);

                    IDal.UpdateEvaluationPrice(oelPurchaseCollection, objTran, objConn);

                    objTran.Commit();
                    infoResult.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }

                return infoResult;
            }
        }
        public List<VoucherDetailEL> GetPurchasesByVoucher(Int64 VoucherNo, Guid IdCompany, bool IsNetTransaction, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdVouchers = new SqlCommand("[Transactions].[Proc_GetPurchasesByVoucher]", objConn))
            {
                cmdVouchers.CommandType = CommandType.StoredProcedure;
                cmdVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdVouchers.Parameters.Add("@VoucherNo", SqlDbType.BigInt).Value = VoucherNo;
                //cmdVouchers.Parameters.Add("@IsNetTransaction", SqlDbType.Bit).Value = IsNetTransaction;
                objReader = cmdVouchers.ExecuteReader();
                while (objReader.Read())
                {
                    //// Getting Purchases Voucher Header Here...
                    VoucherDetailEL oelVoucher = new VoucherDetailEL();
                    oelVoucher.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                    oelVoucher.IdOrder = Validation.GetSafeGuid(objReader["Order_Id"]);
                    oelVoucher.BookNo = Validation.GetSafeLong(objReader["BookNo"]);
                    oelVoucher.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelVoucher.BillNo = Validation.GetSafeString(objReader["BillNo"]);
                    oelVoucher.PoNumber = Validation.GetSafeString(objReader["PoNumber"]);
                    oelVoucher.Purchaser = Validation.GetSafeInteger(objReader["Purchaser"]);
                    
                    oelVoucher.VDate = Validation.GetSafeNullableDateTime(objReader["VDate"]);
                    oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelVoucher.TransactionAccountNo = Validation.GetSafeString(objReader["TransactionAccountNo"]);
                    oelVoucher.LinkAccountNo = Validation.GetSafeString(objReader["LinkAccountNo"]);
                    oelVoucher.VDiscription = Validation.GetSafeString(objReader["VDiscription"]);
                    oelVoucher.Posted = Convert.ToBoolean(objReader["Posted"]);
                    oelVoucher.BillAmount = Validation.GetSafeDecimal(objReader["BillAmount"]);
                    oelVoucher.TotalDiscount = Validation.GetSafeDecimal(objReader["TotalDiscount"]);
                    oelVoucher.ExtraDiscount = Validation.GetSafeDecimal(objReader["ExtraDiscount"]);
                    oelVoucher.TotalFreight = Validation.GetSafeDecimal(objReader["TotalFreight"]);
                    oelVoucher.BillAmountAfterDiscount = Validation.GetSafeDecimal(objReader["BillAmountAfterDiscount"]);
                    oelVoucher.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);
                    //oelVoucher.VAT = Validation.GetSafeLong(objReader["VAT"]);
                    //oelVoucher.VATAmount = Validation.GetSafeLong(objReader["VATTotalAmount"]);
                    oelVoucher.ClosingBalance = Validation.GetSafeDecimal(objReader["ClosingBalance"]);
                    oelVoucher.Posted = Validation.GetSafeBoolean(objReader["Posted"]);
                    oelVoucher.IsNetTransaction = Validation.GetSafeBoolean(objReader["IsNetTransaction"]);
                    oelVoucher.IsDeleted = Validation.GetSafeBooleanNullable(objReader["IsDeleted"]);

                    //// Getting Purchases VoucherDetail Here...
                    oelVoucher.IdVoucherDetail = Validation.GetSafeGuid(objReader["VoucherDetail_Id"]);
                    oelVoucher.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                    oelVoucher.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelVoucher.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelVoucher.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                    //oelVoucher.BatchNo = Validation.GetSafeString(objReader["BatchNo"]);
                    //oelVoucher.Expiry = Validation.GetSafeString(objReader["Expiry"]);

                    oelVoucher.Units = Validation.GetSafeDecimal(objReader["Units"]);
                    oelVoucher.Bonus = Validation.GetSafeLong(objReader["BonusUnits"]);
                    oelVoucher.UnitPrice = Validation.GetSafeLong(objReader["UnitPrice"]);
                    oelVoucher.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                    oelVoucher.Discount = Validation.GetSafeDecimal(objReader["DiscPercentage"]);
                    oelVoucher.DiscountAmount = Validation.GetSafeDecimal(objReader["DiscountAmount"]);
                    oelVoucher.FlatDiscount = Validation.GetSafeDecimal(objReader["FlatDiscount"]);
                    oelVoucher.NetAmount = Validation.GetSafeDecimal(objReader["NetAmount"]);
                    oelVoucher.Discription = Validation.GetSafeString(objReader["Discription"]);

                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public bool DeletePurchases(Guid IdVoucher, SqlConnection objConn)
        {
            try
            {
                SqlCommand cmdDelete = new SqlCommand("[Transactions].[Proc_DeletedPurchases]", objConn);
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
        #region PurchasesReturn
        public EntityoperationInfo InsertPurchasesReturn(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
        {
            lock (this)
            {
                EntityoperationInfo infoResult = new EntityoperationInfo();
                SqlTransaction objTran = null;
                SqlCommand cmdPurchaseHead = new SqlCommand("[Transactions].[Proc_CreatePurchaseReturnHead]", objConn);

                try
                {
                    objTran = objConn.BeginTransaction();
                    cmdPurchaseHead.Transaction = objTran;
                    cmdPurchaseHead.CommandType = CommandType.StoredProcedure;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelVoucher.IdVoucher;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Int64)).Value = oelVoucher.IdCompany;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelVoucher.BookNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.VDate;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelVoucher.SubAccountNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@BillNo", DbType.String)).Value = oelVoucher.BillNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDiscription", DbType.String)).Value = oelVoucher.VDiscription;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdPurchaseHead.ExecuteNonQuery();

                    // Insert Purchase Collection...
                    Pdal.InsertPurchaseReturnDetail(oelPurchaseCollection, objConn, objTran);

                    // Insert Purchase Transactions...
                    Tdal.InsertTransactions(oelTransactionsCollection, objConn, objTran);

                    objTran.Commit();
                    infoResult.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }

                return infoResult;
            }

        }
        public EntityoperationInfo UpdatePurchasesReturn(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
        {
            lock (this)
            {
                EntityoperationInfo infoResult = new EntityoperationInfo();
                SqlTransaction objTran = null;
                SqlCommand cmdPurchaseHead = new SqlCommand("[Transactions].[Proc_UpdatePurchaseReturnHead]", objConn);
                try
                {
                    objTran = objConn.BeginTransaction();

                    cmdPurchaseHead.Transaction = objTran;
                    cmdPurchaseHead.CommandType = CommandType.StoredProcedure;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelVoucher.IdVoucher;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelVoucher.IdCompany;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.VDate;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelVoucher.SubAccountNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@BillNo", DbType.String)).Value = oelVoucher.BillNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDescription", DbType.String)).Value = oelVoucher.VDiscription;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdPurchaseHead.ExecuteNonQuery();





                    // Insert Purchase Collection...
                    Pdal.UpdatePurchaseReturnDetail(oelPurchaseCollection, objConn, objTran);

                    // Insert Purchase Transactions...
                    Tdal.UpdateTransactions(oelTransactionsCollection, objConn, objTran);
                    objTran.Commit();
                    infoResult.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }
                return infoResult;
            }
        }
        public List<VoucherDetailEL> GetPurchasesReturnByVoucher(Int64 VoucherNo, Guid IdCompany, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdVouchers = new SqlCommand("[Transactions].[Proc_GetPurchasesReturnByVoucher]", objConn))
            {
                cmdVouchers.CommandType = CommandType.StoredProcedure;
                cmdVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdVouchers.Parameters.Add("@VoucherNo", SqlDbType.BigInt).Value = VoucherNo;
                objReader = cmdVouchers.ExecuteReader();
                while (objReader.Read())
                {
                    //// Getting Purchases Voucher Header Here...
                    VoucherDetailEL oelVoucher = new VoucherDetailEL();
                    oelVoucher.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                    oelVoucher.BookNo = Validation.GetSafeLong(objReader["BookNo"]);
                    oelVoucher.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelVoucher.BillNo = Validation.GetSafeString(objReader["BillNo"]);
                    oelVoucher.Purchaser = Validation.GetSafeInteger(objReader["Purchaser"]);
                    oelVoucher.FirstName = Validation.GetSafeString(objReader["AccountName"]);
                    oelVoucher.Contact = Validation.GetSafeString(objReader["Contact"]);

                    oelVoucher.VDate = Validation.GetSafeNullableDateTime(objReader["VDate"]);
                    oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelVoucher.VDiscription = Validation.GetSafeString(objReader["VDiscription"]);
                    oelVoucher.Posted = Convert.ToBoolean(objReader["Posted"]);
                    oelVoucher.TotalAmount = Convert.ToInt64(objReader["TotalAmount"]);
                    oelVoucher.VAT = Validation.GetSafeLong(objReader["VAT"]);
                    oelVoucher.VATAmount = Validation.GetSafeLong(objReader["VATTotalAmount"]);
                    oelVoucher.ClosingBalance = Validation.GetSafeDecimal(objReader["ClosingBalance"]);
                    oelVoucher.Posted = Validation.GetSafeBoolean(objReader["Posted"]);
                    oelVoucher.IsDeleted = Validation.GetSafeBooleanNullable(objReader["IsDeleted"]);

                    //// Getting Purchases VoucherDetail Here...
                    oelVoucher.IdVoucherDetail = Validation.GetSafeGuid(objReader["VoucherDetail_Id"]);
                    oelVoucher.ItemNo = Validation.GetSafeString(objReader["ItemNo"]);
                    oelVoucher.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelVoucher.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelVoucher.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                    //oelVoucher.BatchNo = Validation.GetSafeString(objReader["BatchNo"]);
                    //oelVoucher.Expiry = Validation.GetSafeString(objReader["Expiry"]);

                    oelVoucher.Units = Validation.GetSafeDecimal(objReader["Units"]);
                    oelVoucher.UnitPrice = Validation.GetSafeLong(objReader["UnitPrice"]);
                    oelVoucher.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                    oelVoucher.Discount = Validation.GetSafeLong(objReader["Disc"]);
                    oelVoucher.Discription = Validation.GetSafeString(objReader["Discription"]);

                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public bool DeletePurchasesReturn(Guid IdVoucher, SqlConnection objConn)
        {
            try
            {
                SqlCommand cmdDelete = new SqlCommand("[Transactions].[Proc_DeletedPurchasesReturn]", objConn);
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
        public EntityoperationInfo InsertWorkPurchases(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
        {
            lock (this)
            {
                EntityoperationInfo infoResult = new EntityoperationInfo();
                SqlTransaction objTran = null;
                SqlCommand cmdPurchaseHead = new SqlCommand("[Transactions].[Proc_CreatePurchaseWorkHead]", objConn);

                try
                {
                    objTran = objConn.BeginTransaction();
                    cmdPurchaseHead.Transaction = objTran;
                    cmdPurchaseHead.CommandType = CommandType.StoredProcedure;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelVoucher.IdVoucher;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Int64)).Value = oelVoucher.IdCompany;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.Date;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelVoucher.Description;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdPurchaseHead.ExecuteNonQuery();

                    // Insert Purchase Collection...
                    Pdal.InsertWorkPurchaseDetail(oelPurchaseCollection, objConn, objTran);

                    // Insert Purchase Transactions...
                    Tdal.InsertTransactions(oelTransactionsCollection, objConn, objTran);

                    objTran.Commit();
                    infoResult.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }



                return infoResult;
            }
        }
        public EntityoperationInfo UpdateWorkPurchases(VouchersEL oelVoucher, List<VoucherDetailEL> oelPurchaseCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
        {
            lock (this)
            {
                EntityoperationInfo infoResult = new EntityoperationInfo();
                SqlTransaction objTran = null;
                SqlCommand cmdPurchaseHead = new SqlCommand("[Transactions].[Proc_UpdatePurchaseWorkHead]", objConn);

                try
                {
                    objTran = objConn.BeginTransaction();
                    cmdPurchaseHead.Transaction = objTran;
                    cmdPurchaseHead.CommandType = CommandType.StoredProcedure;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelVoucher.IdVoucher;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Int64)).Value = oelVoucher.IdCompany;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.Date;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelVoucher.AccountNo;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelVoucher.Description;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                    cmdPurchaseHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdPurchaseHead.ExecuteNonQuery();

                    // Update Purchase Collection...
                    Pdal.InsertWorkPurchaseDetail(oelPurchaseCollection, objConn, objTran);

                    // Insert Purchase Transactions...
                    Tdal.UpdateTransactions(oelTransactionsCollection, objConn, objTran);

                    objTran.Commit();
                    infoResult.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }



                return infoResult;
            }
        }
        //public static bool UpdatePurchaseMaster(PurchaseMasterEL oelPurchaseMaster, SqlConnection oConn)
        //{
        //    using (SqlCommand cmdPurchaseMaster = new SqlCommand("sp_updatePurchaseMaster", oConn))
        //    {
        //        cmdPurchaseMaster.CommandType = CommandType.StoredProcedure;
        //        cmdPurchaseMaster.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int32)).Value = oelPurchaseMaster.VoucherNo;
        //        cmdPurchaseMaster.Parameters.Add(new SqlParameter("@Date", DbType.DateTime)).Value = oelPurchaseMaster.Date;
        //        cmdPurchaseMaster.Parameters.Add(new SqlParameter("@SupplierNo", DbType.String)).Value = oelPurchaseMaster.SupplierNo;
        //        cmdPurchaseMaster.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelPurchaseMaster.Description;
        //        cmdPurchaseMaster.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelPurchaseMaster.TotalAmount;
        //        cmdPurchaseMaster.Parameters.Add(new SqlParameter("@CashPaid", DbType.Decimal)).Value = oelPurchaseMaster.CashPaid;
        //        cmdPurchaseMaster.Parameters.Add(new SqlParameter("@PaidAccountNo", DbType.String)).Value = oelPurchaseMaster.PaidAccountNo;
        //        cmdPurchaseMaster.Parameters.Add(new SqlParameter("@PaidAccountDescription", DbType.String)).Value = oelPurchaseMaster.PaidAccountDescription;
        //        cmdPurchaseMaster.Parameters.Add(new SqlParameter("@Balance", DbType.Decimal)).Value = oelPurchaseMaster.Balance;
        //        cmdPurchaseMaster.ExecuteNonQuery();
        //        return true;

        //    }
        //}
        public List<VoucherDetailEL> GetVehicalDetail(string VehicalNo, Guid IdCompany, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdPurchase = new SqlCommand("[Transactions].[Proc_GetVehicalDetail]", objConn))
            {
                cmdPurchase.CommandType = CommandType.StoredProcedure;
                cmdPurchase.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdPurchase.Parameters.Add("@VehicalNo", SqlDbType.VarChar).Value = VehicalNo;
                objReader = cmdPurchase.ExecuteReader();
                while (objReader.Read())
                {
                    VoucherDetailEL oelVehical = new VoucherDetailEL();
                    oelVehical.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelVehical.Weight = Validation.GetSafeDecimal(objReader["Weight"]);
                    oelVehical.CreatedDateTime = Validation.GetSafeDateTime(objReader["VDate"]);
                    oelVehical.VoucherType = Validation.GetSafeString(objReader["VehicalType"]);
                    list.Add(oelVehical);
                }
            }
            return list;
        }

    }
}
