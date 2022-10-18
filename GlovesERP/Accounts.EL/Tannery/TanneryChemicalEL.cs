using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{

   public class TanneryChemicalEL : TanneryLotEL
    {
       public Guid IdChemical
       {
           get;
           set;

       }
       public Guid IdItem
       {
           get;
           set;
       }
       public int IssuedQuantity
       {
           get;
           set;
       }
       public decimal CrustIssuedQuantity
       {
           get;
           set;
       }
       public decimal CrustIssuedValue
       {
           get;
           set;
       }
       public decimal DyingIssuedValue
       {
           get;
           set;
       }
       public decimal ReDyingIssuedValue
       {
           get;
           set;
       }
       public decimal DyingIssuedQuantity
       {
           get;
           set;
       }
       public decimal ReDyingIssuedQuantity
       {
           get;
           set;
       }
       public decimal IssuedValue
       {
           get;
           set;
       }
       public decimal CurrentQuantity
       {
           get;
           set;
       }
       public decimal CurrentValue
       {
           get;
           set;
       }

    }
}
