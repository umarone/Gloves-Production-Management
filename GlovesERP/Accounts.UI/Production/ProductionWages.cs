using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accounts.EL;
using Accounts.BLL;
using Accounts.Common;
using MetroFramework.Forms;

namespace Accounts.UI
{
    public partial class frmProductionWages : MetroForm
    {
        public frmProductionWages()
        {
            InitializeComponent();
        }
        private void ProductionWages_Load(object sender, EventArgs e)
        {
            grdProductionWages.AutoGenerateColumns = false;
            colCuttingRate.Visible = false;
        }
        private void cbxProductionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxProcessType.Items.Clear();
            if (cbxProductionType.Text == "Tannery" && cbxProductionType.SelectedIndex == 9)
            {
                colCuttingRate.Visible = true;
            }
            else
            {
                colCuttingRate.Visible = false;
            }
            if (cbxProductionType.SelectedIndex == 1)
            {
                cbxProcessType.Items.Add("");
                cbxProcessType.Items.Add("Trimming");
                cbxProcessType.Items.Add("Splitting");
                cbxProcessType.Items.Add("ReTrimming");
                cbxProcessType.Items.Add("Shaving");
                cbxProcessType.Items.Add("Drumming");
                cbxProcessType.Items.Add("Crust");
                cbxProcessType.Items.Add("Dying");
                cbxProcessType.Items.Add("Re Dying");
                cbxProcessType.Items.Add("Buffing / ReBuffing");
                cbxProcessType.Items.Add("Cutting");
            }
            else if (cbxProductionType.SelectedIndex == 2)
            {
                cbxProcessType.Items.Add("");
                cbxProcessType.Items.Add("Cuff Cutting");
                cbxProcessType.Items.Add("Cuff Printing");
                cbxProcessType.Items.Add("OverLock");
                cbxProcessType.Items.Add("Magzi/Tape");
                cbxProcessType.Items.Add("Stitching");
                cbxProcessType.Items.Add("Checking/Inspection");
                cbxProcessType.Items.Add("Packing");
            }
            else if (cbxProductionType.SelectedIndex == 3)
            {
                cbxProcessType.Items.Add("");
                cbxProcessType.Items.Add("Cutting");
                cbxProcessType.Items.Add("Stitching");
                cbxProcessType.Items.Add("Feedo");
                cbxProcessType.Items.Add("Saftey");
                cbxProcessType.Items.Add("Bartake");
                cbxProcessType.Items.Add("Kaaj");
                cbxProcessType.Items.Add("Button");
                cbxProcessType.Items.Add("Threading");
                cbxProcessType.Items.Add("Checking/Inspection");
                cbxProcessType.Items.Add("Press");
                cbxProcessType.Items.Add("Packing");
            }

        }
        private void cbxProcessType_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<WagesEL> oelWagesCollection = new List<WagesEL>();
            var manager = new WagesBLL();
            grdProductionWages.DataSource = null;
            if (cbxProductionType.Text == "Tannery" && cbxProcessType.SelectedIndex == 10)
            {
                colCuttingRate.Visible = true;
            }
            else
            {
                colCuttingRate.Visible = false;
            }
            #region Tannery Region
            if (cbxProductionType.Text == "Tannery")
            {
                if (cbxProcessType.SelectedIndex == 1)
                {
                    oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
                    if (oelWagesCollection.Count > 0)
                    {
                        grdProductionWages.DataSource = oelWagesCollection;
                    }
                    else
                    {
                        List<WagesEL> oelCollection = new List<WagesEL>();
                        WagesEL oelGalma = new WagesEL() { SerialNo = 1, WorkType = "Galma", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelPuttha = new WagesEL() { SerialNo = 2, WorkType = "Puttha", ProductionType = 1, ProcessName = cbxProcessType.Text };

                        oelWagesCollection.Add(oelGalma);
                        oelWagesCollection.Add(oelPuttha);

                        grdProductionWages.DataSource = oelWagesCollection;
                    }
                }
                else if (cbxProcessType.SelectedIndex == 2)
                {
                    oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
                    if (oelWagesCollection.Count > 0)
                    {
                        grdProductionWages.DataSource = oelWagesCollection;

                    }
                    else
                    {
                        WagesEL oelPutthaPieces = new WagesEL() { SerialNo = 3, WorkType = "PutthaPieces", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelGalmaPieces = new WagesEL() { SerialNo = 4, WorkType = "GalmaPieces", ProductionType = 1, ProcessName = cbxProcessType.Text };

                        oelWagesCollection.Add(oelPutthaPieces);
                        oelWagesCollection.Add(oelGalmaPieces);
                        grdProductionWages.DataSource = oelWagesCollection;
                    }

                }
                else if (cbxProcessType.SelectedIndex == 3)
                {
                    oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
                    if (oelWagesCollection.Count > 0)
                    {
                        grdProductionWages.DataSource = oelWagesCollection;
                    }
                    else
                    {
                        WagesEL oelReTrimmPuttha = new WagesEL() { SerialNo = 5, WorkType = "Puttha", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelReTrimmGalma = new WagesEL() { SerialNo = 6, WorkType = "Galma", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelReTrimmPLoading = new WagesEL() { SerialNo = 7, WorkType = "PLoading", ProductionType = 1, ProcessName = cbxProcessType.Text };

                        oelWagesCollection.Add(oelReTrimmPuttha);
                        oelWagesCollection.Add(oelReTrimmGalma);
                        oelWagesCollection.Add(oelReTrimmPLoading);
                        grdProductionWages.DataSource = oelWagesCollection;
                    }
                }
                else if (cbxProcessType.SelectedIndex == 4)
                {
                    oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
                    if (oelWagesCollection.Count > 0)
                    {
                        grdProductionWages.DataSource = oelWagesCollection;
                    }
                    else
                    {
                        WagesEL oelGalma = new WagesEL() { SerialNo = 8, WorkType = "Galma", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelPuttha = new WagesEL() { SerialNo = 9, WorkType = "Puttha", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelSGalma = new WagesEL() { SerialNo = 10, WorkType = "SGalma", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelSPuttha = new WagesEL() { SerialNo = 11, WorkType = "SPuttha", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelDGalma = new WagesEL() { SerialNo = 12, WorkType = "D.Galam", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelDPuttha = new WagesEL() { SerialNo = 13, WorkType = "D.Puttha", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelSSet = new WagesEL() { SerialNo = 14, WorkType = "S.Set", ProductionType = 1, ProcessName = cbxProcessType.Text };

                        oelWagesCollection.Add(oelGalma);
                        oelWagesCollection.Add(oelPuttha);
                        oelWagesCollection.Add(oelSGalma);
                        oelWagesCollection.Add(oelSPuttha);
                        oelWagesCollection.Add(oelDGalma);
                        oelWagesCollection.Add(oelDPuttha);
                        oelWagesCollection.Add(oelSSet);
                        grdProductionWages.DataSource = oelWagesCollection;
                    }
                }
                else if (cbxProcessType.SelectedIndex == 5)
                {
                    oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
                    if (oelWagesCollection.Count > 0)
                    {
                        grdProductionWages.DataSource = oelWagesCollection;
                    }
                    else
                    {
                        WagesEL oelGalma = new WagesEL() { SerialNo = 15, WorkType = "Galma", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelPuttha = new WagesEL() { SerialNo = 16, WorkType = "Puttha", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelSGalma = new WagesEL() { SerialNo = 17, WorkType = "S.Galma", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelSPuttha = new WagesEL() { SerialNo = 18, WorkType = "S.Puttha", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        oelWagesCollection.Add(oelGalma);
                        oelWagesCollection.Add(oelPuttha);
                        oelWagesCollection.Add(oelSGalma);
                        oelWagesCollection.Add(oelSPuttha);
                        grdProductionWages.DataSource = oelWagesCollection;

                    }
                }
                else if (cbxProcessType.SelectedIndex == 6)
                {
                    oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
                    if (oelWagesCollection.Count > 0)
                    {
                        grdProductionWages.DataSource = oelWagesCollection;
                    }
                    else
                    {
                        WagesEL oelCrustGalma = new WagesEL() { SerialNo = 19, WorkType = "Galma", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelCrustPuttha = new WagesEL() { SerialNo = 20, WorkType = "Puttha", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelCrustSGalma = new WagesEL() { SerialNo = 21, WorkType = "S.CGalma", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelCrustSPuttha = new WagesEL() { SerialNo = 22, WorkType = "S.CPuttha", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        oelWagesCollection.Add(oelCrustGalma);
                        oelWagesCollection.Add(oelCrustPuttha);
                        oelWagesCollection.Add(oelCrustSGalma);
                        oelWagesCollection.Add(oelCrustSPuttha);
                        grdProductionWages.DataSource = oelWagesCollection;
                    }
                }
                else if (cbxProcessType.SelectedIndex == 7)
                {
                    oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
                    if (oelWagesCollection.Count > 0)
                    {
                        grdProductionWages.DataSource = oelWagesCollection;
                    }
                    else
                    {
                        WagesEL oelDyingGalma = new WagesEL() { SerialNo = 23, WorkType = "Galma", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelDyingPuttha = new WagesEL() { SerialNo = 24, WorkType = "Puttha", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelDyingSGalma = new WagesEL() { SerialNo = 25, WorkType = "SDGalma", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelDyingSPuttha = new WagesEL() { SerialNo = 26, WorkType = "SDPuttha", ProductionType = 1, ProcessName = cbxProcessType.Text };

                        oelWagesCollection.Add(oelDyingGalma);
                        oelWagesCollection.Add(oelDyingPuttha);
                        oelWagesCollection.Add(oelDyingSGalma);
                        oelWagesCollection.Add(oelDyingSPuttha);
                        grdProductionWages.DataSource = oelWagesCollection;

                    }
                }
                else if (cbxProcessType.SelectedIndex == 8)
                {
                    oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
                    if (oelWagesCollection.Count > 0)
                    {
                        grdProductionWages.DataSource = oelWagesCollection;
                    }
                    else
                    {
                        WagesEL oelRDyingGalma = new WagesEL() { SerialNo = 27, WorkType = "Galma", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelRDyingPuttha = new WagesEL() { SerialNo = 28, WorkType = "Puttha", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelReDyingGalma = new WagesEL() { SerialNo = 29, WorkType = "RESGalma", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelReDyingPuttha = new WagesEL() { SerialNo = 30, WorkType = "RESPuttha", ProductionType = 1, ProcessName = cbxProcessType.Text };

                        oelWagesCollection.Add(oelRDyingGalma);
                        oelWagesCollection.Add(oelRDyingPuttha);
                        oelWagesCollection.Add(oelReDyingGalma);
                        oelWagesCollection.Add(oelReDyingPuttha);
                        
                        grdProductionWages.DataSource = oelWagesCollection;
                    }
                }
                //else if (cbxProcessType.SelectedIndex == 8)
                //{
                //    oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
                //    if (oelWagesCollection.Count > 0)
                //    {
                //        grdProductionWages.DataSource = oelWagesCollection;
                //    }
                //    else
                //    {
                //        WagesEL oelBuffGalma = new WagesEL() { SerialNo = 20, WorkType = "Galma", ProductionType = 1, ProcessName = cbxProcessType.Text };
                //        WagesEL oelBuffPuttha = new WagesEL() { SerialNo = 21, WorkType = "Puttha", ProductionType = 1, ProcessName = cbxProcessType.Text };
                //        WagesEL oelBuffDGalma = new WagesEL() { SerialNo = 22, WorkType = "D.Galma", ProductionType = 1, ProcessName = cbxProcessType.Text };
                //        oelWagesCollection.Add(oelBuffDGalma);
                //        oelWagesCollection.Add(oelBuffPuttha);
                //        oelWagesCollection.Add(oelBuffDGalma);
                //        grdProductionWages.DataSource = oelWagesCollection;
                //    }
                //}
                else if (cbxProcessType.SelectedIndex == 9)
                {
                    oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
                    if (oelWagesCollection.Count > 0)
                    {
                        grdProductionWages.DataSource = oelWagesCollection;
                    }
                    else
                    {
                        WagesEL oelRBuffGalma = new WagesEL() { SerialNo = 31, WorkType = "Galma", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelRBuffPuttha = new WagesEL() { SerialNo = 32, WorkType = "Puttha", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelRBuffSGalma = new WagesEL() { SerialNo = 33, WorkType = "S.Galma", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelRBuffSPuttha = new WagesEL() { SerialNo = 34, WorkType = "S.Puttha", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        WagesEL oelRBuffDGalma = new WagesEL() { SerialNo = 35, WorkType = "D.Galma", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        oelWagesCollection.Add(oelRBuffGalma);
                        oelWagesCollection.Add(oelRBuffPuttha);
                        oelWagesCollection.Add(oelRBuffSGalma);
                        oelWagesCollection.Add(oelRBuffSPuttha);
                        oelWagesCollection.Add(oelRBuffDGalma);
                        grdProductionWages.DataSource = oelWagesCollection;
                    }
                }
                else if (cbxProcessType.SelectedIndex == 10)
                {
                    oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
                    if (oelWagesCollection.Count > 0)
                    {
                        grdProductionWages.DataSource = oelWagesCollection;
                    }
                    else
                    {
                        WagesEL oelCutting = new WagesEL() { SerialNo = 34, WorkType = "Cutting", ProductionType = 1, ProcessName = cbxProcessType.Text };
                        oelWagesCollection.Add(oelCutting);
                        grdProductionWages.DataSource = oelWagesCollection;
                    }
                }
            }
            #endregion
            #region Gloves Region
            //else if (cbxProductionType.Text == "Gloves")
            //{
            //    if (cbxProcessType.SelectedIndex == 0)
            //    {
            //        oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
            //        if (oelWagesCollection.Count > 0)
            //        {
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //        else
            //        {
            //            WagesEL oelCuffCutting = new WagesEL() { SerialNo = 27, WorkType = "Cuff Cutting", ProductionType = 2 };
            //            oelWagesCollection.Add(oelCuffCutting);
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //    }
            //    else if (cbxProcessType.SelectedIndex == 1)
            //    {
            //        oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
            //        if (oelWagesCollection.Count > 0)
            //        {
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //        else
            //        {
            //            WagesEL oelCuffPrinting = new WagesEL() { SerialNo = 28, WorkType = "Cuff Printing", ProductionType = 2 };
            //            oelWagesCollection.Add(oelCuffPrinting);
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //    }
            //    else if (cbxProcessType.SelectedIndex == 2)
            //    {
            //        oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
            //        if (oelWagesCollection.Count > 0)
            //        {
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //        else
            //        {
            //            WagesEL oelOverlock = new WagesEL() { SerialNo = 29, WorkType = "OverLock", ProductionType = 2 };
            //            oelWagesCollection.Add(oelOverlock);
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //    }
            //    else if (cbxProcessType.SelectedIndex == 3)
            //    {
            //        oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
            //        if (oelWagesCollection.Count > 0)
            //        {
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //        else
            //        {
            //            WagesEL oelMagzi = new WagesEL() { SerialNo = 30, WorkType = "Magzi/Tape", ProductionType = 2 };
            //            oelWagesCollection.Add(oelMagzi);
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //    }
            //    else if (cbxProcessType.SelectedIndex == 4)
            //    {
            //        oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
            //        if (oelWagesCollection.Count > 0)
            //        {
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //        else
            //        {
            //            WagesEL oelStitching = new WagesEL() { SerialNo = 31, WorkType = "Stitching", ProductionType = 2 };
            //            oelWagesCollection.Add(oelStitching);
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //    }
            //    else if (cbxProcessType.SelectedIndex == 5)
            //    {
            //        oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
            //        if (oelWagesCollection.Count > 0)
            //        {
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //        else
            //        {
            //            WagesEL oelInspection = new WagesEL() { SerialNo = 32, WorkType = "Checking/Inspection", ProductionType = 2 };
            //            oelWagesCollection.Add(oelInspection);
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //    }
            //    else if (cbxProcessType.SelectedIndex == 6)
            //    {
            //        oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
            //        if (oelWagesCollection.Count > 0)
            //        {
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //        else
            //        {
            //            WagesEL oelPacking = new WagesEL() { SerialNo = 33, WorkType = "Packing", ProductionType = 2 };
            //            oelWagesCollection.Add(oelPacking);
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //    }
            //}
            #endregion
            #region Garments Region
            //if (cbxProductionType.Text == "Garments")
            //{
            //    if (cbxProcessType.SelectedIndex == 0)
            //    {
            //        oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
            //        if (oelWagesCollection.Count > 0)
            //        {
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //        else
            //        {
            //            WagesEL oelCutting = new WagesEL() { SerialNo = 34, WorkType = "Cutting", ProductionType = 3 };
            //            oelWagesCollection.Add(oelCutting);
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //    }
            //    if (cbxProcessType.SelectedIndex == 1)
            //    {
            //        oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
            //        if (oelWagesCollection.Count > 0)
            //        {
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //        else
            //        {
            //            WagesEL oelStitching = new WagesEL() { SerialNo = 35, WorkType = "Stitching", ProductionType = 3 };
            //            oelWagesCollection.Add(oelStitching);
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //    }
            //    if (cbxProcessType.SelectedIndex == 2)
            //    {
            //        oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
            //        if (oelWagesCollection.Count > 0)
            //        {
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //        else
            //        {
            //            WagesEL oelFeedo = new WagesEL() { SerialNo = 36, WorkType = "Feedo", ProductionType = 3 };
            //            oelWagesCollection.Add(oelFeedo);
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //    }
            //    if (cbxProcessType.SelectedIndex == 3)
            //    {
            //        oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
            //        if (oelWagesCollection.Count > 0)
            //        {
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //        else
            //        {
            //            WagesEL oelSafety = new WagesEL() { SerialNo = 37, WorkType = "Safety", ProductionType = 3 };
            //            oelWagesCollection.Add(oelSafety);
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //    }
            //    if (cbxProcessType.SelectedIndex == 4)
            //    {
            //        oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
            //        if (oelWagesCollection.Count > 0)
            //        {
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //        else
            //        {
            //            WagesEL oelBartake = new WagesEL() { SerialNo = 38, WorkType = "Bartake", ProductionType = 3 };
            //            oelWagesCollection.Add(oelBartake);
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //    }
            //    if (cbxProcessType.SelectedIndex == 5)
            //    {
            //        oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
            //        if (oelWagesCollection.Count > 0)
            //        {
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //        else
            //        {
            //            WagesEL oelKaaj = new WagesEL() { SerialNo = 39, WorkType = "Kaaj", ProductionType = 3 };
            //            oelWagesCollection.Add(oelKaaj);
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //    }
            //    if (cbxProcessType.SelectedIndex == 6)
            //    {
            //        oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
            //        if (oelWagesCollection.Count > 0)
            //        {
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //        else
            //        {
            //            WagesEL oelButton = new WagesEL() { SerialNo = 40, WorkType = "Button", ProductionType = 3 };
            //            oelWagesCollection.Add(oelButton);
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //    }
            //    if (cbxProcessType.SelectedIndex == 7)
            //    {
            //        oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
            //        if (oelWagesCollection.Count < 0)
            //        {
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //        else
            //        {
            //            WagesEL oelThreading = new WagesEL() { SerialNo = 41, WorkType = "Threading", ProductionType = 3 };
            //            oelWagesCollection.Add(oelThreading);
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //    }
            //    if (cbxProcessType.SelectedIndex == 8)
            //    {
            //        oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
            //        if (oelWagesCollection.Count > 0)
            //        {
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //        else
            //        {
            //            WagesEL oelChecking = new WagesEL() { SerialNo = 42, WorkType = "Checking/Inspection", ProductionType = 3 };
            //            oelWagesCollection.Add(oelChecking);
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //    }
            //    if (cbxProcessType.SelectedIndex == 9)
            //    {
            //        oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
            //        if (oelWagesCollection.Count > 0)
            //        {
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }

            //        else
            //        {
            //            WagesEL oelPress = new WagesEL() { SerialNo = 43, WorkType = "Press", ProductionType = 3 };
            //            oelWagesCollection.Add(oelPress);
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //    }
            //    if (cbxProcessType.SelectedIndex == 10)
            //    {
            //        oelWagesCollection = manager.GetWagesByProcess(cbxProcessType.Text);
            //        if (oelWagesCollection.Count < 0)
            //        {
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //        else
            //        {
            //            WagesEL oelPacking = new WagesEL() { SerialNo = 44, WorkType = "Packing", ProductionType = 3 };
            //            oelWagesCollection.Add(oelPacking);
            //            grdProductionWages.DataSource = oelWagesCollection;
            //        }
            //    }
            //}
            #endregion
        }
        private void btnWagesSave_Click(object sender, EventArgs e)
        {
            try
            {

                List<WagesEL> oelWagesCollection = new List<WagesEL>();
                for (int i = 0; i < grdProductionWages.Rows.Count; i++)
                {
                    WagesEL oelWages = new WagesEL();
                    oelWages.SerialNo = Validation.GetSafeInteger(grdProductionWages.Rows[i].Cells["colIdWorkType"].Value);
                    oelWages.WorkType = Validation.GetSafeString(grdProductionWages.Rows[i].Cells["colWorkType"].Value);
                    oelWages.WorkRate = Validation.GetSafeDecimal(grdProductionWages.Rows[i].Cells["colWorkRate"].Value);
                    oelWages.CuttingRate = Validation.GetSafeDecimal(grdProductionWages.Rows[i].Cells["colCuttingRate"].Value);
                    oelWages.ProcessName = cbxProcessType.Text;
                    if (cbxProductionType.SelectedIndex == 1)
                    {
                        oelWages.ProductionType = 1;
                    }
                    else if (cbxProductionType.SelectedIndex == 2)
                    {
                        oelWages.ProductionType = 2;
                    }
                    else if (cbxProductionType.SelectedIndex == 3)
                    {
                        oelWages.ProductionType = 3;
                    }
                    oelWagesCollection.Add(oelWages);                    
                }
                var manager = new WagesBLL();
                if (manager.CreateWages(oelWagesCollection))
                {
                    oelWagesCollection.Clear();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}