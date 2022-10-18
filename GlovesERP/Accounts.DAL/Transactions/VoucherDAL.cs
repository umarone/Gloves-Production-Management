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
    public class VoucherDAL
    {
        IDataReader objReader;
        TransactionsDAL Tdal;
        VouchersDetailDAL VDal;
        public VoucherDAL()
        {
            Tdal = new TransactionsDAL();
            VDal = new VouchersDetailDAL();
        }
        public EntityoperationInfo InsertVouchersHead(VouchersEL oelVoucher, List<VoucherDetailEL> oelDetailCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
        {
            lock (this)
            {
                EntityoperationInfo infoResult = new EntityoperationInfo();
                SqlTransaction objTran = objConn.BeginTransaction();
                SqlCommand cmdVoucherHead = new SqlCommand("[Transactions].[Proc_CreateVouchersHead]", objConn);
                try
                {
                    cmdVoucherHead.Transaction = objTran;
                    cmdVoucherHead.CommandType = CommandType.StoredProcedure;

                    cmdVoucherHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelVoucher.IdVoucher;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelVoucher.IdCompany;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelVoucher.BookNo;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelVoucher.SubAccountNo;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.VDate;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@ChequeNo", DbType.String)).Value = oelVoucher.ChequeNo;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@VDiscription", DbType.String)).Value = oelVoucher.VDiscription;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@VType", DbType.String)).Value = oelVoucher.VoucherType;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@AdjustmentType", DbType.Int32)).Value = oelVoucher.AdjustmentType;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdVoucherHead.ExecuteNonQuery();

                    // Insert Vouchers Detail

                    VDal.InsertVouchersDetail(oelDetailCollection, objConn, objTran);

                    // Insert Vouchers Transactions
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
        public EntityoperationInfo UpdateVouchersHead(VouchersEL oelVoucher, List<VoucherDetailEL> oelDetailCollection, List<TransactionsEL> oelTransactionsCollection, SqlConnection objConn)
        {
            lock (this)
            {
                EntityoperationInfo infoResult = new EntityoperationInfo();
                SqlTransaction objTran = objConn.BeginTransaction();
                SqlCommand cmdVoucherHead = new SqlCommand("[Transactions].[Proc_UpdateVouchersHead]", objConn);
                try
                {
                    cmdVoucherHead.Transaction = objTran;
                    cmdVoucherHead.CommandType = CommandType.StoredProcedure;

                    cmdVoucherHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelVoucher.IdVoucher;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelVoucher.IdCompany;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelVoucher.IdUser;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelVoucher.BookNo;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@EmpCode", DbType.String)).Value = oelVoucher.SubAccountNo;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelVoucher.VDate;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@ChequeNo", DbType.String)).Value = oelVoucher.ChequeNo;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@VDiscription", DbType.String)).Value = oelVoucher.VDiscription;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelVoucher.TotalAmount;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@VType", DbType.String)).Value = oelVoucher.VoucherType;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@AdjustmentType", DbType.Int32)).Value = oelVoucher.AdjustmentType;
                    cmdVoucherHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelVoucher.Posted;
                    cmdVoucherHead.ExecuteNonQuery();

                    // Insert Vouchers Detail

                    VDal.UpdateVouchersDetail(oelDetailCollection, objConn, objTran);

                    // Insert Vouchers Transactions
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
        public bool DeleteVouchers(Guid IdVoucher, Guid IdCompany, SqlConnection objConn)
        {
            using (SqlTransaction objTran = objConn.BeginTransaction())
            {
                try
                {
                    SqlCommand cmdDeleteVouchers = new SqlCommand("[Transactions].[Proc_DeleteFinancialVouchers]", objConn);
                    cmdDeleteVouchers.CommandType = CommandType.StoredProcedure;
                    cmdDeleteVouchers.Transaction = objTran;
                    cmdDeleteVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                    cmdDeleteVouchers.Parameters.Add("@IdVoucher", SqlDbType.UniqueIdentifier).Value = IdVoucher;
                    cmdDeleteVouchers.ExecuteNonQuery();
                    cmdDeleteVouchers.Parameters.Clear();

                    objTran.Commit();
                }
                catch (Exception ex)
                {
                    objTran.Rollback();
                    throw ex;
                }
            }
            return true;
        }
        public bool DeleteChildRecords(Guid Id, string VoucherType, SqlConnection objConn)
        {
            SqlCommand cmdDeleteDetail = new SqlCommand();
            cmdDeleteDetail.CommandType = CommandType.StoredProcedure;
            cmdDeleteDetail.Connection = objConn;

            cmdDeleteDetail.CommandText = "[Transactions].[Proc_DeleteChildRecords]";
            cmdDeleteDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Int64)).Value = Id;
            cmdDeleteDetail.Parameters.Add(new SqlParameter("@VoucherType", DbType.String)).Value = VoucherType;
            cmdDeleteDetail.ExecuteNonQuery();
            return true;
        }
        public List<VouchersEL> GetVouchersByTypeAndDate(Guid IdCompany, string VoucherType, DateTime VoucherDate, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdVouchers = new SqlCommand("[Transactions].[Proc_GetVoucherByType]", objConn))
            {
                cmdVouchers.CommandType = CommandType.StoredProcedure;
                cmdVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdVouchers.Parameters.Add("@VoucherType", SqlDbType.VarChar).Value = VoucherType;
                cmdVouchers.Parameters.Add("@VDate", SqlDbType.DateTime).Value = VoucherDate;
                objReader = cmdVouchers.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();

                    oelVoucher.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                    oelVoucher.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);

                    oelVoucher.Date = Convert.ToDateTime(objReader["VDate"]);
                    if (VoucherType == "StockReceiptVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                        oelVoucher.VoucherType = "StockReceiptVoucher";
                    }
                    else if (VoucherType == "CashReceiptVoucher")
                    {
                        //oelVoucher.AccountNo = Validation.GetSafeLong(objReader["AccountNo"]);
                        oelVoucher.VoucherType = "Receipt Voucher";
                    }
                    else if (VoucherType == "PaymentVoucher")
                    {
                        //oelVoucher.AccountNo = Validation.GetSafeLong(objReader["AccountNo"]);
                        oelVoucher.VoucherType = "Payment Voucher";
                    }
                    else if (VoucherType == "SaleInvoiceVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                        oelVoucher.VoucherType = "Invoice Voucher";
                    }
                    else if (VoucherType == "SalesReturnVoucher")
                    {
                        //oelVoucher.AccountNo = Validation.GetSafeLong(objReader["AccountNo"]);
                        oelVoucher.VoucherType = "SalesReturnVoucher";
                    }
                    else if (VoucherType == "BankPaymentVoucher")
                    {
                        //oelVoucher.AccountNo = Validation.GetSafeLong(objReader["AccountNo"]);
                        oelVoucher.VoucherType = "BankPaymentVoucher";
                    }
                    else if (VoucherType == "BankReceiptVoucher")
                    {
                        //oelVoucher.AccountNo = Validation.GetSafeLong(objReader["AccountNo"]);
                        oelVoucher.VoucherType = "BankReceiptVoucher";
                    }
                    else if (VoucherType == "PrescriberSampleVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.VoucherType = "PrescriberSampleVoucher";
                    }
                    else if (VoucherType == "JournalVoucher")
                    {
                        oelVoucher.VoucherType = "JournalVoucher";
                    }
                    if (VoucherType != "PaymentVoucher" && VoucherType != "CashReceiptVoucher" && VoucherType != "SaleInvoiceVoucher" && VoucherType != "SalesReturnVoucher" && VoucherType != "BankPaymentVoucher" && VoucherType != "BankReceiptVoucher" && VoucherType != "PrescriberSampleVoucher" && VoucherType != "JournalVoucher")
                    {
                        if (objReader["BillNo"] != DBNull.Value)
                        {
                            oelVoucher.BillNo = objReader["BillNo"].ToString();
                        }
                        else
                        {
                            oelVoucher.BillNo = "";
                        }
                    }
                    if (VoucherType != "JournalVoucher")
                    {
                        //oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    }
                    if (VoucherType == "PrescriberSampleVoucher")
                    {
                        oelVoucher.Description = Convert.ToString(objReader["Discription"] ?? "");
                    }
                    else
                    {
                        if (VoucherType != "JournalVoucher")
                        {
                            oelVoucher.Description = Convert.ToString(objReader["Description"] ?? "");
                        }
                    }
                    oelVoucher.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                    oelVoucher.Posted = Convert.ToBoolean(objReader["Posted"]);
                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public List<VouchersEL> GetVouchersByTypeAndVoucherNumber(Guid IdCompany, string VoucherType, Int64 VoucherNo, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdVouchers = new SqlCommand("[Transactions].[Proc_GetVoucherByTypeAndVoucherNo]", objConn))
            {
                cmdVouchers.CommandType = CommandType.StoredProcedure;
                cmdVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdVouchers.Parameters.Add("@VoucherType", SqlDbType.VarChar).Value = VoucherType;
                cmdVouchers.Parameters.Add("@VoucherNo", SqlDbType.BigInt).Value = VoucherNo;
                objReader = cmdVouchers.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();

                    oelVoucher.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                    oelVoucher.VoucherNo = Convert.ToInt64(objReader["VoucherNo"]);
                    oelVoucher.VDate = Convert.ToDateTime(objReader["VDate"]);
                    if (VoucherType == "StockReceiptVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.LinkAccountNo = Validation.GetSafeString(objReader["LinkAccountNo"]);
                        oelVoucher.Discription = Validation.GetSafeString(objReader["Discription"]);
                        oelVoucher.VoucherType = "StockReceiptVoucher";
                        oelVoucher.VehicalNo = Validation.GetSafeString(objReader["VehicalNo"]);
                        oelVoucher.VehicalType = Validation.GetSafeInteger(objReader["VehicalType"]);
                        oelVoucher.Weight = Validation.GetSafeDecimal(objReader["Weight"]);
                        oelVoucher.Purchaser = Validation.GetSafeInteger(objReader["Purchaser"]);
                        oelVoucher.PurchaseType = Validation.GetSafeInteger(objReader["PurchaseType"]);

                        //oelVoucher.VAT = Validation.GetSafeDecimal(objReader["VAT"]);
                        //oelVoucher.VATAmount = Validation.GetSafeDecimal(objReader["VATAmount"]);
                    }
                    else if (VoucherType == "PurchaseOrder")
                    {
                        oelVoucher.Description = Validation.GetSafeString(objReader["Description"]);
                        oelVoucher.VoucherType = "PurchaseOrder";
                        oelVoucher.PurchaseType = Validation.GetSafeInteger(objReader["POType"]);

                        //oelVoucher.VAT = Validation.GetSafeDecimal(objReader["VAT"]);
                        //oelVoucher.VATAmount = Validation.GetSafeDecimal(objReader["VATAmount"]);
                    }
                    else if (VoucherType == "PurchaseReturnVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.VoucherType = "PurchaseReturnVoucher";
                        //oelVoucher.VAT = Validation.GetSafeDecimal(objReader["VAT"]);
                        //oelVoucher.VATAmount = Validation.GetSafeDecimal(objReader["VATAmount"]);
                    }
                    else if (VoucherType == "CashReceiptVoucher")
                    {
                        //oelVoucher.AccountNo = Validation.GetSafeLong(objReader["AccountNo"]);
                        oelVoucher.SubAccountNo = Validation.GetSafeString(objReader["EmpCode"]);
                        oelVoucher.VoucherType = "Receipt Voucher";
                        oelVoucher.VDiscription = Validation.GetSafeString(objReader["VDiscription"]);
                        oelVoucher.AdjustmentType = Validation.GetSafeInteger(objReader["AdjustmentType"]);
                    }
                    else if (VoucherType == "PaymentVoucher")
                    {
                        //oelVoucher.AccountNo = Validation.GetSafeLong(objReader["AccountNo"]);
                        oelVoucher.SubAccountNo = Validation.GetSafeString(objReader["EmpCode"]);
                        oelVoucher.VoucherType = "Payment Voucher";
                        oelVoucher.VDiscription = Validation.GetSafeString(objReader["VDiscription"]);
                        oelVoucher.AdjustmentType = Validation.GetSafeInteger(objReader["AdjustmentType"]);
                    }
                    else if (VoucherType == "SaleInvoiceVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.SubAccountNo = Validation.GetSafeString(objReader["EmpCode"]);
                        oelVoucher.PersonName = Validation.GetSafeString(objReader["MakerName"]);
                        oelVoucher.MemoSaleNo = Validation.GetSafeLong(objReader["MemoSaleNo"]);
                        oelVoucher.OutWardGatePassNo = Validation.GetSafeString(objReader["OutWardGatePassNo"]);
                        oelVoucher.VehicalNo = Validation.GetSafeString(objReader["VehicleNo"]);
                        oelVoucher.SampleNo = Validation.GetSafeLong(objReader["SampleNo"]);
                        oelVoucher.Transactiondays = Validation.GetSafeLong(objReader["CreditDays"]);
                        oelVoucher.IsRecieved = Validation.GetSafeBooleanNullable(objReader["IsRecieved"]);
                        oelVoucher.VAT = Validation.GetSafeDecimal(objReader["VAT"]);
                        oelVoucher.VATAmount = Validation.GetSafeDecimal(objReader["VATAmount"]);
                        oelVoucher.Seller = Validation.GetSafeInteger(objReader["Seller"]);
                        oelVoucher.SaleType = Validation.GetSafeInteger(objReader["SaleType"]);
                        oelVoucher.VoucherType = "Invoice Voucher";
                    }
                    else if (VoucherType == "SampleVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.DemandNo = Validation.GetSafeString(objReader["DemandNo"]);
                        oelVoucher.OutWardGatePassNo = Validation.GetSafeString(objReader["OutWardGatePassNo"]);
                        oelVoucher.Transactiondays = Validation.GetSafeLong(objReader["SampleDays"]);
                        oelVoucher.IsRecieved = Validation.GetSafeBooleanNullable(objReader["IsRecieved"]);
                        if (DBNull.Value != objReader["IsSold"])
                        {
                            oelVoucher.IsSold = Convert.ToBoolean(objReader["IsSold"]);
                        }
                        else
                        {
                            oelVoucher.IsSold = false;
                        }
                        oelVoucher.VoucherType = "Sample Voucher";
                    }
                    else if (VoucherType == "SampleReturnVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.InWardGatePassNo = Validation.GetSafeString(objReader["InWardGatePassNo"]);
                        oelVoucher.OutWardGatePassNo = Validation.GetSafeString(objReader["OutWardGatePassNo"]);
                        oelVoucher.VoucherType = "Sample Return Voucher";
                    }
                    else if (VoucherType == "SalesReturnVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.InWardGatePassNo = Validation.GetSafeString(objReader["InWardGatePassNo"]);
                        oelVoucher.OutWardGatePassNo = Validation.GetSafeString(objReader["OutWardGatePassNo"]);
                        oelVoucher.ReturnType = Validation.GetSafeInteger(objReader["ReturnType"]);
                        oelVoucher.VoucherType = "SalesReturnVoucher";
                        oelVoucher.VAT = Validation.GetSafeDecimal(objReader["VAT"]);
                        oelVoucher.VATAmount = Validation.GetSafeDecimal(objReader["VATAmount"]);
                    }
                    else if (VoucherType == "BankPaymentVoucher")
                    {
                        //oelVoucher.AccountNo = Validation.GetSafeLong(objReader["AccountNo"]);
                        oelVoucher.SubAccountNo = Validation.GetSafeString(objReader["EmpCode"]);
                        oelVoucher.ChequeNo = Validation.GetSafeString(objReader["ChequeNo"]);
                        oelVoucher.VoucherType = "BankPaymentVoucher";
                        oelVoucher.VDiscription = Validation.GetSafeString(objReader["VDiscription"]);
                        oelVoucher.AdjustmentType = Validation.GetSafeInteger(objReader["AdjustmentType"]);
                    }
                    else if (VoucherType == "BankReceiptVoucher")
                    {
                        //oelVoucher.AccountNo = Validation.GetSafeLong(objReader["AccountNo"]);
                        oelVoucher.SubAccountNo = Validation.GetSafeString(objReader["EmpCode"]);
                        oelVoucher.ChequeNo = Validation.GetSafeString(objReader["ChequeNo"]);
                        oelVoucher.VDiscription = Validation.GetSafeString(objReader["VDiscription"]);
                        oelVoucher.AdjustmentType = Validation.GetSafeInteger(objReader["AdjustmentType"]);
                        oelVoucher.VoucherType = "BankReceiptVoucher";
                    }
                    else if (VoucherType == "PrescriberSampleVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.VoucherType = "PrescriberSampleVoucher";
                    }
                    else if (VoucherType == "PrescriberSampleVoucher")
                    {
                        oelVoucher.VoucherType = "JournalVoucher";
                    }
                    else if (VoucherType == "JournalVoucher")
                    {
                        oelVoucher.VDiscription = Convert.ToString(objReader["VDiscription"] ?? "");
                        oelVoucher.VoucherType = "JournalVoucher";
                        oelVoucher.AdjustmentType = Validation.GetSafeInteger(objReader["AdjustmentType"]);
                    }
                    else if (VoucherType == "WorkProcess")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                        oelVoucher.Description = Validation.GetSafeString(objReader["Description"]);
                        oelVoucher.WorkType = Validation.GetSafeInteger(objReader["WorkType"]);
                        oelVoucher.ProcessType = Validation.GetSafeInteger(objReader["ProcessType"]);
                        oelVoucher.IsClaimed = Validation.GetSafeBooleanNullable(objReader["Claimed"]);
                        oelVoucher.IsPlain = Validation.GetSafeBooleanNullable(objReader["IsPlain"]);
                    }
                    if (VoucherType != "PaymentVoucher" && VoucherType != "CashReceiptVoucher" && VoucherType != "SaleInvoiceVoucher" && VoucherType != "SalesReturnVoucher" && VoucherType != "BankPaymentVoucher" && VoucherType != "BankReceiptVoucher" && VoucherType != "PrescriberSampleVoucher" && VoucherType != "JournalVoucher" && VoucherType != "SampleVoucher" && VoucherType != "SampleReturnVoucher" && VoucherType != "WorkProcess" && VoucherType != "PurchaseOrder")
                    {
                        if (objReader["BillNo"] != DBNull.Value)
                        {
                            oelVoucher.BillNo = objReader["BillNo"].ToString();
                        }
                        else
                        {
                            oelVoucher.BillNo = "";
                        }
                    }
                    if (VoucherType != "JournalVoucher")
                    {
                        //oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    }
                    if (VoucherType == "PrescriberSampleVoucher")
                    {
                        oelVoucher.VDiscription = Convert.ToString(objReader["VDiscription"] ?? "");
                    }
                    else
                    {
                        if (VoucherType != "JournalVoucher")
                        {
                            oelVoucher.VDiscription = Convert.ToString(objReader["VDiscription"] ?? "");
                        }
                    }
                    oelVoucher.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);
                    oelVoucher.Posted = Validation.GetSafeBoolean(objReader["Posted"]);
                    oelVoucher.IsDeleted = Validation.GetSafeBooleanNullable(objReader["isDeleted"]);
                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public List<VouchersEL> GetVouchersByVehicleNumber(Guid IdCompany, string VehicleNo, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdVouchers = new SqlCommand("[Transactions].[Proc_GetVoucherInfoByVehicleNo]", objConn))
            {
                cmdVouchers.CommandType = CommandType.StoredProcedure;
                cmdVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdVouchers.Parameters.Add("@VehicleNo", SqlDbType.VarChar).Value = VehicleNo;
                objReader = cmdVouchers.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();

                    oelVoucher.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                    oelVoucher.VoucherNo = Convert.ToInt64(objReader["VoucherNo"]);
                    oelVoucher.Date = Convert.ToDateTime(objReader["VDate"]);

                    oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelVoucher.LinkAccountNo = Validation.GetSafeString(objReader["LinkAccountNo"]);
                    oelVoucher.Description = Validation.GetSafeString(objReader["Description"]);
                    oelVoucher.VoucherType = "StockReceiptVoucher";
                    oelVoucher.VehicalNo = Validation.GetSafeString(objReader["VehicalNo"]);
                    oelVoucher.VehicalType = Validation.GetSafeInteger(objReader["VehicalType"]);
                    oelVoucher.Weight = Validation.GetSafeDecimal(objReader["Weight"]);
                    oelVoucher.PurchaseType = Validation.GetSafeInteger(objReader["PurchaseType"]);
                    oelVoucher.Purchaser = Validation.GetSafeInteger(objReader["Purchaser"]);
                }
            }
            return list;
        }
        public List<VouchersEL> GetVouchersByTypeAndAccountNo(Guid IdCompany, string VoucherType, string AccountNo, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdVouchers = new SqlCommand("[Transactions].[Proc_GetVoucherByTypeAndAccountNo]", objConn))
            {
                cmdVouchers.CommandType = CommandType.StoredProcedure;
                cmdVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdVouchers.Parameters.Add("@VoucherType", SqlDbType.VarChar).Value = VoucherType;
                cmdVouchers.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                objReader = cmdVouchers.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();
                    oelVoucher.VoucherNo = Convert.ToInt64(objReader["VoucherNo"]);
                    oelVoucher.Date = Convert.ToDateTime(objReader["VDate"]);
                    if (VoucherType == "StockReceiptVoucher")
                    {
                        //oelVoucher.PersonName = Convert.ToString(objReader["SupplierNo"]);
                        oelVoucher.PersonName = Convert.ToString(objReader["AccountNo"]);
                        oelVoucher.VoucherType = "StockReceiptVoucher";
                    }
                    else if (VoucherType == "CashReceiptVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.VoucherType = "Receipt Voucher";
                    }
                    else if (VoucherType == "PaymentVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.VoucherType = "Payment Voucher";
                    }
                    else if (VoucherType == "SaleInvoiceVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.VoucherType = "Invoice Voucher";
                    }
                    else if (VoucherType == "SalesReturnVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["CustomerNo"]);
                        oelVoucher.VoucherType = "SalesReturnVoucher";
                    }
                    else if (VoucherType == "BankPaymentVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.VoucherType = "BankPaymentVoucher";
                    }
                    else if (VoucherType == "BankReceiptVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.VoucherType = "BankReceiptVoucher";
                    }
                    else if (VoucherType == "PrescriberSampleVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.VoucherType = "PrescriberSampleVoucher";
                    }
                    else if (VoucherType == "PrescriberSampleVoucher")
                    {
                        oelVoucher.VoucherType = "JournalVoucher";
                    }
                    if (VoucherType != "PaymentVoucher" && VoucherType != "CashReceiptVoucher" && VoucherType != "SaleInvoiceVoucher" && VoucherType != "SalesReturnVoucher" && VoucherType != "BankPaymentVoucher" && VoucherType != "BankReceiptVoucher" && VoucherType != "PrescriberSampleVoucher" && VoucherType != "JournalVoucher")
                    {
                        if (objReader["BillNo"] != DBNull.Value)
                        {
                            oelVoucher.BillNo = objReader["BillNo"].ToString();
                        }
                        else
                        {
                            oelVoucher.BillNo = "";
                        }
                    }
                    oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    if (VoucherType == "PrescriberSampleVoucher")
                    {
                        oelVoucher.Description = Convert.ToString(objReader["Discription"] ?? "");
                    }
                    else
                    {
                        if (VoucherType != "JournalVoucher")
                        {
                            oelVoucher.Description = Convert.ToString(objReader["Description"] ?? "");
                        }
                    }
                    oelVoucher.Amount = Convert.ToInt64(objReader["Amount"]);
                    oelVoucher.Posted = Convert.ToBoolean(objReader["Posted"]);
                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public List<VouchersEL> GetAllVouchersByType(Guid IdCompany, string VoucherType, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdVouchers = new SqlCommand("[Transactions].[Proc_GetAllVouchersByType]", objConn))
            {
                cmdVouchers.CommandType = CommandType.StoredProcedure;
                cmdVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdVouchers.Parameters.Add("@VoucherType", SqlDbType.VarChar).Value = VoucherType;
                objReader = cmdVouchers.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();

                    oelVoucher.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                    oelVoucher.VoucherNo = Convert.ToInt64(objReader["VoucherNo"]);
                    oelVoucher.Date = Convert.ToDateTime(objReader["VDate"]);
                    if (VoucherType == "StockReceiptVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                        oelVoucher.VoucherType = "StockReceiptVoucher";
                    }
                    else if (VoucherType == "CashReceiptVoucher")
                    {
                        //oelVoucher.AccountNo = Validation.GetSafeLong(objReader["AccountNo"]);
                        oelVoucher.SubAccountNo = Validation.GetSafeString(objReader["EmpCode"]);
                        oelVoucher.VoucherType = "Receipt Voucher";
                    }
                    else if (VoucherType == "PaymentVoucher")
                    {
                        //oelVoucher.AccountNo = Validation.GetSafeLong(objReader["AccountNo"]);
                        oelVoucher.SubAccountNo = Validation.GetSafeString(objReader["EmpCode"]);
                        oelVoucher.VoucherType = "Payment Voucher";
                    }
                    else if (VoucherType == "SaleInvoiceVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                        oelVoucher.MemoSaleNo = Validation.GetSafeLong(objReader["MemoSaleNo"]);
                        oelVoucher.VoucherType = "Invoice Voucher";
                    }
                    else if (VoucherType == "SalesReturnVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                        oelVoucher.VoucherType = "SalesReturnVoucher";
                    }
                    else if (VoucherType == "BankPaymentVoucher")
                    {
                        //oelVoucher.AccountNo = Validation.GetSafeLong(objReader["AccountNo"]);
                        oelVoucher.SubAccountNo = Validation.GetSafeString(objReader["EmpCode"]);
                        oelVoucher.VoucherType = "BankPaymentVoucher";
                    }
                    else if (VoucherType == "BankReceiptVoucher")
                    {
                        //oelVoucher.AccountNo = Validation.GetSafeLong(objReader["AccountNo"]);
                        oelVoucher.SubAccountNo = Validation.GetSafeString(objReader["EmpCode"]);
                        oelVoucher.VoucherType = "BankReceiptVoucher";
                    }
                    else if (VoucherType == "PrescriberSampleVoucher")
                    {
                        oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        oelVoucher.VoucherType = "PrescriberSampleVoucher";
                    }
                    else if (VoucherType == "PrescriberSampleVoucher")
                    {
                        oelVoucher.VoucherType = "JournalVoucher";
                    }
                    if (VoucherType != "PaymentVoucher" && VoucherType != "CashReceiptVoucher" && VoucherType != "SaleInvoiceVoucher" && VoucherType != "SalesReturnVoucher" && VoucherType != "BankPaymentVoucher" && VoucherType != "BankReceiptVoucher" && VoucherType != "PrescriberSampleVoucher" && VoucherType != "JournalVoucher")
                    {
                        if (objReader["BillNo"] != DBNull.Value)
                        {
                            oelVoucher.BillNo = objReader["BillNo"].ToString();
                        }
                        else
                        {
                            oelVoucher.BillNo = "";
                        }
                    }
                    if (VoucherType != "JournalVoucher")
                    {
                        //oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    }
                    if (VoucherType == "PrescriberSampleVoucher")
                    {
                        oelVoucher.Description = Convert.ToString(objReader["Discription"] ?? "");
                    }
                    else
                    {
                        if (VoucherType != "JournalVoucher")
                        {
                            oelVoucher.Description = Convert.ToString(objReader["Description"] ?? "");
                        }
                    }
                    oelVoucher.Amount = Convert.ToInt64(objReader["Amount"]);
                    oelVoucher.Posted = Convert.ToBoolean(objReader["Posted"]);
                    list.Add(oelVoucher);
                }
            }
            return list;
        }
        public string GetMaxVoucherNumber(string VoucherType, Guid IdCompany, SqlConnection objConn)
        {
            using (SqlCommand cmdVouchers = new SqlCommand("[Transactions].[Proc_GetMaxVoucherNumber]", objConn))
            {
                cmdVouchers.CommandType = CommandType.StoredProcedure;
                cmdVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdVouchers.Parameters.Add("@VoucherType", SqlDbType.NVarChar).Value = VoucherType;
                return cmdVouchers.ExecuteScalar().ToString();
            }
        }
        public string GetMaxVehicleNumber(Guid IdCompany, Int64 VoucherNo, SqlConnection objConn)
        {
            using (SqlCommand cmdVouchers = new SqlCommand("[Transactions].[Proc_GetMaxVehicleNumber]", objConn))
            {
                cmdVouchers.CommandType = CommandType.StoredProcedure;
                cmdVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdVouchers.Parameters.Add("@VoucherNo", SqlDbType.BigInt).Value = VoucherNo;
                return cmdVouchers.ExecuteScalar().ToString();
            }
        }
        public List<PersonsEL> GetStockSupplier(Int64 AccountNo, Int64 VoucherNo, Guid IdCompany, SqlConnection objConn)
        {
            List<PersonsEL> oelPersonCollection = new List<PersonsEL>();
            using (SqlCommand cmdTransaction = new SqlCommand("[Transactions].[Proc_GetStockSupplier]", objConn))
            {
                cmdTransaction.CommandType = CommandType.StoredProcedure;
                cmdTransaction.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdTransaction.Parameters.Add("@VoucherNo", SqlDbType.BigInt).Value = VoucherNo;
                cmdTransaction.Parameters.Add("@AccountNo", SqlDbType.BigInt).Value = AccountNo;
                objReader = cmdTransaction.ExecuteReader();
                while (objReader.Read())
                {
                    PersonsEL oelPerson = new PersonsEL();
                    oelPerson.PAccountId = Validation.GetSafeGuid(objReader["transaction_id"]);
                    oelPerson.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelPerson.PersonName = objReader["PersonName"].ToString();
                    oelPerson.Contact = objReader["Contact"].ToString();
                    oelPerson.Address = objReader["Address"].ToString();
                    oelPerson.NTN = objReader["NTN"].ToString();
                    //oelTransaction.TransactionID = new Guid(objReader["Transaction_Id"].ToString());
                    //oelTransaction.AccountNo = objReader["AccountNo"].ToString();
                    //oelTransaction.Date = Convert.ToDateTime(objReader["Date"]);
                    //oelTransaction.VoucherNo = Convert.ToInt32(objReader["VoucherNo"]);
                    //oelTransaction.Qty = Convert.ToInt32(objReader["qty"]);                   
                    //oelTransaction.Debit = Convert.ToDecimal(objReader["Debit"]);
                    //oelTransaction.Credit = Convert.ToDecimal(objReader["Credit"]);
                    //oelTransaction.Description = objReader["Description"].ToString();


                    oelPersonCollection.Add(oelPerson);
                }
            }
            return oelPersonCollection;
        }
        public List<PersonsEL> GetSaleCustomer(Guid IdVoucher, string AccountNo, Guid IdCompany, SqlConnection objConn)
        {
            List<PersonsEL> list = new List<PersonsEL>();
            using (SqlCommand cmdSaleCustomer = new SqlCommand("[Transactions].[Proc_GetSaleCustomer]", objConn))
            {
                cmdSaleCustomer.CommandType = CommandType.StoredProcedure;
                cmdSaleCustomer.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSaleCustomer.Parameters.Add("@IdVoucher", SqlDbType.UniqueIdentifier).Value = IdVoucher;
                cmdSaleCustomer.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                objReader = cmdSaleCustomer.ExecuteReader();
                while (objReader.Read())
                {
                    PersonsEL oelPerson = new PersonsEL();
                    oelPerson.PAccountId = Validation.GetSafeGuid(objReader["transaction_id"]);
                    oelPerson.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelPerson.SubAccountNo = Validation.GetSafeString(objReader["EmpCode"]);
                    oelPerson.PersonName = objReader["PersonName"].ToString();
                    //oelPerson.Contact = objReader["Contact"].ToString();
                    //oelPerson.Address = objReader["Address"].ToString();
                    //oelPerson.NTN = objReader["NTN"].ToString();
                    oelPerson.Balance = Validation.GetSafeDecimal(objReader["Amount"]);
                    list.Add(oelPerson);
                }
            }
            return list;
        }
        public List<PersonsEL> GetSalesReturnCustomer(Guid IdVoucher, string AccountNo, Guid IdCompany, SqlConnection objConn)
        {
            List<PersonsEL> list = new List<PersonsEL>();
            using (SqlCommand cmdSaleCustomer = new SqlCommand("[Transactions].[Proc_GetSalesReturnCustomer]", objConn))
            {
                cmdSaleCustomer.CommandType = CommandType.StoredProcedure;
                cmdSaleCustomer.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSaleCustomer.Parameters.Add("@IdVoucher", SqlDbType.BigInt).Value = IdVoucher;
                cmdSaleCustomer.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                objReader = cmdSaleCustomer.ExecuteReader();
                while (objReader.Read())
                {
                    PersonsEL oelPerson = new PersonsEL();
                    oelPerson.PAccountId = Validation.GetSafeGuid(objReader["transaction_id"]);
                    oelPerson.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelPerson.SubAccountNo = Validation.GetSafeString(objReader["EmpCode"]);
                    oelPerson.PersonName = objReader["PersonName"].ToString();
                    oelPerson.Contact = objReader["Contact"].ToString();
                    oelPerson.Address = objReader["Address"].ToString();
                    oelPerson.NTN = objReader["NTN"].ToString();
                    oelPerson.Balance = Validation.GetSafeDecimal(objReader["Amount"]);

                    list.Add(oelPerson);
                }
            }
            return list;
        }
        public List<PersonsEL> GetSampleCustomer(Int64 SampleNumber, string AccountNo, string Transactiontype, Guid IdCompany, SqlConnection objConn)
        {
            List<PersonsEL> list = new List<PersonsEL>();
            using (SqlCommand cmdSaleCustomer = new SqlCommand("[Transactions].[Proc_GetSampleCustomer]", objConn))
            {
                cmdSaleCustomer.CommandType = CommandType.StoredProcedure;
                cmdSaleCustomer.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSaleCustomer.Parameters.Add("@VoucherNo", SqlDbType.BigInt).Value = SampleNumber;
                cmdSaleCustomer.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
                cmdSaleCustomer.Parameters.Add("@TransactionType", SqlDbType.VarChar).Value = Transactiontype;
                objReader = cmdSaleCustomer.ExecuteReader();
                while (objReader.Read())
                {
                    PersonsEL oelPerson = new PersonsEL();
                    oelPerson.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelPerson.SubAccountNo = Validation.GetSafeString(objReader["EmpCode"]);
                    oelPerson.PersonName = objReader["PersonName"].ToString();
                    oelPerson.Contact = objReader["Contact"].ToString();
                    oelPerson.Address = objReader["Address"].ToString();
                    oelPerson.NTN = objReader["NTN"].ToString();
                    oelPerson.Balance = Validation.GetSafeDecimal(objReader["Amount"]);
                    list.Add(oelPerson);
                }
            }
            return list;
        }
        public List<TransactionsEL> GetTransactionsByVoucherAndType(Guid IdCompany, Guid IdVoucher, Int64 VoucherNo, string VoucherType, SqlConnection objConn)
        {
            List<TransactionsEL> oelTransactionCollection = new List<TransactionsEL>();
            using (SqlCommand cmdTransaction = new SqlCommand("[Transactions].[Proc_GetTransactionsByVoucherAndType]", objConn))
            {
                cmdTransaction.CommandType = CommandType.StoredProcedure;
                cmdTransaction.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdTransaction.Parameters.Add("@IdVoucher", SqlDbType.UniqueIdentifier).Value = IdVoucher;
                cmdTransaction.Parameters.Add("@VoucherNo", SqlDbType.BigInt).Value = VoucherNo;
                cmdTransaction.Parameters.Add("@VoucherType", SqlDbType.NVarChar).Value = VoucherType;
                objReader = cmdTransaction.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    //oelTransaction.TransactionID = new Guid(objReader["Transaction_Id"].ToString());

                    oelTransaction.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    if (VoucherType != "PurchaseReturnVoucher" && VoucherType != "WorkProcess")
                    {
                        oelTransaction.LinkAccountNo = Validation.GetSafeString(objReader["LinkAccountNo"]);
                    }
                    oelTransaction.AccountName = objReader["AccountName"].ToString();
                    //oelTransaction.Date = Convert.ToDateTime(objReader["VDate"]);
                    //oelTransaction.VoucherNo = Convert.ToInt32(objReader["VoucherNo"]);

                    oelTransaction.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);
                    //oelTransaction.Description = objReader["Description"].ToString();
                    // oelTransaction.Amount = Convert.ToDecimal(objReader["Amount"]);                   
                    if (VoucherType == "StockReceiptVoucher")
                    {
                        if (objReader["VoucherDetail_Id"] != DBNull.Value)
                        {

                            oelTransaction.IdDetail = Validation.GetSafeGuid(objReader["VoucherDetail_Id"].ToString());
                            oelTransaction.VDiscription = Validation.GetSafeString(objReader["VDiscription"]);
                            oelTransaction.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                            //oelTransaction.BatchNo = Validation.GetSafeString(objReader["BatchNo"]);
                            oelTransaction.Qty = Validation.GetSafeDecimal(objReader["units"]);
                            //oelTransaction.Bonus = Validation.GetSafeLong(objReader["Bonus"]);
                            oelTransaction.unitprice = Validation.GetSafeDecimal(objReader["UnitPrice"]);
                            oelTransaction.Discount = Validation.GetSafeDecimal(objReader["Disc"]);
                            //oelTransaction.Expiry = Validation.GetSafeString(objReader["Expiry"]);
                            oelTransaction.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);
                        }
                        oelTransaction.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                        //oelTransaction.unitprice = Convert.ToDecimal(objReader["unitprice"]);
                    }
                    if (VoucherType == "WorkProcess")
                    {
                        if (objReader["VoucherDetail_Id"] != DBNull.Value)
                        {

                            oelTransaction.IdDetail = Validation.GetSafeGuid(objReader["VoucherDetail_Id"].ToString());
                            oelTransaction.Qty = Validation.GetSafeInteger(objReader["units"]);
                            oelTransaction.MeterYardQty = Validation.GetSafeDecimal(objReader["YardQty"]);
                            oelTransaction.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                            //oelTransaction.Bonus = Validation.GetSafeLong(objReader["Bonus"]);
                            oelTransaction.unitprice = Validation.GetSafeDecimal(objReader["UnitPrice"]); ;
                            oelTransaction.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);
                        }
                        oelTransaction.IdAccount = Validation.GetSafeGuid(objReader["Item_Id"]);
                        //oelTransaction.unitprice = Convert.ToDecimal(objReader["unitprice"]);
                    }
                    if (VoucherType == "PurchaseReturnVoucher")
                    {
                        if (objReader["VoucherDetail_Id"] != DBNull.Value)
                        {

                            oelTransaction.IdDetail = Validation.GetSafeGuid(objReader["VoucherDetail_Id"].ToString());
                            oelTransaction.Discription = Validation.GetSafeString(objReader["Discription"]);
                            oelTransaction.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                            //oelTransaction.BatchNo = Validation.GetSafeString(objReader["BatchNo"]);
                            oelTransaction.Qty = Validation.GetSafeInteger(objReader["units"]);
                            //oelTransaction.Bonus = Validation.GetSafeLong(objReader["Bonus"]);
                            oelTransaction.unitprice = Validation.GetSafeDecimal(objReader["UnitPrice"]);
                            oelTransaction.Discount = Validation.GetSafeDecimal(objReader["Disc"]);
                            //oelTransaction.Expiry = Validation.GetSafeString(objReader["Expiry"]);
                            oelTransaction.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);
                        }
                        oelTransaction.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                        //oelTransaction.unitprice = Convert.ToDecimal(objReader["unitprice"]);
                    }
                    else if (VoucherType == "JournalVoucher" || VoucherType == "PaymentVoucher" || VoucherType == "CashReceiptVoucher" || VoucherType == VoucherTypes.BankPaymentVoucher.ToString() || VoucherType == VoucherTypes.BankReceiptVoucher.ToString())
                    {
                        oelTransaction.IdDetail = Validation.GetSafeGuid(objReader["VoucherDetail_Id"]);
                        oelTransaction.TransactionID = Validation.GetSafeGuid(objReader["Transaction_Id"]);
                        oelTransaction.AccountType = Validation.GetSafeString(objReader["AccountType"]);
                        oelTransaction.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);
                        oelTransaction.IdAccount = Validation.GetSafeGuid(objReader["Account_Id"]);
                        oelTransaction.ClosingBalance = Convert.ToDecimal(objReader["ClosingBalance"]);
                        oelTransaction.Debit = Convert.ToDecimal(objReader["Debit"]);
                        oelTransaction.Credit = Convert.ToDecimal(objReader["Credit"]);
                        oelTransaction.VDiscription = Validation.GetSafeString(objReader["VDiscription"]);                        
                    }
                    //oelTransaction.PersonName = objReader["PersonName"].ToString();
                    oelTransactionCollection.Add(oelTransaction);
                }
            }
            return oelTransactionCollection;
        }
        public List<VouchersEL> GetUnPostedVouchers(Guid IdCompany, string VoucherType, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdUnPostedVouchers = new SqlCommand("[Transactions].[Proc_GetUnPostedVouchers]", objConn))
            {
                cmdUnPostedVouchers.CommandType = CommandType.StoredProcedure;
                cmdUnPostedVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdUnPostedVouchers.Parameters.Add("@VoucherType", SqlDbType.NVarChar).Value = VoucherType;
                objReader = cmdUnPostedVouchers.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL obj = new VouchersEL();
                    obj.VoucherNo = Convert.ToInt64(objReader["VoucherNo"]);
                    obj.Date = Convert.ToDateTime(objReader["VDate"]);
                    if (VoucherType != "JournalVoucher" && VoucherType != "BankPaymentVoucher" && VoucherType != "BankReceiptVoucher" && VoucherType != "PaymentVoucher"
                        && VoucherType != "CashReceiptVoucher")
                    {
                        obj.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                        obj.PersonName = Convert.ToString(objReader["AccountName"]);
                    }
                    obj.Amount = Convert.ToDecimal(objReader["TotalAmount"]);
                    if (VoucherType == "BankPaymentVoucher")
                    {
                        //obj.ChequeNo = objReader["ChequeNo"].ToString();
                    }
                    else if (VoucherType == "BankReceiptVoucher")
                    {
                        //obj.ChequeNo = objReader["ChequeNo"].ToString();
                    }
                    list.Add(obj);
                }
            }
            return list;
        }
        public EntityoperationInfo PostUnPostedVouchers(string VoucherType, Int64 VoucherNo, Guid IdCompany, SqlConnection objConn)
        {
            int status;
            EntityoperationInfo resultInfo = new EntityoperationInfo();
            using (SqlCommand cmdPostVoucher = new SqlCommand("[Transactions].[Proc_PostUnpostedVouchers]", objConn))
            {
                try
                {
                    cmdPostVoucher.CommandType = CommandType.StoredProcedure;
                    cmdPostVoucher.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                    cmdPostVoucher.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = VoucherNo;
                    cmdPostVoucher.Parameters.Add(new SqlParameter("@VoucherType", DbType.Int64)).Value = VoucherType;
                    status = cmdPostVoucher.ExecuteNonQuery();
                    if (status > -1)
                    {
                        resultInfo.IsSuccess = true;
                    }
                    else
                    {
                        resultInfo.IsSuccess = false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resultInfo;
        }
        public List<TransactionsEL> GetTransactions(Guid IdVoucher, string VoucherType, Guid IdCompany, SqlConnection objConn)
        {
            List<TransactionsEL> list = new List<TransactionsEL>();
            using (SqlCommand cmdSaleCustomer = new SqlCommand("[Transactions].[Proc_GetTransactions]", objConn))
            {
                cmdSaleCustomer.CommandType = CommandType.StoredProcedure;
                cmdSaleCustomer.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                cmdSaleCustomer.Parameters.Add("@IdVoucher", SqlDbType.UniqueIdentifier).Value = IdVoucher;
                cmdSaleCustomer.Parameters.Add("@VoucherType", SqlDbType.VarChar).Value = VoucherType;
                objReader = cmdSaleCustomer.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();
                    oelTransaction.TransactionID = Validation.GetSafeGuid(objReader["transaction_id"]);
                    oelTransaction.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelTransaction.LinkAccountNo = Validation.GetSafeString(objReader["LinkAccountNo"]);
                    oelTransaction.SubAccountNo = Validation.GetSafeString(objReader["EmpCode"]);
                    oelTransaction.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    if (VoucherType == "StockReceiptVoucher/Sub")
                    {
                        oelTransaction.AccountType = Validation.GetSafeString(objReader["AccountType"]);
                        oelTransaction.Description = Validation.GetSafeString(objReader["Description"]);
                        oelTransaction.ClosingBalance = Validation.GetSafeDecimal(objReader["ClosingBalance"]);
                    }
                    oelTransaction.Debit = Validation.GetSafeDecimal(objReader["Debit"]);
                    oelTransaction.Credit = Validation.GetSafeDecimal(objReader["Credit"]);

                    list.Add(oelTransaction);
                }
            }
            return list;
        }
        public EntityoperationInfo UpdateDaysStatus(VouchersEL oelVoucher, int IsSale, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlTransaction objTran = objConn.BeginTransaction();
            SqlCommand cmdVoucherHead = new SqlCommand("[Transactions].[Proc_UpdateDaysStatus]", objConn);
            try
            {
                cmdVoucherHead.Transaction = objTran;
                cmdVoucherHead.CommandType = CommandType.StoredProcedure;


                cmdVoucherHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelVoucher.IdCompany;
                cmdVoucherHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelVoucher.VoucherNo;
                cmdVoucherHead.Parameters.Add(new SqlParameter("@IsSale", DbType.Int32)).Value = IsSale;

                cmdVoucherHead.ExecuteNonQuery();

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
        public bool CheckVoucherNo(Guid? IdCompany, Int64 VoucherNo, string VoucherType, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdVoucherHead = new SqlCommand("[Transactions].[Proc_CheckVoucherNo]", objConn);
            cmdVoucherHead.CommandType = CommandType.StoredProcedure;
            List<VouchersEL> list = new List<VouchersEL>();

            cmdVoucherHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany.Value;
            cmdVoucherHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = VoucherNo;
            cmdVoucherHead.Parameters.Add(new SqlParameter("@VoucherType", DbType.Int32)).Value = VoucherType;
            objReader = cmdVoucherHead.ExecuteReader();
            while (objReader.Read())
            {
                VouchersEL oelVoucher = new VouchersEL();
                oelVoucher.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                list.Add(oelVoucher);
            }
            if (list.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //public List<VouchersEL> GetAllVouchersByType(Guid IdCompany, string VoucherType, SqlConnection objConn)
        //{
        //    List<VouchersEL> list = new List<VouchersEL>();
        //    using (SqlCommand cmdVouchers = new SqlCommand("[Transactions].[Proc_GetAllVouchersByType]", objConn))
        //    {
        //        cmdVouchers.CommandType = CommandType.StoredProcedure;
        //        cmdVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
        //        cmdVouchers.Parameters.Add("@VoucherType", SqlDbType.VarChar).Value = VoucherType;
        //        objReader = cmdVouchers.ExecuteReader();
        //        while (objReader.Read())
        //        {
        //            VouchersEL oelVoucher = new VouchersEL();

        //            oelVoucher.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
        //            oelVoucher.VoucherNo = Convert.ToInt64(objReader["VoucherNo"]);
        //            oelVoucher.Date = Convert.ToDateTime(objReader["VDate"]);
        //            if (VoucherType == "StockReceiptVoucher")
        //            {
        //                oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
        //                oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
        //                oelVoucher.VoucherType = "StockReceiptVoucher";
        //            }
        //            else if (VoucherType == "CashReceiptVoucher")
        //            {
        //                //oelVoucher.AccountNo = Validation.GetSafeLong(objReader["AccountNo"]);
        //                oelVoucher.SubAccountNo = Validation.GetSafeString(objReader["EmpCode"]);
        //                oelVoucher.VoucherType = "Receipt Voucher";
        //            }
        //            else if (VoucherType == "PaymentVoucher")
        //            {
        //                //oelVoucher.AccountNo = Validation.GetSafeLong(objReader["AccountNo"]);
        //                oelVoucher.SubAccountNo = Validation.GetSafeString(objReader["EmpCode"]);
        //                oelVoucher.VoucherType = "Payment Voucher";
        //            }
        //            else if (VoucherType == "SaleInvoiceVoucher")
        //            {
        //                oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
        //                oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
        //                oelVoucher.MemoSaleNo = Validation.GetSafeLong(objReader["MemoSaleNo"]);
        //                oelVoucher.VoucherType = "Invoice Voucher";
        //            }
        //            else if (VoucherType == "SalesReturnVoucher")
        //            {
        //                oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
        //                oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
        //                oelVoucher.VoucherType = "SalesReturnVoucher";
        //            }
        //            else if (VoucherType == "BankPaymentVoucher")
        //            {
        //                //oelVoucher.AccountNo = Validation.GetSafeLong(objReader["AccountNo"]);
        //                oelVoucher.SubAccountNo = Validation.GetSafeString(objReader["EmpCode"]);
        //                oelVoucher.VoucherType = "BankPaymentVoucher";
        //            }
        //            else if (VoucherType == "BankReceiptVoucher")
        //            {
        //                //oelVoucher.AccountNo = Validation.GetSafeLong(objReader["AccountNo"]);
        //                oelVoucher.SubAccountNo = Validation.GetSafeString(objReader["EmpCode"]);
        //                oelVoucher.VoucherType = "BankReceiptVoucher";
        //            }
        //            else if (VoucherType == "PrescriberSampleVoucher")
        //            {
        //                oelVoucher.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
        //                oelVoucher.VoucherType = "PrescriberSampleVoucher";
        //            }
        //            else if (VoucherType == "PrescriberSampleVoucher")
        //            {
        //                oelVoucher.VoucherType = "JournalVoucher";
        //            }
        //            if (VoucherType != "PaymentVoucher" && VoucherType != "CashReceiptVoucher" && VoucherType != "SaleInvoiceVoucher" && VoucherType != "SalesReturnVoucher" && VoucherType != "BankPaymentVoucher" && VoucherType != "BankReceiptVoucher" && VoucherType != "PrescriberSampleVoucher" && VoucherType != "JournalVoucher")
        //            {
        //                if (objReader["BillNo"] != DBNull.Value)
        //                {
        //                    oelVoucher.BillNo = objReader["BillNo"].ToString();
        //                }
        //                else
        //                {
        //                    oelVoucher.BillNo = "";
        //                }
        //            }
        //            if (VoucherType != "JournalVoucher")
        //            {
        //                //oelVoucher.AccountName = Validation.GetSafeString(objReader["AccountName"]);
        //            }
        //            if (VoucherType == "PrescriberSampleVoucher")
        //            {
        //                oelVoucher.Description = Convert.ToString(objReader["Discription"] ?? "");
        //            }
        //            else
        //            {
        //                if (VoucherType != "JournalVoucher")
        //                {
        //                    oelVoucher.Description = Convert.ToString(objReader["Description"] ?? "");
        //                }
        //            }
        //            oelVoucher.Amount = Convert.ToInt64(objReader["Amount"]);
        //            oelVoucher.Posted = Convert.ToBoolean(objReader["Posted"]);
        //            list.Add(oelVoucher);
        //        }
        //    }
        //    return list;
        //}
        public List<VouchersEL> GetAllVehicles(Guid IdCompany, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdVouchers = new SqlCommand("[Transactions].[Proc_GetAllVehicles]", objConn))
            {
                cmdVouchers.CommandType = CommandType.StoredProcedure;
                cmdVouchers.Parameters.Add("@IdCompany", SqlDbType.UniqueIdentifier).Value = IdCompany;
                objReader = cmdVouchers.ExecuteReader();
                while (objReader.Read())
                {
                    VouchersEL oelVoucher = new VouchersEL();
                    oelVoucher.VehicalNo = Validation.GetSafeString(objReader["VehicalNo"]);
                    list.Add(oelVoucher);
                }
            }
            return list;
        }

        public List<VouchersEL> GetStockVouchersByUserAndDateForActivity(Guid IdUser, DateTime ActivityDate, string VType, SqlConnection objConn)
        {
            List<VouchersEL> list = new List<VouchersEL>();
            using (SqlCommand cmdBalanceSheetAccounts = new SqlCommand("[Transactions].[Proc_GetStockVouchersByUserAndDateForActivity]", objConn))
            {
                cmdBalanceSheetAccounts.CommandType = CommandType.StoredProcedure;
                cmdBalanceSheetAccounts.Parameters.Add("@IdUser", SqlDbType.UniqueIdentifier).Value = IdUser;
                cmdBalanceSheetAccounts.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = ActivityDate;
                cmdBalanceSheetAccounts.Parameters.Add("@VoucherType", SqlDbType.VarChar).Value = VType;
                objReader = cmdBalanceSheetAccounts.ExecuteReader();
                while (objReader.Read())
                {
                    TransactionsEL oelTransaction = new TransactionsEL();

                    oelTransaction.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                    oelTransaction.TotalAmount = Validation.GetSafeDecimal(objReader["Amount"]);
                    oelTransaction.CreatedDateTime = Validation.GetSafeDateTime(objReader["VDate"]);
                    oelTransaction.Posted = Validation.GetSafeBoolean(objReader["Posted"]);

                    list.Add(oelTransaction);
                }
            }
            return list;
        }
    }
}
