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
    public class GarmentsCalculationDAL
    {
        public bool CreateGarmentsCalculation(ItemFormulaEL oelCreateGarmentsCalcultion, SqlConnection objConn)
        {
            SqlCommand cmdCreatetGarments = new SqlCommand("[Setup].[Proc_CreateGarmentsCalculation]", objConn);

            cmdCreatetGarments.CommandType = CommandType.StoredProcedure;
            cmdCreatetGarments.Parameters.Add(new SqlParameter("@IdCalculation", DbType.Guid)).Value = oelCreateGarmentsCalcultion.IdCalculation;
            cmdCreatetGarments.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelCreateGarmentsCalcultion.IdItem;
            cmdCreatetGarments.Parameters.Add(new SqlParameter("@MaterialType", DbType.Guid)).Value = oelCreateGarmentsCalcultion.MaterialType;
            cmdCreatetGarments.Parameters.Add(new SqlParameter("@OperationType", DbType.Guid)).Value = oelCreateGarmentsCalcultion.OperationType;
            cmdCreatetGarments.Parameters.Add(new SqlParameter("@OrderQuantity", DbType.Int32)).Value = oelCreateGarmentsCalcultion.TotalExactQty;
            cmdCreatetGarments.Parameters.Add(new SqlParameter("@NoOfItems", DbType.Int32)).Value = oelCreateGarmentsCalcultion.PerUnitTotal;
            cmdCreatetGarments.Parameters.Add(new SqlParameter("@CalculatedTotal", DbType.Decimal)).Value = oelCreateGarmentsCalcultion.TotalQty;

            cmdCreatetGarments.ExecuteNonQuery();

            return true;
        }
        public bool UpdateGarmentsCalculation(ItemFormulaEL oelUpdateGarmentsCalcultion, SqlConnection objConn)
        {
            SqlCommand cmdUpdateGarments = new SqlCommand("[Setup].[Proc_UpdateGarmentsCalculation]", objConn);

            cmdUpdateGarments.CommandType = CommandType.StoredProcedure;
            cmdUpdateGarments.Parameters.Add(new SqlParameter("@IdCalculation", DbType.Guid)).Value = oelUpdateGarmentsCalcultion.IdCalculation;
            cmdUpdateGarments.Parameters.Add(new SqlParameter("@IdItem", DbType.Guid)).Value = oelUpdateGarmentsCalcultion.IdItem;
            cmdUpdateGarments.Parameters.Add(new SqlParameter("@MaterialType", DbType.Guid)).Value = oelUpdateGarmentsCalcultion.MaterialType;
            cmdUpdateGarments.Parameters.Add(new SqlParameter("@OperationType", DbType.Guid)).Value = oelUpdateGarmentsCalcultion.OperationType;
            cmdUpdateGarments.Parameters.Add(new SqlParameter("@OrderQuantity", DbType.Int32)).Value = oelUpdateGarmentsCalcultion.PerUnitTotal;
            cmdUpdateGarments.Parameters.Add(new SqlParameter("@NoOfItems", DbType.Int32)).Value = oelUpdateGarmentsCalcultion.TotalExactQty;
            cmdUpdateGarments.Parameters.Add(new SqlParameter("@CalulatedTotal", DbType.Decimal)).Value = oelUpdateGarmentsCalcultion.TotalQty;

            cmdUpdateGarments.ExecuteNonQuery();
            
            return true;
        }
        public List<ItemFormulaEL> GetFormulaByItem(Guid IdItem, SqlConnection objConn)
        {
            List<ItemFormulaEL> list = new List<ItemFormulaEL>();
            SqlCommand cmdItem = new SqlCommand("[Setup].[Proc_GetGarmentsFormula]", objConn);

            cmdItem.Parameters.Add("@IdItem", SqlDbType.UniqueIdentifier).Value = IdItem;

            cmdItem.CommandType = CommandType.StoredProcedure;
            SqlDataReader oReader = cmdItem.ExecuteReader();
            while (oReader.Read())
            {
                ItemFormulaEL oelFormula = new ItemFormulaEL();
                oelFormula.IdCalculation = Validation.GetSafeGuid(oReader["Calculation_Id"]);  
                oelFormula.MaterialType = Validation.GetSafeString(oReader["MaterialType"]);
                oelFormula.OperationType = Validation.GetSafeString(oReader["OperationType"]);
                oelFormula.PerUnitTotal = Validation.GetSafeInteger(oReader["NoOfItems"]);
                oelFormula.TotalExactQty = Validation.GetSafeInteger(oReader["OrderQuantity"]);
                oelFormula.TotalQty = Validation.GetSafeDecimal(oReader["CalculatedTotal"]);
                list.Add(oelFormula);
            }
            return list;
        }
    }
}