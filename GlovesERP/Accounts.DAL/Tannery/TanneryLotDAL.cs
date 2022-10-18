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
    public class TanneryLotDAL
    {
        IDataReader objReader;
        TanneryProcessesDAL PDal;
        TanneryChemicalDAL CDal;
        public TanneryLotDAL()
        {
            PDal = new TanneryProcessesDAL();
            CDal = new TanneryChemicalDAL();
        }
        public bool CreateCompleteLot(TanneryLotEL oelTanneryLot, List<TanneryProcessesEL> oelProcessesCollection, List<TanneryLotDetailEL> oelLotDetailCollection, List<TanneryChemicalEL> oelTanneryChemicalCollection, SqlConnection objConn)
        {
            SqlTransaction objTran = objConn.BeginTransaction();
            try
            {
                EntityoperationInfo infoResult = new EntityoperationInfo();

                SqlCommand cmdTanneryLot = new SqlCommand("[Tannery].[Proc_CreatetLot]", objConn, objTran);
                cmdTanneryLot.CommandType = CommandType.StoredProcedure;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdLot", DbType.Guid)).Value = oelTanneryLot.IdLot;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdProcessHead", DbType.Guid)).Value = oelTanneryLot.IdVoucher;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelTanneryLot.IdUser;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdQuality", DbType.Guid)).Value = oelTanneryLot.IdQuality;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@LotNo", DbType.Int64)).Value = oelTanneryLot.LotNo;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@LotWeight", DbType.Decimal)).Value = oelTanneryLot.LotWeight;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = oelTanneryLot.VehicleNo;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@LotDate", DbType.DateTime)).Value = oelTanneryLot.LotDate;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = oelTanneryLot.ProcessName;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@Status", DbType.String)).Value = oelTanneryLot.Status;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@LotType", DbType.Int32)).Value = oelTanneryLot.LotType;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@CloseDate", DbType.DateTime)).Value = oelTanneryLot.CloseDate;

                cmdTanneryLot.ExecuteNonQuery();

                PDal.CreateProcessesWithLots(oelProcessesCollection, oelLotDetailCollection, objConn, objTran);

                CDal.CreateChemical(oelTanneryChemicalCollection, objConn, objTran);

                objTran.Commit();
            }
            catch (Exception ex)
            {
                objConn.Dispose();
                objTran.Rollback();
                objTran.Dispose();
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
                objTran.Dispose();
            }
            return true;

        }
        public bool CreatePostingLot(TanneryLotEL oelTanneryLot, List<TanneryProcessesEL> oelProcessesCollection, List<TanneryLotDetailEL> oelLotDetailCollection, SqlConnection objConn)
        {
            SqlTransaction objTran = objConn.BeginTransaction();
            try
            {
                SqlCommand cmdTanneryLot = new SqlCommand("[Tannery].[Proc_UpdateLot]", objConn, objTran);

                cmdTanneryLot.CommandType = CommandType.StoredProcedure;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdLot", DbType.Guid)).Value = oelTanneryLot.IdLot;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdProcessHead", DbType.Guid)).Value = oelTanneryLot.IdVoucher;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelTanneryLot.IdUser;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdQuality", DbType.Guid)).Value = oelTanneryLot.IdQuality;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@LotNo", DbType.Int64)).Value = oelTanneryLot.LotNo;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@LotWeight", DbType.Decimal)).Value = oelTanneryLot.LotWeight;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = oelTanneryLot.VehicleNo;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@LotDate", DbType.DateTime)).Value = oelTanneryLot.LotDate;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = oelTanneryLot.ProcessName;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@Status", DbType.String)).Value = oelTanneryLot.Status;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@LotType", DbType.Int32)).Value = oelTanneryLot.LotType;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@CloseDate", DbType.DateTime)).Value = oelTanneryLot.CloseDate;

                cmdTanneryLot.ExecuteNonQuery();

                PDal.CreateProcessesWithLots(oelProcessesCollection, oelLotDetailCollection, objConn, objTran);

                objTran.Commit();
            }
            catch (Exception ex)
            {
                objConn.Dispose();
                objTran.Rollback();
                objTran.Dispose();
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
                objTran.Dispose();
            }
            return true;

        }
        public bool UpdatePostingLot(TanneryLotEL oelTanneryLot, List<TanneryProcessesEL> oelProcessesCollection, List<TanneryLotDetailEL> oelLotDetailCollection, SqlConnection objConn)
        {
            SqlTransaction objTran = objConn.BeginTransaction();
            try
            {
                SqlCommand cmdTanneryLot = new SqlCommand("[Tannery].[Proc_UpdateLot]", objConn, objTran);

                cmdTanneryLot.CommandType = CommandType.StoredProcedure;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdLot", DbType.Guid)).Value = oelTanneryLot.IdLot;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdProcessHead", DbType.Guid)).Value = oelTanneryLot.IdVoucher;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelTanneryLot.IdUser;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdQuality", DbType.Guid)).Value = oelTanneryLot.IdQuality;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@LotNo", DbType.String)).Value = oelTanneryLot.LotNo;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@LotWeight", DbType.Decimal)).Value = oelTanneryLot.LotWeight;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = oelTanneryLot.VehicleNo;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@LotDate", DbType.DateTime)).Value = oelTanneryLot.LotDate;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = oelTanneryLot.ProcessName;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@Status", DbType.String)).Value = oelTanneryLot.Status;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@LotType", DbType.Int32)).Value = oelTanneryLot.LotType;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@CloseDate", DbType.DateTime)).Value = oelTanneryLot.CloseDate;

                cmdTanneryLot.ExecuteNonQuery();

                PDal.UpdateProcessesWithLots(oelProcessesCollection, oelLotDetailCollection, objConn, objTran);

                objTran.Commit();
            }
            catch (Exception ex)
            {
                objConn.Dispose();
                objTran.Rollback();
                objTran.Dispose();
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
                objTran.Dispose();
            }
            return true;

        }
        public bool CreateLot(TanneryLotEL oelTanneryLot, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();

            SqlCommand cmdTanneryLot = new SqlCommand("[Tannery].[Proc_CreatetLot]", objConn);
            cmdTanneryLot.CommandType = CommandType.StoredProcedure;
            cmdTanneryLot.Parameters.Add(new SqlParameter("@IdLot", DbType.Guid)).Value = oelTanneryLot.IdLot;
            cmdTanneryLot.Parameters.Add(new SqlParameter("@IdProcessHead", DbType.Guid)).Value = oelTanneryLot.IdVoucher;
            cmdTanneryLot.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelTanneryLot.IdUser;
            cmdTanneryLot.Parameters.Add(new SqlParameter("@IdQuality", DbType.Guid)).Value = oelTanneryLot.IdQuality;
            cmdTanneryLot.Parameters.Add(new SqlParameter("@LotNo", DbType.String)).Value = oelTanneryLot.LotNo;
            cmdTanneryLot.Parameters.Add(new SqlParameter("@LotWeight", DbType.Decimal)).Value = oelTanneryLot.LotWeight;
            cmdTanneryLot.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = oelTanneryLot.VehicleNo;
            cmdTanneryLot.Parameters.Add(new SqlParameter("@LotDate", DbType.DateTime)).Value = oelTanneryLot.LotDate;
            cmdTanneryLot.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = oelTanneryLot.ProcessName;
            cmdTanneryLot.Parameters.Add(new SqlParameter("@Status", DbType.String)).Value = oelTanneryLot.Status;
            cmdTanneryLot.Parameters.Add(new SqlParameter("@LotType", DbType.Int32)).Value = oelTanneryLot.LotType;
            cmdTanneryLot.Parameters.Add(new SqlParameter("@CloseDate", DbType.DateTime)).Value = oelTanneryLot.CloseDate;

            cmdTanneryLot.ExecuteNonQuery();

            return true;

        }
        public bool UpdateLot(TanneryLotEL oelTanneryLot, List<TanneryProcessesEL> oelProcessesCollection, List<TanneryLotDetailEL> oelLotDetailCollection, List<TanneryChemicalEL> oelTanneryChemicalCollection, SqlConnection objConn)
        {
            SqlTransaction objTran = objConn.BeginTransaction();
            try
            {
                SqlCommand cmdTanneryLot = new SqlCommand("[Tannery].[Proc_UpdateLot]", objConn, objTran);

                cmdTanneryLot.CommandType = CommandType.StoredProcedure;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdLot", DbType.Guid)).Value = oelTanneryLot.IdLot;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdProcessHead", DbType.Guid)).Value = oelTanneryLot.IdVoucher;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelTanneryLot.IdUser;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdQuality", DbType.Guid)).Value = oelTanneryLot.IdQuality;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@LotNo", DbType.String)).Value = oelTanneryLot.LotNo;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@LotWeight", DbType.Decimal)).Value = oelTanneryLot.LotWeight;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@VehicleNo", DbType.String)).Value = oelTanneryLot.VehicleNo;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@LotDate", DbType.DateTime)).Value = oelTanneryLot.LotDate;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = oelTanneryLot.ProcessName;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@Status", DbType.String)).Value = oelTanneryLot.Status;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@LotType", DbType.Int32)).Value = oelTanneryLot.LotType;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@CloseDate", DbType.DateTime)).Value = oelTanneryLot.CloseDate;

                cmdTanneryLot.ExecuteNonQuery();

                PDal.UpdateProcessesWithLots(oelProcessesCollection, oelLotDetailCollection, objConn, objTran);

                CDal.UpdateChemical(oelTanneryChemicalCollection, objConn, objTran);

                objTran.Commit();

            }
            catch (Exception)
            {
                objTran.Rollback();
                objTran.Dispose();
            }
            finally
            {
                objTran.Dispose();
            }
            return true;
        }
        public List<TanneryLotEL> GetLotById(Guid IdLot, SqlConnection objConn)
        {
            List<TanneryLotEL> list = new List<TanneryLotEL>();
            SqlCommand cmdLotDetail = new SqlCommand("[Tannery].[Proc_GetLot]", objConn);
            cmdLotDetail.Parameters.Add(new SqlParameter("@IdLot", DbType.Guid)).Value = IdLot;
            cmdLotDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdLotDetail.ExecuteReader();
            while (objReader.Read())
            {
                TanneryLotEL oelTanneryLot = new TanneryLotEL();
                oelTanneryLot.IdLot = Validation.GetSafeGuid(objReader["Lot_Id"]);
                oelTanneryLot.IdQuality = Validation.GetSafeGuid(objReader["Quality_Id"]);
                oelTanneryLot.QualityName = Validation.GetSafeString(objReader["LotQuality"]);
                oelTanneryLot.ProcessName = Validation.GetSafeString(objReader["ProcessName"]);
                oelTanneryLot.Status = Validation.GetSafeString(objReader["Status"]);
                oelTanneryLot.Amount = Validation.GetSafeDecimal(objReader["AdditionalCost"]);
                oelTanneryLot.CloseDate = Validation.GetSafeDateTime(objReader["CloseDate"]);
               
                list.Add(oelTanneryLot);
            }
            return list;
        }
        public bool CloseLot(TanneryLotEL oelTanneryLot, SqlConnection objConn)
        {
            try
            {
                SqlCommand cmdTanneryLot = new SqlCommand("[Tannery].[Proc_CloseLot]", objConn);

                cmdTanneryLot.CommandType = CommandType.StoredProcedure;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@IdLot", DbType.Guid)).Value = oelTanneryLot.IdLot;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@AdditionalCost", DbType.Guid)).Value = oelTanneryLot.Amount;
                cmdTanneryLot.Parameters.Add(new SqlParameter("@ClosedDate", DbType.DateTime)).Value = oelTanneryLot.CloseDate;

                cmdTanneryLot.ExecuteNonQuery();

                return true;
                

            }
            catch (Exception)
            {
            
            }
            finally
            {            
            }
            return true;
        }
        public EntityoperationInfo DeleteTanneryLot(Guid IdLot, SqlConnection objConn)
        {
            EntityoperationInfo deleteInfo = new EntityoperationInfo();
            int rowsEffected = -1;
            using (SqlCommand cmdTanneryLot = new SqlCommand("[Tannery].[Proc_DeleteLot]", objConn))
            {
                cmdTanneryLot.CommandType = CommandType.StoredProcedure;
                cmdTanneryLot.Parameters.Add("@IdLot", SqlDbType.UniqueIdentifier).Value = IdLot;
                rowsEffected = cmdTanneryLot.ExecuteNonQuery();
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
        public List<TanneryLotEL> GetLotsByProcessHead(Guid IdVoucher, SqlConnection objConn)
        {
            List<TanneryLotEL> list = new List<TanneryLotEL>();
            SqlCommand cmdAccount = new SqlCommand("[Tannery].[Proc_GetLotsByProcessHead]", objConn);
            cmdAccount.CommandType = CommandType.StoredProcedure;
            cmdAccount.Parameters.Add(new SqlParameter("@IdProcessHead", DbType.Guid)).Value = IdVoucher;
            cmdAccount.CommandType = CommandType.StoredProcedure;
            objReader = cmdAccount.ExecuteReader();
            while (objReader.Read())
            {
                TanneryLotEL oelLot = new TanneryLotEL();
                oelLot.IdLot = Validation.GetSafeGuid(objReader["Lot_Id"]);
                oelLot.LotNo = Validation.GetSafeLong(objReader["LotNo"]);
                oelLot.LotDate = Validation.GetSafeDateTime(objReader["LotDate"]);
                oelLot.ProcessName = Validation.GetSafeString(objReader["ProcessName"]);
                oelLot.Status = Validation.GetSafeString(objReader["Status"]);

                list.Add(oelLot);
            }

            return list;
        }
        public List<TanneryLotEL> GetLotByLotNo(Int64 LotNo, SqlConnection objConn)
        {
            List<TanneryLotEL> list = new List<TanneryLotEL>();
            SqlCommand cmdAccount = new SqlCommand("[Tannery].[Proc_GetLotByLotNo]", objConn);
            cmdAccount.CommandType = CommandType.StoredProcedure;
            cmdAccount.Parameters.Add(new SqlParameter("@LotNo", DbType.Int64)).Value = LotNo;
            cmdAccount.CommandType = CommandType.StoredProcedure;
            objReader = cmdAccount.ExecuteReader();
            while (objReader.Read())
            {
                TanneryLotEL oelLot = new TanneryLotEL();
                oelLot.IdLot = Validation.GetSafeGuid(objReader["Lot_Id"]);
                oelLot.LotNo = Validation.GetSafeLong(objReader["LotNo"]);
                oelLot.VehicleNo = Validation.GetSafeString(objReader["VehicleNo"]);
                oelLot.LotDate = Validation.GetSafeDateTime(objReader["LotDate"]);                

                list.Add(oelLot);
            }

            return list;
        }
        public Int64 GetMaxLotNo(Guid IdVoucher, SqlConnection objConn)
        {
            SqlCommand cmdAccount = new SqlCommand("[Tannery].[Proc_GetMaxLotNoByProcessHead]", objConn);
            cmdAccount.CommandType = CommandType.StoredProcedure;
            cmdAccount.Parameters.Add(new SqlParameter("@IdProcessHead", DbType.Guid)).Value = IdVoucher;
            return Validation.GetSafeLong(cmdAccount.ExecuteScalar());

        }
        public List<TanneryLotEL> GetVehicleLots(string VehicleNo, SqlConnection objConn)
        {
            List<TanneryLotEL> list = new List<TanneryLotEL>();
            SqlCommand cmdLots = new SqlCommand("[Tannery].[Proc_GetVehicleTotalLots]", objConn);
            cmdLots.Parameters.Add(new SqlParameter("@VehicleNo", DbType.Guid)).Value = VehicleNo;
            cmdLots.CommandType = CommandType.StoredProcedure;
            objReader = cmdLots.ExecuteReader();
            while (objReader.Read())
            {
                TanneryLotEL oelTanneryLot = new TanneryLotEL();
                oelTanneryLot.IdLot = Validation.GetSafeGuid(objReader["Lot_Id"]);
                oelTanneryLot.LotNo = Validation.GetSafeLong(objReader["LotNo"]);
                oelTanneryLot.LotWeight = Validation.GetSafeLong(objReader["LotWeight"]);
                oelTanneryLot.ProcessName = Validation.GetSafeString(objReader["ProcessName"]);
                oelTanneryLot.Status = Validation.GetSafeString(objReader["Status"]);
                oelTanneryLot.QualityName = Validation.GetSafeString(objReader["QualityName"]);
                oelTanneryLot.CloseDate = Validation.GetSafeDateTime(objReader["LotDate"]);

                list.Add(oelTanneryLot);
            }
            return list;
        }

        public List<TanneryLotEL> GetLotsFilterResults(Int64 LotNo, string UOM, string AccountNo, Guid IdItem, DateTime StartDate, DateTime EndDate, int FilterIndex, SqlConnection objConn)
        {
            List<TanneryLotEL> list = new List<TanneryLotEL>();
            SqlCommand cmdLots = new SqlCommand("[Tannery].[Proc_GetLotsFilterResults]", objConn);
            cmdLots.Parameters.Add(new SqlParameter("@LotNo", DbType.Int64)).Value = LotNo;
            cmdLots.Parameters.Add(new SqlParameter("@UOM", DbType.Int64)).Value = UOM;
            cmdLots.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = AccountNo;
            cmdLots.Parameters.Add(new SqlParameter("@IdQuality", DbType.Guid)).Value = IdItem;
            cmdLots.Parameters.Add(new SqlParameter("@StartDate", DbType.DateTime)).Value = StartDate;
            cmdLots.Parameters.Add(new SqlParameter("@EndDate", DbType.DateTime)).Value = EndDate;
            cmdLots.Parameters.Add(new SqlParameter("@FilterIndex", DbType.Int32)).Value = FilterIndex;
            cmdLots.CommandType = CommandType.StoredProcedure;
            objReader = cmdLots.ExecuteReader();
            while (objReader.Read())
            {
                TanneryLotEL oelTanneryLot = new TanneryLotEL();
                oelTanneryLot.IdLot = Validation.GetSafeGuid(objReader["Lot_Id"]);
                oelTanneryLot.LotNo = Validation.GetSafeLong(objReader["LotNo"]);
                oelTanneryLot.LotWeight = Validation.GetSafeDecimal(objReader["LotWeight"]);
                oelTanneryLot.VehicleNo = Validation.GetSafeString(objReader["VehicleNo"]);
                oelTanneryLot.LotDate = Validation.GetSafeDateTime(objReader["LotDate"]);
                oelTanneryLot.ProcessName = Validation.GetSafeString(objReader["ProcessName"]);
                oelTanneryLot.Status = Validation.GetSafeString(objReader["Status"]);
                oelTanneryLot.QualityName = Validation.GetSafeString(objReader["QualityName"]);
                oelTanneryLot.CloseDate = Validation.GetSafeDateTime(objReader["LotDate"]);

                list.Add(oelTanneryLot);
            }
            return list;
        }
        public List<TanneryChemicalEL> GetLotsByChemical(Guid IdChemical, SqlConnection objConn)
        {
            List<TanneryChemicalEL> list = new List<TanneryChemicalEL>();
            SqlCommand cmdChemicals = new SqlCommand("[Tannery].[Proc_GetLotsByChemical]", objConn);
            cmdChemicals.CommandType = CommandType.StoredProcedure;
            cmdChemicals.Parameters.Add(new SqlParameter("@IdChemical", DbType.Guid)).Value = IdChemical;
            cmdChemicals.CommandType = CommandType.StoredProcedure;
            objReader = cmdChemicals.ExecuteReader();
            while (objReader.Read())
            {
                TanneryChemicalEL oelChemical = new TanneryChemicalEL();
                //oelChemical.IdChemical = Validation.GetSafeGuid(objReader["Chemical_Id"]);
                //oelChemical.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                //oelChemical.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelChemical.LotNo = Validation.GetSafeLong(objReader["LotNo"]);
                oelChemical.LotWeight = Validation.GetSafeLong(objReader["LotWeight"]);
                oelChemical.LotTypeDiscription = Validation.GetSafeString(objReader["LotType"]);
                oelChemical.LotDate = Validation.GetSafeDateTime(objReader["LotDate"]);
                oelChemical.CrustIssuedQuantity = Validation.GetSafeDecimal(objReader["CrustIssuedQuantity"]);
                oelChemical.CrustIssuedValue = Validation.GetSafeDecimal(objReader["CrustIssuedValue"]);
                oelChemical.DyingIssuedQuantity = Validation.GetSafeDecimal(objReader["DyingIssuedQuantity"]);
                oelChemical.DyingIssuedValue = Validation.GetSafeDecimal(objReader["DyingIssuedValue"]);
                oelChemical.ReDyingIssuedQuantity = Validation.GetSafeDecimal(objReader["ReDyingIssuedQuantity"]);
                oelChemical.ReDyingIssuedValue = Validation.GetSafeDecimal(objReader["ReDyingIssuedValue"]);
                oelChemical.CurrentQuantity = Validation.GetSafeInteger(objReader["TotalQuantity"]);
                oelChemical.CurrentValue = Validation.GetSafeDecimal(objReader["TotalAmount"]);


                list.Add(oelChemical);
            }

            return list;
        }
    }
}
