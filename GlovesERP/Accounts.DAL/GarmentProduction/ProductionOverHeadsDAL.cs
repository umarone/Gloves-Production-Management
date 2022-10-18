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
    public class ProductionOverHeadsDAL
    {
        IDataReader objReader;
        public bool CreateUpdateProductionOverHeads(List<ProductionOverHeadEL> oelProductionOverHeadCollection, SqlConnection objConn)
        {
            SqlTransaction objTran = objConn.BeginTransaction();
            SqlCommand cmdOverHead = new SqlCommand("[Production].[Proc_CreateOverHeadsDetail]", objConn, objTran);
            for (int i = 0; i < oelProductionOverHeadCollection.Count; i++)
            {
                if (oelProductionOverHeadCollection[i].IsNew)
                {
                    cmdOverHead.CommandText = "[Production].[Proc_CreateOverHeadsDetail]";
                }
                else
                {
                    cmdOverHead.CommandText = "[Production].[Proc_UpdateOverHeadsDetail]";
                }
                cmdOverHead.CommandType = CommandType.StoredProcedure;
                cmdOverHead.Parameters.Add(new SqlParameter("@IdOverHead", DbType.Guid)).Value = oelProductionOverHeadCollection[i].IdProductionOverHead;
                cmdOverHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelProductionOverHeadCollection[i].IdVoucher;
                cmdOverHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelProductionOverHeadCollection[i].AccountNo;
                cmdOverHead.Parameters.Add(new SqlParameter("@Description", DbType.Int64)).Value = oelProductionOverHeadCollection[i].Description;
                cmdOverHead.Parameters.Add(new SqlParameter("@Cost", DbType.Decimal)).Value = oelProductionOverHeadCollection[i].OverHeadCost;                
                cmdOverHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelProductionOverHeadCollection[i].OverHeadDate;
                cmdOverHead.Parameters.Add(new SqlParameter("@ProcessHead", DbType.Int64)).Value = oelProductionOverHeadCollection[i].ProcessType;
                cmdOverHead.ExecuteNonQuery();
                cmdOverHead.Parameters.Clear();
            }
            objTran.Commit();
            return true;
        }
        public List<ProductionOverHeadEL> GetProductionOverHeadsByVoucher(Guid IdVoucher, int ProcessHead, SqlConnection objConn)
        {
            List<ProductionOverHeadEL> list = new List<ProductionOverHeadEL>();
            SqlCommand cmdOverHead = new SqlCommand("[Production].[Proc_GetProductionOverHeadsByVoucherAndProcessHead]", objConn);
            cmdOverHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = IdVoucher;
            cmdOverHead.Parameters.Add(new SqlParameter("@ProcessHead", DbType.Int32)).Value = ProcessHead;
            cmdOverHead.CommandType = CommandType.StoredProcedure;
            objReader = cmdOverHead.ExecuteReader();
            while (objReader.Read())
            {
                ProductionOverHeadEL oelProductionOverhead = new ProductionOverHeadEL();
                oelProductionOverhead.IdProductionOverHead = Validation.GetSafeGuid(objReader["OverHead_Id"]);
                oelProductionOverhead.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                oelProductionOverhead.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                oelProductionOverhead.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelProductionOverhead.Description = Validation.GetSafeString(objReader["Description"]);

                oelProductionOverhead.OverHeadCost = Validation.GetSafeLong(objReader["Cost"]);
                oelProductionOverhead.OverHeadDate = Validation.GetSafeNullableDateTime(objReader["VDate"]);


                list.Add(oelProductionOverhead);
            }
            return list;
        }
        public EntityoperationInfo DeleteFOHEntry(Guid Id, SqlConnection objConn)
        {
            EntityoperationInfo deleteInfo = new EntityoperationInfo();
            int rowsEffected = -1;
            using (SqlCommand cmdDelete = new SqlCommand("[Production].[Proc_DeleteOverHeadsDetail]", objConn))
            {
                cmdDelete.CommandType = CommandType.StoredProcedure;
                cmdDelete.Parameters.Add("@IdOverHead", SqlDbType.BigInt).Value = Id;
                rowsEffected = Convert.ToInt32(cmdDelete.ExecuteNonQuery());
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
    }

}
