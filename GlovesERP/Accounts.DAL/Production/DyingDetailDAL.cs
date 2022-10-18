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
    public class DyingDetailDAL
    {
        IDataReader objReader;
        public DyingDetailDAL()
        { 
            
        }
        public bool InsertDyingDetail(List<VoucherDetailEL> oelDyingCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdDyingDetail = new SqlCommand("[Production].[Proc_CreateDyingDetail]", objConn);
            cmdDyingDetail.CommandType = CommandType.StoredProcedure;
            cmdDyingDetail.Transaction = objTran;
            for (int i = 0; i < oelDyingCollection.Count; i++)
            {
                cmdDyingDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelDyingCollection[i].IdVoucherDetail;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelDyingCollection[i].IdVoucher;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@SeqNo", DbType.Int32)).Value = oelDyingCollection[i].Seq;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelDyingCollection[i].IdItem;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@IdColor", DbType.Guid)).Value = oelDyingCollection[i].IdColor;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@GradeAUnits", DbType.Guid)).Value = oelDyingCollection[i].GradeAUnits;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@GradeAAmount", DbType.Guid)).Value = oelDyingCollection[i].GradeAAmount;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@GradeBUnits", DbType.Guid)).Value = oelDyingCollection[i].GradeBUnits;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@GradeBAmount", DbType.Guid)).Value = oelDyingCollection[i].GradeBAmount;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@CPUnits", DbType.Decimal)).Value = oelDyingCollection[i].CPUnits;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@Units", DbType.Decimal)).Value = oelDyingCollection[i].Units;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelDyingCollection[i].UnitPrice;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Int64)).Value = oelDyingCollection[i].Amount;
                cmdDyingDetail.ExecuteNonQuery();
                cmdDyingDetail.Parameters.Clear();

            }
            return true;
        }
        public bool UpdateDyingDetail(List<VoucherDetailEL> oelDyingCollection, SqlConnection objConn, SqlTransaction objTran)
        {
            SqlCommand cmdDyingDetail = new SqlCommand();
            cmdDyingDetail.CommandType = CommandType.StoredProcedure;
            cmdDyingDetail.Connection = objConn;
            cmdDyingDetail.Transaction = objTran;
            for (int i = 0; i < oelDyingCollection.Count; i++)
            {
                if (oelDyingCollection[i].IsNew)
                {
                    cmdDyingDetail.CommandText = "[Production].[Proc_CreateDyingDetail]";
                }
                else
                {
                    cmdDyingDetail.CommandText = "[Production].[Proc_UpdateDyingDetail]";
                }
                cmdDyingDetail.Parameters.Add(new SqlParameter("@IdVoucherDetail", DbType.Guid)).Value = oelDyingCollection[i].IdVoucherDetail;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = oelDyingCollection[i].IdVoucher;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@SeqNo", DbType.Int32)).Value = oelDyingCollection[i].Seq;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelDyingCollection[i].IdItem;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@IdColor", DbType.Guid)).Value = oelDyingCollection[i].IdColor;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@GradeAUnits", DbType.Guid)).Value = oelDyingCollection[i].GradeAUnits;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@GradeAAmount", DbType.Guid)).Value = oelDyingCollection[i].GradeAAmount;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@GradeBUnits", DbType.Guid)).Value = oelDyingCollection[i].GradeBUnits;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@GradeBAmount", DbType.Guid)).Value = oelDyingCollection[i].GradeBAmount;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@CPUnits", DbType.Decimal)).Value = oelDyingCollection[i].CPUnits;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@Units", DbType.Decimal)).Value = oelDyingCollection[i].Units;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelDyingCollection[i].UnitPrice;
                cmdDyingDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Int64)).Value = oelDyingCollection[i].Amount;

                cmdDyingDetail.ExecuteNonQuery();
                cmdDyingDetail.Parameters.Clear();
            }
            return true;
        }
        public List<VoucherDetailEL> GetDyingByIssuanceTypeAndNumber(Guid IdCompany, Int64 IssuanceNo, int IssuanceType, SqlConnection objConn)
        {
            List<VoucherDetailEL> list = new List<VoucherDetailEL>();
            using (SqlCommand cmdProduction = new SqlCommand("[Production].[Proc_GetDyingByIssuanceTypeAndNumber]", objConn))
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
                    VoucherDetailEL oeldyingDetail = new VoucherDetailEL();
                    oeldyingDetail.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                    oeldyingDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oeldyingDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oeldyingDetail.VDate = Validation.GetSafeNullableDateTime(objReader["VDate"]);
                    oeldyingDetail.VDiscription = Validation.GetSafeString(objReader["VDiscription"]);
                    oeldyingDetail.WorkType = Validation.GetSafeInteger(objReader["WorkType"]);
                    oeldyingDetail.Posted = Validation.GetSafeBoolean(objReader["Posted"]);
                    oeldyingDetail.IsDeleted = Validation.GetSafeBooleanNullable(objReader["IsDeleted"]);

                    /// Now Add Detail Record Detail
                    oeldyingDetail.IdVoucherDetail = Validation.GetSafeGuid(objReader["VoucherDetail_Id"]);
                    oeldyingDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oeldyingDetail.IdColor = Validation.GetSafeGuid(objReader["Color_Id"]);
                    oeldyingDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oeldyingDetail.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                    oeldyingDetail.GradeAUnits = Validation.GetSafeLong(objReader["GradeAUnits"]);
                    oeldyingDetail.GradeAAmount = Validation.GetSafeLong(objReader["GradeAAmount"]);
                    oeldyingDetail.GradeBUnits = Validation.GetSafeLong(objReader["GradeBUnits"]);
                    oeldyingDetail.GradeBAmount = Validation.GetSafeLong(objReader["GradeBAmount"]);
                    oeldyingDetail.CPUnits = Validation.GetSafeLong(objReader["CPUnits"]);
                    oeldyingDetail.Units = Validation.GetSafeLong(objReader["Units"]);
                    oeldyingDetail.UnitPrice = Validation.GetSafeDecimal(objReader["UnitPrice"]);
                    oeldyingDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                    oeldyingDetail.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);

                    list.Add(oeldyingDetail);
                }
            }
            return list;
        }
    }
}
