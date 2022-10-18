using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MetroFramework.Forms;
using Accounts.BLL;
using Accounts.EL;
using Accounts.Common;

namespace Accounts.UI
{
    public partial class frmVehicleStockComparison : MetroForm
    {
        #region Variables
        TextBox txtSplittingGalma = new TextBox();
        TextBox txtSplittingPuttha = new TextBox();
        TextBox txtShavingGalma = new TextBox();
        TextBox txtShavingPuttha = new TextBox();
        TextBox txtShavingSGalma = new TextBox();
        TextBox txtShavingSPuttha = new TextBox();
        TextBox txtDrummingGalma = new TextBox();
        TextBox txtDrummingPuttha = new TextBox();
        TextBox txtDrummingSGalma = new TextBox();
        TextBox txtDrummingSPuttha = new TextBox();
        TextBox txtBuffingGalma = new TextBox();
        TextBox txtBuffingPuttha = new TextBox();
        TextBox txtBuffingSGalma = new TextBox();
        TextBox txtBuffingSPuttha = new TextBox();

        Panel pnlSplittingSum = new Panel();
        Panel pnlShavingSum = new Panel();
        Panel pnlDrummingSum = new Panel();
        Panel pnlBuffingSum = new Panel();
        #endregion
        public frmVehicleStockComparison()
        {
            InitializeComponent();
        }
        private void frmVehicleStockComparison_Load(object sender, EventArgs e)
        {
            this.grdSplitting.AutoGenerateColumns = false;
            this.grdShaving.AutoGenerateColumns = false;
            this.grdDrumming.AutoGenerateColumns = false;
            this.grdBuffing.AutoGenerateColumns = false;
            CreateAndInitializeFooterRow();
            FillVehicles();
        }
        private void CreateAndInitializeFooterRow()
        {
            #region Generial

            txtSplittingGalma.Enabled = false;
            txtSplittingGalma.BringToFront();
            txtSplittingPuttha.Enabled = false;
            txtSplittingPuttha.BringToFront();

            txtShavingGalma.Enabled = false;
            txtShavingPuttha.Enabled = false;
            txtShavingSGalma.Enabled = false;
            txtShavingSPuttha.Enabled = false;
            
            txtDrummingGalma.Enabled = false;
            txtDrummingPuttha.Enabled = false;
            txtDrummingSGalma.Enabled = false;
            txtDrummingSPuttha.Enabled = false;

            txtBuffingGalma.Enabled = false;
            txtBuffingPuttha.Enabled = false;
            txtBuffingSGalma.Enabled = false;
            txtBuffingSPuttha.Enabled = false;

            txtSplittingGalma.TextAlign = HorizontalAlignment.Center;
            txtSplittingPuttha.TextAlign = HorizontalAlignment.Center;

            txtShavingGalma.TextAlign = HorizontalAlignment.Center;
            txtShavingPuttha.TextAlign = HorizontalAlignment.Center;
            txtShavingSGalma.TextAlign = HorizontalAlignment.Center;
            txtShavingSPuttha.TextAlign = HorizontalAlignment.Center;

            txtDrummingGalma.TextAlign = HorizontalAlignment.Center;
            txtDrummingPuttha.TextAlign = HorizontalAlignment.Center;
            txtDrummingSGalma.TextAlign = HorizontalAlignment.Center;
            txtDrummingSPuttha.TextAlign = HorizontalAlignment.Center;

            txtBuffingGalma.TextAlign = HorizontalAlignment.Center;
            txtBuffingPuttha.TextAlign = HorizontalAlignment.Center;
            txtBuffingSGalma.TextAlign = HorizontalAlignment.Center;
            txtBuffingSPuttha.TextAlign = HorizontalAlignment.Center;

            #endregion
            #region Splitting Controls
            int Xdgv0 = this.grdSplitting.GetCellDisplayRectangle(3, -1, true).Location.X;

            pnlSplittingSum.Height = 21;
            pnlSplittingSum.BackColor = Color.Wheat;
            pnlSplittingSum.AutoSize = false;
            pnlSplittingSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlSplittingSum.Width = this.grdSplitting.Columns[3].Width + Xdgv0;
            pnlSplittingSum.Location = new Point(0, this.grdSplitting.Height - txtSplittingPuttha.Height);

            this.grdSplitting.Controls.Add(pnlSplittingSum);

            int Xdgvx01 = this.grdSplitting.GetCellDisplayRectangle(2, -1, true).Location.X;


            txtSplittingGalma.Width = this.grdSplitting.Columns[2].Width;

            txtSplittingGalma.Location = new Point(Xdgvx01, grdSplitting.Height - txtSplittingGalma.Height);

            this.grdSplitting.Controls.Add(txtSplittingGalma);


            int Xdgvx021 = this.grdSplitting.GetCellDisplayRectangle(3, -1, true).Location.X;


            txtSplittingPuttha.Width = this.grdSplitting.Columns[3].Width;

            txtSplittingPuttha.Location = new Point(Xdgvx021, grdSplitting.Height - txtSplittingPuttha.Height);

            this.grdSplitting.Controls.Add(txtSplittingPuttha);

            this.pnlSplittingSum.SendToBack();
            #endregion
            #region Shaving Controls
            int Xdgv1 = this.grdShaving.GetCellDisplayRectangle(2, -1, true).Location.X;

            pnlShavingSum.Height = 21;
            pnlShavingSum.BackColor = Color.Wheat;
            pnlShavingSum.AutoSize = false;
            pnlShavingSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlShavingSum.Width = this.grdShaving.Columns[3].Width + Xdgv1;
            pnlShavingSum.Location = new Point(0, this.grdShaving.Height - txtShavingGalma.Height);

            this.grdShaving.Controls.Add(pnlShavingSum);

            int Xdgvx0 = this.grdShaving.GetCellDisplayRectangle(3, -1, true).Location.X;


            txtShavingPuttha.Width = this.grdShaving.Columns[3].Width;

            txtShavingPuttha.Location = new Point(Xdgvx0, grdShaving.Height - txtShavingPuttha.Height);

            this.grdShaving.Controls.Add(txtShavingPuttha);


            int Xdgvx1 = this.grdShaving.GetCellDisplayRectangle(2, -1, true).Location.X;


            txtShavingGalma.Width = this.grdShaving.Columns[2].Width;

            txtShavingGalma.Location = new Point(Xdgvx1, grdShaving.Height - txtShavingGalma.Height);

            this.grdShaving.Controls.Add(txtShavingGalma);

            
            int Xdgvx2 = this.grdShaving.GetCellDisplayRectangle(4, -1, true).Location.X;

            txtShavingSGalma.Width = this.grdShaving.Columns[4].Width;

            txtShavingSGalma.Location = new Point(Xdgvx2, grdShaving.Height - txtShavingSGalma.Height);

            this.grdShaving.Controls.Add(txtShavingSGalma);


            int Xdgvx3 = this.grdShaving.GetCellDisplayRectangle(5, -1, true).Location.X;

            txtShavingSPuttha.Width = this.grdShaving.Columns[5].Width;

            txtShavingSPuttha.Location = new Point(Xdgvx3, grdShaving.Height - txtShavingSPuttha.Height);

            this.grdShaving.Controls.Add(txtShavingSPuttha);

            pnlShavingSum.SendToBack();

            #endregion
            #region Drumming Controls
            int Xdgv2 = this.grdDrumming.GetCellDisplayRectangle(2, -1, true).Location.X;

            pnlDrummingSum.Height = 21;
            pnlDrummingSum.BackColor = Color.Wheat;
            pnlDrummingSum.AutoSize = false;
            pnlDrummingSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlDrummingSum.Width = this.grdDrumming.Columns[4].Width + Xdgv2;
            pnlDrummingSum.Location = new Point(0, this.grdDrumming.Height - txtShavingGalma.Height);

            this.grdDrumming.Controls.Add(pnlDrummingSum);

            int Xdgvx4 = grdDrumming.GetCellDisplayRectangle(3, -1, true).Location.X;
            txtDrummingGalma.Width = this.grdDrumming.Columns[3].Width;
            txtDrummingGalma.Location = new Point(Xdgvx4, grdDrumming.Height - txtDrummingGalma.Height);
            
            this.grdDrumming.Controls.Add(txtDrummingGalma);

            int Xdgvx5 = grdDrumming.GetCellDisplayRectangle(4, -1, true).Location.X;
            txtDrummingPuttha.Width = this.grdDrumming.Columns[4].Width;
            txtDrummingPuttha.Location = new Point(Xdgvx5, grdDrumming.Height - txtDrummingPuttha.Height);
            
            grdDrumming.Controls.Add(txtDrummingPuttha);

            int Xdgvx6 = grdDrumming.GetCellDisplayRectangle(5, -1, true).Location.X;
            txtDrummingSGalma.Width = this.grdDrumming.Columns[5].Width;
            txtDrummingSGalma.Location = new Point(Xdgvx6, grdDrumming.Height - txtDrummingSGalma.Height);

            grdDrumming.Controls.Add(txtDrummingSGalma);

            int Xdgvx7 = grdDrumming.GetCellDisplayRectangle(6, -1, true).Location.X;
            txtDrummingSPuttha.Width = this.grdDrumming.Columns[6].Width;
            txtDrummingSPuttha.Location = new Point(Xdgvx7, grdDrumming.Height - txtDrummingSPuttha.Height);

            grdDrumming.Controls.Add(txtDrummingSPuttha);

            this.pnlDrummingSum.SendToBack();

            #endregion
            #region Buffing Controls
            int Xdgv3 = this.grdBuffing.GetCellDisplayRectangle(4, -1, true).Location.X;

            pnlBuffingSum.Height = 21;
            pnlBuffingSum.BackColor = Color.Wheat;
            pnlBuffingSum.AutoSize = false;
            pnlBuffingSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlBuffingSum.Width = this.grdBuffing.Columns[4].Width + Xdgv3;
            pnlBuffingSum.Location = new Point(0, this.grdBuffing.Height - txtBuffingGalma.Height);

            this.grdBuffing.Controls.Add(this.pnlBuffingSum);

            int Xdgvx8 = grdBuffing.GetCellDisplayRectangle(3, -1, true).Location.X;
            txtBuffingGalma.Width = this.grdBuffing.Columns[3].Width;
            txtBuffingGalma.Location = new Point(Xdgvx8, grdBuffing.Height - txtBuffingGalma.Height);

            this.grdBuffing.Controls.Add(txtBuffingGalma);

            int Xdgvx9 = grdBuffing.GetCellDisplayRectangle(4, -1, true).Location.X;
            txtBuffingPuttha.Width = this.grdBuffing.Columns[4].Width;
            txtBuffingPuttha.Location = new Point(Xdgvx9, grdBuffing.Height - txtBuffingPuttha.Height);

            grdBuffing.Controls.Add(txtBuffingPuttha);

            int Xdgvx10 = grdBuffing.GetCellDisplayRectangle(5, -1, true).Location.X;
            txtBuffingSGalma.Width = this.grdBuffing.Columns[5].Width;
            txtBuffingSGalma.Location = new Point(Xdgvx10, grdBuffing.Height - txtBuffingSGalma.Height);

            this.grdBuffing.Controls.Add(txtBuffingSGalma);

            int Xdgvx11 = grdBuffing.GetCellDisplayRectangle(6, -1, true).Location.X;
            txtBuffingSPuttha.Width = this.grdBuffing.Columns[6].Width;
            txtBuffingSPuttha.Location = new Point(Xdgvx11, grdBuffing.Height - txtBuffingSPuttha.Height);

            this.grdBuffing.Controls.Add(txtBuffingSPuttha);

            this.pnlBuffingSum.SendToBack();
            #endregion
        }
        private void FillVehicles()
        {
            var manager = new TanneryProcessesHeadBLL();
            List<TanneryProcessesHeadEL> list = manager.GetVehiclesByStatus(2);
            list.Insert(0, new TanneryProcessesHeadEL() { VehicleNo = "" });
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    cbxVehicles.Items.Add(list[i].VehicleNo ?? "");
                }
            }
        }
        private void ClearControls()
        {
            /// Splitting...
            txtSplittingGalmaStock.Text = string.Empty;
            txtSplittingPutthaStock.Text = string.Empty;

            /// Shaving....
            txtShavingGalmaStock.Text = string.Empty;
            txtShavingPutthaStock.Text = string.Empty;
            txtShavingSGalmaStock.Text = string.Empty;
            txtShavingSPutthaStock.Text = string.Empty;

            ///Drumming...
            txtDrummingSGalmaStock.Text = string.Empty;
            txtDrummingSPuthhaStock.Text = string.Empty;
            txtDrummingGalmastock.Text = string.Empty;
            txtDrummingPutthastock.Text = string.Empty;
        }
        private void btnLoadLots_Click(object sender, EventArgs e)
        {
            // First Load Shaving Stock
            var ShavingManager = new TanneryProcessDetailsBLL();
            var Manager = new TanneryLotDetailBLL();
            ClearControls();
            #region Splitting Operation
            List<TanneryProcessDetailsEL> lstSplitting = ShavingManager.GetVehicleWiseSplittingStock(cbxVehicles.Text);
            if (lstSplitting.Count > 0)
            {
                grdSplitting.DataSource = lstSplitting;
                txtSplittingGalma.Text = lstSplitting.Sum(x => x.GalmaPieces).ToString();
                txtSplittingPuttha.Text = lstSplitting.Sum(x => x.PutthaPieces).ToString();
            }
            else 
            {
                grdSplitting.DataSource = null;

                txtSplittingGalma.Text = string.Empty;
                txtSplittingPuttha.Text = string.Empty;
                txtSplittingGalmaStock.Text = string.Empty;
                txtSplittingPutthaStock.Text = string.Empty;

            }
            #endregion
            #region Shaving Operation
            List<TanneryProcessDetailsEL> lstShavingStock = ShavingManager.GetVehicleWiseShavingStock(cbxVehicles.Text);
            if (lstShavingStock.Count > 0)
            {
                grdShaving.DataSource = lstShavingStock;
                txtShavingGalma.Text = lstShavingStock.Sum(x => x.Galma).ToString();
                txtShavingPuttha.Text = lstShavingStock.Sum(x => x.Puttha).ToString();
                txtShavingSGalma.Text = lstShavingStock.Sum(x => x.SGalma).ToString();
                txtShavingSPuttha.Text = lstShavingStock.Sum(x => x.SPuttha).ToString();               
            }
            else
            {
                grdShaving.DataSource = null;

                txtShavingGalma.Text = string.Empty;
                txtShavingPuttha.Text = string.Empty;
                txtShavingSGalma.Text = string.Empty;
                txtShavingSPuttha.Text = string.Empty;

                txtShavingGalmaStock.Text = string.Empty;
                txtShavingPutthaStock.Text = string.Empty;
            }
            #endregion
            #region Drumming Operation
            List<TanneryLotDetailEL> listDrumming = Manager.GetVehicleWiseDrummingBuffingStock(cbxVehicles.Text, "Drumming");
            if (listDrumming.Count > 0)
            {
                grdDrumming.DataSource = listDrumming;
                txtDrummingGalma.Text = listDrumming.Sum(x => x.Pieces).ToString();
                txtDrummingPuttha.Text = listDrumming.Sum(x => x.PPieces).ToString();
                txtDrummingSGalma.Text = listDrumming.Sum(x => x.SGalma).ToString();
                txtDrummingSPuttha.Text = listDrumming.Sum(x => x.SPuttha).ToString();               
            }
            else
            {
                grdDrumming.DataSource = null;

                txtDrummingGalma.Text = string.Empty;
                txtDrummingPuttha.Text = string.Empty;
                txtDrummingSGalma.Text = string.Empty;
                txtDrummingSPuttha.Text = string.Empty;

                txtDrummingGalmastock.Text = string.Empty;
                txtDrummingPutthastock.Text = string.Empty;
            }
            #endregion
            #region Buffing Operation
            List<TanneryLotDetailEL> listBuffing = Manager.GetVehicleWiseDrummingBuffingStock(cbxVehicles.Text, "Buffing");
            if (listBuffing.Count > 0)
            {
                grdBuffing.DataSource = listBuffing;
                txtBuffingGalma.Text = listBuffing.Sum(x => x.Pieces).ToString();
                txtBuffingPuttha.Text = listBuffing.Sum(x => x.PPieces).ToString();
                txtBuffingSGalma.Text = listBuffing.Sum(x => x.SGalma).ToString();
                txtBuffingSPuttha.Text = listBuffing.Sum(x => x.SPuttha).ToString();
            }
            else
            {
                grdBuffing.DataSource = null;
                txtBuffingGalma.Text = string.Empty;
                txtBuffingPuttha.Text = string.Empty;
                txtBuffingSGalma.Text = string.Empty;
                txtBuffingSPuttha.Text = string.Empty;
            }
            #endregion

            #region Splitting Calculations

            txtSplittingGalmaStock.Text = (Validation.GetSafeLong(txtSplittingGalma.Text) - Validation.GetSafeLong(txtShavingSGalma.Text)).ToString();
            txtSplittingPutthaStock.Text = (Validation.GetSafeLong(txtSplittingPuttha.Text) - Validation.GetSafeLong(txtShavingSPuttha.Text)).ToString();

            #endregion
            #region Shaving Calculations

            txtShavingGalmaStock.Text = (Validation.GetSafeLong(txtShavingGalma.Text) - Validation.GetSafeLong(txtDrummingGalma.Text)).ToString();
            txtShavingPutthaStock.Text = (Validation.GetSafeLong(txtShavingPuttha.Text) - Validation.GetSafeLong(txtDrummingPuttha.Text)).ToString();

            txtShavingSGalmaStock.Text = (Validation.GetSafeLong(txtShavingSGalma.Text) - Validation.GetSafeLong(txtDrummingSGalma.Text)).ToString();
            txtShavingSPutthaStock.Text = (Validation.GetSafeLong(txtShavingSPuttha.Text) - Validation.GetSafeLong(txtDrummingSPuttha.Text)).ToString();

            #endregion
            #region Drumming Calculations

            txtDrummingSGalmaStock.Text = (Validation.GetSafeLong(txtDrummingSGalma.Text) - Validation.GetSafeLong(txtBuffingSGalma.Text)).ToString();
            txtDrummingSPuthhaStock.Text = (Validation.GetSafeLong(txtDrummingSPuttha.Text) - Validation.GetSafeLong(txtBuffingSPuttha.Text)).ToString();

            txtDrummingGalmastock.Text = (Validation.GetSafeLong(txtDrummingGalma.Text) - Validation.GetSafeLong(txtBuffingGalma.Text)).ToString();
            txtDrummingPutthastock.Text = (Validation.GetSafeLong(txtDrummingPuttha.Text) - Validation.GetSafeLong(txtBuffingPuttha.Text)).ToString();

            #endregion
        }
    }
}
