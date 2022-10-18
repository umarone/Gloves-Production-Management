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
    public class ProductionProcessesHeadDAL
    {
        IDataReader objReader;
        //ProductionProcessesDAL PDal;
        ProductionProcessesDetailsDAL PDal;
        public ProductionProcessesHeadDAL()
        {
            //PDal = new ProductionProcessesDAL();
            PDal = new ProductionProcessesDetailsDAL();
        }
        public bool CreateProductionHeadWithMaterials(ProductionProcessesHeadEL oelProductionProcessHead, SqlConnection objConn, SqlTransaction ObjTran)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            
            SqlCommand cmdHead = new SqlCommand("[Production].[Proc_CreateProductionHead]", objConn, ObjTran);

            cmdHead.CommandType = CommandType.StoredProcedure;
            cmdHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelProductionProcessHead.IdVoucher;
            cmdHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelProductionProcessHead.IdCompany;
            cmdHead.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = oelProductionProcessHead.IdOrder;
            cmdHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelProductionProcessHead.UserId;
            cmdHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelProductionProcessHead.VoucherNo;
            cmdHead.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelProductionProcessHead.BookNo;
            cmdHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelProductionProcessHead.AccountNo;
            cmdHead.Parameters.Add(new SqlParameter("@CustomerPoNo", DbType.String)).Value = oelProductionProcessHead.CustomerPO;
            cmdHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelProductionProcessHead.VDate;
            cmdHead.Parameters.Add(new SqlParameter("@VDiscription", DbType.String)).Value = oelProductionProcessHead.VDiscription;
            cmdHead.Parameters.Add(new SqlParameter("@WorkType", DbType.Int32)).Value = oelProductionProcessHead.WorkType;
            cmdHead.Parameters.Add(new SqlParameter("@CloseDate", DbType.DateTime)).Value = oelProductionProcessHead.CloseDate;
            cmdHead.Parameters.Add(new SqlParameter("@ProductionType", DbType.Int32)).Value = oelProductionProcessHead.ProductionType;
            cmdHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelProductionProcessHead.TotalAmount;
            cmdHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelProductionProcessHead.Posted;

            cmdHead.ExecuteNonQuery();

            return true;
        }
        public EntityoperationInfo CreateProductionHead(ProductionProcessesHeadEL oelProductionProcessHead, List<ProductionProcessDetailEL> oelDetailCollection, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlTransaction objTran = objConn.BeginTransaction();
            if (!IsProductionProcessHeadExists(oelProductionProcessHead.IdVoucher, oelProductionProcessHead.IdCompany, objConn, objTran))
            {
                SqlCommand cmdHead = new SqlCommand("[Production].[Proc_CreateProductionHead]", objConn, objTran);

                cmdHead.CommandType = CommandType.StoredProcedure;
                cmdHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelProductionProcessHead.IdVoucher;
                cmdHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelProductionProcessHead.IdCompany;
                cmdHead.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = oelProductionProcessHead.IdOrder;
                cmdHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelProductionProcessHead.UserId;
                cmdHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelProductionProcessHead.VoucherNo;
                cmdHead.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelProductionProcessHead.BookNo;
                cmdHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelProductionProcessHead.AccountNo;
                cmdHead.Parameters.Add(new SqlParameter("@CustomerPoNo", DbType.String)).Value = oelProductionProcessHead.CustomerPO;
                cmdHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelProductionProcessHead.VDate;
                cmdHead.Parameters.Add(new SqlParameter("@VDiscription", DbType.String)).Value = oelProductionProcessHead.VDiscription;
                cmdHead.Parameters.Add(new SqlParameter("@WorkType", DbType.Int32)).Value = oelProductionProcessHead.WorkType;
                cmdHead.Parameters.Add(new SqlParameter("@CloseDate", DbType.DateTime)).Value = oelProductionProcessHead.CloseDate;
                cmdHead.Parameters.Add(new SqlParameter("@ProductionType", DbType.Int32)).Value = oelProductionProcessHead.ProductionType;
                cmdHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelProductionProcessHead.TotalAmount;
                cmdHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelProductionProcessHead.Posted;

                if (cmdHead.ExecuteNonQuery() > -1)
                {
                    infoResult.IsSuccess = true;
                }
                else
                {
                    infoResult.IsSuccess = false;
                }
            }
            //if (!IsProductionProcessHeadExists(oelProductionProcessHead.IdVoucher, oelProductionProcessHead.IdCompany, objConn, objTran))
            //{
            //    if (cmdHead.ExecuteNonQuery() > -1)
            //    {
            //        infoResult.IsSuccess = true;
            //    }
            //    else
            //    {
            //        infoResult.IsSuccess = false;
            //    }
            //}

            //PDal.CreateProductionProcesses(oelProductionProcess, oelDetailCollection, objConn, objTran);

            PDal.CreateProductionProcessesDetails(oelDetailCollection, objConn, objTran);
            objTran.Commit();

            infoResult.IsSuccess = true;

            return infoResult;
        }
        public EntityoperationInfo UpdateProductionHead(ProductionProcessesHeadEL oelProductionProcessHead, List<ProductionProcessDetailEL> oelDetailCollection, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlTransaction objTran = objConn.BeginTransaction();

            SqlCommand cmdHead = new SqlCommand("[Production].[Proc_UpdateProductionHead]", objConn, objTran);

            cmdHead.CommandType = CommandType.StoredProcedure;

            cmdHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelProductionProcessHead.IdVoucher;
            cmdHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelProductionProcessHead.IdCompany;
            cmdHead.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = oelProductionProcessHead.IdOrder;
            cmdHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelProductionProcessHead.UserId;
            cmdHead.Parameters.Add(new SqlParameter("@VoucherNo", DbType.Int64)).Value = oelProductionProcessHead.VoucherNo;
            cmdHead.Parameters.Add(new SqlParameter("@BookNo", DbType.Int64)).Value = oelProductionProcessHead.BookNo;
            cmdHead.Parameters.Add(new SqlParameter("@AccountNo", DbType.String)).Value = oelProductionProcessHead.AccountNo;
            cmdHead.Parameters.Add(new SqlParameter("@CustomerPoNo", DbType.String)).Value = oelProductionProcessHead.CustomerPO;
            cmdHead.Parameters.Add(new SqlParameter("@VDate", DbType.DateTime)).Value = oelProductionProcessHead.VDate;
            cmdHead.Parameters.Add(new SqlParameter("@VDiscription", DbType.String)).Value = oelProductionProcessHead.VDiscription;
            cmdHead.Parameters.Add(new SqlParameter("@WorkType", DbType.Int32)).Value = oelProductionProcessHead.WorkType;
            cmdHead.Parameters.Add(new SqlParameter("@CloseDate", DbType.DateTime)).Value = oelProductionProcessHead.CloseDate;
            cmdHead.Parameters.Add(new SqlParameter("@ProductionType", DbType.Int32)).Value = oelProductionProcessHead.ProductionType;
            cmdHead.Parameters.Add(new SqlParameter("@TotalAmount", DbType.Decimal)).Value = oelProductionProcessHead.TotalAmount;
            cmdHead.Parameters.Add(new SqlParameter("@Posted", DbType.Boolean)).Value = oelProductionProcessHead.Posted;
            //if (cmdItems.ExecuteNonQuery() > -1 && cmdAccounts.ExecuteNonQuery() > -1)
            if (cmdHead.ExecuteNonQuery() > -1)
            {
                infoResult.IsSuccess = true;
            }
            else
            {
                infoResult.IsSuccess = false;
            }

            //PDal.UpdateProductionProcesses(oelProductionProcess, oelDetailCollection, objConn, objTran);
            PDal.UpdateProductionProcessesDetails(oelDetailCollection, objConn, objTran);

            objTran.Commit();

            return infoResult;
        }
        public bool DeleteInspectionPackingByVoucher(Guid IdVoucher, SqlConnection objConn)
        {
            using (SqlTransaction oTran = objConn.BeginTransaction())
            {
                try
                {
                    SqlCommand cmdDelete = new SqlCommand("[Production].[Proc_DeleteInspectionPackingByVoucher]", objConn);
                    cmdDelete.Transaction = oTran;
                    cmdDelete.CommandType = CommandType.StoredProcedure;
                    cmdDelete.Parameters.Add("@IdVoucher", SqlDbType.UniqueIdentifier).Value = IdVoucher;
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
        public EntityoperationInfo CreateUpdateGlovesProductionOpeningStock(ProductionProcessesHeadEL oelProductionProcessHead, List<ProductionProcessDetailEL> oelDetailCollection, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();
            SqlTransaction objTran = objConn.BeginTransaction();
            if (oelProductionProcessHead.IdVoucher != Guid.Empty && oelProductionProcessHead.IsNew)
            {
                CreateProductionHeadWithMaterials(oelProductionProcessHead, objConn, objTran);
            }
            SqlCommand cmdHead = new SqlCommand("", objConn, objTran);
            cmdHead.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < oelDetailCollection.Count; i++)
            {
                if (oelDetailCollection[i].IsNew)
                {
                    cmdHead.CommandText = "[Production].[Proc_CreateProductionOpeningStock]";
                }
                else
                {
                    cmdHead.CommandText = "[Production].[Proc_UpdateProductionOpeningStock]";
                }
                cmdHead.Parameters.Add(new SqlParameter("@IdProductionOpeningStock", DbType.Guid)).Value = oelDetailCollection[i].IdProductionProcessDetail;
                //cmdHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = oelDetailCollection[i].IdCompany;
                cmdHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = oelDetailCollection[i].IdVoucher;
                cmdHead.Parameters.Add(new SqlParameter("@PoNumber", DbType.String)).Value = oelDetailCollection[i].PoNumber;
                //cmdHead.Parameters.Add(new SqlParameter("@IdUser", DbType.Guid)).Value = oelDetailCollection[i].UserId;
                cmdHead.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelDetailCollection[i].IdItem;
                cmdHead.Parameters.Add(new SqlParameter("@IdBrand", DbType.Guid)).Value = oelDetailCollection[i].IdBrand;
                cmdHead.Parameters.Add(new SqlParameter("@IdColor", DbType.Guid)).Value = oelDetailCollection[i].IdColor;
                cmdHead.Parameters.Add(new SqlParameter("@IdProcessHead", DbType.Int32)).Value = oelDetailCollection[i].ProductionType;
                cmdHead.Parameters.Add(new SqlParameter("@IdProcess", DbType.Int32)).Value = oelDetailCollection[i].IdProductionDepartment;
                cmdHead.Parameters.Add(new SqlParameter("@ProcessName", DbType.String)).Value = oelDetailCollection[i].ProductionProcessName;
                cmdHead.Parameters.Add(new SqlParameter("@ItemSize", DbType.String)).Value = oelDetailCollection[i].ItemSize;
                cmdHead.Parameters.Add(new SqlParameter("@GType", DbType.Int32)).Value = oelDetailCollection[i].GType;
                cmdHead.Parameters.Add(new SqlParameter("@WorkType", DbType.Int32)).Value = oelDetailCollection[i].GarmentWorkType;
                cmdHead.Parameters.Add(new SqlParameter("@Quantity", DbType.Int32)).Value = oelDetailCollection[i].Qty;
                cmdHead.Parameters.Add(new SqlParameter("@Rate", DbType.Decimal)).Value = oelDetailCollection[i].UnitPrice;
                cmdHead.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelDetailCollection[i].Amount;
                cmdHead.ExecuteNonQuery();
                cmdHead.Parameters.Clear();
            }


            objTran.Commit();

            infoResult.IsSuccess = true;

            return infoResult;
        }
        private bool IsProductionProcessHeadExists(Guid IdVoucher, Guid? IdCompany, SqlConnection objConn, SqlTransaction objTran)
        {
            bool Status = false;
            SqlCommand cmdProdcutionProcessHead = new SqlCommand("[Production].[Proc_IsProductionProcessHeadExists]", objConn, objTran);

            cmdProdcutionProcessHead.CommandType = CommandType.StoredProcedure;
            cmdProdcutionProcessHead.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Guid)).Value = IdVoucher;
            cmdProdcutionProcessHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany.Value;
            objReader = cmdProdcutionProcessHead.ExecuteReader();
            while (objReader.Read())
            {
                Status = true;
                break;
            }
            objReader.Close();
            return Status;
        }
        public List<ProductionProcessesHeadEL> GetProductionByNumberAndType(Guid IdCompany, Int64 ProductionNumber, Int32 ProductionType, SqlConnection objConn)
        {
            List<ProductionProcessesHeadEL> list = new List<ProductionProcessesHeadEL>();
            SqlCommand cmdProductionHead = new SqlCommand("[Production].[Proc_GetProductionByNumberAndType]", objConn);
            cmdProductionHead.CommandType = CommandType.StoredProcedure;
            cmdProductionHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdProductionHead.Parameters.Add(new SqlParameter("@ProudctionNumber", DbType.Int64)).Value = ProductionNumber;
            cmdProductionHead.Parameters.Add(new SqlParameter("@ProductionType", DbType.Int32)).Value = ProductionType;
            objReader = cmdProductionHead.ExecuteReader();
            while (objReader.Read())
            {
                ProductionProcessesHeadEL oelProductionProcessHead = new ProductionProcessesHeadEL();
                oelProductionProcessHead.IdVoucher = Validation.GetSafeGuid(objReader["Voucher_Id"]);
                list.Add(oelProductionProcessHead);
            }
            return list;
        }
        public Int64 GetMaxProductionProcessCode(Guid IdCompany, Int32 WorkType, Int32 ProductionType, SqlConnection objConn)
        {
            SqlCommand cmdProductionHead = new SqlCommand("[Production].[Proc_GetMaxProductionProcessCode]", objConn);
            cmdProductionHead.CommandType = CommandType.StoredProcedure;
            cmdProductionHead.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
            cmdProductionHead.Parameters.Add(new SqlParameter("@WorkType", DbType.Int32)).Value = WorkType;
            cmdProductionHead.Parameters.Add(new SqlParameter("@ProductionType", DbType.Int32)).Value = ProductionType;
            return Validation.GetSafeLong(cmdProductionHead.ExecuteScalar());
        }
        public EntityoperationInfo UpdateProductionProcessDetailEntries(Guid IdEntity, Guid IdVoucher, bool Posted, SqlConnection objConn)
        {
            EntityoperationInfo infoResult = new EntityoperationInfo();

            SqlCommand cmdProcess = new SqlCommand("[Production].[Proc_UpdateProductionProcessDetailEntry]", objConn);

            cmdProcess.CommandType = CommandType.StoredProcedure;
            cmdProcess.Parameters.Add(new SqlParameter("@IdEntity", DbType.Guid)).Value = IdEntity;
            cmdProcess.Parameters.Add(new SqlParameter("@IdVoucher", DbType.Int64)).Value = IdVoucher;
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
        public List<ProductionProcessesHeadEL> GetCustomerPOSByStatusAndType(int OrderType, SqlConnection objConn)
        {
            List<ProductionProcessesHeadEL> list = new List<ProductionProcessesHeadEL>();
            SqlCommand cmdPos = new SqlCommand("[Production].[Proc_GetCustomerPosByStatusAndType]", objConn);
            cmdPos.Parameters.Add(new SqlParameter("@OrderType", DbType.String)).Value = OrderType;
            cmdPos.CommandType = CommandType.StoredProcedure;
            objReader = cmdPos.ExecuteReader();
            while (objReader.Read())
            {
                ProductionProcessesHeadEL oelHead = new ProductionProcessesHeadEL();
                oelHead.CustomerPO = Validation.GetSafeString(objReader["PoNumber"]);

                list.Add(oelHead);
            }
            return list;
        }
        public List<TanneryProcessesHeadEL> GetVoucherInfoByCustomerPo(string CustomerPo, int ProductionType, SqlConnection objConn)
        {
            List<TanneryProcessesHeadEL> list = new List<TanneryProcessesHeadEL>();
            SqlCommand cmdVoucherInfo = new SqlCommand("[Production].[Proc_GetVoucherInfoByCustomerPo]", objConn);
            cmdVoucherInfo.Parameters.Add(new SqlParameter("@PoNumber", DbType.String)).Value = CustomerPo;
            cmdVoucherInfo.Parameters.Add(new SqlParameter("@ProductionType", DbType.Int32)).Value = ProductionType;
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
        public List<ItemsEL> GetArticleClosingStockForInspectionPacking(Guid IdArticle, string AccountNo, int WorkType, int ProductionType, SqlConnection objConn)
        {
            List<ItemsEL> list = new List<ItemsEL>();
            SqlCommand cmdStock = new SqlCommand("[Production].[Proc_GetClosingStockForInspectionPacking]", objConn);
            cmdStock.CommandType = CommandType.StoredProcedure;
            cmdStock.Parameters.Add("@IdArticle", SqlDbType.UniqueIdentifier).Value = IdArticle;
            cmdStock.Parameters.Add("@AccountNo", SqlDbType.VarChar).Value = AccountNo;
            cmdStock.Parameters.Add("@WorkType", SqlDbType.Int).Value = WorkType;
            cmdStock.Parameters.Add("@ProductionType", SqlDbType.Int).Value = ProductionType;
            objReader = cmdStock.ExecuteReader();
            while (objReader.Read())
            {
                ItemsEL oelItem = new ItemsEL();
                oelItem.Qty = Validation.GetSafeDecimal(objReader["Closing"]);


                list.Add(oelItem);
            }

            return list;
        }
    }
}
