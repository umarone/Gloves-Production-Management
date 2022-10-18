using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Accounts.DAL;
using Accounts.Common;
using Accounts.EL;
using System.Data.SqlClient;
using System.Data;

namespace Accounts.BLL
{
    public class ProductionProcessDetailBLL
    {
        ProductionProcessesDetailsDAL dal;
        public ProductionProcessDetailBLL()
        {
            dal = new ProductionProcessesDetailsDAL();
        }
        public List<ProductionProcessDetailEL> GetGarmentProcessesDetailByVoucherNoAndProcess(Guid IdCompany, string ProcessName, Int64 VoucherNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetGarmentProcessesDetailByVoucherNoAndProcess(IdCompany, ProcessName, VoucherNo, objConn);
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
        public List<ProductionProcessDetailEL> GetGarmentProcessesDetailByCustomerPoNoAndProcess(Guid IdCompany, string ProcessName, string CustomerPo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetGarmentProcessesDetailByCustomerPoNoAndProcess(IdCompany, ProcessName, CustomerPo, objConn);
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
        public List<ProductionProcessDetailEL> GetVendorDateWiseWorkReport(string AccountNo, int ProductionType, DateTime startDate, DateTime endDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetVendorDateWiseWorkReport(AccountNo, ProductionType, startDate, endDate, objConn);
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
        public List<ProductionProcessDetailEL> GetProductionProcessDetailByVoucherNoAndProductionType(Guid IdCompany, Int64 VoucherNo, int WorkType, int ProductionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetProductionProcessDetailByVoucherNoAndProductionType(IdCompany, VoucherNo, WorkType, ProductionType, objConn);
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
        public List<ProductionProcessesEL> GetProcessDetailByName(string ProcessName)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetProcessDetailByName(ProcessName, objConn);
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
        public List<ProductionProcessDetailEL> GetOrderCosting(string CustomerPoNo, int ProductionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetOrderCosting(CustomerPoNo, ProductionType, objConn);
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
        public bool DeleteGarmentsProcessEntry(Guid IdEntry, Guid IdVoucher)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.DeleteGarmentsProcessEntry(IdEntry, IdVoucher, objConn);
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

        public List<ProductionProcessDetailEL> GetWorkerInspectionPackingReport(Guid IdCompany, string AccountNo, int WorkType, int ProductionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetWorkerInspectionPackingReport(IdCompany, AccountNo, WorkType, ProductionType, objConn);
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
        public List<ProductionProcessDetailEL> GetWorkerInspectionPackingReportByDate(Guid IdCompany, string AccountNo, DateTime StartDate, DateTime EndDate, int WorkType, int ProductionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetWorkerInspectionPackingReportByDate(IdCompany, AccountNo, StartDate, EndDate, WorkType, ProductionType, objConn);
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
        public List<ProductionProcessDetailEL> GetStitcherWorkerInspectionReport(Guid IdCompany, string AccountNo, int WorkType, int ProductionType, int WorkerType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetStitcherWorkerInspectionReport(IdCompany, AccountNo, WorkType, ProductionType, WorkerType, objConn);
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
        public List<ProductionProcessDetailEL> GetStitcherWorkerInspectionReportByDate(Guid IdCompany, string AccountNo, DateTime StartDate, DateTime EndDate, int WorkType, int ProductionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetStitcherWorkerInspectionReportByDate(IdCompany, AccountNo, StartDate, EndDate, WorkType, ProductionType, objConn);
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
        public DataTable GetStitcherArticleWiseCrossTabInfo(string AccountNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetStitcherArticleWiseCrossTabInfo(AccountNo, objConn);
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
        public DataTable GetStitcherArticleWiseCrossTabInfoByArticle(string AccountNo, Guid IdItem)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetStitcherArticleWiseCrossTabInfoByArticle(AccountNo, IdItem, objConn);
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
        public List<VoucherDetailEL> GetReadyToInspectionStockByArticle(Guid IdArticle, int ProductionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetReadyToInspectionStockByArticle(IdArticle, ProductionType, objConn);
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
        public List<VoucherDetailEL> GetReadyToInspectionStockForAllArticles(int ProductionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetReadyToInspectionStockForAllArticles(ProductionType, objConn);
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
        public List<VoucherDetailEL> GetReadyToPackingStockByArticle(Guid IdArticle, int ProductionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetReadyToPackingStockByArticle(IdArticle, ProductionType, objConn);
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
        public List<VoucherDetailEL> GetReadyToPackingStockForAllArticles(int ProductionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetReadyToPackingStockForAllArticles(ProductionType, objConn);
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

        public List<VoucherDetailEL> GetGlovesRepairableClosingStock(Guid IdItem)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetGlovesRepairableClosingStock(IdItem, objConn);
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
        public List<VoucherDetailEL> GetRepairStockByArticle(Guid IdArticle, int ProductionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetRepairStockByArticle(IdArticle, ProductionType, objConn);
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
        public List<VoucherDetailEL> GetRepairStockForAllArticles(int ProductionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetRepairStockForAllArticles(ProductionType, objConn);
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
        public List<VoucherDetailEL> GetRepairStockByArticleAndWorker(Guid IdArticle, int ProductionType, string AccountNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetRepairStockByArticleAndWorker(IdArticle, ProductionType, AccountNo, objConn);
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
        public List<VoucherDetailEL> GetGlovesGarmentsRejectionClosingStock(Guid IdItem, int ProductionType, int SaleType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetGlovesGarmentsRejectionClosingStock(IdItem,ProductionType,SaleType, objConn);
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

        public List<VoucherDetailEL> GetGlovesGarmentsRejectionStockByArticle(Guid IdArticle, int ProductionType, int SaleType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetGlovesGarmentsRejectionStockByArticle(IdArticle, ProductionType, SaleType, objConn);
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
        public List<VoucherDetailEL> GetGlovesGarmentsTotalCartonsStockByArticle(Guid IdArticle, int ProductionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetGlovesGarmentsTotalCartonsStockByArticle(IdArticle, ProductionType, objConn);
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
        public List<VoucherDetailEL> GetGlovesGarmentsTotalCartonsClosingStock(Guid IdItem, int ProductionType, int SaleType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetGlovesGarmentsTotalCartonsClosingStock(IdItem, ProductionType, SaleType, objConn);
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
        public List<VoucherDetailEL> GetRepairStockByStitcher(string AccountNo, int ProductionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetRepairStockByStitcher(AccountNo, ProductionType, objConn);
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
        public List<VoucherDetailEL> GetRepairStockForAllArticlesByStitcher(int ProductionType, string AccountNo)
        {

            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetRepairStockForAllArticlesByStitcher(ProductionType, AccountNo, objConn);
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

        public List<ProductionProcessDetailEL> GetProductionOpeningStockByOrder(Guid IdVoucher, int ProductionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetProductionOpeningStockByOrder(IdVoucher, ProductionType, objConn);
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
        #region Work In Process Reports
        public List<VoucherDetailEL> GetArticleWiseInOutStock(Guid IdArticle, int ProductionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetArticleWiseInOutStock(IdArticle, ProductionType, objConn);
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
        public List<VoucherDetailEL> GetArticleDateWiseInOutStock(Guid IdArticle, int ProductionType, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetArticleDateWiseInOutStock(IdArticle, ProductionType, StartDate, EndDate, objConn);
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

        public List<VoucherDetailEL> GetWorkInProcessReport(Guid IdArticle, int ProductionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetWorkInProcessReport(IdArticle, ProductionType, objConn);
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
        public List<VoucherDetailEL> GetDateWiseWorkInProcessReport(Guid IdArticle, int ProductionType, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetDateWiseWorkInProcessReport(IdArticle, ProductionType, StartDate, EndDate, objConn);
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
        #endregion
        #region Stock Check Methods
        public decimal GetGlovesProductionClosingStockByCustomerPO(Guid IdItem, int IdDepartment, string ProcessName, string CustomerPoNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetGlovesProductionClosingStockByCustomerPO(IdItem, IdDepartment, ProcessName, CustomerPoNo, objConn);
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
        public decimal GetGlovesRepairProductionClosingStockByCustomerPO(Guid IdItem, int IdDepartment, string ProcessName, string CustomerPoNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetGlovesRepairProductionClosingStockByCustomerPO(IdItem, IdDepartment, ProcessName, CustomerPoNo, objConn);
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
        public decimal GetGlovesAvgCostingByCustomerPO(Guid IdItem, int IdDepartment, string ProcessName, string CustomerPoNo, string CaseType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetGlovesAvgCostingByCustomerPO(IdItem, IdDepartment, ProcessName, CustomerPoNo, CaseType, objConn);
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

        public decimal GetGarmentProductionClosingStockByCustomerPO(Guid IdItem, Guid IdColor, Int64 BundleNo, string ProcessName, string SubProcessName, string CustomerPoNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetGarmentProductionClosingStockByCustomerPO(IdItem, IdColor, BundleNo, ProcessName, SubProcessName, CustomerPoNo, objConn);
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
        public decimal GetGarmentAvgCostingByCustomerPO(Guid IdItem, Guid IdColor, string ProcessName, string SubProcessName, string CustomerPoNo)
        {

            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetGarmentAvgCostingByCustomerPO(IdItem, IdColor, ProcessName, SubProcessName, CustomerPoNo, objConn);
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
        #endregion
        #region Inspection Related Methods
        public decimal GetGlovesDepartmentClosingStockInInspection(Guid IdArticle, string AccountNo, Int32 IdDepartment, string CustomerPoNumber)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetGlovesDepartmentClosingStockInInspection(IdArticle, AccountNo, IdDepartment, CustomerPoNumber, objConn);
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
        #endregion
        #region Gloves Reports
        #region Gloves Financial Reports
        public List<ProductionProcessDetailEL> GetWorkerWeeklyFinancialPerformanceBill(int ProductionType, string AccountNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetWorkerWeeklyFinancialPerformanceBill(ProductionType, AccountNo, objConn);
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
        public List<ProductionProcessDetailEL> GetWorkerWeeklyFinancialPerformanceBillByDate(int ProductionType, string AccountNo, DateTime StartDate, DateTime EndDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetWorkerWeeklyFinancialPerformanceBillByDate(ProductionType, AccountNo, StartDate, EndDate, objConn);
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
        #endregion
         #endregion
        #region Costing Related Methods
        public List<ProductionProcessDetailEL> GetAllOrdersCosting(int ProductionType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetAllOrdersCosting(ProductionType, objConn);
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
        public List<ProductionProcessDetailEL> GetProductionOrderLabourCostingDetail(Guid IdOrder)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetProductionOrderLabourCostingDetail(IdOrder, objConn);
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
        public List<ProductionProcessDetailEL> GetProductionOrderMaterialCostingDetail(Guid IdOrder)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetProductionOrderMaterialCostingDetail(IdOrder, objConn);
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
        public List<ProductionProcessDetailEL> GetProductionOrderMiscCostingDetail(Guid IdOrder)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetProductionOrderMiscCostingDetail(IdOrder, objConn);
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
        #endregion
        #region Misc
        public Int64 GetMaxBundleNoByArticleAndColor(Guid IdArticle, Guid IdColor)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetMaxBundleNoByArticleAndColor(IdArticle, IdColor, objConn);
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
        #endregion
    }
}
