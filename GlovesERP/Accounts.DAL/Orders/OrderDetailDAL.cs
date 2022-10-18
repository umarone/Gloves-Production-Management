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
   public class OrderDetailDAL
    {
        IDataReader objReader;
        public bool InsertOrderDetail(List<OrdersDetailEL> oelOrderDetailCollection, SqlConnection objConn, SqlTransaction oTran)
        {
            SqlCommand cmdOrdersDetail = new SqlCommand("[Transactions].[Proc_CreateOrdersDetails]", objConn);
            cmdOrdersDetail.CommandType = CommandType.StoredProcedure;
            cmdOrdersDetail.CommandTimeout = 0;
            cmdOrdersDetail.Transaction = oTran;
            for (int i = 0; i < oelOrderDetailCollection.Count; i++)
            {
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@IdOrderDetail", DbType.Guid)).Value = oelOrderDetailCollection[i].IdOrderDetail;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = oelOrderDetailCollection[i].IdOrder;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelOrderDetailCollection[i].IdAccount;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@IdSize", DbType.Guid)).Value = oelOrderDetailCollection[i].IdSize;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@IdColor", DbType.Guid)).Value = oelOrderDetailCollection[i].IdColor;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@SeqNo", DbType.Int32)).Value = oelOrderDetailCollection[i].Seq;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@Configuration", DbType.String)).Value = oelOrderDetailCollection[i].Configuration;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@Color", DbType.String)).Value = oelOrderDetailCollection[i].Color;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@TotalQuantity", DbType.Int64)).Value = oelOrderDetailCollection[i].Quantity;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelOrderDetailCollection[i].UnitPrice;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelOrderDetailCollection[i].Amount;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@DeliveredQuantity", DbType.Int64)).Value = oelOrderDetailCollection[i].DeliveredQuantity;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@RemainingQuantity", DbType.Int64)).Value = oelOrderDetailCollection[i].DeliveredRemainderQuantity;
              
                cmdOrdersDetail.ExecuteNonQuery();
                cmdOrdersDetail.Parameters.Clear();
            }
            return true;
        }
        public bool UpdateOrdersDetail(List<OrdersDetailEL> oelOrderDetailCollection, SqlConnection objConn, SqlTransaction oTran)
        {
            SqlCommand cmdOrdersDetail = new SqlCommand();
            cmdOrdersDetail.CommandType = CommandType.StoredProcedure;
            cmdOrdersDetail.Connection = objConn;
            cmdOrdersDetail.Transaction = oTran;
            for (int i = 0; i < oelOrderDetailCollection.Count; i++)
            {
                if (oelOrderDetailCollection[i].IsNew)
                {
                    cmdOrdersDetail.CommandText = "[Transactions].[Proc_CreateOrdersDetails]";
                }
                else
                {
                    cmdOrdersDetail.CommandText = "[Transactions].[Proc_UpdateOrdersDetails]";
                }
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@IdOrderDetail", DbType.Guid)).Value = oelOrderDetailCollection[i].IdOrderDetail;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = oelOrderDetailCollection[i].IdOrder;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelOrderDetailCollection[i].IdAccount;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@IdSize", DbType.Guid)).Value = oelOrderDetailCollection[i].IdSize;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@IdColor", DbType.Guid)).Value = oelOrderDetailCollection[i].IdColor;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@SeqNo", DbType.Int32)).Value = oelOrderDetailCollection[i].Seq;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@Configuration", DbType.String)).Value = oelOrderDetailCollection[i].Configuration;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@Color", DbType.String)).Value = oelOrderDetailCollection[i].Color;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@TotalQuantity", DbType.Int64)).Value = oelOrderDetailCollection[i].Quantity;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@UnitPrice", DbType.Decimal)).Value = oelOrderDetailCollection[i].UnitPrice;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@Amount", DbType.Decimal)).Value = oelOrderDetailCollection[i].Amount;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@DeliveredQuantity", DbType.Int64)).Value = oelOrderDetailCollection[i].DeliveredQuantity;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@RemainingQuantity", DbType.Int64)).Value = oelOrderDetailCollection[i].DeliveredRemainderQuantity;
              
                cmdOrdersDetail.ExecuteNonQuery();
                cmdOrdersDetail.Parameters.Clear();
            }

            return true;
        }
        public bool InsertOrderBreakupDetail(List<ItemsAttributesDetailsEL> oelOrderDetailCollection, SqlConnection objConn, SqlTransaction oTran)
        {
            SqlCommand cmdOrdersDetail = new SqlCommand("[Production].[Proc_CreateGarmentsOrderBreakup]", objConn);
            cmdOrdersDetail.CommandType = CommandType.StoredProcedure;
            cmdOrdersDetail.CommandTimeout = 0;
            cmdOrdersDetail.Transaction = oTran;
            for (int i = 0; i < oelOrderDetailCollection.Count; i++)
            {
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@IdOrderDetail", DbType.Guid)).Value = oelOrderDetailCollection[i].IdOrderDetail;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = oelOrderDetailCollection[i].IdOrder;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelOrderDetailCollection[i].IdItem;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@Small", DbType.Int64)).Value = oelOrderDetailCollection[i].Small;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@Medium", DbType.Int64)).Value = oelOrderDetailCollection[i].Medium;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@Large", DbType.Int64)).Value = oelOrderDetailCollection[i].Large;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@XLarge", DbType.Int64)).Value = oelOrderDetailCollection[i].XLarge;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@2XLarge", DbType.Int64)).Value = oelOrderDetailCollection[i].DoubleXLarge;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@3XLarge", DbType.Int64)).Value = oelOrderDetailCollection[i].TripleXLarge;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@4XLarge", DbType.Int64)).Value = oelOrderDetailCollection[i].FourthXLarge;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@5XLarge", DbType.Int64)).Value = oelOrderDetailCollection[i].FifthXLarge;
                cmdOrdersDetail.Parameters.Add(new SqlParameter("@Total", DbType.Int64)).Value = oelOrderDetailCollection[i].TotalBreakup;

                cmdOrdersDetail.ExecuteNonQuery();
                cmdOrdersDetail.Parameters.Clear();
            }
            return true;
        }
        public bool UpdateOrderBreakupDetail(List<ItemsAttributesDetailsEL> oelBreakupCollection, SqlConnection objConn, SqlTransaction oTran)
        {
            SqlCommand cmdOrderBreakup = new SqlCommand();
            cmdOrderBreakup.CommandType = CommandType.StoredProcedure;
            cmdOrderBreakup.Connection = objConn;
            cmdOrderBreakup.Transaction = oTran;
            for (int i = 0; i < oelBreakupCollection.Count; i++)
            {
                if (oelBreakupCollection[i].IsNew)
                {
                    cmdOrderBreakup.CommandText = "[Production].[Proc_CreateGarmentsOrderBreakup]";
                }
                else
                {
                    cmdOrderBreakup.CommandText = "[Production].[Proc_UpdateGarmentsOrderBreakup]";
                }
                cmdOrderBreakup.Parameters.Add(new SqlParameter("@IdOrderDetail", DbType.Guid)).Value = oelBreakupCollection[i].IdOrderDetail;
                cmdOrderBreakup.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = oelBreakupCollection[i].IdOrder;
                cmdOrderBreakup.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelBreakupCollection[i].IdItem;
                cmdOrderBreakup.Parameters.Add(new SqlParameter("@Small", DbType.Int64)).Value = oelBreakupCollection[i].Small;
                cmdOrderBreakup.Parameters.Add(new SqlParameter("@Medium", DbType.Int64)).Value = oelBreakupCollection[i].Medium;
                cmdOrderBreakup.Parameters.Add(new SqlParameter("@Large", DbType.Int64)).Value = oelBreakupCollection[i].Large;
                cmdOrderBreakup.Parameters.Add(new SqlParameter("@XLarge", DbType.Int64)).Value = oelBreakupCollection[i].XLarge;
                cmdOrderBreakup.Parameters.Add(new SqlParameter("@2XLarge", DbType.Int64)).Value = oelBreakupCollection[i].DoubleXLarge;
                cmdOrderBreakup.Parameters.Add(new SqlParameter("@3XLarge", DbType.Int64)).Value = oelBreakupCollection[i].TripleXLarge;
                cmdOrderBreakup.Parameters.Add(new SqlParameter("@4XLarge", DbType.Int64)).Value = oelBreakupCollection[i].FourthXLarge;
                cmdOrderBreakup.Parameters.Add(new SqlParameter("@5XLarge", DbType.Int64)).Value = oelBreakupCollection[i].FifthXLarge;
                cmdOrderBreakup.Parameters.Add(new SqlParameter("@Total", DbType.Int64)).Value = oelBreakupCollection[i].TotalBreakup;

                cmdOrderBreakup.ExecuteNonQuery();
                cmdOrderBreakup.Parameters.Clear();
            }

            return true;
        }
        public List<OrdersDetailEL> GetOrderDetailByOrderNo(Int64 OrderNo, Int32 OrderType,Guid IdCompany, SqlConnection objConn)
        {
            List<OrdersDetailEL> list = new List<OrdersDetailEL>();
            using (SqlCommand cmdOrders = new SqlCommand("[Transactions].[Proc_GetOrderByOrderNo]", objConn))
            {
                cmdOrders.CommandType = CommandType.StoredProcedure;
                cmdOrders.CommandTimeout = 0;
                cmdOrders.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                cmdOrders.Parameters.Add(new SqlParameter("@OrderNo", DbType.Int64)).Value = OrderNo;
                cmdOrders.Parameters.Add(new SqlParameter("@OrderType", DbType.Int64)).Value = OrderType;
                objReader = cmdOrders.ExecuteReader();
                while (objReader.Read())
                {
                    OrdersDetailEL oelOrderDetail = new OrdersDetailEL();
                    oelOrderDetail.IdOrder = Validation.GetSafeGuid(objReader["Order_Id"]);
                    oelOrderDetail.IdBrand = Validation.GetSafeGuid(objReader["Brand_Id"]);
                    oelOrderDetail.IdCurrency = Validation.GetSafeLong(objReader["Currency_Id"]);
                    oelOrderDetail.BrandName = Validation.GetSafeString(objReader["Brand_Name"]);
                    oelOrderDetail.CustomerPo = Validation.GetSafeString(objReader["PoNumber"]);
                    oelOrderDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelOrderDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelOrderDetail.OrderType = Validation.GetSafeInteger(objReader["OrderType"]);
                    oelOrderDetail.VDiscription = Validation.GetSafeString(objReader["VDiscription"]);
                    oelOrderDetail.OrderStatus = Validation.GetSafeInteger(objReader["OrderStatus"]);
                    oelOrderDetail.OrderDate = Validation.GetSafeDateTime(objReader["OrderDate"]);
                    oelOrderDetail.ProductionDate = Validation.GetSafeDateTime(objReader["ProductionDate"]);
                    oelOrderDetail.DeliveryDate = Validation.GetSafeDateTime(objReader["DeliveryDate"]);
                    oelOrderDetail.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);
                    oelOrderDetail.Posted = Validation.GetSafeBoolean(objReader["Posted"]);
                    oelOrderDetail.IsDeleted = Validation.GetSafeBooleanNullable(objReader["IsDeleted"]);

                    //// Now Pick Detail Data from Order Detail
                    oelOrderDetail.IdOrderDetail = Validation.GetSafeGuid(objReader["OrderDetail_Id"]);
                    oelOrderDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelOrderDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelOrderDetail.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                    oelOrderDetail.Configuration = Validation.GetSafeString(objReader["Configuration"]);
                    oelOrderDetail.IdSize = Validation.GetSafeGuid(objReader["Size_Id"]);
                    oelOrderDetail.IdColor = Validation.GetSafeGuid(objReader["Color_Id"]);
                    oelOrderDetail.Color = Validation.GetSafeString(objReader["Color"]);
                    oelOrderDetail.Seq = Validation.GetSafeInteger(objReader["SeqNo"]);
                    oelOrderDetail.Quantity = Validation.GetSafeLong(objReader["TotalQuantity"]);
                    oelOrderDetail.UnitPrice = Validation.GetSafeDecimal(objReader["UnitPrice"]);
                    oelOrderDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                    oelOrderDetail.DeliveredQuantity = Validation.GetSafeLong(objReader["DeliveredQuantity"]);
                    oelOrderDetail.DeliveredRemainderQuantity = Validation.GetSafeLong(objReader["RemainingQuantity"]);

                    list.Add(oelOrderDetail);
                }
            }
            return list;
        }
        public List<OrdersDetailEL> GetOrderDetailById(Guid IdOrder, SqlConnection objConn)
        {
            List<OrdersDetailEL> list = new List<OrdersDetailEL>();
            using (SqlCommand cmdOrders = new SqlCommand("[Transactions].[Proc_GetOrderById]", objConn))
            {
                cmdOrders.CommandType = CommandType.StoredProcedure;
                cmdOrders.CommandTimeout = 0;
                cmdOrders.Parameters.Add(new SqlParameter("@IdOrder", DbType.Guid)).Value = IdOrder;
                objReader = cmdOrders.ExecuteReader();
                while (objReader.Read())
                {
                    OrdersDetailEL oelOrderDetail = new OrdersDetailEL();
                    oelOrderDetail.IdOrder = Validation.GetSafeGuid(objReader["Order_Id"]);
                    oelOrderDetail.OrderNo = Validation.GetSafeLong(objReader["OrderNo"]);
                    oelOrderDetail.IdBrand = Validation.GetSafeGuid(objReader["Brand_Id"]);
                    oelOrderDetail.IdCurrency = Validation.GetSafeLong(objReader["Currency_Id"]);
                    oelOrderDetail.BrandName = Validation.GetSafeString(objReader["Brand_Name"]);
                    oelOrderDetail.CustomerPo = Validation.GetSafeString(objReader["PoNumber"]);
                    oelOrderDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelOrderDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelOrderDetail.OrderType = Validation.GetSafeInteger(objReader["OrderType"]);
                    oelOrderDetail.VDiscription = Validation.GetSafeString(objReader["VDiscription"]);
                    oelOrderDetail.OrderStatus = Validation.GetSafeInteger(objReader["OrderStatus"]);
                    oelOrderDetail.OrderDate = Validation.GetSafeDateTime(objReader["OrderDate"]);
                    oelOrderDetail.ProductionDate = Validation.GetSafeDateTime(objReader["ProductionDate"]);
                    oelOrderDetail.DeliveryDate = Validation.GetSafeDateTime(objReader["DeliveryDate"]);
                    oelOrderDetail.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);
                    oelOrderDetail.Posted = Validation.GetSafeBoolean(objReader["Posted"]);
                    oelOrderDetail.IsDeleted = Validation.GetSafeBooleanNullable(objReader["IsDeleted"]);

                    //// Now Pick Detail Data from Order Detail
                    oelOrderDetail.IdOrderDetail = Validation.GetSafeGuid(objReader["OrderDetail_Id"]);
                    oelOrderDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelOrderDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelOrderDetail.PackingSize = Validation.GetSafeString(objReader["PackingSize"]);
                    oelOrderDetail.Configuration = Validation.GetSafeString(objReader["Configuration"]);
                    oelOrderDetail.IdSize = Validation.GetSafeGuid(objReader["Size_Id"]);
                    oelOrderDetail.IdColor = Validation.GetSafeGuid(objReader["Color_Id"]);
                    oelOrderDetail.Color = Validation.GetSafeString(objReader["Color"]);
                    oelOrderDetail.Seq = Validation.GetSafeInteger(objReader["SeqNo"]);
                    oelOrderDetail.Quantity = Validation.GetSafeLong(objReader["TotalQuantity"]);
                    oelOrderDetail.UnitPrice = Validation.GetSafeDecimal(objReader["UnitPrice"]);
                    oelOrderDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                    oelOrderDetail.DeliveredQuantity = Validation.GetSafeLong(objReader["DeliveredQuantity"]);
                    oelOrderDetail.DeliveredRemainderQuantity = Validation.GetSafeLong(objReader["RemainingQuantity"]);

                    list.Add(oelOrderDetail);
                }
            }
            return list;
        }       
        public List<ItemsAttributesDetailsEL> GetGarmentOrderDetailByOrderNo(Int64 OrderNo, Guid IdCompany, SqlConnection objConn)
        {
            List<ItemsAttributesDetailsEL> list = new List<ItemsAttributesDetailsEL>();
            using (SqlCommand cmdOrders = new SqlCommand("[Transactions].[Proc_GetGarmentOrderByOrderNo]", objConn))
            {
                cmdOrders.CommandType = CommandType.StoredProcedure;
                cmdOrders.CommandTimeout = 0;
                cmdOrders.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                cmdOrders.Parameters.Add(new SqlParameter("@OrderNo", DbType.Int64)).Value = OrderNo;
                objReader = cmdOrders.ExecuteReader();
                while (objReader.Read())
                {
                    ItemsAttributesDetailsEL oelOrderDetail = new ItemsAttributesDetailsEL();
                    oelOrderDetail.IdOrder = Validation.GetSafeGuid(objReader["Order_Id"]);
                    oelOrderDetail.IdBrand = Validation.GetSafeGuid(objReader["Brand_Id"]);
                    oelOrderDetail.IdCurrency = Validation.GetSafeLong(objReader["Currency_Id"]);
                    oelOrderDetail.BrandName = Validation.GetSafeString(objReader["Brand_Name"]);
                    oelOrderDetail.CustomerPo = Validation.GetSafeString(objReader["PoNumber"]);
                    oelOrderDetail.AccountNo = Validation.GetSafeString(objReader["AccountNo"]);
                    oelOrderDetail.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                    oelOrderDetail.OrderType = Validation.GetSafeInteger(objReader["OrderType"]);
                    oelOrderDetail.VDiscription = Validation.GetSafeString(objReader["VDiscription"]);
                    oelOrderDetail.OrderStatus = Validation.GetSafeInteger(objReader["OrderStatus"]);
                    oelOrderDetail.OrderDate = Validation.GetSafeDateTime(objReader["OrderDate"]);
                    oelOrderDetail.ProductionDate = Validation.GetSafeDateTime(objReader["ProductionDate"]);
                    oelOrderDetail.DeliveryDate = Validation.GetSafeDateTime(objReader["DeliveryDate"]);
                    oelOrderDetail.TotalAmount = Validation.GetSafeDecimal(objReader["TotalAmount"]);
                    oelOrderDetail.Posted = Validation.GetSafeBoolean(objReader["Posted"]);
                    oelOrderDetail.IsDeleted = Validation.GetSafeBooleanNullable(objReader["IsDeleted"]);

                    //// Now Pick Detail Data from Order Detail
                    oelOrderDetail.IdOrderDetail = Validation.GetSafeGuid(objReader["OrderDetail_Id"]);
                    oelOrderDetail.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelOrderDetail.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelOrderDetail.Configuration = Validation.GetSafeString(objReader["Configuration"]);
                    oelOrderDetail.IdSize = Validation.GetSafeGuid(objReader["Size_Id"]);
                    oelOrderDetail.IdColor = Validation.GetSafeGuid(objReader["Color_Id"]);

                    oelOrderDetail.Color = Validation.GetSafeString(objReader["Color"]);
                    oelOrderDetail.Quantity = Validation.GetSafeLong(objReader["TotalQuantity"]);
                    oelOrderDetail.UnitPrice = Validation.GetSafeDecimal(objReader["UnitPrice"]);
                    oelOrderDetail.Amount = Validation.GetSafeDecimal(objReader["Amount"]);
                    oelOrderDetail.DeliveredQuantity = Validation.GetSafeLong(objReader["DeliveredQuantity"]);
                    oelOrderDetail.DeliveredRemainderQuantity = Validation.GetSafeLong(objReader["RemainingQuantity"]);

                    list.Add(oelOrderDetail);                                       
                }
            }
            return list;
        }
        public List<ItemsAttributesDetailsEL> GetGarmentBreakupByOrderNo(Int64 OrderNo, Guid IdCompany, SqlConnection objConn)
        {
            List<ItemsAttributesDetailsEL> listBreakups = new List<ItemsAttributesDetailsEL>();
            using (SqlCommand cmdOrders = new SqlCommand("[Production].[Proc_GetGarmentBreakupByOrderNo]", objConn))
            {
                cmdOrders.CommandType = CommandType.StoredProcedure;
                cmdOrders.CommandTimeout = 0;
                cmdOrders.Parameters.Add(new SqlParameter("@IdCompany", DbType.Guid)).Value = IdCompany;
                cmdOrders.Parameters.Add(new SqlParameter("@OrderNo", DbType.Int64)).Value = OrderNo;
                objReader = cmdOrders.ExecuteReader();
                while (objReader.Read())
                {
                    /// Now Pick Order Breakup Data from Breakup Table

                    ItemsAttributesDetailsEL oelbreakup = new ItemsAttributesDetailsEL();
                    oelbreakup.IdOrder = Validation.GetSafeGuid(objReader["Order_Id"].ToString());
                    oelbreakup.IdOrderDetail = Validation.GetSafeGuid(objReader["OrderDetail_Id"]);
                    oelbreakup.IdItem = Validation.GetSafeGuid(objReader["Item_Id"]);
                    oelbreakup.ItemName = Validation.GetSafeString(objReader["ItemName"]);
                    oelbreakup.Small = Validation.GetSafeLong(objReader["Small"]);
                    oelbreakup.Medium = Validation.GetSafeLong(objReader["Medium"]);
                    oelbreakup.Large = Validation.GetSafeLong(objReader["Large"]);
                    oelbreakup.XLarge = Validation.GetSafeLong(objReader["XLarge"]);
                    oelbreakup.DoubleXLarge = Validation.GetSafeLong(objReader["2XLarge"]);
                    oelbreakup.TripleXLarge = Validation.GetSafeLong(objReader["3XLarge"]);
                    oelbreakup.FourthXLarge = Validation.GetSafeLong(objReader["4XLarge"]);
                    oelbreakup.FifthXLarge = Validation.GetSafeLong(objReader["5XLarge"]);
                    oelbreakup.TotalBreakup = Validation.GetSafeLong(objReader["Total"]);

                    listBreakups.Add(oelbreakup);
                }
            }
            return listBreakups;
        }
        public List<ItemsAttributesDetailsEL> GetGarmentBreakupDetailById(Guid Id, SqlConnection objConn)
        {
            List<ItemsAttributesDetailsEL> listBreakups = new List<ItemsAttributesDetailsEL>();
            using (SqlCommand cmdOrders = new SqlCommand("[Production].[GetGarmentBreakupDetailById]", objConn))
            {
                cmdOrders.CommandType = CommandType.StoredProcedure;
                cmdOrders.CommandTimeout = 0;
                cmdOrders.Parameters.Add(new SqlParameter("@IdgarmentDetail", DbType.Guid)).Value = Id;
                objReader = cmdOrders.ExecuteReader();
                while (objReader.Read())
                {
                    /// Now Pick Order Breakup Data from Breakup Table

                    ItemsAttributesDetailsEL oelbreakup = new ItemsAttributesDetailsEL();
                    oelbreakup.IdOrder = Validation.GetSafeGuid(objReader["Order_Id"].ToString());
                    oelbreakup.IdOrderDetail = Validation.GetSafeGuid(objReader["OrderDetail_Id"]);
                    oelbreakup.Small = Validation.GetSafeLong(objReader["Small"]);
                    oelbreakup.Medium = Validation.GetSafeLong(objReader["Medium"]);
                    oelbreakup.Large = Validation.GetSafeLong(objReader["Large"]);
                    oelbreakup.XLarge = Validation.GetSafeLong(objReader["XLarge"]);
                    oelbreakup.DoubleXLarge = Validation.GetSafeLong(objReader["2XLarge"]);
                    oelbreakup.TripleXLarge = Validation.GetSafeLong(objReader["3XLarge"]);
                    oelbreakup.FourthXLarge = Validation.GetSafeLong(objReader["4XLarge"]);
                    oelbreakup.FifthXLarge = Validation.GetSafeLong(objReader["5XLarge"]);
                    oelbreakup.TotalBreakup = Validation.GetSafeLong(objReader["Total"]);

                    listBreakups.Add(oelbreakup);
                }
            }
            return listBreakups;
        }
    }
}
