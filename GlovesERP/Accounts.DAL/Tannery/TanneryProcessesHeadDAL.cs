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
    public class TanneryProcessesHeadDAL
    {
        IDataReader objReader;
        TanneryProcessesDAL PDal;
        public TanneryProcessesHeadDAL()
        {
            PDal = new TanneryProcessesDAL();
        }
        public EntityoperationInfo CreateProcessHead(TanneryProcessesHeadEL oelProcessHead, TanneryProcessesEL oelTanneryProcess, List<TanneryProcessDetailsEL> oelDetailCollection, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlTransaction objTran = objConn.BeginTransaction();
            SqlCommand cmdProcessHead = new SqlCommand("[Tannery].[Proc_CreateProcessHead]", objConn, objTran);

            cmdProcessHead.CommandType = CommandType.StoredProcedure;
            cmdProcessHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelProcessHead.IdVoucher;
            cmdProcessHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelProcessHead.IdCompany;
            cmdProcessHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelProcessHead.VoucherNo;
            cmdProcessHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelProcessHead.UserId;
            cmdProcessHead.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = oelProcessHead.VehicleNo;
            cmdProcessHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelProcessHead.VDate;
            cmdProcessHead.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelProcessHead.Description;
            cmdProcessHead.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelProcessHead.Amount;
            cmdProcessHead.Parameters.Add(new SqlParameter("@IsComplete", DbType.Boolean)).Value = oelProcessHead.IsComplete;
            cmdProcessHead.Parameters.Add(new SqlParameter("@CloseDate", DbType.DateTime)).Value = oelProcessHead.CloseDate;

            if (!IsProcessHeadExists(oelProcessHead.IdVoucher, oelProcessHead.IdCompany,objConn,objTran))
            {
                if (cmdProcessHead.ExecuteNonQuery() > -1)
                {
                    infoResult.IsSuccess = true;
                }
                else
                {
                    infoResult.IsSuccess = false;
                }
            }

            PDal.CreateProcesses(oelTanneryProcess, oelDetailCollection, objConn, objTran);

            objTran.Commit();

            infoResult.IsSuccess = true;

            return infoResult;
        }
        public EntityoperationInfo UpdateProcessHead(TanneryProcessesHeadEL oelProcessHead, TanneryProcessesEL oelTanneryProcess, List<TanneryProcessDetailsEL> oelDetailCollection, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlTransaction objTran = objConn.BeginTransaction();

            SqlCommand cmdProcessHead = new SqlCommand("[Tannery].[Proc_UpdateProcessHead]", objConn,objTran);
            
            cmdProcessHead.CommandType = CommandType.StoredProcedure;
            cmdProcessHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelProcessHead.IdVoucher;
            cmdProcessHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelProcessHead.IdCompany;
            cmdProcessHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelProcessHead.VoucherNo;
            cmdProcessHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelProcessHead.UserId;
            cmdProcessHead.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = oelProcessHead.VehicleNo;
            cmdProcessHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelProcessHead.VDate;
            cmdProcessHead.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelProcessHead.Description;
            cmdProcessHead.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelProcessHead.Amount;
            cmdProcessHead.Parameters.Add(new SqlParameter("@IsComplete", DbType.Boolean)).Value = oelProcessHead.IsComplete;
            cmdProcessHead.Parameters.Add(new SqlParameter("@CloseDate", DbType.DateTime)).Value = oelProcessHead.CloseDate;

            //if (cmdItems.ExecuteNonQuery() > -1 && cmdAccounts.ExecuteNonQuery() > -1)
            if (cmdProcessHead.ExecuteNonQuery() > -1)
            {
                infoResult.IsSuccess = true;
            }
            else
            {
                infoResult.IsSuccess = false;
            }

            PDal.UpdateProcesses(oelTanneryProcess, oelDetailCollection, objConn, objTran);

            objTran.Commit();

            return infoResult;
        }
        private bool IsProcessHeadExists(Guid IdVoucher, Guid? IdCompany, SqlConnection objConn, SqlTransaction objTran)
        {
            bool Status = false;
            SqlCommand cmdProcessHead = new SqlCommand("[Tannery].[Proc_IsProcessHeadExists]", objConn, objTran);

            cmdProcessHead.CommandType = CommandType.StoredProcedure;
            cmdProcessHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = IdVoucher;
            cmdProcessHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany.Value;
            objReader = cmdProcessHead.ExecuteReader();
            while (objReader.Read())
            {
                Status = true;
                break;
            }
            objReader.Close();
            return Status;
        }
        public Int64 GetMaxProductionCode(Guid IdCompany, SqlConnection objConn)
        {
            SqlCommand cmdProductionHead = new SqlCommand("[Tannery].[Proc_GetMaxProductionCode]", objConn);
            cmdProductionHead.CommandType = CommandType.StoredProcedure;
            cmdProductionHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            return Validation.GetSafeLong(cmdProductionHead.ExecuteScalar());

        }
        public EntityoperationInfo UpdateProcessEntries(Guid IdEntity,string ProcessName, Guid IdVoucher, bool Posted, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();

            SqlCommand cmdProcess = new SqlCommand("[Tannery].[Proc_UpdateProcessDetailEntry]", objConn);

            cmdProcess.CommandType = CommandType.StoredProcedure;
            cmdProcess.Parameters.Add(new SqlParameter("@IdEntity", DbType.Guid)).Value = IdEntity;
            cmdProcess.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = ProcessName;
            cmdProcess.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = IdVoucher;
            cmdProcess.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = Posted;

            //if (cmdItems.ExecuteNonQuery() > -1 && cmdAccounts.ExecuteNonQuery() > -1)
            if (cmdProcess.ExecuteNonQuery() > -1)
            {
                infoResult.IsSuccess = true;
            }
            else
            {
                infoResult.IsSuccess = false;
            }
            return infoResult;
        }
        public List<TanneryProcessesHeadEL> GetVoucherInfoByVehicleNo(string VehicleNo, SqlConnection objConn)
        {
            List<TanneryProcessesHeadEL> list = new List<TanneryProcessesHeadEL>();
            SqlCommand cmdProfitLoss = new SqlCommand("[Tannery].[Proc_GetVoucherInfoByVehicleNo]", objConn);
            cmdProfitLoss.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = VehicleNo;
            cmdProfitLoss.CommandType = CommandType.StoredProcedure;
            objReader = cmdProfitLoss.ExecuteReader();
            while (objReader.Read())
            {
                TanneryProcessesHeadEL oelHead = new TanneryProcessesHeadEL();
                oelHead.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                oelHead.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                list.Add(oelHead);
            }
            return list;
        }
        public List<TanneryProcessesHeadEL> GetVoucherInfoByVoucherNo(Int64 VoucherNo, SqlConnection objConn)
        {
            List<TanneryProcessesHeadEL> list = new List<TanneryProcessesHeadEL>();
            SqlCommand cmdVoucherInfo = new SqlCommand("[Tannery].[Proc_GetVoucherInfoByVoucherNo]", objConn);
            cmdVoucherInfo.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = VoucherNo;
            cmdVoucherInfo.CommandType = CommandType.StoredProcedure;
            objReader = cmdVoucherInfo.ExecuteReader();
            while (objReader.Read())
            {
                TanneryProcessesHeadEL oelHead = new TanneryProcessesHeadEL();
                oelHead.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                oelHead.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                list.Add(oelHead);
            }
            return list;
        }
        public List<TanneryProcessesHeadEL> GetVehicleProfitAndLoss(string VehicleNo, SqlConnection objConn)
        {
            List<TanneryProcessesHeadEL> list = new List<TanneryProcessesHeadEL>();
            SqlCommand cmdProfitLoss = new SqlCommand("[Tannery].[Proc_GetVehicleProfitAndLoss]", objConn);
            cmdProfitLoss.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = VehicleNo;
            cmdProfitLoss.CommandType = CommandType.StoredProcedure;
            objReader = cmdProfitLoss.ExecuteReader();
            while (objReader.Read())
            {
                TanneryProcessesHeadEL oelProfit = new TanneryProcessesHeadEL();
                oelProfit.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelProfit.Amount = Validation.GetSafeDecimal(objReader["Expense"]);

                list.Add(oelProfit);
            }
            return list;
        }

        public List<TanneryProcessesHeadEL> GetAllVehicleProfitAndLoss(SqlConnection objConn)
        {
            List<TanneryProcessesHeadEL> list = new List<TanneryProcessesHeadEL>();
            SqlCommand cmdProfitLoss = new SqlCommand("[Tannery].[Proc_GetAllVehicalProfitAndLoss]", objConn);
            //cmdProfitLoss.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = VehicleNo;
            cmdProfitLoss.CommandType = CommandType.StoredProcedure;
            objReader = cmdProfitLoss.ExecuteReader();
            while (objReader.Read())
            {
                TanneryProcessesHeadEL oelProfit = new TanneryProcessesHeadEL();
                oelProfit.VehicalNo = Validation.GetSafeString(objReader["VehicalNo"]);
                oelProfit.Credit = Validation.GetSafeDecimal(objReader["Credit"]);
                oelProfit.Debit = Validation.GetSafeDecimal(objReader["Debit"]);
                oelProfit.ClosingBalance = oelProfit.Credit - oelProfit.Debit;

                list.Add(oelProfit);
            }
            return list;
        }
        public List<TanneryProcessesHeadEL> GetVehiclesByStatus(int Status,SqlConnection objConn)
        {
            List<TanneryProcessesHeadEL> list = new List<TanneryProcessesHeadEL>();
            SqlCommand cmdVehicles = new SqlCommand("[Tannery].[Proc_GetVehiclesByStatus]", objConn);
            cmdVehicles.Parameters.Add(new SqlParameter("@Status", DbType.String)).Value = Status;
            cmdVehicles.CommandType = CommandType.StoredProcedure;
            objReader = cmdVehicles.ExecuteReader();
            while (objReader.Read())
            {
                TanneryProcessesHeadEL oelTannery = new TanneryProcessesHeadEL();
                oelTannery.VehicleNo = Validation.GetSafeString(objReader["Vehicleno"]);
                oelTannery.IsComplete = Validation.GetSafeBooleanNullable(objReader["IsComplete"]);
                list.Add(oelTannery);
            }
            return list;
        }
        public EntityoperationInfo CompleteVehicle(Guid IdVoucher, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();

            SqlCommand cmdCompleteVehicle = new SqlCommand("[Tannery].[CompleteVehicle]", objConn);

            cmdCompleteVehicle.CommandType = CommandType.StoredProcedure;
            cmdCompleteVehicle.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = IdVoucher;

            if (cmdCompleteVehicle.ExecuteNonQuery() > -1)
            {
                infoResult.IsSuccess = true;
            }
            else
            {
                infoResult.IsSuccess = false;
            }
            return infoResult;
        }
        //public List<CategoryEL> GetCategoryById(Guid IdCategory, SqlConnection objConn)
        //{
        //    List<CategoryEL> list = new List<CategoryEL>();
        //    SqlCommand cmdCategory = new SqlCommand("[Setup].[Proc_GetCategoryById]", objConn);

        //    cmdCategory.Parameters.Add("@IdCategory", SqlDbType.UniqueIdentifier).Value = IdCategory;

        //    cmdCategory.CommandType = CommandType.StoredProcedure;
        //    objReader = cmdCategory.ExecuteReader();
        //    while (objReader.Read())
        //    {
        //        CategoryEL oelCategory = new CategoryEL();
        //        oelCategory.IdCategory = Validation.GetSafeGuid(objReader["Category_Id"]);
        //        oelCategory.CategoryCode = Validation.GetSafeString(objReader["Category_Code"]);
        //        oelCategory.CategoryName = Validation.GetSafeString(objReader["Category_Name"]);
        //        oelCategory.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
        //        oelCategory.IsActive = Validation.GetSafeBooleanNullable(objReader["IsActive"]);
        //        oelCategory.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);
        //        list.Add(oelCategory);
        //    }
        //    return list;
        //}
        //public List<CategoryEL> GetAllCategories(Guid IdCompany, SqlConnection objConn)
        //{
        //    List<CategoryEL> list = new List<CategoryEL>();
        //    SqlCommand cmdCategory = new SqlCommand("[Setup].[Proc_GetAllCategories]", objConn);
        //    cmdCategory.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
        //    cmdCategory.CommandType = CommandType.StoredProcedure;
        //    objReader = cmdCategory.ExecuteReader();
        //    while (objReader.Read())
        //    {
        //        CategoryEL oelCategory = new CategoryEL();
        //        oelCategory.IdCategory = Validation.GetSafeGuid(objReader["Category_Id"]);
        //        oelCategory.CategoryCode = Validation.GetSafeString(objReader["Category_Code"]);
        //        oelCategory.CategoryName = Validation.GetSafeString(objReader["Category_Name"]);
        //        oelCategory.UserId = Validation.GetSafeGuid(objReader["User_Id"]);
        //        oelCategory.IsActive = Validation.GetSafeBooleanNullable(objReader["IsActive"]);
        //        oelCategory.CreatedDateTime = Validation.GetSafeDateTime(objReader["Created_DateTime"]);
        //        list.Add(oelCategory);
        //    }
        //    return list;
        //}  
        public EntityoperationInfo CreateTanneryCuttingRate(decimal CuttingRate, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlTransaction objTran = objConn.BeginTransaction();
            SqlCommand cmdTanneryRate = new SqlCommand("[Tannery].[Proc_SaveTanneryCuttingRate]", objConn, objTran);

            cmdTanneryRate.CommandType = CommandType.StoredProcedure;
            cmdTanneryRate.Parameters.Add(new SqlParameter("@CuttingRate", DbType.DateTime)).Value = CuttingRate;
            cmdTanneryRate.ExecuteNonQuery();

            objTran.Commit();

            infoResult.IsSuccess = true;

            return infoResult;
        }
        public List<TanneryProcessesHeadEL> GetCuttingPurchaseRate(SqlConnection objConn)
        {
            List<TanneryProcessesHeadEL> list = new List<TanneryProcessesHeadEL>();
            SqlCommand cmdCuttingRate = new SqlCommand("[Tannery].[Proc_GetTanneryCuttingRate]", objConn);
            cmdCuttingRate.CommandType = CommandType.StoredProcedure;
            objReader = cmdCuttingRate.ExecuteReader();
            while (objReader.Read())
            {
                TanneryProcessesHeadEL oelHead = new TanneryProcessesHeadEL();
                oelHead.Amount = Validation.GetSafeDecimal(objReader["CuttingRate"]);
                list.Add(oelHead);
            }
            return list;
        }

        public List<TanneryProcessesHeadEL> GetLotProfitAndLoss(Guid IdLot, SqlConnection objConn)
        {
            List<TanneryProcessesHeadEL> list = new List<TanneryProcessesHeadEL>();
            SqlCommand cmdProfitLoss = new SqlCommand("[Tannery].[Proc_GetLotProfitAndLoss]", objConn);
            cmdProfitLoss.Parameters.Add(new SqlParameter("@IdLot", DbType.String)).Value = IdLot;
            cmdProfitLoss.CommandType = CommandType.StoredProcedure;
            objReader = cmdProfitLoss.ExecuteReader();
            while (objReader.Read())
            {
                TanneryProcessesHeadEL oelProfit = new TanneryProcessesHeadEL();
                oelProfit.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelProfit.Amount = Validation.GetSafeDecimal(objReader["Expense"]);

                list.Add(oelProfit);
            }
            return list;
        }
    }
}
