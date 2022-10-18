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
    public class TanneryProcessesDetailsDAL
    {
        IDataReader objReader;
        public bool CreateProcessesDetails(List<TanneryProcessDetailsEL> oelProcessDetailCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdProcessDetails = new SqlCommand("[Tannery].[Proc_CreateProcessesDetails]", objConn, objTran);

            cmdProcessDetails.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < oelProcessDetailCollection.Count; i++)
            {
                cmdProcessDetails.Parameters.Add(new SqlParameter("@IdProcessesDetails", DbType.Guid)).Value = oelProcessDetailCollection[i].IdProcessDetail;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@IdProcess", DbType.Guid)).Value = oelProcessDetailCollection[i].IdProcess;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelProcessDetailCollection[i].IdUser;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelProcessDetailCollection[i].AccountNo;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelProcessDetailCollection[i].Description;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Item_Id", DbType.Guid)).Value = oelProcessDetailCollection[i].IdItem;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = oelProcessDetailCollection[i].VehicleNo;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Galma", DbType.Int64)).Value = oelProcessDetailCollection[i].Galma;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@GalmaPieces", DbType.Int64)).Value = oelProcessDetailCollection[i].GalmaPieces;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Puttha", DbType.Int64)).Value = oelProcessDetailCollection[i].Puttha;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@PutthaPieces", DbType.Int64)).Value = oelProcessDetailCollection[i].PutthaPieces;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@DGalma", DbType.Int64)).Value = oelProcessDetailCollection[i].DGalma;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@DPuttha", DbType.Int64)).Value = oelProcessDetailCollection[i].DPuttha;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Pieces", DbType.Int64)).Value = oelProcessDetailCollection[i].Pieces;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@SGalma", DbType.Int64)).Value = oelProcessDetailCollection[i].SGalma;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@SPuttha", DbType.Int64)).Value = oelProcessDetailCollection[i].SPuttha;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@WorkDate", DbType.DateTime)).Value = oelProcessDetailCollection[i].WorkDate;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@SSet", DbType.Int32)).Value = oelProcessDetailCollection[i].SSet;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Rate", DbType.Decimal)).Value = oelProcessDetailCollection[i].Rate;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelProcessDetailCollection[i].Amount;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelProcessDetailCollection[i].Posted;
                cmdProcessDetails.ExecuteNonQuery();
                cmdProcessDetails.Parameters.Clear();
            }           
           
            return true;
        }
        public bool UpdateProcessesDetails(List<TanneryProcessDetailsEL> oelProcessDetailCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdProcessDetails = new SqlCommand("[Tannery].[Proc_UpdateProcessesDetails]", objConn,objTran);
            cmdProcessDetails.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < oelProcessDetailCollection.Count; i++)
            {
                if (oelProcessDetailCollection[i].IsNew)
                {
                    cmdProcessDetails.CommandText = "[Tannery].[Proc_CreateProcessesDetails]";
                }
                else
                {
                    cmdProcessDetails.CommandText = "[Tannery].[Proc_UpdateProcessesDetails]";
                }
                cmdProcessDetails.Parameters.Add(new SqlParameter("@IdProcessesDetails", DbType.Guid)).Value = oelProcessDetailCollection[i].IdProcessDetail;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@IdProcess", DbType.Guid)).Value = oelProcessDetailCollection[i].IdProcess;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelProcessDetailCollection[i].IdUser;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelProcessDetailCollection[i].AccountNo;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelProcessDetailCollection[i].Description;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Item_Id", DbType.Guid)).Value = oelProcessDetailCollection[i].IdItem;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = oelProcessDetailCollection[i].VehicleNo;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Galma", DbType.Int64)).Value = oelProcessDetailCollection[i].Galma;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@GalmaPieces", DbType.Int64)).Value = oelProcessDetailCollection[i].GalmaPieces;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Puttha", DbType.Int64)).Value = oelProcessDetailCollection[i].Puttha;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@PutthaPieces", DbType.Int64)).Value = oelProcessDetailCollection[i].PutthaPieces;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@DGalma", DbType.Int64)).Value = oelProcessDetailCollection[i].DGalma;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@DPuttha", DbType.Int64)).Value = oelProcessDetailCollection[i].DPuttha;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Pieces", DbType.Int64)).Value = oelProcessDetailCollection[i].Pieces;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@SGalma", DbType.Int64)).Value = oelProcessDetailCollection[i].SGalma;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@SPuttha", DbType.Int64)).Value = oelProcessDetailCollection[i].SPuttha;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@WorkDate", DbType.DateTime)).Value = oelProcessDetailCollection[i].WorkDate;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@SSet", DbType.Int32)).Value = oelProcessDetailCollection[i].SSet;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Rate", DbType.Decimal)).Value = oelProcessDetailCollection[i].Rate;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelProcessDetailCollection[i].Amount;
                cmdProcessDetails.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelProcessDetailCollection[i].Posted;

                cmdProcessDetails.ExecuteNonQuery();
                cmdProcessDetails.Parameters.Clear();
   
            }

            return true;
        }
        public List<TanneryProcessDetailsEL> GetProcessesDetailByVehicleAndProcess(Guid IdCompany,string ProcessName,string VehicleNo, SqlConnection objConn)
        {
            List<TanneryProcessDetailsEL> list = new List<TanneryProcessDetailsEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Tannery].[Proc_GetProcessesDetailByVehicleAndProcess]", objConn);
            cmdProcessDetail.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = ProcessName;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = VehicleNo;
            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                TanneryProcessDetailsEL oelProcessDetail = new TanneryProcessDetailsEL();
                oelProcessDetail.IdProcessDetail = Validation.GetSafeGuid(objReader["ProcessDetails_Id"]);
                oelProcessDetail.IdProcess = Validation.GetSafeGuid(objReader["Process_Id"]);
                oelProcessDetail.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                oelProcessDetail.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                oelProcessDetail.IdPosting = Validation.GetSafeLong(objReader["Posting_Id"]);
                if (DBNull.Value != objReader["Posted"])
                {
                    oelProcessDetail.Posted = Convert.ToBoolean(objReader["Posted"]);
                }
                else
                {
                    oelProcessDetail.Posted = false;
                }
                oelProcessDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelProcessDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelProcessDetail.AccountType = Validation.GetSafeString(objReader["AccountType"]);
                oelProcessDetail.VehicleNo = Validation.GetSafeString(objReader["VehicleNo"]);
                oelProcessDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                oelProcessDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelProcessDetail.Galma = Validation.GetSafeLong(objReader["Galma"]);
                oelProcessDetail.GalmaPieces = Validation.GetSafeLong(objReader["GalmaPieces"]);
                oelProcessDetail.Puttha = Validation.GetSafeLong(objReader["Puttha"]);
                oelProcessDetail.PutthaPieces = Validation.GetSafeLong(objReader["PutthaPieces"]);
                oelProcessDetail.DGalma = Validation.GetSafeLong(objReader["DGalma"]);
                oelProcessDetail.DPuttha = Validation.GetSafeLong(objReader["DPuttha"]);
                oelProcessDetail.Pieces = Validation.GetSafeLong(objReader["Pieces"]);
                oelProcessDetail.SGalma = Validation.GetSafeLong(objReader["SGalma"]);
                oelProcessDetail.SPuttha = Validation.GetSafeLong(objReader["SPuttha"]);
                oelProcessDetail.WorkDate = Convert.ToDateTime(objReader["WorkDate"]);
                oelProcessDetail.SSet = Validation.GetSafeLong(objReader["Sset"]);
                oelProcessDetail.Rate = Validation.GetSafeDecimal(objReader["Rate"]);
                oelProcessDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                list.Add(oelProcessDetail);
            }
            return list;
        }
        public List<TanneryProcessDetailsEL> GetProcessesDetailByVoucherNoAndProcess(Guid IdCompany, string ProcessName, string VoucherNo, SqlConnection objConn)
        {
            List<TanneryProcessDetailsEL> list = new List<TanneryProcessDetailsEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Tannery].[Proc_GetProcessesDetailByVoucherAndProcess]", objConn);
            cmdProcessDetail.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = ProcessName;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = VoucherNo;
            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                TanneryProcessDetailsEL oelProcessDetail = new TanneryProcessDetailsEL();
                oelProcessDetail.IdProcessDetail = Validation.GetSafeGuid(objReader["ProcessDetails_Id"]);
                oelProcessDetail.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                oelProcessDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelProcessDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelProcessDetail.AccountType = Validation.GetSafeString(objReader["AccountType"]);
                oelProcessDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                oelProcessDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelProcessDetail.VehicleNo = Validation.GetSafeString(objReader["VehicleNo"]);
                oelProcessDetail.Galma = Validation.GetSafeLong(objReader["Galma"]);
                oelProcessDetail.GalmaPieces = Validation.GetSafeLong(objReader["GalmaPieces"]);
                oelProcessDetail.Puttha = Validation.GetSafeLong(objReader["Puttha"]);
                oelProcessDetail.PutthaPieces = Validation.GetSafeLong(objReader["PutthaPieces"]);
                oelProcessDetail.DGalma = Validation.GetSafeLong(objReader["DGalma"]);
                oelProcessDetail.DPuttha = Validation.GetSafeLong(objReader["DPuttha"]);
                oelProcessDetail.SSet = Validation.GetSafeLong(objReader["Sset"]);
                oelProcessDetail.Pieces = Validation.GetSafeLong(objReader["Pieces"]);
                oelProcessDetail.SGalma = Validation.GetSafeLong(objReader["SGalma"]);
                oelProcessDetail.SPuttha = Validation.GetSafeLong(objReader["SPuttha"]);
                oelProcessDetail.Rate = Validation.GetSafeDecimal(objReader["Rate"]);
                oelProcessDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                list.Add(oelProcessDetail);
            }
            return list;
        }
        public List<TanneryProcessesEL> GetProcessDetailByName(string ProcessName, Guid IdVoucher, SqlConnection objConn)
        {
            List<TanneryProcessesEL> list = new List<TanneryProcessesEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Tannery].[Proc_GetProcessDetailByProcessName]", objConn);
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = ProcessName;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = IdVoucher;
            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                TanneryProcessesEL oelProces = new TanneryProcessesEL();

                oelProces.IdProcess = Validation.GetSafeGuid(objReader["Process_Id"]);

                list.Add(oelProces);
            }
            return list;
        }
        public List<TanneryProcessDetailsEL> GetVendorDateWiseWorkReport(string AccountNo, bool WorkType, DateTime startDate, DateTime endDate, SqlConnection objConn)
        {
            List<TanneryProcessDetailsEL> list = new List<TanneryProcessDetailsEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Reports].[Proc_GetVendorDateWiseWorkReport]", objConn);
            cmdProcessDetail.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@WorkType", DbType.Boolean)).Value = WorkType;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@StartDate", DbType.DateTime)).Value = startDate;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@EndDate", DbType.DateTime)).Value = endDate;
            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                TanneryProcessDetailsEL oelDetail = new TanneryProcessDetailsEL();
                oelDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelDetail.ProcessName = Validation.GetSafeString(objReader["ProcessName"]);
                oelDetail.VehicleNo = Validation.GetSafeString(objReader["VehicleNo"]);
                oelDetail.WorkDate =Convert.ToDateTime(objReader["WorkingDate"]);
                oelDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                list.Add(oelDetail);
            }
            return list;
        }
        public List<TanneryProcessDetailsEL> GetProcessesWorkersDetailReport(string AccountNo, string WorkType, DateTime startDate, DateTime endDate, SqlConnection objConn)
        {
            List<TanneryProcessDetailsEL> list = new List<TanneryProcessDetailsEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Reports].[Proc_GetVendorDateAndWorkWiseReport]", objConn);
            cmdProcessDetail.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@WorkType", DbType.Boolean)).Value = WorkType;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@StartDate", DbType.DateTime)).Value = startDate;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@EndDate", DbType.DateTime)).Value = endDate;
            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                TanneryProcessDetailsEL oelProcessDetail = new TanneryProcessDetailsEL();               
                oelProcessDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelProcessDetail.ProcessName = WorkType;
                oelProcessDetail.Quality = Validation.GetSafeString(objReader["ItemName"]);
                oelProcessDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelProcessDetail.VehicleNo = Validation.GetSafeString(objReader["VehicleNo"]);
                oelProcessDetail.Galma = Validation.GetSafeInteger(objReader["Galma"]);
                oelProcessDetail.SGalma = Validation.GetSafeLong(objReader["SGalma"]);
                oelProcessDetail.SPuttha = Validation.GetSafeLong(objReader["SPuttha"]);
                oelProcessDetail.GalmaPieces = Validation.GetSafeInteger(objReader["GalmaPieces"]);
                oelProcessDetail.Puttha = Validation.GetSafeInteger(objReader["Puttha"]);
                oelProcessDetail.PutthaPieces = Validation.GetSafeInteger(objReader["PutthaPieces"]);
                oelProcessDetail.DGalma = Validation.GetSafeInteger(objReader["DGalma"]);
                oelProcessDetail.DPuttha = Validation.GetSafeInteger(objReader["DPuttha"]);
                oelProcessDetail.SSet = Validation.GetSafeInteger(objReader["Sset"]);
                oelProcessDetail.Rate = Validation.GetSafeDecimal(objReader["Rate"]);
                oelProcessDetail.WorkingDate = Validation.GetSafeDateTime(objReader["WorkDate"]);
                oelProcessDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                list.Add(oelProcessDetail);
            }
            return list;
        }
        public List<TanneryProcessDetailsEL> GetVehicleWiseShavingStock(string VehicleNo, SqlConnection objConn)
        {
            List<TanneryProcessDetailsEL> list = new List<TanneryProcessDetailsEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Reports].[Proc_GetVehicleWiseShavingStock]", objConn);
            cmdProcessDetail.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = VehicleNo;
            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                TanneryProcessDetailsEL oelProcessDetail = new TanneryProcessDetailsEL();
                oelProcessDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelProcessDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelProcessDetail.Galma = Validation.GetSafeLong(objReader["Galma"]);
                oelProcessDetail.GalmaPieces = Validation.GetSafeLong(objReader["GalmaPieces"]);
                oelProcessDetail.Puttha = Validation.GetSafeLong(objReader["Puttha"]);
                oelProcessDetail.PutthaPieces = Validation.GetSafeLong(objReader["PutthaPieces"]);
                oelProcessDetail.DGalma = Validation.GetSafeLong(objReader["DGalma"]);
                oelProcessDetail.DPuttha = Validation.GetSafeLong(objReader["DPuttha"]);
                oelProcessDetail.SSet = Validation.GetSafeLong(objReader["Sset"]);
                oelProcessDetail.SGalma = Validation.GetSafeLong(objReader["SGalma"]);
                oelProcessDetail.SPuttha = Validation.GetSafeLong(objReader["SPuttha"]);
                oelProcessDetail.Rate = Validation.GetSafeDecimal(objReader["Rate"]);
                oelProcessDetail.WorkingDate = Validation.GetSafeDateTime(objReader["WorkDate"]);
                oelProcessDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                list.Add(oelProcessDetail);
            }
            return list;
        }
        public List<TanneryProcessDetailsEL> GetVehicleWiseSplittingStock(string VehicleNo, SqlConnection objConn)
        {
            List<TanneryProcessDetailsEL> list = new List<TanneryProcessDetailsEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Reports].[Proc_GetVehicleWiseSplittingStock]", objConn);
            cmdProcessDetail.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = VehicleNo;
            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                TanneryProcessDetailsEL oelProcessDetail = new TanneryProcessDetailsEL();
                oelProcessDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelProcessDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelProcessDetail.Galma = Validation.GetSafeLong(objReader["Galma"]);
                oelProcessDetail.GalmaPieces = Validation.GetSafeLong(objReader["GalmaPieces"]);
                oelProcessDetail.Puttha = Validation.GetSafeLong(objReader["Puttha"]);
                oelProcessDetail.PutthaPieces = Validation.GetSafeLong(objReader["PutthaPieces"]);
                oelProcessDetail.DGalma = Validation.GetSafeLong(objReader["DGalma"]);
                oelProcessDetail.DPuttha = Validation.GetSafeLong(objReader["DPuttha"]);
                oelProcessDetail.SSet = Validation.GetSafeLong(objReader["Sset"]);
                oelProcessDetail.SGalma = Validation.GetSafeLong(objReader["SGalma"]);
                oelProcessDetail.SPuttha = Validation.GetSafeLong(objReader["SPuttha"]);
                oelProcessDetail.Rate = Validation.GetSafeDecimal(objReader["Rate"]);
                oelProcessDetail.WorkingDate = Validation.GetSafeDateTime(objReader["WorkDate"]);
                oelProcessDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                list.Add(oelProcessDetail);
            }
            return list;
        }
        public bool DeleteProcessEntry(Guid IdEntry, Guid IdVoucher, string ProcessName, SqlConnection objConn)
        {
            using (SqlTransaction oTran = objConn.BeginTransaction())
            {
                try
                {
                    SqlCommand cmdDelete = new SqlCommand("[Tannery].[Proc_DeleteProcessesDetailById]", objConn);
                    cmdDelete.Transaction = oTran;
                    cmdDelete.CommandType = CommandType.StoredProcedure;
                    cmdDelete.Parameters.Add("@IdEntry", SqlDbType.UniqueIdentifier).Value = IdEntry;
                    cmdDelete.Parameters.Add("@IdVoucher", SqlDbType.UniqueIdentifier).Value = IdVoucher;
                    cmdDelete.Parameters.Add("@ProcessName", SqlDbType.VarChar).Value = ProcessName;
                    cmdDelete.ExecuteNonQuery();
                    
                    oTran.Commit();
                }
                catch (Exception ex)
                {
                    oTran.Rollback();
                    throw ex;
                }
            }
            return true;
        }
        //public Int64 GetMaxCategoryCode(Guid IdCompany, SqlConnection objConn)
        //{
        //    SqlCommand cmdAccount = new SqlCommand("[Setup].[Proc_GetMaxCategoryCode]", objConn);
        //    cmdAccount.CommandType = CommandType.StoredProcedure;
        //    cmdAccount.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
        //    return Validation.GetSafeLong(cmdAccount.ExecuteScalar());

        //}
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

        public List<TanneryProcessDetailsEL> GetDateWiseDepartmentProcessWork(Guid IdCompany, Guid IdDepartment , DateTime startDate, DateTime endDate, SqlConnection objConn)
        {
            List<TanneryProcessDetailsEL> list = new List<TanneryProcessDetailsEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Tannery].[GetDateWiseDepartmentProcessWork]", objConn);
            cmdProcessDetail.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@IdDepartment", DbType.Guid)).Value = IdDepartment;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@StartDate", DbType.DateTime)).Value = startDate;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@EndDate", DbType.DateTime)).Value = endDate;
            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                TanneryProcessDetailsEL oelProcessDetail = new TanneryProcessDetailsEL();
                oelProcessDetail.AccountName = Validation.GetSafeString(objReader["PersonName"]);
                oelProcessDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelProcessDetail.Galma = Validation.GetSafeLong(objReader["Galma"]);
                oelProcessDetail.GalmaPieces = Validation.GetSafeLong(objReader["GalmaPieces"]);
                oelProcessDetail.Puttha = Validation.GetSafeLong(objReader["Puttha"]);
                oelProcessDetail.PutthaPieces = Validation.GetSafeLong(objReader["PutthaPieces"]);
                oelProcessDetail.DGalma = Validation.GetSafeLong(objReader["DGalma"]);
                oelProcessDetail.DPuttha = Validation.GetSafeLong(objReader["DPuttha"]);
                oelProcessDetail.SSet = Validation.GetSafeLong(objReader["Sset"]);
                oelProcessDetail.SGalma = Validation.GetSafeLong(objReader["SGalma"]);
                oelProcessDetail.SPuttha = Validation.GetSafeLong(objReader["SPuttha"]);
                oelProcessDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);

                list.Add(oelProcessDetail);
            }
            return list;
        }
        public Int64 GetProcessesClosingStock(string ProcessName, string ChildProcess, string PiecesType, string ChildPiecesType, int IdHeader, string VehicleNo,Guid IdLot, SqlConnection objConn)
        {
            List<TanneryProcessDetailsEL> list = new List<TanneryProcessDetailsEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Tannery].[Proc_GetProcessesClosingStock]", objConn);
            Int64 ClosingUnits = 0;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = ProcessName;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ChildProcess", DbType.String)).Value = ChildProcess;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@PiecesType", DbType.String)).Value = PiecesType;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ChildPiecesType", DbType.String)).Value = ChildPiecesType;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@IdHeader", DbType.Int32)).Value = IdHeader;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@VechileNo", DbType.String)).Value = VehicleNo;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@Idlot", DbType.Guid)).Value = IdLot;

            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                ClosingUnits = Validation.GetSafeLong(objReader["Closing"]);
            }
            return ClosingUnits;
        }
        public Int64 GetProcessesCompareStockBeforeDeleting(string ProcessName, string ChildProcess, string PiecesType, string ChildPiecesType, int IdHeader, string VehicleNo, Guid IdLot, SqlConnection objConn)
        {
            List<TanneryProcessDetailsEL> list = new List<TanneryProcessDetailsEL>();
            SqlCommand cmdProcessDetail = new SqlCommand("[Tannery].[Proc_GetProcessesCompareStockBeforeDeleting]", objConn);
            Int64 ClosingUnits = 0;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = ProcessName;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ChildProcess", DbType.String)).Value = ChildProcess;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@PiecesType", DbType.String)).Value = PiecesType;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@ChildPiecesType", DbType.String)).Value = ChildPiecesType;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@IdHeader", DbType.Int32)).Value = IdHeader;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@VechileNo", DbType.String)).Value = VehicleNo;
            cmdProcessDetail.Parameters.Add(new SqlParameter("@Idlot", DbType.Guid)).Value = IdLot;

            cmdProcessDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdProcessDetail.ExecuteReader();
            while (objReader.Read())
            {
                ClosingUnits = Validation.GetSafeLong(objReader["Closing"]);
            }
            return ClosingUnits;
        }
        public decimal GetVehicleClosingWeight(string VehicleNo, SqlConnection objConn)
        {
            SqlCommand cmdVehicleClosingStock = new SqlCommand("[Tannery].[Proc_GetVehicleClosingWeight]", objConn);
            cmdVehicleClosingStock.CommandType = CommandType.StoredProcedure;
            cmdVehicleClosingStock.Parameters.Add("@VehicleNo", SqlDbType.VarChar).Value = VehicleNo;
            return Validation.GetSafeDecimal(cmdVehicleClosingStock.ExecuteScalar());
        }
    }
}
