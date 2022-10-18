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
    public class RequisitionItemsDAL
    {        
        public bool InsertRequisitionItems(List<ItemFormulaEL> oelItems, SqlConnection objConn)
        {
            lock (this)
            {
                EntityoperationInfo infoResult = new EntityoperationInfo();
                SqlTransaction objTran = objConn.BeginTransaction();
                try
                {

                    SqlCommand cmdItems = new SqlCommand("[Setup].[Proc_CreateRequisitionItems]", objConn, objTran);
                    for (int i = 0; i < oelItems.Count; i++)
                    {
                        if (oelItems[i].IsNew)
                        {
                            cmdItems.CommandText = "[Setup].[Proc_CreateRequisitionItems]";
                        }
                        else
                        {
                            cmdItems.CommandText = "[Setup].[Proc_UdateRequisitionItems]";
                        }
                        cmdItems.CommandType = CommandType.StoredProcedure;
                        cmdItems.Parameters.Add(new SqlParameter("@IdArticle", DbType.Guid)).Value = oelItems[i].IdArticle;
                        cmdItems.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelItems[i].IdItem;
                        cmdItems.Parameters.Add(new SqlParameter("@UOM", DbType.Guid)).Value = oelItems[i].PackingSize;
                        cmdItems.Parameters.Add(new SqlParameter("@OperationType", DbType.Guid)).Value = oelItems[i].OperationType;
                        cmdItems.Parameters.Add(new SqlParameter("@IsCuffItem", DbType.Boolean)).Value = oelItems[i].IsCuffItem;
                        cmdItems.Parameters.Add(new SqlParameter("@IsTalliItem", DbType.Boolean)).Value = oelItems[i].IsTalliItem;
                        cmdItems.Parameters.Add(new SqlParameter("@Quantity", DbType.Decimal)).Value = oelItems[i].PerUnitTotal;
                        cmdItems.Parameters.Add(new SqlParameter("@RequiredQuantity", DbType.Decimal)).Value = oelItems[i].TotalQty;
                        cmdItems.Parameters.Add(new SqlParameter("@GrandTotal", DbType.Decimal)).Value = oelItems[i].TotalExactQty;
                        cmdItems.Parameters.Add(new SqlParameter("@IsActive", DbType.Guid)).Value = oelItems[i].IsActive;
                        cmdItems.ExecuteNonQuery();
                        cmdItems.Parameters.Clear();
                    }
                    objTran.Commit();

                }
                catch (Exception ex)
                {
                    objConn.Dispose();
                    objTran.Dispose();
                    return false;
                }
                finally
                {
                    objConn.Dispose();
                    objTran.Dispose();
                }
                return true;
            }

        }
        public bool DeleteItemsByArticle(Guid IdArticle, Guid IdItem, SqlConnection objConn)
        {
                try
                {
                    SqlCommand cmdDeleteItem = new SqlCommand("[Setup].[Proc_DeleteRequistionItems]", objConn);
                    cmdDeleteItem.Connection = objConn;
                    cmdDeleteItem.CommandType = CommandType.StoredProcedure;
                    cmdDeleteItem.Parameters.Add("@IdArticle", SqlDbType.UniqueIdentifier).Value = IdArticle;
                    cmdDeleteItem.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;
                    cmdDeleteItem.ExecuteNonQuery();            
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            
            return true;
        }
        public List<ItemFormulaEL> GetItemsByAritcle(Guid IdArticle, SqlConnection objConn)
        {
            List<ItemFormulaEL> list = new List<ItemFormulaEL>();
            SqlCommand cmdSearchAccount = new SqlCommand("[Setup].[Proc_GetAllRequisitionItemsByArticle]", objConn);

            cmdSearchAccount.Parameters.Add("@IdArticle", SqlDbType.UniqueIdentifier).Value = IdArticle;

            cmdSearchAccount.CommandType = CommandType.StoredProcedure;
            SqlDataReader oReader = cmdSearchAccount.ExecuteReader();
            while (oReader.Read())
            {
                ItemFormulaEL oelItems = new ItemFormulaEL();
                oelItems.IdItem = Validation.GetSafeGuid(oReader["Item_Id"]);
                oelItems.ItemName = Validation.GetSafeString(oReader["ItemName"]);
                oelItems.PackingSize = Validation.GetSafeString(oReader["UOM"]);
                oelItems.OperationType = Validation.GetSafeString(oReader["OperationType"]);
                oelItems.IsCuffItem = Validation.GetSafeBooleanNullable(oReader["IsCuffItem"]);
                oelItems.IsTalliItem = Validation.GetSafeBooleanNullable(oReader["IsTalliItem"]);
                oelItems.PerUnitTotal = Validation.GetSafeInteger(oReader["PerUnitQuantity"]);
                oelItems.TotalQty = Validation.GetSafeDecimal(oReader["RequiredQuantity"]);
                oelItems.TotalExactQty = Validation.GetSafeDecimal(oReader["GrandTotal"]);
                list.Add(oelItems);
            }
            return list;
        }
    }
}
