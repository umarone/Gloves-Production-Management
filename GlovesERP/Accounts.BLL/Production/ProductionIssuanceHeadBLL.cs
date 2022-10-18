using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using Accounts.DAL;
using Accounts.Common;
using Accounts.EL;

namespace Accounts.BLL
{
    public class ProductionIssuanceHeadBLL
    {
        EntityoperationInfo infoResult;
        ProductionIssuanceHeadDAL dal;
        ProductionIssuanceDetailDAL dal1;
        public ProductionIssuanceHeadBLL()
        { 
            dal = new ProductionIssuanceHeadDAL();
            dal1 = new ProductionIssuanceDetailDAL();
        }
        public EntityoperationInfo InsertProductionIssuance(VouchersEL oelVoucher, List<VoucherDetailEL> oelProductionCollection, List<ProductionBatchesEL> BatchList, bool WorkType)
        {
             SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                infoResult = dal.InsertProductionIssuance(oelVoucher, oelProductionCollection, WorkType, BatchList, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
            return infoResult;
        }
        public EntityoperationInfo UpdateProductionIssuance(VouchersEL oelVoucher, List<VoucherDetailEL> oelProductionCollection, bool WorkType)
        {
             SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                infoResult = dal.UpdateProductionIssuance(oelVoucher, oelProductionCollection, WorkType, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
            return infoResult;
        }
        public Int64 GetMaxVoucherNumber(Guid IdCompany, int IssuanceType, int OperationType, int ProductionType)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.GetMaxVoucherNumber(IdCompany, IssuanceType, OperationType, ProductionType, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        public bool DeleteGatePass(Guid IdVoucher, int ProductionType)
        {
            SqlConnection objconn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objconn.Open();
                return dal.DeleteGatePass(IdVoucher, ProductionType, objconn);
            }
            catch (Exception ex)
            {
                objconn.Close();
                objconn.Dispose();
                throw ex;
            }
            finally
            {
                if (objconn.State == ConnectionState.Open)
                {
                    objconn.Close();
                    objconn.Dispose();
                }
            }
        }
        public List<VouchersEL> GetProductionIssuanceVoucherByNo(Int64 IssuanceNo, Guid IdCompany, int IssuanceType, int OperationType, int ProductionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetProductionIssuanceVoucherByNo(IssuanceNo, IdCompany, IssuanceType, OperationType, ProductionType, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public List<VoucherDetailEL> GetProductionStockIssuanceByNo(Int64 IssuanceNo, Guid IdCompany, int IssuanceType, int ProductionType, Guid IdProductionIssuance)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal1.GetProductionStockIssuanceByNo(IssuanceNo, IdCompany, IssuanceType, ProductionType, IdProductionIssuance, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            } 
        }
        public List<VoucherDetailEL> GetProcessWiseWorkerReport(Guid IdCompany, string AccountNo, int OperationType, int ProductionType, string OutPutProcessName, string MaterialProcessName)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal1.GetProcessWiseWorkerReport(IdCompany, AccountNo, OperationType, ProductionType, OutPutProcessName, MaterialProcessName, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public List<VoucherDetailEL> GetProcessWiseWorkerReportByDate(Guid IdCompany, string AccountNo, DateTime StartDate, DateTime EndDate, int OperationType, int ProductionType, string OutPutProcessName, string MaterialProcessName)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal1.GetProcessWiseWorkerReportByDate(IdCompany, AccountNo, StartDate, EndDate, OperationType, ProductionType, OutPutProcessName, MaterialProcessName, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public List<VoucherDetailEL> GetProductionStockIssuanceDetailForTalliBariByNo(Int64 IssuanceNo, Guid IdCompany)
        {

            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal1.GetProductionStockIssuanceDetailForTalliBariByNo(IssuanceNo, IdCompany, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public List<VoucherDetailEL> GetRubberingStockById(Guid IdItem, Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal1.GetRubberingStockById(IdCompany, IdItem, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }

        public List<VoucherDetailEL> GetWorkInProcessReportByWorker(Guid IdArticle, int ProductionType, string AccountNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal1.GetWorkInProcessReportByWorker(IdArticle, ProductionType, AccountNo, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public List<VoucherDetailEL> GetDateWiseWorkInProcessReportByWorker(Guid IdArticle, int ProductionType, string AccountNo, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal1.GetDateWiseWorkInProcessReportByWorker(IdArticle, ProductionType, AccountNo, StartDate, EndDate, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public List<VoucherDetailEL> GetProcessWiseStock(int ProcessIndex)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal1.GetProcessWiseStock(ProcessIndex, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public List<VoucherDetailEL> GetProcessWiseStockByItem(Guid IdItem, int ProcessIndex)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal1.GetProcessWiseStockByItem(IdItem, ProcessIndex, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public List<VoucherDetailEL> GetGlovesGarmentsWorkerFinancialReport(Int64 OperationType, string AccountNo, Guid IdCompany, int ProductionType,
            DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal1.GetGlovesGarmentsWorkerFinancialReport(OperationType, AccountNo, IdCompany, ProductionType, StartDate,EndDate, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public decimal GetGlovesBatchWiseItemAvgCosting(Guid IdItem, Int64 BatchNo, int ProductionType, string OperationType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal1.GetGlovesBatchWiseItemAvgCosting(IdItem, BatchNo, ProductionType, OperationType, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public decimal GetGlovesStitchingAvgCosting(Guid IdItem, int ProductionType, int IdDepartment)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal1.GetGlovesStitchingAvgCosting(IdItem, ProductionType, IdDepartment, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public decimal GetGlovesBatchWiseItemClosingStock(Guid IdItem, Int64 BatchNo, int ProductionType, int IssuanceType, string OperationType, int IdDepartment)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal1.GetGlovesBatchWiseItemClosingStock(IdItem, BatchNo, ProductionType, IssuanceType, OperationType, IdDepartment, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public decimal GetBatchWiseCuffsCost(Guid IdItem, int ProductionType, Int64 BatchNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal1.GetBatchWiseCuffsCost(IdItem, ProductionType, BatchNo, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public List<BrandEL> GetBrandByBatch(Int64 BatchNo, int ProductionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal1.GetBrandByBatch(BatchNo, ProductionType, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public decimal GetProductionOpeningPurchasedExtraUnitsByItem(Guid IdItem)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal1.GetProductionOpeningPurchasedExtraUnitsByItem(IdItem, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public decimal GetStockForStitching(Guid IdItem, int ProductionType, int IdDepartment)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal1.GetStockForStitching(IdItem, ProductionType, IdDepartment, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
        public decimal GetRepairStockClosingStockForAllArticles(Guid IdItem, Guid IdOrder, string AccountNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal1.GetRepairStockClosingStockForAllArticles(IdItem, IdOrder, AccountNo, objConn);
            }
            catch (Exception ex)
            {
                objConn.Close();
                objConn.Dispose();
                throw ex;
            }
            finally
            {
                if (objConn.State == System.Data.ConnectionState.Open)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
            }
        }
    }
}

