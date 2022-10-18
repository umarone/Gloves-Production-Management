using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
   public class ItemsEL : CategoryEL
    {
        #region items
       public Guid IdItem 
       { 
           get; 
           set; 
       }
       public Guid IdLinkItem 
       { 
           get; 
           set; 
       }
       public Guid IdSideItem
       {
           get;
           set;
       }
       public Guid IdArticle
       {
           get;
           set;
       }
       public Guid IdSubArticle
       {
           get;
           set;
       }
       public Guid IdSize 
       { 
           get; 
           set; 
       }
       public Guid IdColor
       {
           get;
           set;
       }
       public string ItemSize
       {
           get;
           set;
       }
       public string ItemColor
       {
           get;
           set;
       }
       public Guid IdTradingCo 
       { 
           get; 
           set; 
       }
       public string ItemNo
        {
            get;
            set;
        }
       public Guid? IdCurrentStock
       {
           get;
           set;
       }
       public string Mfg
       {
           get;
           set;
       }
       public string Expiry
       {
           get;
           set;
       }
       public Int32 Seq
       {
           get;
           set;
       }
       public string ProductCode
       {
           get;
           set;
       }
       public string ItemName
       {
            get;
            set;
       }
       public string LinkItemName
       {
           get;
           set;
       }
       public string SideItemName
       {
           get;
           set;
       }
       public string ArticleName
       {
           get;
           set;
       }
       public string ItemConfiguration
       {
           get;
           set;
       }
       public string SubArticle
       {
           get;
           set;
       }
       public string Power
       {
           get;
           set;
       }
       public string ColorTemperature
       {
           get;
           set;
       }
       public string BarCode
       {
           get;
           set;
       }
       public Decimal MRP
       {
           get;
           set;
       }
       public Decimal UnitPrice
       {
           get;
           set;
       }
       public Decimal CurrentUnitPrice
       {
           get;
           set;
       }
       public Int32 ReorderLevel
       {
           get;
           set;
       }
       public decimal CuttingRates
       {
           get;
           set;
       }
       public decimal CuttingWages
       {
           get;
           set;
       }
       public Int32 StockOnHand
       {
           get;
           set;
       }
       public string PackingSize
       {
           get;
           set;
       }
       public string BatchNo
        {
            get;
            set;
        }
       public string Description
        {
            get;
            set;
        }
       public string ProductRegNo
        {
            get;
            set;
        }
       public decimal Qty
        {
            get;
            set;
        }
       public decimal Balance
       {
           get;
           set;
       }
       public decimal TotalAmount
       {
           get;
           set;
       }
       public DateTime StockOnHandDate
       {
           get;
           set;
       }
       public decimal AvgRate { get; set; }
       public decimal FlatRate { get; set; }
       public bool? IsTalliItem { get; set; }
       public bool? IsCuffItem { get; set; }
       public int ItemType
       {
           get;
           set;
       }
       public bool IsNew
       {
           get;
           set;
       }
       public bool? IsRazing
       {
           get;
           set;
       }
       public bool? IsMandatory
       {
           get;
           set;
       }
       public bool? IsMarkeen
       {
           get;
           set;
       }
       public Int64 BundleNo { get; set; }
       public decimal Average { get; set; }
       public int GarmentsStockType { get; set; }
       public decimal FreshClotheQuantity { get; set; }
       public decimal FreshClotheRate { get; set; }
       public decimal GradeAUnits { get; set; }
       public decimal GradeAAmount { get; set; }
       public decimal GradeBUnits { get; set; }
       public decimal GradeBAmount { get; set; }
       public decimal CPUnits { get; set; }
        #endregion
    }
}
