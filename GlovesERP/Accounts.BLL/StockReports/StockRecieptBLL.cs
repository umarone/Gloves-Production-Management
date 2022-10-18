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
    public class StockRecieptBLL
    {
            StockDAL dal;
            public StockRecieptBLL()
            {
                dal = new StockDAL();
            }
            public bool InsertUpdateStock(List<StockReceiptEL> oelStockReceiptCollectioin)
            {
                SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
                try
                {
                    objConn.Open();
                    return dal.InsertUpdateStock(oelStockReceiptCollectioin, objConn);
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
            public List<StockReceiptEL> GetTotalStockReport(Guid IdCategory, Guid IdCompany)
            {
                SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
                try
                {
                    objConn.Open();
                    return dal.GetTotalStockReport(IdCategory, IdCompany, objConn);
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
            public List<StockReceiptEL> GetTanneryTotalStockReport(Guid IdCategory, Guid IdCompany)
            {
                SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
                try
                {
                    objConn.Open();
                    return dal.GetTanneryTotalStockReport(IdCategory, IdCompany, objConn);
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
            public List<StockReceiptEL> GetDateWiseTotalStockReport(Guid IdCategory, Guid IdCompany, DateTime StartDate, DateTime EndDate)
            {
                SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
                try
                {
                    objConn.Open();
                    return dal.GetDateWiseTotalStockReport(IdCategory, IdCompany, StartDate, EndDate, objConn);
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
            public List<StockReceiptEL> GetTradingWiseTotalStock(Guid IdTrading, Guid IdCompany)
            {
                SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
                try
                {
                    objConn.Open();
                    return dal.GetTradingWiseTotalStock(IdTrading, IdCompany, objConn);
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
            public List<StockReceiptEL> GetDateAndTradingWiseTotalStockReport(Guid IdTrading, Guid IdCompany, DateTime StartDate, DateTime EndDate)
            {
                SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
                try
                {
                    objConn.Open();
                    return dal.GetDateAndTradingWiseTotalStockReport(IdTrading, IdCompany, StartDate, EndDate, objConn);
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

            public List<StockReceiptEL> GetRawMaterialTotalStock(Guid IdCategory, Guid IdCompany)
            {
                SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
                try
                {
                    objConn.Open();
                    return dal.GetRawMaterialTotalStock(IdCategory, IdCompany, objConn);
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
            public List<StockReceiptEL> GetDateWiseRawMaterialTotalStock(Guid IdCategory, Guid IdCompany, DateTime StartDate, DateTime EndDate)
            {
                SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
                try
                {
                    objConn.Open();
                    return dal.GetDateWiseRawMaterialTotalStock(IdCategory, IdCompany, StartDate, EndDate, objConn);
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
            public List<StockReceiptEL> GetGlovesSemiFinishMaterialTotalStock(Guid IdCategory, Guid IdCompany)
            {
                SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
                try
                {
                    objConn.Open();
                    return dal.GetGlovesSemiFinishMaterialTotalStock(IdCategory, IdCompany, objConn);
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
            public List<StockReceiptEL> GetDateWiseGlovesSemiFinishMaterialTotalStock(Guid IdCategory, Guid IdCompany, DateTime StartDate, DateTime EndDate)
            {
                SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
                try
                {
                    objConn.Open();
                    return dal.GetDateWiseGlovesSemiFinishMaterialTotalStock(IdCategory, IdCompany, StartDate, EndDate, objConn);
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
