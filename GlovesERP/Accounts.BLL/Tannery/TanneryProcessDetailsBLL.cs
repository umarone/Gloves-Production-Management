using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Accounts.DAL;
using Accounts.Common;
using Accounts.EL;
using System.Data.SqlClient;

namespace Accounts.BLL
{
    public class TanneryProcessDetailsBLL
    {
        TanneryProcessesDetailsDAL dal;
        public TanneryProcessDetailsBLL()
        {
            dal = new TanneryProcessesDetailsDAL();
        }
        public List<TanneryProcessDetailsEL> GetProcessesDetailByVehicleAndProcess(Guid IdCompany,string ProcessName,string VehicleNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetProcessesDetailByVehicleAndProcess(IdCompany, ProcessName, VehicleNo, objConn);
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
        public List<TanneryProcessDetailsEL> GetProcessesDetailByVoucherNoAndProcess(Guid IdCompany, string ProcessName, string VoucherNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetProcessesDetailByVoucherNoAndProcess(IdCompany, ProcessName, VoucherNo, objConn);
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
        public List<TanneryProcessesEL> GetProcessDetailByName(string ProcessName, Guid IdVoucher)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetProcessDetailByName(ProcessName, IdVoucher, objConn);
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
        public List<TanneryProcessDetailsEL> GetVendorDateWiseWorkReport(string AccountNo, bool WorkType, DateTime startDate, DateTime endDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetVendorDateWiseWorkReport(AccountNo, WorkType, startDate, endDate, objConn);
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
        public List<TanneryProcessDetailsEL> GetProcessesWorkersDetailReport(string AccountNo, string WorkType, DateTime startDate, DateTime endDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetProcessesWorkersDetailReport(AccountNo, WorkType, startDate, endDate, objConn);
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
        public List<TanneryProcessDetailsEL> GetVehicleWiseShavingStock(string VehicleNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetVehicleWiseShavingStock(VehicleNo, objConn);
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
        public List<TanneryProcessDetailsEL> GetVehicleWiseSplittingStock(string VehicleNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetVehicleWiseSplittingStock(VehicleNo, objConn);
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
        public bool DeleteProcessEntry(Guid IdEntry, Guid IdVoucher, string ProcessName)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.DeleteProcessEntry(IdEntry, IdVoucher, ProcessName, objConn);
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

        public List<TanneryProcessDetailsEL> GetDateWiseDepartmentProcessWork(Guid IdCompany, Guid IdDepartment, DateTime startDate, DateTime endDate)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetDateWiseDepartmentProcessWork(IdCompany, IdDepartment, startDate, endDate, objConn);
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
        public Int64 GetProcessesClosingStock(string ProcessName, string ChildProcess, string PiecesType, string ChildPiecesType, int IdHeader, string VehicleNo, Guid IdLot)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetProcessesClosingStock(ProcessName, ChildProcess, PiecesType, ChildPiecesType, IdHeader, VehicleNo, IdLot, objConn);
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
        public Int64 GetProcessesCompareStockBeforeDeleting(string ProcessName, string ChildProcess, string PiecesType, string ChildPiecesType, int IdHeader, string VehicleNo, Guid IdLot)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetProcessesCompareStockBeforeDeleting(ProcessName, ChildProcess, PiecesType, ChildPiecesType, IdHeader, VehicleNo, IdLot, objConn);
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
        public decimal GetVehicleClosingWeight(string VehicleNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetVehicleClosingWeight(VehicleNo, objConn);
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
