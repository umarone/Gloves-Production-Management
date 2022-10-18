using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MetroFramework.Forms;
using Accounts.EL;
using Accounts.Common;
using Accounts.BLL;
namespace Accounts.UI
{
    public partial class frmGlovesAllOrdersCostingDetail : MetroForm
    {
        #region Variables
        public Guid IdOrder = Guid.Empty;
        frmFindOrders frmfindOrders;
        #endregion
        #region Form Methods
        public frmGlovesAllOrdersCostingDetail()
        {
            InitializeComponent();
        }
        private void frmGlovesAllOrdersCostingDetail_Load(object sender, EventArgs e)
        {
            grdMaterialCost.AutoGenerateColumns = false;
            grdLabourCost.AutoGenerateColumns = false;
            grdMiscCost.AutoGenerateColumns = false;
            if (IdOrder != Guid.Empty)
            {
                GetOrderById();
                btnLoadCosting_Click(sender, e);
            }
        }
        #endregion
        #region Button Events and Customer Events And Methdos        
        private void btnLoadCosting_Click(object sender, EventArgs e)
        {
            var manager = new ProductionProcessDetailBLL();
            List<ProductionProcessDetailEL> listLabourCost = manager.GetProductionOrderLabourCostingDetail(IdOrder);
            List<ProductionProcessDetailEL> listMaterialCost = manager.GetProductionOrderMaterialCostingDetail(IdOrder);
            List<ProductionProcessDetailEL> listMisCost = manager.GetProductionOrderMiscCostingDetail(IdOrder);

            if (listMaterialCost.Count > 0)
            {
                grdMaterialCost.DataSource = listMaterialCost;
                lblMaterialsCost.Text = "Total Material Cost is :" + listMaterialCost.Sum(x => x.MaterialsCost).ToString();
            }
            else
            {
                grdMaterialCost.DataSource = null;
                lblMaterialsCost.Text = string.Empty;
            }
            if (listLabourCost.Count > 0)
            {
                grdLabourCost.DataSource = listLabourCost;
                lbllabourCost.Text = "Total Labour Cost is :" + listLabourCost.Sum(x => x.LabourCost).ToString();
            }
            else
            {
                grdLabourCost.DataSource = null;
                lbllabourCost.Text = string.Empty;
            }
            if (listMisCost.Count > 0)
            {
                grdMiscCost.DataSource = listMisCost;
                lblMiscCost.Text = "Total Misc Cost is :" + listMisCost.Sum(x => x.TotalAmount).ToString();
            }
            else
            {
                grdMiscCost.DataSource = null;
                lblMiscCost.Text = string.Empty;
            }
            if (listMaterialCost.Count > 0 || listLabourCost.Count > 0 || listMisCost.Count > 0)
            {
                lblTotalCost.Text = "Total Order Cost Is : " + (Validation.GetSafeDecimal(listMaterialCost.Sum(x => x.MaterialsCost)) + Validation.GetSafeDecimal(listLabourCost.Sum(x => x.LabourCost)) +
                                    Validation.GetSafeDecimal(listMisCost.Sum(x => x.TotalAmount))).ToString();
            }
            else
            {
                lblTotalCost.Text = string.Empty;
            }
        }
        private void btnSelectOrder_Click(object sender, EventArgs e)
        {
            frmfindOrders = new frmFindOrders();
            frmfindOrders.ExecuteFindOrdersEvent += new frmFindOrders.FindOrdersDelegate(frmfindOrders_ExecuteFindOrdersEvent);
            frmfindOrders.ShowDialog();
        }
        void frmfindOrders_ExecuteFindOrdersEvent(object Sender, OrdersEL oelOrder)
        {
            IdOrder = oelOrder.IdOrder;
            GetOrderById();
        }
        private void GetOrderById()
        {
            var manager = new OrderDetailBLL();
            List<OrdersDetailEL> listOrders = manager.GetOrderDetailById(IdOrder);
            if (listOrders.Count > 0)
            {
                txtOrderNo.Text = listOrders[0].OrderNo.ToString();
                txtOrderedCustomer.Text = listOrders[0].AccountName;
                if (listOrders[0].OrderType == 1)
                {
                    txtOrderType.Text = "Gloves Order";
                }
                else
                {
                    txtOrderType.Text = "Garments Order";
                }
                if (listOrders[0].OrderStatus == 0)
                {
                    txtOrderStatus.Text = "Opened";
                }
                else
                {
                    txtOrderStatus.Text = "Closed";
                }
            }
        }
        #endregion
    }
}
