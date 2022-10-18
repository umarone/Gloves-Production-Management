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
    public partial class frmRequisition : MetroForm
    {
        #region Variables
        frmStockAccounts frmstockAccounts;
        public Int64 GlovesOrderNo { get; set; }
        string StockCommand = "";
        Guid IdOrder;
        Guid IdRequisition;
        Guid IdArticle;
        Guid IdBrand;
        string AccountNo;
        Int64 ArticleQuantity;
        #endregion
        #region Form Methods And Events
        public frmRequisition()
        {
            InitializeComponent();
        }
        private void frmRequisition_Load(object sender, EventArgs e)
        {
            this.grdOrderdArticles.AutoGenerateColumns = false;
            this.grdMaterials.AutoGenerateColumns = false;
            FillMaxRequisitionNumber();
            FillGlovesOrder();
            GetRequisitionDetailByOrder();
        }
        #endregion
        #region Simple Methods
        private void FillMaxRequisitionNumber()
        {
            var manager = new GarmentsRequisitionBLL();
            VEditBox.Text = manager.GetMaxRequisitionNumber(1, Operations.IdCompany).ToString();
        }
        private void FillGlovesOrder()
        {
            var Manager = new OrderDetailBLL();
            if (VEditBox.Text != string.Empty)
            {
                List<OrdersDetailEL> list = Manager.GetOrderDetailByOrderNo(GlovesOrderNo, 1, Operations.IdCompany);
                if (list.Count > 0)
                {
                    AccountNo = list[0].AccountNo;
                    SEditBox.Text = list[0].AccountName;
                    txtCustomerPo.Text = list[0].CustomerPo;
                    txtBrand.Text = Validation.GetSafeString(list[0].BrandName);
                    IdBrand = list[0].IdBrand;
                    IdOrder = list[0].IdOrder;
                    if (list[0].OrderStatus == 1)
                    {
                        //if (Operations.IdRole != Validation.GetSafeGuid(EnRoles.Administrator))
                        {
                            btnSave.Enabled = false;
                            btnDelete.Enabled = false;
                        }
                    }
                    else
                    {
                        btnSave.Enabled = true;
                        btnDelete.Enabled = true;
                    }

                    FillGlovesOrderDetail(list);

                }
                else
                {
                    MessageBox.Show("Order Number Not Found ...");
                    //ClearControl();
                }
            }
        }
        private void GetRequisitionDetailByOrder()
        {
            var manager = new GlovesRequisitionBLL();
            List<RequisitionDetailEL> list = manager.GetRequisitionDetailByOrder(IdOrder);
            if (list.Count > 0)
            {
                IdRequisition = list[0].IdRequisition;
            }
        }
        private void FillGlovesOrderDetail(List<OrdersDetailEL> List)
        {
            if (grdOrderdArticles.Rows.Count > 0)
            {
                grdOrderdArticles.Rows.Clear();
            }
            if (List != null && List.Count > 0)
            {
                for (int i = 0; i < List.Count; i++)
                {
                    grdOrderdArticles.Rows.Add();
                    grdOrderdArticles.Rows[i].Cells[0].Value = List[i].IdOrderDetail;
                    grdOrderdArticles.Rows[i].Cells[1].Value = List[i].IdItem;
                    grdOrderdArticles.Rows[i].Cells[2].Value = List[i].Seq;
                    grdOrderdArticles.Rows[i].Cells[3].Value = List[i].ItemName;
                    grdOrderdArticles.Rows[i].Cells[4].Value = List[i].Quantity;
                }
            }
        }
        private void LoadItemsByCategory()
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetItemsByCategoryType("");
            if (list.Count > 0)
            {
                grdFormulaRequisition.DataSource = list;
            }
        }
        private void LoadItemColors(Guid IdItem)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetItemsColorAttributes(IdItem);
            if (list.Count > 0)
            {
                list.Insert(0, new ItemsEL { IdColor = Guid.Empty, ItemColor = "" });

                colClotheColor.DataSource = list;

                colClotheColor.DisplayMember = "ItemColor";
                colClotheColor.ValueMember = "IdColor";
            }
        }
        private void ClearControl()
        {
            grdMaterials.Rows.Clear();
            grdFormulaRequisition.Rows.Clear();
            VEditBox.Enabled = true;

            lblStatuMessage.Text = string.Empty;


        }
        #endregion
        #region Validation Methods
        private bool ValidateRows()
        {

            for (int i = 0; i < grdFormulaRequisition.Rows.Count - 1; i++)
            {
                if (grdFormulaRequisition.Rows[i].Cells["colClotheItemName"].Value == null)
                {
                    return false;
                }
                else if (grdFormulaRequisition.Rows[i].Cells["colClotheCalculatedQty"].Value == null)
                {
                    return false;
                }
            }
            return true;
        }
        private bool ValidateControls()
        {
            //if (SEditBox.Text == string.Empty)
            //{
            //    lblStatuMessage.Text = "Customer Missing...";
            //    return false;
            //}
            return true;
        }
        #endregion
        #region Button Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<RequisitionDetailEL> oelRequisitionCollection = new List<RequisitionDetailEL>();
            if (ValidateRows())
            {
                if (ValidateControls())
                {
                    /// Add Voucher...
                    #region Voucher Head Entries
                    RequisitionEL oelRequisition = new RequisitionEL();
                    if (IdRequisition == Guid.Empty)
                    {
                        oelRequisition.IdRequisition = Guid.NewGuid();
                    }
                    else
                    {
                        oelRequisition.IdRequisition = IdRequisition;
                    }
                    //oelRequisition.IdBrand = ;
                    oelRequisition.IdUser = Operations.UserID;
                    oelRequisition.IdCompany = Operations.IdCompany;
                    oelRequisition.ReqNo = Convert.ToInt64(VEditBox.Text);
                    oelRequisition.CustomerPo = Validation.GetSafeString(txtCustomerPo.Text);
                    oelRequisition.IdOrder = IdOrder;
                    oelRequisition.IdBrand = IdBrand;
                    //oelRequisition.Description = Validation.GetSafeString(txtDescription.Text);
                    oelRequisition.ReqType = 1;
                    oelRequisition.ReqDate = reqDate.Value;
                    #endregion
                    ///Add Stock Detail 
                    #region Stock Entries
                    for (int i = 0; i < grdFormulaRequisition.Rows.Count - 1; i++)
                    {
                        RequisitionDetailEL oelReqDetail = new RequisitionDetailEL();
                        ItemsEL oelItem = new ItemsEL();
                        oelReqDetail.IdRequisition = oelRequisition.IdRequisition;
                        oelReqDetail.VoucherNo = Convert.ToInt64(VEditBox.Text);

                        if (grdFormulaRequisition.Rows[i].Cells["colClotheIdDetail"].Value != null)
                        {
                            oelReqDetail.IdRequisitionDetail = new Guid(grdFormulaRequisition.Rows[i].Cells["colClotheIdDetail"].Value.ToString());
                            oelReqDetail.IsNew = false;
                        }
                        else
                        {
                            oelReqDetail.IdRequisitionDetail = Guid.NewGuid();
                            oelReqDetail.IsNew = true;
                        }
                        oelReqDetail.Seq = i + 1;
                        oelReqDetail.IdItem = Validation.GetSafeGuid(grdFormulaRequisition.Rows[i].Cells["colClotheIdItem"].Value);
                        oelReqDetail.IdArticle = IdArticle;
                        oelReqDetail.IdColor = Validation.GetSafeGuid(grdFormulaRequisition.Rows[i].Cells["colClotheColor"].Value);
                        oelReqDetail.TalliBariSize = Validation.GetSafeDecimal(grdFormulaRequisition.Rows[i].Cells["colClotheBariSize"].Value);
                        oelReqDetail.TalliBariWidth = Validation.GetSafeDecimal(grdFormulaRequisition.Rows[i].Cells["colClotheWidth"].Value);
                        oelReqDetail.TotalCuffs = Validation.GetSafeDecimal(grdFormulaRequisition.Rows[i].Cells["colClotheCuffTalliSize"].Value);
                        oelReqDetail.CalculatedQty = Validation.GetSafeDecimal(grdFormulaRequisition.Rows[i].Cells["colClotheCalculatedQty"].Value);
                        oelReqDetail.CurrentStock = Validation.GetSafeLong(grdFormulaRequisition.Rows[i].Cells["colClotheCurrentStock"].Value);
                        oelReqDetail.CalculatedQty = Validation.GetSafeDecimal(grdFormulaRequisition.Rows[i].Cells["colClotheCalculatedQty"].Value);
                        oelReqDetail.RequiredQty = Validation.GetSafeDecimal(grdFormulaRequisition.Rows[i].Cells["colClotheRequiredQty"].Value);
                        oelReqDetail.ReqDetailType = 1;

                        oelRequisitionCollection.Add(oelReqDetail);
                    }
                    #endregion
                    // Now Add Order Breakup Detail
                    #region Stock Entries
                    for (int i = 0; i < grdMaterials.Rows.Count - 1; i++)
                    {
                        RequisitionDetailEL oelMaterial = new RequisitionDetailEL();
                        oelMaterial.IdRequisition = oelRequisition.IdRequisition;
                        oelMaterial.VoucherNo = Convert.ToInt64(VEditBox.Text);

                        if (grdMaterials.Rows[i].Cells["colMaterialIdDetail"].Value != null)
                        {
                            oelMaterial.IdRequisitionDetail = new Guid(grdMaterials.Rows[i].Cells["colMaterialIdDetail"].Value.ToString());
                            oelMaterial.IsNew = false;
                        }
                        else
                        {
                            oelMaterial.IdRequisitionDetail = Guid.NewGuid();
                            oelMaterial.IsNew = true;
                        }
                        oelMaterial.Seq = i + 1;
                        oelMaterial.IdItem = Validation.GetSafeGuid(grdMaterials.Rows[i].Cells["colMaterialIdItem"].Value);
                        oelMaterial.IdArticle = IdArticle;
                        oelMaterial.IdColor = Validation.GetSafeGuid(grdMaterials.Rows[i].Cells["colMaterialColor"].Value);
                        oelMaterial.TalliBariSize = 0;
                        oelMaterial.TalliBariWidth = 0;
                        oelMaterial.TotalCuffs = 0;
                        oelMaterial.CalculatedQty = Validation.GetSafeDecimal(grdMaterials.Rows[i].Cells["colMaterialCalculatedQty"].Value);
                        oelMaterial.CurrentStock = Validation.GetSafeLong(grdMaterials.Rows[i].Cells["colMaterialCurrentStock"].Value);
                        oelMaterial.RequiredQty = Validation.GetSafeDecimal(grdMaterials.Rows[i].Cells["colMaterialRequiedQty"].Value);
                        oelMaterial.AvgRate = Validation.GetSafeDecimal(grdMaterials.Rows[i].Cells["colMaterialAvgRate"].Value);
                        oelMaterial.TotalAvgRate = Validation.GetSafeDecimal(grdMaterials.Rows[i].Cells["colMaterialTotalAvgAmount"].Value);
                        oelMaterial.ReqDetailType = 2;

                        oelRequisitionCollection.Add(oelMaterial);
                    }
                    #endregion
                    #region Saving Entries
                    if (IdRequisition == Guid.Empty)
                    {
                        var manager = new GlovesRequisitionBLL();
                        if (manager.CreateGlovesRequisiton(oelRequisition, oelRequisitionCollection))
                        {
                            IdRequisition = oelRequisition.IdRequisition;
                            ClearControl();
                            FillMaxRequisitionNumber();
                            lblStatus.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Some Problem Occured while Saving Order :");
                        }
                    }
                    else
                    {
                        var manager = new GlovesRequisitionBLL();
                        if (manager.UpdateGlovesRequisiton(oelRequisition, oelRequisitionCollection))
                        {
                            lblStatus.Visible = true;
                            ClearControl();
                            FillMaxRequisitionNumber();
                        }
                    }
                    #endregion
                }
                else
                {
                    lblStatuMessage.Text = "Check Values";
                }
            }
            else
            {
                lblStatuMessage.Text = "Incomplete Entry...";
            }
        }
        #endregion
        #region Formula Grid Events And Methods
        private void grdFormulaRequisition_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                SendKeys.Send("{F4}");
            }
        }
        private void grdFormulaRequisition_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                var ItemManager = new ItemsBLL();
                decimal CurrentQty = 0;
                if (grdFormulaRequisition.Rows[e.RowIndex].Cells["colClotheWidth"].Value != null && grdFormulaRequisition.Rows[e.RowIndex].Cells["colClotheCuffTalliSize"].Value != null && grdFormulaRequisition.Rows[e.RowIndex].Cells["colClotheBariSize"].Value != null)
                {
                    if (Validation.GetSafeDecimal(grdFormulaRequisition.Rows[e.RowIndex].Cells["colClotheBariSize"].Value) >= 10)
                    {
                        if (grdMaterials.Rows.Count > 0)
                        {
                            var manager = new RequisitionItemsBLL();
                            List<ItemFormulaEL> listMaterials = manager.GetItemsByAritcle(IdArticle);
                            Guid IdCalItem = Guid.Empty;
                            if (listMaterials.Count > 0)
                            {
                                for (int i = 0; i < listMaterials.Count; i++)
                                {
                                    if (Convert.ToBoolean(listMaterials[i].IsCuffItem))
                                    {
                                        IdCalItem = listMaterials[i].IdItem;
                                        break;
                                    }

                                }
                                for (int j = 0; j < grdMaterials.Rows.Count; j++)
                                {
                                    if (IdCalItem == Validation.GetSafeGuid(grdMaterials.Rows[j].Cells["colMaterialIdItem"].Value))
                                    {
                                        CurrentQty = Validation.GetSafeDecimal(grdMaterials.Rows[j].Cells["colMaterialRequiedQty"].Value);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Validation.GetSafeDecimal(grdFormulaRequisition.Rows[e.RowIndex].Cells["colClotheBariSize"].Value) <= 10)
                        {
                            if (grdMaterials.Rows.Count > 0)
                            {
                                var manager = new RequisitionItemsBLL();
                                List<ItemFormulaEL> listMaterials = manager.GetItemsByAritcle(IdArticle);
                                Guid IdCalItem = Guid.Empty;
                                if (listMaterials.Count > 0)
                                {
                                    for (int i = 0; i < listMaterials.Count; i++)
                                    {
                                        if (Convert.ToBoolean(listMaterials[i].IsTalliItem))
                                        {
                                            IdCalItem = listMaterials[i].IdItem;
                                            break;
                                        }

                                    }
                                    for (int j = 0; j < grdMaterials.Rows.Count; j++)
                                    {
                                        if (IdCalItem == Validation.GetSafeGuid(grdMaterials.Rows[j].Cells["colMaterialIdItem"].Value))
                                        {
                                            CurrentQty = Validation.GetSafeDecimal(grdMaterials.Rows[j].Cells["colMaterialRequiedQty"].Value);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                        grdFormulaRequisition.Rows[e.RowIndex].Cells["colClotheCalculatedQty"].Value = ((CurrentQty * 24) / Validation.GetSafeLong((Validation.GetSafeLong(grdFormulaRequisition.Rows[e.RowIndex].Cells["colClotheWidth"].Value) /
                                                                                                 Validation.GetSafeDecimal(grdFormulaRequisition.Rows[e.RowIndex].Cells["colClotheCuffTalliSize"].Value)))
                                                                                                 * (Validation.GetSafeDecimal(grdFormulaRequisition.Rows[e.RowIndex].Cells["colClotheBariSize"].Value)) / 39).ToString("0.00");
                        grdFormulaRequisition.Rows[e.RowIndex].Cells["colClotheCurrentStock"].Value = ItemManager.GetLinkItemStockWithBalance(Validation.GetSafeGuid(grdFormulaRequisition.Rows[e.RowIndex].Cells["colClotheIdItem"].Value), Operations.IdCompany)[0].Qty;
                            //ItemManager.GetItemStockWithBalance(Validation.GetSafeGuid(grdFormulaRequisition.Rows[e.RowIndex].Cells["colClotheIdItem"].Value), Operations.IdCompany)[0].Qty;
                        if (Validation.GetSafeDecimal(grdFormulaRequisition.Rows[e.RowIndex].Cells["colClotheCurrentStock"].Value) > Validation.GetSafeDecimal(grdFormulaRequisition.Rows[e.RowIndex].Cells["colClotheCalculatedQty"].Value))
                        {
                            grdFormulaRequisition.Rows[e.RowIndex].Cells["colClotheRequiredQty"].Value = 0;
                        }
                        else
                        {
                            grdFormulaRequisition.Rows[e.RowIndex].Cells["colClotheRequiredQty"].Value = Validation.GetSafeDecimal(grdFormulaRequisition.Rows[e.RowIndex].Cells["colClotheCalculatedQty"].Value)
                                                                                                        - Validation.GetSafeDecimal(grdFormulaRequisition.Rows[e.RowIndex].Cells["colClotheCurrentStock"].Value);
                        }                    
                }
            }
        }
        private void grdFormulaRequisition_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 8)
            //{
            //    decimal RemainingStock = 0,MinusStock = 0;
            //    if (grdFormulaRequisition.Rows.Count > 2)
            //    {
            //        RemainingStock += Validation.GetSafeDecimal(grdFormulaRequisition.Rows[0].Cells["colClotheCurrentStock"].Value);
            //        for (int i = 0; i < grdFormulaRequisition.Rows.Count - 2; i++)
            //        {                        
            //            MinusStock += Validation.GetSafeDecimal(grdFormulaRequisition.Rows[i].Cells["colClotheCalculatedQty"].Value);
            //        }
            //        grdFormulaRequisition.Rows[e.RowIndex].Cells["colClotheCurrentStock"].Value = RemainingStock - MinusStock;
            //    }

            //}
        }
        private void grdFormulaRequisition_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdFormulaRequisition.CurrentCellAddress.X == 3)
            {
                TextBox txtClotheItemName = e.Control as TextBox;
                if (txtClotheItemName != null)
                {
                    txtClotheItemName.KeyPress -= new KeyPressEventHandler(txtClotheItemName_KeyPress);
                    txtClotheItemName.KeyPress += new KeyPressEventHandler(txtClotheItemName_KeyPress);
                }
            }
        }
        void txtClotheItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdFormulaRequisition.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    StockCommand = "OrderClothe";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        void frmstockAccounts_ExecuteFindStockAccountEvent(object Sender, ItemsEL oelItems)
        {
            var manager = new ItemsBLL();
            grdFormulaRequisition.RefreshEdit();
            grdMaterials.RefreshEdit();
            //if (manager.VerifyAccount(Operations.IdCompany, "Items", oelItems.AccountNo).Count > 0)
            {
                lblStatuMessage.Text = "";
                if (StockCommand == "OrderClothe")
                {
                    grdFormulaRequisition.CurrentRow.Cells["colClotheIdItem"].Value = oelItems.IdItem;
                    //grdOrderdClothe.CurrentRow.Cells["colItemNo"].Value = oelItems.AccountNo;
                    grdFormulaRequisition.CurrentRow.Cells["colClotheItemName"].Value = oelItems.ItemName;
                    //grdOrderdClothe.CurrentRow.Cells["colpacking"].Value = oelItems.PackingSize;
                    LoadItemColors(oelItems.IdItem);
                }
                else if (StockCommand == "MaterialItems")
                {
                    grdMaterials.CurrentRow.Cells["colMaterialIdItem"].Value = oelItems.IdItem;
                    grdMaterials.CurrentRow.Cells["colMaterialItemName"].Value = oelItems.ItemName;
                }
                else
                {
                    grdFormulaRequisition.CurrentRow.Cells["colBreakupIdItem"].Value = oelItems.IdItem;
                    grdFormulaRequisition.CurrentRow.Cells["colBreakupItemName"].Value = oelItems.ItemName;

                }


            }
            //else
            //{
                //lblStatuMessage.Text = "Wrong Account...";
            //}
        }
        #endregion
        #region Orders Grid Methods And Events
        private void grdOrderdArticles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            grdMaterials.Rows.Clear();
            grdFormulaRequisition.Rows.Clear();
            lblStatus.Visible = false;
            var manager = new GlovesRequisitionDetailBLL();
            
            IdArticle = Validation.GetSafeGuid(grdOrderdArticles.Rows[e.RowIndex].Cells["colOrderdArticleIdItem"].Value);
            ArticleQuantity = Validation.GetSafeLong(grdOrderdArticles.Rows[e.RowIndex].Cells["colOrderedArticleQty"].Value);
            List<RequisitionDetailEL> Reqlist = manager.GetGlovesRequisitionDetailsArticles(IdArticle, IdRequisition);
            if (Reqlist.Count > 0)
            {
                lblStatus.Visible = true;
                FillArticleRequisition(Reqlist);
            }
            else
            {
                //LoadGlovesMaterials();
                LoadArticleMaterials();
            }
        }
        private void FillArticleRequisition(List<RequisitionDetailEL> Reqlist)
        {
            List<RequisitionDetailEL> lstClothe = Reqlist.FindAll(x => x.ReqDetailType == 1);
            if (lstClothe.Count > 0)
            {
                grdFormulaRequisition.Rows.Clear();
                for (int i = 0; i < lstClothe.Count; i++)
                {
                    grdFormulaRequisition.Rows.Add();
                    grdFormulaRequisition.Rows[i].Cells["colClotheIdDetail"].Value = lstClothe[i].IdRequisitionDetail;
                    grdFormulaRequisition.Rows[i].Cells["colClotheIdItem"].Value = lstClothe[i].IdItem;
                    grdFormulaRequisition.Rows[i].Cells["colClotheItemName"].Value = lstClothe[i].ItemName;
                    grdFormulaRequisition.Rows[i].Cells["colClotheBariSize"].Value = lstClothe[i].TalliBariSize;
                    grdFormulaRequisition.Rows[i].Cells["colClotheWidth"].Value = lstClothe[i].TalliBariWidth;
                    grdFormulaRequisition.Rows[i].Cells["colClotheCuffTalliSize"].Value = lstClothe[i].TotalCuffs;
                    grdFormulaRequisition.Rows[i].Cells["colClotheCalculatedQty"].Value = lstClothe[i].CalculatedQty;
                    grdFormulaRequisition.Rows[i].Cells["colClotheCurrentStock"].Value = lstClothe[i].CurrentStock;
                    grdFormulaRequisition.Rows[i].Cells["colClotheRequiredQty"].Value = lstClothe[i].RequiredQty;
                }
            }
            else
            {
                grdFormulaRequisition.Rows.Clear();
            }
            List<RequisitionDetailEL> lstMaterials = Reqlist.FindAll(x => x.ReqDetailType == 2);
            if (lstMaterials.Count > 0)
            {
                grdMaterials.Rows.Clear();
                for (int i = 0; i < lstMaterials.Count; i++)
                {
                    grdMaterials.Rows.Add();
                    grdMaterials.Rows[i].Cells["colMaterialIdDetail"].Value = lstMaterials[i].IdRequisitionDetail;
                    grdMaterials.Rows[i].Cells["colMaterialIdItem"].Value = lstMaterials[i].IdItem;
                    grdMaterials.Rows[i].Cells["colMaterialItemName"].Value = lstMaterials[i].ItemName;
                    grdMaterials.Rows[i].Cells["colMaterialColor"].Value = lstMaterials[i].ItemColor;

                    grdMaterials.Rows[i].Cells["colMaterialCalculatedQty"].Value = (lstMaterials[i].CalculatedQty).ToString("0.00");
                    grdMaterials.Rows[i].Cells["colMaterialCurrentStock"].Value = lstMaterials[i].CurrentStock;
                    grdMaterials.Rows[i].Cells["colMaterialRequiedQty"].Value = lstMaterials[i].RequiredQty;
                    grdMaterials.Rows[i].Cells["colMaterialAvgRate"].Value = lstMaterials[i].AvgRate;
                    grdMaterials.Rows[i].Cells["colMaterialTotalAvgAmount"].Value = lstMaterials[i].TotalAvgRate;

                }
            }
            else
            {
                grdMaterials.Rows.Clear();
            }
        }
        private void LoadArticleMaterials()
        {
            var manager = new RequisitionItemsBLL();
            var ItemManager = new ItemsBLL();
            List<ItemFormulaEL> listMaterials = manager.GetItemsByAritcle(IdArticle);
            if (listMaterials.Count > 0)
            {
                grdMaterials.Rows.Clear();
                for (int i = 0; i < listMaterials.Count; i++)
                {
                    grdMaterials.Rows.Add();
                    List<ItemsEL> lstItemStockWithAvg = ItemManager.GetItemStockWithBalance(listMaterials[i].IdItem, Operations.IdCompany);
                    grdMaterials.Rows[i].Cells["colMaterialIdItem"].Value = listMaterials[i].IdItem;
                    grdMaterials.Rows[i].Cells["colMaterialItemName"].Value = listMaterials[i].ItemName;
                    grdMaterials.Rows[i].Cells["colMaterialColor"].Value = listMaterials[i].OperationType;  //listMaterials[i].ItemColor;

                    grdMaterials.Rows[i].Cells["colMaterialCalculatedQty"].Value = (ArticleQuantity * listMaterials[i].TotalExactQty).ToString("0.00");
                    grdMaterials.Rows[i].Cells["colMaterialCurrentStock"].Value = lstItemStockWithAvg[0].Qty; //ItemManager.GetItemStockWithBalance(listMaterials[i].IdItem,Operations.IdCompany)[0].Qty;
                    if (Validation.GetSafeDecimal(grdMaterials.Rows[i].Cells["colMaterialCalculatedQty"].Value) < Validation.GetSafeDecimal(grdMaterials.Rows[i].Cells["colMaterialCurrentStock"].Value))
                    {
                        grdMaterials.Rows[i].Cells["colMaterialRequiedQty"].Value = 0;
                    }
                    else
                    {
                        grdMaterials.Rows[i].Cells["colMaterialRequiedQty"].Value = Validation.GetSafeDecimal(grdMaterials.Rows[i].Cells["colMaterialCalculatedQty"].Value) - Validation.GetSafeDecimal(grdMaterials.Rows[i].Cells["colMaterialCurrentStock"].Value);
                    }
                    grdMaterials.Rows[i].Cells["colMaterialAvgRate"].Value = lstItemStockWithAvg[0].TotalAmount.ToString("0.00"); //LoadItemAvgRate(listMaterials[i].IdItem).ToString("0.00");
                    if (grdMaterials.Rows[i].Cells["colMaterialRequiedQty"].Value == null || Validation.GetSafeDecimal(grdMaterials.Rows[i].Cells["colMaterialRequiedQty"].Value) == 0)
                    {
                        grdMaterials.Rows[i].Cells["colMaterialTotalAvgAmount"].Value = (Validation.GetSafeDecimal(grdMaterials.Rows[i].Cells["colMaterialCalculatedQty"].Value) * Validation.GetSafeDecimal(grdMaterials.Rows[i].Cells["colMaterialAvgRate"].Value)).ToString("0.00");
                    }
                    else
                    {
                        grdMaterials.Rows[i].Cells["colMaterialTotalAvgAmount"].Value = (Validation.GetSafeDecimal(grdMaterials.Rows[i].Cells["colMaterialRequiedQty"].Value) * Validation.GetSafeDecimal(grdMaterials.Rows[i].Cells["colMaterialAvgRate"].Value)).ToString("0.00");
                    }
                }
            }
        }
        private decimal LoadItemAvgRate(Guid IdItem)
        {
            var manager = new ItemsBLL();
            List<ItemsEL> list = manager.GetItemAverageRate(IdItem);
            if (list.Count > 0)
            {
                return Validation.GetSafeDecimal(list[0].TotalAmount);
            }
            else
            {
                return 0;
            }
            
        }
        #endregion
        //private void LoadGlovesMaterials()
        //{
        //    var manager = new ItemsBLL();
        //    var CManager = new GarmentsCalculationBLL();
        //    List<ItemsEL> listItemsCollection = manager.GetItemsByCategoryType("Gloves Material");
        //    List<ItemFormulaEL> listItemsFormula = null;
        //    if (listItemsCollection.Count > 0)
        //    {
        //        if (grdMaterials.Rows.Count > 0)
        //        {
        //            grdMaterials.Rows.Clear();
        //        }
        //        for (int i = 0; i < listItemsCollection.Count; i++)
        //        {
        //            grdMaterials.Rows.Add();
        //            grdMaterials.Rows[i].Cells["colMaterialIdItem"].Value = listItemsCollection[i].IdItem;
        //            grdMaterials.Rows[i].Cells["colMaterialItemName"].Value = listItemsCollection[i].ItemName;
        //            grdMaterials.Rows[i].Cells["colMaterialColor"].Value = "RED";
        //            listItemsFormula = CManager.GetFormulaByItem(listItemsCollection[i].IdItem);
        //            if (listItemsFormula.Count > 0)
        //            {
        //                grdMaterials.Rows[i].Cells["colMaterialCalculatedQty"].Value = (ArticleQuantity * listItemsFormula[0].TotalQty).ToString("0.00");
        //                grdMaterials.Rows[i].Cells["colMaterialCurrentStock"].Value = 500;
        //                grdMaterials.Rows[i].Cells["colMaterialRequiedQty"].Value = 500 - Validation.GetSafeDecimal(grdMaterials.Rows[i].Cells["colMaterialCalculatedQty"].Value); 
        //            }                   
        //        }
        //    }
        //}
        #region Material Grid Methods And events
        private void grdMaterials_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (grdMaterials.CurrentCellAddress.X == 3)
            {
                TextBox txtMaterialName = e.Control as TextBox;
                if (txtMaterialName != null)
                {
                    txtMaterialName.KeyPress -= new KeyPressEventHandler(txtMaterialName_KeyPress);
                    txtMaterialName.KeyPress += new KeyPressEventHandler(txtMaterialName_KeyPress);
                }
            }
        }
        void txtMaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdMaterials.CurrentCellAddress.X == 3)
            {
                if (e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Escape)
                {
                    frmstockAccounts = new frmStockAccounts();
                    StockCommand = "MaterialItems";
                    frmstockAccounts.ExecuteFindStockAccountEvent += new frmStockAccounts.FindStockAccountDelegate(frmstockAccounts_ExecuteFindStockAccountEvent);
                    frmstockAccounts.SearchText = e.KeyChar.ToString();
                    frmstockAccounts.ShowDialog(this);
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else if (e.KeyChar == (char)Keys.Back)
                {

                }
                else
                    e.Handled = true;
            }
        }
        #endregion
    }
}
