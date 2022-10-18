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
    public class OrdersBLL
    {
        OrdersDAL dal;
        EntityoperationInfo infoResult;
        bool status;
        public OrdersBLL()
        {
            dal = new OrdersDAL();
            infoResult = new EntityoperationInfo();
        }
        public bool InsertOrders(OrdersEL oelOrder, List<OrdersDetailEL> oelOrderDetailCollection, List<ItemsAttributesDetailsEL> oelBreakupCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                status = dal.InsertOrders(oelOrder, oelOrderDetailCollection, oelBreakupCollection, objConn);
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
            return status;
        }
        public bool UpdateOrder(OrdersEL oelOrder, List<OrdersDetailEL> oelOrdersDetailCollection, List<ItemsAttributesDetailsEL> oelBreakupCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                status = dal.UpdateOrder(oelOrder, oelOrdersDetailCollection, oelBreakupCollection, objConn);
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
            return status;
        }
        public bool DeleteOrders(Guid IdOrder)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                status = dal.DeleteOrders(IdOrder, objConn);
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
            return status;
        }
        public string GetMaxOrderNumber(Int32 OrderType, Guid IdCompany)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetMaxOrderNumber(OrderType, IdCompany, objConn);
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
        public List<OrdersEL> GetOpenCustomerPos(int OrderType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetOpenCustomerPos(OrderType, objConn);
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
        public bool CheckPoNumber(string PoNumber, int OrderType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.CheckPoNumber(PoNumber, OrderType, objConn);
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
        public List<OrdersEL> GetCustomerOrdersByType(Guid IdCompany, string AccountNo, int OrderType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetCustomerOrdersByType(IdCompany, AccountNo, OrderType, objConn);
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
        public bool CompleteOrder(Guid IdOrder)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                status = dal.CompleteOrder(IdOrder, objConn);
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
            return status;
        }
        public List<OrdersEL> GetOrderDetailByCustomerPo(Guid IdCompany, string CustomerPoNumber, int OrderType)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetOrderDetailByCustomerPo(IdCompany, CustomerPoNumber, OrderType, objConn);
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
