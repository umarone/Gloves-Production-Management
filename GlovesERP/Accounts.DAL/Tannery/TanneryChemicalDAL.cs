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
    public class TanneryChemicalDAL
    {
        IDataReader objReader;
        public bool CreateChemical(List<TanneryChemicalEL> oelTanneryChemicalCollection, SqlConnection objConn, SqlTransaction objTran)
        {            
           SqlCommand cmdChemical = new SqlCommand("[Tannery].[Proc_CreateLotChemical]", objConn,objTran);
           for (int i = 0; i < oelTanneryChemicalCollection.Count; i++)
			{
                cmdChemical.CommandType = CommandType.StoredProcedure;
                cmdChemical.Parameters.Add(new SqlParameter("@IdChemical", DbType.Guid)).Value = oelTanneryChemicalCollection[i].IdChemical;
                cmdChemical.Parameters.Add(new SqlParameter("@IdLot", DbType.Guid)).Value = oelTanneryChemicalCollection[i].IdLot;
                cmdChemical.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelTanneryChemicalCollection[i].IdItem;
                cmdChemical.Parameters.Add(new SqlParameter("@CrustIssuedQuantity", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].CrustIssuedQuantity;
                cmdChemical.Parameters.Add(new SqlParameter("@CrustIssuedValue", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].CrustIssuedValue;
                cmdChemical.Parameters.Add(new SqlParameter("@DyingIssuedQuantity", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].DyingIssuedQuantity;
                cmdChemical.Parameters.Add(new SqlParameter("@DyingIssuedValue", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].DyingIssuedValue;
                cmdChemical.Parameters.Add(new SqlParameter("@ReDyingIssuedQuantity", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].ReDyingIssuedQuantity;
                cmdChemical.Parameters.Add(new SqlParameter("@ReDyingIssuedValue", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].ReDyingIssuedValue;
                cmdChemical.Parameters.Add(new SqlParameter("@CurrentStock", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].CurrentQuantity;
                cmdChemical.Parameters.Add(new SqlParameter("@CurrentValue", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].CurrentValue;
                cmdChemical.ExecuteNonQuery();
                cmdChemical.Parameters.Clear();
			}
           return true;
        }
        public bool CreateChemical(List<TanneryChemicalEL> oelTanneryChemicalCollection, SqlConnection objConn)
        {
            SqlTransaction objTran = objConn.BeginTransaction();
            try
            {
                SqlCommand cmdChemical = new SqlCommand("[Tannery].[Proc_CreateLotChemical]", objConn, objTran);
                for (int i = 0; i < oelTanneryChemicalCollection.Count; i++)
                {
                    cmdChemical.CommandType = CommandType.StoredProcedure;
                    cmdChemical.Parameters.Add(new SqlParameter("@IdChemical", DbType.Guid)).Value = oelTanneryChemicalCollection[i].IdChemical;
                    cmdChemical.Parameters.Add(new SqlParameter("@IdLot", DbType.Guid)).Value = oelTanneryChemicalCollection[i].IdLot;
                    cmdChemical.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelTanneryChemicalCollection[i].IdItem;
                    cmdChemical.Parameters.Add(new SqlParameter("@CrustIssuedQuantity", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].CrustIssuedQuantity;
                    cmdChemical.Parameters.Add(new SqlParameter("@CrustIssuedValue", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].CrustIssuedValue;
                    cmdChemical.Parameters.Add(new SqlParameter("@DyingIssuedQuantity", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].DyingIssuedQuantity;
                    cmdChemical.Parameters.Add(new SqlParameter("@DyingIssuedValue", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].DyingIssuedValue;
                    cmdChemical.Parameters.Add(new SqlParameter("@ReDyingIssuedQuantity", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].ReDyingIssuedQuantity;
                    cmdChemical.Parameters.Add(new SqlParameter("@ReDyingIssuedValue", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].ReDyingIssuedValue;
                    cmdChemical.Parameters.Add(new SqlParameter("@CurrentStock", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].CurrentQuantity;
                    cmdChemical.Parameters.Add(new SqlParameter("@CurrentValue", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].CurrentValue;
                    cmdChemical.ExecuteNonQuery();
                    cmdChemical.Parameters.Clear();
                }

                objTran.Commit();
            }
            catch (Exception ex)
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
        public bool UpdateChemical(List<TanneryChemicalEL> oelTanneryChemicalCollection, SqlConnection objConn, SqlTransaction objTran)
        {

            SqlCommand cmdChemical = new SqlCommand("[Tannery].[Proc_UpdateLotChemical]", objConn, objTran);
            cmdChemical.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < oelTanneryChemicalCollection.Count; i++)
            {
                if (oelTanneryChemicalCollection[i].IsNew)
                {
                    cmdChemical.CommandText = "[Tannery].[Proc_CreateLotChemical]";
                }
                else
                {
                    cmdChemical.CommandText = "[Tannery].[Proc_UpdateLotChemical]";
                }
                cmdChemical.Parameters.Add(new SqlParameter("@IdChemical", DbType.Guid)).Value = oelTanneryChemicalCollection[i].IdChemical;
                cmdChemical.Parameters.Add(new SqlParameter("@IdLot", DbType.Guid)).Value = oelTanneryChemicalCollection[i].IdLot;
                cmdChemical.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelTanneryChemicalCollection[i].IdItem;
                cmdChemical.Parameters.Add(new SqlParameter("@CrustIssuedQuantity", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].CrustIssuedQuantity;
                cmdChemical.Parameters.Add(new SqlParameter("@CrustIssuedValue", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].CrustIssuedValue;
                cmdChemical.Parameters.Add(new SqlParameter("@DyingIssuedQuantity", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].DyingIssuedQuantity;
                cmdChemical.Parameters.Add(new SqlParameter("@DyingIssuedValue", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].DyingIssuedValue;
                cmdChemical.Parameters.Add(new SqlParameter("@ReDyingIssuedQuantity", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].ReDyingIssuedQuantity;
                cmdChemical.Parameters.Add(new SqlParameter("@ReDyingIssuedValue", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].ReDyingIssuedValue;
                cmdChemical.Parameters.Add(new SqlParameter("@CurrentStock", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].CurrentQuantity;
                cmdChemical.Parameters.Add(new SqlParameter("@CurrentValue", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].CurrentValue;
                cmdChemical.ExecuteNonQuery();
                cmdChemical.Parameters.Clear();
            }                            
            return true;
        }
        public bool UpdateChemical(List<TanneryChemicalEL> oelTanneryChemicalCollection, SqlConnection objConn)
        {
            SqlTransaction objTran = objConn.BeginTransaction();
            try
            {
                SqlCommand cmdChemical = new SqlCommand("[Tannery].[Proc_UpdateLotChemical]", objConn, objTran);
                cmdChemical.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < oelTanneryChemicalCollection.Count; i++)
                {
                    if (oelTanneryChemicalCollection[i].IsNew)
                    {
                        cmdChemical.CommandText = "[Tannery].[Proc_CreateLotChemical]";
                    }
                    else
                    {
                        cmdChemical.CommandText = "[Tannery].[Proc_UpdateLotChemical]";
                    }
                    cmdChemical.Parameters.Add(new SqlParameter("@IdChemical", DbType.Guid)).Value = oelTanneryChemicalCollection[i].IdChemical;
                    cmdChemical.Parameters.Add(new SqlParameter("@IdLot", DbType.Guid)).Value = oelTanneryChemicalCollection[i].IdLot;
                    cmdChemical.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelTanneryChemicalCollection[i].IdItem;
                    cmdChemical.Parameters.Add(new SqlParameter("@CrustIssuedQuantity", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].CrustIssuedQuantity;
                    cmdChemical.Parameters.Add(new SqlParameter("@CrustIssuedValue", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].CrustIssuedValue;
                    cmdChemical.Parameters.Add(new SqlParameter("@DyingIssuedQuantity", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].DyingIssuedQuantity;
                    cmdChemical.Parameters.Add(new SqlParameter("@DyingIssuedValue", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].DyingIssuedValue;
                    cmdChemical.Parameters.Add(new SqlParameter("@ReDyingIssuedQuantity", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].ReDyingIssuedQuantity;
                    cmdChemical.Parameters.Add(new SqlParameter("@ReDyingIssuedValue", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].ReDyingIssuedValue;
                    cmdChemical.Parameters.Add(new SqlParameter("@CurrentStock", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].CurrentQuantity;
                    cmdChemical.Parameters.Add(new SqlParameter("@CurrentValue", DbType.Decimal)).Value = oelTanneryChemicalCollection[i].CurrentValue;
                    cmdChemical.ExecuteNonQuery();
                    cmdChemical.Parameters.Clear();
                }
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
        public EntityoperationInfo DeleteChemical(Guid IdChemical, SqlConnection objConn)
        {
            EntityoperationInfo deleteInfo = new EntityoperationInfo();
            int rowsEffected = -1;
            using (SqlCommand cmdChemical = new SqlCommand("[Tannery].[Proc_DeleteLotChemical]", objConn))
            {
                cmdChemical.CommandType = CommandType.StoredProcedure;
                cmdChemical.Parameters.Add("@IdChemical", SqlDbType.BigInt).Value = IdChemical;
                ;
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
        public List<TanneryChemicalEL> GetChemicalDetailsByLot(Guid IdLot, SqlConnection objConn)
        {
            List<TanneryChemicalEL> list = new List<TanneryChemicalEL>();
            SqlCommand cmdChemicals = new SqlCommand("[Tannery].[Proc_GetChemicalDetailsByLot]", objConn);
            cmdChemicals.CommandType = CommandType.StoredProcedure;
            cmdChemicals.Parameters.Add(new SqlParameter("@IdLot", DbType.Guid)).Value = IdLot;
            cmdChemicals.CommandType = CommandType.StoredProcedure;
            objReader = cmdChemicals.ExecuteReader();
            while (objReader.Read())
            {
                TanneryChemicalEL oelChemical = new TanneryChemicalEL();
                oelChemical.IdChemical = Validation.GetSafeGuid(objReader["Chemical_Id"]);
                oelChemical.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                oelChemical.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                oelChemical.CrustIssuedQuantity = Validation.GetSafeDecimal(objReader["CrustIssuedQuantity"]);
                oelChemical.CrustIssuedValue = Validation.GetSafeDecimal(objReader["CrustIssuedValue"]);
                oelChemical.DyingIssuedQuantity = Validation.GetSafeDecimal(objReader["DyingIssuedQuantity"]);
                oelChemical.DyingIssuedValue = Validation.GetSafeDecimal(objReader["DyingIssuedValue"]);
                oelChemical.ReDyingIssuedQuantity = Validation.GetSafeDecimal(objReader["ReDyingIssuedQuantity"]);
                oelChemical.ReDyingIssuedValue = Validation.GetSafeDecimal(objReader["ReDyingIssuedValue"]);
                oelChemical.CurrentQuantity = Validation.GetSafeInteger(objReader["CurrentQuantity"]);
                oelChemical.CurrentValue = Validation.GetSafeDecimal(objReader["CurrentValue"]);

                list.Add(oelChemical);
            }

            return list;
        }
        public List<TanneryChemicalEL> GetItemAverageRate(Guid IdItem, SqlConnection objConn)
        {
            List<TanneryChemicalEL> list = new List<TanneryChemicalEL>();
            SqlCommand cmdChemicals = new SqlCommand("[Tannery].[Proc_GetItemAverageRate]", objConn);
            cmdChemicals.CommandType = CommandType.StoredProcedure;
            cmdChemicals.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = IdItem;
            cmdChemicals.CommandType = CommandType.StoredProcedure;
            objReader = cmdChemicals.ExecuteReader();
            while (objReader.Read())
            {
                TanneryChemicalEL oelChemical = new TanneryChemicalEL();
                oelChemical.Amount = Validation.GetSafeDecimal(objReader["AverageAmount"]);

                list.Add(oelChemical);
            }

            return list;
        }
        public decimal GetChemicalClosingStock(Guid IdItem, SqlConnection objConn)
        {
            SqlCommand cmdStock = new SqlCommand("[Tannery].[Proc_GetChemicalClosingStock]", objConn);
            cmdStock.CommandType = CommandType.StoredProcedure;
            cmdStock.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
            return Validation.GetSafeDecimal(cmdStock.ExecuteScalar());
        }
    }
}
