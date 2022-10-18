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
    public class TanneryLotDetailDAL
    {
        IDataReader objReader;
        public bool CreateLotDetail(List<TanneryLotDetailEL> oelLotDetailCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdTanneryLot = new SqlCommand("[Tannery].[Proc_CreateLotDetail]", objConn, objTran);
            cmdTanneryLot.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < oelLotDetailCollection.Count; i++)
            {
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdLotDetail", DbType.Guid)).Value = oelLotDetailCollection[i].IdLotDetail;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdLot", DbType.Guid)).Value = oelLotDetailCollection[i].IdLot;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdProcess", DbType.Guid)).Value = oelLotDetailCollection[i].IdProcess;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelLotDetailCollection[i].IdUser;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdQuality", DbType.Guid)).Value = oelLotDetailCollection[i].IdQuality;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelLotDetailCollection[i].AccountNo;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@ProcessType", DbType.Int32)).Value = oelLotDetailCollection[i].ProcessType;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@SeqNo", DbType.Int32)).Value = oelLotDetailCollection[i].SeqNo;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelLotDetailCollection[i].Description;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@UOM", DbType.String)).Value = oelLotDetailCollection[i].Uom;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@Weight", DbType.Decimal)).Value = oelLotDetailCollection[i].Weight;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@GalmaPieces", DbType.Int32)).Value = oelLotDetailCollection[i].GalmaPieces;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@PutthaPieces", DbType.Int32)).Value = oelLotDetailCollection[i].PutthaPieces;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@DGalma", DbType.Int32)).Value = oelLotDetailCollection[i].DGalma;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@Pieces", DbType.Int32)).Value = oelLotDetailCollection[i].Pieces;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@Cutting", DbType.Int32)).Value = oelLotDetailCollection[i].Cutting;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@CuttingRateValue", DbType.Decimal)).Value = oelLotDetailCollection[i].CuttingRateValue;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@CuttingStock", DbType.Int32)).Value = oelLotDetailCollection[i].CuttingStock;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@StockValue", DbType.Decimal)).Value = oelLotDetailCollection[i].CuttingStockValue;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@WorkDate", DbType.DateTime)).Value = oelLotDetailCollection[i].WorkingDate;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelLotDetailCollection[i].Amount;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelLotDetailCollection[i].Posted;
                cmdTanneryLot.ExecuteNonQuery();
                cmdTanneryLot.Parameters.Clear();
            }

            return true;
        }
        public bool UpdateLotDetail(List<TanneryLotDetailEL> oelLotDetailCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlCommand cmdTanneryLotDetail = new SqlCommand("[Tannery].[Proc_UpdateLotDetail]", objConn, objTran);
            cmdTanneryLotDetail.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < oelLotDetailCollection.Count; i++)
            {
                //if (oelLotDetailCollection[i].IsNew)
                //{
                //    cmdTanneryLotDetail.CommandText = "[Tannery].[Proc_CreateLotDetail]";
                //}
                //else
                //{
                    cmdTanneryLotDetail.CommandText = "[Tannery].[Proc_UpdateLotDetail]";
                //}
                cmdTanneryLotDetail.Parameters.Add(new SqlParameter("@IdLotDetail", DbType.Guid)).Value = oelLotDetailCollection[i].IdLotDetail;
                cmdTanneryLotDetail.Parameters.Add(new SqlParameter("@IdLot", DbType.Guid)).Value = oelLotDetailCollection[i].IdLot;
                cmdTanneryLotDetail.Parameters.Add(new SqlParameter("@IdProcess", DbType.Guid)).Value = oelLotDetailCollection[i].IdProcess;
                cmdTanneryLotDetail.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelLotDetailCollection[i].IdUser;
                cmdTanneryLotDetail.Parameters.Add(new SqlParameter("@IdQuality", DbType.Guid)).Value = oelLotDetailCollection[i].IdQuality;
                cmdTanneryLotDetail.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelLotDetailCollection[i].AccountNo;
                cmdTanneryLotDetail.Parameters.Add(new SqlParameter("@ProcessType", DbType.String)).Value = oelLotDetailCollection[i].ProcessType;
                cmdTanneryLotDetail.Parameters.Add(new SqlParameter("@Description", DbType.String)).Value = oelLotDetailCollection[i].Description;
                cmdTanneryLotDetail.Parameters.Add(new SqlParameter("@UOM", DbType.String)).Value = oelLotDetailCollection[i].Uom;
                cmdTanneryLotDetail.Parameters.Add(new SqlParameter("@Weight", DbType.Decimal)).Value = oelLotDetailCollection[i].Weight;
                cmdTanneryLotDetail.Parameters.Add(new SqlParameter("@Pieces", DbType.Int32)).Value = oelLotDetailCollection[i].Pieces;
                cmdTanneryLotDetail.Parameters.Add(new SqlParameter("@GalmaPieces", DbType.Int32)).Value = oelLotDetailCollection[i].GalmaPieces;
                cmdTanneryLotDetail.Parameters.Add(new SqlParameter("@PutthaPieces", DbType.Int32)).Value = oelLotDetailCollection[i].PutthaPieces;
                cmdTanneryLotDetail.Parameters.Add(new SqlParameter("@DGalma", DbType.Int32)).Value = oelLotDetailCollection[i].DGalma;
                cmdTanneryLotDetail.Parameters.Add(new SqlParameter("@Cutting", DbType.Int32)).Value = oelLotDetailCollection[i].Cutting;
                cmdTanneryLotDetail.Parameters.Add(new SqlParameter("@CuttingRateValue", DbType.Decimal)).Value = oelLotDetailCollection[i].CuttingRateValue;
                cmdTanneryLotDetail.Parameters.Add(new SqlParameter("@CuttingStock", DbType.Int32)).Value = oelLotDetailCollection[i].CuttingStock;
                cmdTanneryLotDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelLotDetailCollection[i].Amount;
                cmdTanneryLotDetail.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelLotDetailCollection[i].Posted;
                cmdTanneryLotDetail.ExecuteNonQuery();
                cmdTanneryLotDetail.Parameters.Clear();
            }

            return true;
        }
        public EntityoperationInfo DeleteTanneryLotDetail(Guid IdLotDetail, SqlConnection objConn)
        {
            EntityoperationInfo deleteInfo = new EntityoperationInfo();
            int rowsEffected = -1;
            using (SqlCommand cmdTanneryLotDetail = new SqlCommand("[Tannery].[Proc_DeleteLotDetail]", objConn))
            {
                cmdTanneryLotDetail.CommandType = CommandType.StoredProcedure;
                cmdTanneryLotDetail.Parameters.Add("@IdLotDetail", SqlDbType.UniqueIdentifier).Value = IdLotDetail;

                if (rowsEffected > -1)
                {
                    deleteInfo.IsSuccess = true;
                }
                else
                {
                    deleteInfo.IsSuccess = false;
                }
            }
            return deleteInfo;
        }
        public List<TanneryLotDetailEL> GetLotDetailByLotNoWithProcessHead(Guid IdVoucher, Int64 LotNo, SqlConnection objConn)
        {
            List<TanneryLotDetailEL> list = new List<TanneryLotDetailEL>();
            SqlCommand cmdLotDetail = new SqlCommand("[Tannery].[Proc_GetLotDetailByLotNoWithProcessHead]", objConn);
            cmdLotDetail.Parameters.Add(new SqlParameter("@LotNo", DbType.Guid)).Value = LotNo;
            cmdLotDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = IdVoucher;
            cmdLotDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdLotDetail.ExecuteReader();
            while (objReader.Read())
            {
                TanneryLotDetailEL oelTanneryDetail = new TanneryLotDetailEL();
                oelTanneryDetail.IdLotDetail = Validation.GetSafeGuid(objReader["LotDetail_Id"]);
                oelTanneryDetail.IdProcess = Validation.GetSafeGuid(objReader["Process_Id"]);
                oelTanneryDetail.IdPosting = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                if (DBNull.Value != objReader["Posted"])
                {
                    oelTanneryDetail.Posted = Convert.ToBoolean(objReader["Posted"]);
                }
                else
                {
                    oelTanneryDetail.Posted = false;
                }                
                oelTanneryDetail.IdQuality = Validation.GetSafeGuid(objReader["IdQuality"]);
                oelTanneryDetail.QualityName = Validation.GetSafeString(objReader["ItemName"]);
                oelTanneryDetail.LotWeight = Validation.GetSafeDecimal(objReader["LotWeight"]);
                oelTanneryDetail.LotType = Validation.GetSafeInteger(objReader["LotType"]);
                oelTanneryDetail.IdAccount = Validation.GetSafeGuid(objReader["Quality_Id"]);
                oelTanneryDetail.ItemName = Validation.GetSafeString(objReader["ChildQuality"]);
                oelTanneryDetail.ProcessName = Validation.GetSafeString(objReader["ProcessName"]);
                oelTanneryDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelTanneryDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelTanneryDetail.AccountType = Validation.GetSafeString(objReader["AccountType"]);
                oelTanneryDetail.SeqNo = Validation.GetSafeInteger(objReader["SeqNo"]);
                oelTanneryDetail.Weight = Validation.GetSafeDecimal(objReader["Weight"]);
                oelTanneryDetail.ProcessType = Validation.GetSafeInteger(objReader["ProcessType"]);
                oelTanneryDetail.Uom = Validation.GetSafeString(objReader["UOM"]);
                oelTanneryDetail.Pieces = Validation.GetSafeInteger(objReader["Pieces"]);
                oelTanneryDetail.GalmaPieces = Validation.GetSafeInteger(objReader["GalmaPieces"]);
                oelTanneryDetail.PutthaPieces = Validation.GetSafeInteger(objReader["PutthaPieces"]);
                oelTanneryDetail.DGalma = Validation.GetSafeInteger(objReader["DGalma"]);
                oelTanneryDetail.Cutting = Validation.GetSafeInteger(objReader["Cutting"]);
                oelTanneryDetail.CuttingRateValue = Validation.GetSafeInteger(objReader["CuttingValue"]);
                oelTanneryDetail.CuttingStock = Validation.GetSafeInteger(objReader["CuttingStock"]);
                oelTanneryDetail.WorkingDate = Validation.GetSafeDateTime(objReader["WorkingDate"]);
                oelTanneryDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                //oelTanneryDetail.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                //oelTanneryDetail.Posted = Validation.GetSafeBooleanNullable(objReader["Posted"]).Value;

                list.Add(oelTanneryDetail);
            }
            return list;
        }
        public List<TanneryLotDetailEL> GetLotInformation(Guid IdVoucher, Int64 LotNo, SqlConnection objConn)
        {
            List<TanneryLotDetailEL> list = new List<TanneryLotDetailEL>();
            SqlCommand cmdLotDetail = new SqlCommand("[Tannery].[Proc_GetLotInformation]", objConn);
            cmdLotDetail.Parameters.Add(new SqlParameter("@LotNo", DbType.Guid)).Value = LotNo;
            cmdLotDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = IdVoucher;
            cmdLotDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdLotDetail.ExecuteReader();
            while (objReader.Read())
            {
                TanneryLotDetailEL oelTanneryDetail = new TanneryLotDetailEL();                
                oelTanneryDetail.IdQuality = Validation.GetSafeGuid(objReader["IdQuality"]);
                oelTanneryDetail.QualityName = Validation.GetSafeString(objReader["ItemName"]);
                
                list.Add(oelTanneryDetail);
            }
            return list;
        }
        public List<TanneryLotDetailEL> GetLotDetailById(Guid IdLot, SqlConnection objConn)
        {
            List<TanneryLotDetailEL> list = new List<TanneryLotDetailEL>();
            SqlCommand cmdLotDetail = new SqlCommand("[Tannery].[Proc_GetLotDetailById]", objConn);
            cmdLotDetail.Parameters.Add(new SqlParameter("@IdLot", DbType.Guid)).Value = IdLot;
            cmdLotDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdLotDetail.ExecuteReader();
            while (objReader.Read())
            {
                TanneryLotDetailEL oelTanneryDetail = new TanneryLotDetailEL();
                oelTanneryDetail.ProcessName = Validation.GetSafeString(objReader["ProcessName"]);                
                oelTanneryDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelTanneryDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelTanneryDetail.Cutting = Validation.GetSafeInteger(objReader["Cutting"]);
                oelTanneryDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                
                list.Add(oelTanneryDetail);
            }
            return list;
        }
        public List<TanneryLotDetailEL> GetLotWorkersDetailReport(string AccountNo, string WorkType, DateTime startDate, DateTime endDate, SqlConnection objConn)
        {
            List<TanneryLotDetailEL> list = new List<TanneryLotDetailEL>();
            SqlCommand cmdLotDetail = new SqlCommand("[Reports].[Proc_GetVendorDateAndWorkWiseReport]", objConn);
            cmdLotDetail.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
            cmdLotDetail.Parameters.Add(new SqlParameter("@WorkType", DbType.String)).Value = WorkType;
            cmdLotDetail.Parameters.Add(new SqlParameter("@StartDate", DbType.DateTime)).Value = startDate;
            cmdLotDetail.Parameters.Add(new SqlParameter("@EndDate", DbType.DateTime)).Value = endDate;
            cmdLotDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdLotDetail.ExecuteReader();
            while (objReader.Read())
            {
                TanneryLotDetailEL oelTanneryDetail = new TanneryLotDetailEL();
                oelTanneryDetail.QualityName = Validation.GetSafeString(objReader["ItemName"]);
                oelTanneryDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelTanneryDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelTanneryDetail.QualityName = Validation.GetSafeString(objReader["ItemName"]);
                oelTanneryDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelTanneryDetail.ProcessName = Validation.GetSafeString(objReader["ProcessName"]);
                oelTanneryDetail.LotNo = Validation.GetSafeLong(objReader["LotNo"]);
                oelTanneryDetail.VehicleNo = Validation.GetSafeString(objReader["VehicleNo"]);
                oelTanneryDetail.SeqNo = Validation.GetSafeInteger(objReader["SeqNo"]);
                oelTanneryDetail.Weight = Validation.GetSafeDecimal(objReader["Weight"]);
                oelTanneryDetail.ProcessType = Validation.GetSafeInteger(objReader["ProcessType"]);
                oelTanneryDetail.Uom = Validation.GetSafeString(objReader["UOM"]);
                oelTanneryDetail.Pieces = Validation.GetSafeInteger(objReader["GPieces"]);
                oelTanneryDetail.PPieces = Validation.GetSafeInteger(objReader["PPieces"]);
                oelTanneryDetail.SGalma = Validation.GetSafeLong(objReader["SGalmaPieces"]);
                oelTanneryDetail.SPuttha = Validation.GetSafeLong(objReader["SPutthaPieces"]);
                oelTanneryDetail.GalmaPieces = Validation.GetSafeInteger(objReader["GalmaPieces"]);
                oelTanneryDetail.PutthaPieces = Validation.GetSafeInteger(objReader["PutthaPieces"]);
                oelTanneryDetail.DGalma = Validation.GetSafeInteger(objReader["DGalma"]);
                oelTanneryDetail.Cutting = Validation.GetSafeInteger(objReader["Cutting"]);
                oelTanneryDetail.CuttingRateValue = Validation.GetSafeInteger(objReader["CuttingValue"]);
                oelTanneryDetail.CuttingStock = Validation.GetSafeInteger(objReader["CuttingStock"]);
                oelTanneryDetail.WorkingDate = Validation.GetSafeDateTime(objReader["WorkingDate"]);
                oelTanneryDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                //oelTanneryDetail.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                oelTanneryDetail.Posted = Validation.GetSafeBooleanNullable(objReader["Posted"]).Value;

                list.Add(oelTanneryDetail);
            }
            return list;
        }
        public List<TanneryLotDetailEL> GetLotWorkerWiseComparisonReport(string AccountNo, string WorkType, DateTime startDate, DateTime endDate, SqlConnection objConn)
        {
            List<TanneryLotDetailEL> list = new List<TanneryLotDetailEL>();
            SqlCommand cmdLotDetail = new SqlCommand("[Reports].[Proc_GetVendorDateAndWorkWiseComparisonReport]", objConn);
            cmdLotDetail.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
            cmdLotDetail.Parameters.Add(new SqlParameter("@WorkType", DbType.String)).Value = WorkType;
            cmdLotDetail.Parameters.Add(new SqlParameter("@StartDate", DbType.DateTime)).Value = startDate;
            cmdLotDetail.Parameters.Add(new SqlParameter("@EndDate", DbType.DateTime)).Value = endDate;
            cmdLotDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdLotDetail.ExecuteReader();
            while (objReader.Read())
            {
                TanneryLotDetailEL oelTanneryDetail = new TanneryLotDetailEL();
                oelTanneryDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelTanneryDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelTanneryDetail.Galma = Validation.GetSafeInteger(objReader["Galma"]);
                oelTanneryDetail.Puttha = Validation.GetSafeInteger(objReader["Puttha"]);
                oelTanneryDetail.SGalma = Validation.GetSafeInteger(objReader["SGalma"]);
                oelTanneryDetail.SPuttha = Validation.GetSafeInteger(objReader["SPuttha"]);
                oelTanneryDetail.DGalma = Validation.GetSafeInteger(objReader["DGalma"]);
                oelTanneryDetail.Cutting = Validation.GetSafeInteger(objReader["Cutting"]);                
                oelTanneryDetail.WorkingDate = Validation.GetSafeDateTime(objReader["WorkingDate"]);
                oelTanneryDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                
                //oelTanneryDetail.Posted = Validation.GetSafeBooleanNullable(objReader["Posted"]).Value;

                list.Add(oelTanneryDetail);
            }
            return list;
        }
        public List<TanneryLotDetailEL> GetVehicleWiseDrummingBuffingStock(string VehicleNo, string WorkType, SqlConnection objConn)
        {
            List<TanneryLotDetailEL> list = new List<TanneryLotDetailEL>();
            SqlCommand cmdLotDetail = new SqlCommand("[Reports].[Proc_GetVehicleWiseDrummingBuffingStock]", objConn);
            cmdLotDetail.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = VehicleNo;
            cmdLotDetail.Parameters.Add(new SqlParameter("@WorkType", DbType.String)).Value = WorkType;
            cmdLotDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdLotDetail.ExecuteReader();
            while (objReader.Read())
            {
                TanneryLotDetailEL oelTanneryDetail = new TanneryLotDetailEL();
                oelTanneryDetail.QualityName = Validation.GetSafeString(objReader["ItemName"]);
                oelTanneryDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelTanneryDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelTanneryDetail.QualityName = Validation.GetSafeString(objReader["ItemName"]);
                oelTanneryDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelTanneryDetail.ProcessName = Validation.GetSafeString(objReader["ProcessName"]);
                oelTanneryDetail.LotNo = Validation.GetSafeLong(objReader["LotNo"]);
                oelTanneryDetail.VehicleNo = Validation.GetSafeString(objReader["VehicleNo"]);
                oelTanneryDetail.SeqNo = Validation.GetSafeInteger(objReader["SeqNo"]);
                oelTanneryDetail.Weight = Validation.GetSafeDecimal(objReader["Weight"]);
                oelTanneryDetail.ProcessType = Validation.GetSafeInteger(objReader["ProcessType"]);
                oelTanneryDetail.Uom = Validation.GetSafeString(objReader["UOM"]);
                oelTanneryDetail.Pieces = Validation.GetSafeInteger(objReader["GPieces"]);
                oelTanneryDetail.PPieces = Validation.GetSafeInteger(objReader["PPieces"]);
                if (WorkType == "Drumming")
                {
                    oelTanneryDetail.SGalma = Validation.GetSafeLong(objReader["SGalmaPieces"]);
                    oelTanneryDetail.SPuttha = Validation.GetSafeLong(objReader["SPutthaPieces"]);
                }
                else
                {
                    oelTanneryDetail.SGalma = Validation.GetSafeLong(objReader["SBuffingGalmaPieces"]);
                    oelTanneryDetail.SPuttha = Validation.GetSafeLong(objReader["SBuffingPutthaPieces"]);
                }

                oelTanneryDetail.GalmaPieces = Validation.GetSafeInteger(objReader["GalmaPieces"]);
                oelTanneryDetail.PutthaPieces = Validation.GetSafeInteger(objReader["PutthaPieces"]);
                oelTanneryDetail.DGalma = Validation.GetSafeInteger(objReader["DGalma"]);
                oelTanneryDetail.Cutting = Validation.GetSafeInteger(objReader["Cutting"]);
                oelTanneryDetail.CuttingRateValue = Validation.GetSafeInteger(objReader["CuttingValue"]);
                oelTanneryDetail.CuttingStock = Validation.GetSafeInteger(objReader["CuttingStock"]);
                oelTanneryDetail.WorkingDate = Validation.GetSafeDateTime(objReader["WorkingDate"]);
                oelTanneryDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                //oelTanneryDetail.VoucherNo = Validation.GetSafeLong(objReader["VoucherNo"]);
                oelTanneryDetail.Posted = Validation.GetSafeBooleanNullable(objReader["Posted"]).Value;

                list.Add(oelTanneryDetail);
            }
            return list;
        }

        public List<TanneryLotDetailEL> GetDateWiseDepartmentLotsWork(Guid IdCompany, Guid IdDepartment, DateTime startDate, DateTime endDate, SqlConnection objConn)
        {
            List<TanneryLotDetailEL> list = new List<TanneryLotDetailEL>();
            SqlCommand cmdLotDetail = new SqlCommand("[Tannery].[GetDateWiseDepartmentLotsWork]", objConn);
            cmdLotDetail.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdLotDetail.Parameters.Add(new SqlParameter("@IdDepartment", DbType.Guid)).Value = IdDepartment;
            cmdLotDetail.Parameters.Add(new SqlParameter("@StartDate", DbType.DateTime)).Value = startDate;
            cmdLotDetail.Parameters.Add(new SqlParameter("@EndDate", DbType.DateTime)).Value = endDate;
            cmdLotDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdLotDetail.ExecuteReader();
            while (objReader.Read())
            {
                TanneryLotDetailEL oelTanneryDetail = new TanneryLotDetailEL();
                oelTanneryDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelTanneryDetail.AccountName = Validation.GetSafeString(objReader["PersonName"]);
                oelTanneryDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelTanneryDetail.LotNo = Validation.GetSafeLong(objReader["LotNo"]);
                oelTanneryDetail.Galma = Validation.GetSafeInteger(objReader["Galma"]);
                oelTanneryDetail.Puttha = Validation.GetSafeInteger(objReader["Puttha"]);
                oelTanneryDetail.SGalma = Validation.GetSafeInteger(objReader["SGalma"]);
                oelTanneryDetail.SGalma = Validation.GetSafeInteger(objReader["SGalma"]);
                oelTanneryDetail.SPuttha = Validation.GetSafeInteger(objReader["SPuttha"]);
                oelTanneryDetail.DGalma = Validation.GetSafeInteger(objReader["DGalma"]);
                oelTanneryDetail.Cutting = Validation.GetSafeInteger(objReader["Cutting"]);
                oelTanneryDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
           
                list.Add(oelTanneryDetail);
            }
            return list;
        }
        public List<TanneryLotDetailEL> GetTanneryDetailsByUserAndDateForActivity(Guid IdUser, DateTime ActivityDate, string VType, SqlConnection objConn)
        {
            List<TanneryLotDetailEL> list = new List<TanneryLotDetailEL>();
            SqlCommand cmdLotDetail = new SqlCommand("[Transactions].[Proc_GetTanneryDetailsByUserAndDateForActivity]", objConn);

            cmdLotDetail.Parameters.Add("@IdUser", SqlDbType.UniqueIdentifier).Value = IdUser;
            cmdLotDetail.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = ActivityDate;
            cmdLotDetail.Parameters.Add("@TanneryType", SqlDbType.VarChar).Value = VType;
            cmdLotDetail.CommandType = CommandType.StoredProcedure;
            
            objReader = cmdLotDetail.ExecuteReader();
            while (objReader.Read())
            {
                TanneryLotDetailEL oelTanneryDetail = new TanneryLotDetailEL();
                oelTanneryDetail.WorkingDate = Validation.GetSafeDateTime(objReader["WorkingDate"]);
                oelTanneryDetail.VehicleNo = Validation.GetSafeString(objReader["VehicleNo"]);
                oelTanneryDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                oelTanneryDetail.LotNo = Validation.GetSafeLong(objReader["LotNo"]);

                list.Add(oelTanneryDetail);
            }
            return list;
        }
    }
}


