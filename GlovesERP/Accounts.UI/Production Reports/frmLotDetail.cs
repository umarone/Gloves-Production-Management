using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.EL;
using Accounts.Common;
using Accounts.BLL;
using MetroFramework.Forms;

namespace Accounts.UI
{
    public partial class frmLotDetail : MetroForm
    {
        public Guid IdLotDetail { get; set; }
        public frmLotDetail()
        {
            InitializeComponent();
        }
        private void frmLotDetail_Load(object sender, EventArgs e)
        {
            this.grdLotDetail.AutoGenerateColumns = false;
            this.grdChemicals.AutoGenerateColumns = false;
            FillLotDetail();
            FillLotChemicals(IdLotDetail);
        }
        private void FillLotDetail()
        {
            var manager = new TanneryLotDetailBLL();
            List<TanneryLotDetailEL> list = manager.GetLotDetailById(IdLotDetail);
            if (list.Count > 0)
            {
                grdLotDetail.DataSource = list;
            }
            else
            {
                grdLotDetail.DataSource = null;
            }
        }
        private void FillLotChemicals(Guid IdLot)
        {
            var manager = new TanneryChemicalBLL();
            List<TanneryChemicalEL> list = manager.GetChemicalDetailsByLot(IdLot);
            if (list.Count > 0)
            {
                grdChemicals.DataSource = list;
            }
            else
            {
                grdChemicals.DataSource = null;
            }
        }
    }
}
