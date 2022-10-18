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
    public class TanneryStockDAL
    {
        IDataReader objReader;
        public List<TanneryStockEL> GetTanneryStock(Guid IdQuality, SqlConnection objConn)
        {
            List<TanneryStockEL> list = new List<TanneryStockEL>();
            SqlCommand cmdLotDetail = new SqlCommand("[Reports].[Proc_GetTanneryStockReport]", objConn);
            cmdLotDetail.Parameters.Add(new SqlParameter("@IdQuality", DbType.Guid)).Value = IdQuality;
            cmdLotDetail.CommandType = CommandType.StoredProcedure;
            objReader = cmdLotDetail.ExecuteReader();
            while (objReader.Read())
            {
                TanneryStockEL oelTanneryStock = new TanneryStockEL();
                oelTanneryStock.Description = Validation.GetSafeString(objReader["Description"]);
                oelTanneryStock.Type = Validation.GetSafeString(objReader["Desc"]);
                oelTanneryStock.StockDate = Validation.GetSafeDateTime(objReader["Date"]);
                oelTanneryStock.AccountName = Validation.GetSafeString(objReader["AccountName"]);
                oelTanneryStock.Units = Validation.GetSafeDecimal(objReader["Units"]);
                oelTanneryStock.Value = Validation.GetSafeDecimal(objReader["Value"]);
                oelTanneryStock.LotNo = Validation.GetSafeLong(objReader["LotNo"]);


                list.Add(oelTanneryStock);
            }
            return list;
        }
    }
}
