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
    public class TanneryLotBLL
    {
        TanneryLotDAL dal;
        public TanneryLotBLL()
        {
            dal = new TanneryLotDAL();
        }
        public bool CreateCompleteLot(TanneryLotEL oelTanneryLot, List<TanneryProcessesEL> oelProcessesCollection, List<TanneryLotDetailEL> oelLotDetailCollection, List<TanneryChemicalEL> oelTanneryChemicalCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.CreateCompleteLot(oelTanneryLot, oelProcessesCollection, oelLotDetailCollection, oelTanneryChemicalCollection, objConn);
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
        public bool CreateLot(TanneryLotEL oelTanneryLot)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.CreateLot(oelTanneryLot, objConn);
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
        public bool CreatePostingLot(TanneryLotEL oelTanneryLot, List<TanneryProcessesEL> oelProcessesCollection, List<TanneryLotDetailEL> oelLotDetailCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.CreatePostingLot(oelTanneryLot, oelProcessesCollection, oelLotDetailCollection, objConn);
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
        public bool UpdatePostingLot(TanneryLotEL oelTanneryLot, List<TanneryProcessesEL> oelProcessesCollection, List<TanneryLotDetailEL> oelLotDetailCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.UpdatePostingLot(oelTanneryLot, oelProcessesCollection, oelLotDetailCollection, objConn);
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
        public bool UpdateLot(TanneryLotEL oelTanneryLot, List<TanneryProcessesEL> oelProcessesCollection, List<TanneryLotDetailEL> oelLotDetailCollection, List<TanneryChemicalEL> oelTanneryChemicalCollection)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.UpdateLot(oelTanneryLot, oelProcessesCollection, oelLotDetailCollection, oelTanneryChemicalCollection, objConn);
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
        public List<TanneryLotEL> GetLotById(Guid IdLot)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetLotById(IdLot, objConn);
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
        public List<TanneryLotEL> GetLotByLotNo(Int64 LotNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetLotByLotNo(LotNo, objConn);
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
        public EntityoperationInfo DeleteTanneryLot(Guid IdLot)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.DeleteTanneryLot(IdLot, objConn);
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
        public bool CloseLot(TanneryLotEL oelTanneryLot)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.CloseLot(oelTanneryLot, objConn);
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
        public Int64 GetMaxLotNo(Guid IdVoucher)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetMaxLotNo(IdVoucher, objConn);
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
        public List<TanneryLotEL> GetLotsByProcessHead(Guid IdVoucher)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetLotsByProcessHead(IdVoucher, objConn);
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
        public List<TanneryLotEL> GetVehicleLots(string VehicleNo)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetVehicleLots(VehicleNo, objConn);
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
        public List<TanneryLotEL> GetLotsFilterResults(Int64 LotNo, string UOM, string AccountNo, Guid IdItem, DateTime StartDate, DateTime EndDate, int FilterIndex)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetLotsFilterResults(LotNo, UOM, AccountNo, IdItem, StartDate, EndDate, FilterIndex, objConn);
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

        public List<TanneryChemicalEL> GetLotsByChemical(Guid IdChemical)
        {
            SqlConnection objConn = new SqlConnection(DBHelper.DataConnection);
            try
            {
                objConn.Open();
                return dal.GetLotsByChemical(IdChemical, objConn);
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
