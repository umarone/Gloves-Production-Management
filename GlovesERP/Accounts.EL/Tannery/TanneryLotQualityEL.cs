using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounts.EL
{
    public class TanneryLotQualityEL : TanneryProcessesEL
    {
       public Guid IdQuality
       {
           get;
           set;
       }
       public int QualityCode
       {
           get;
           set;
       }
       public string QualityName
       {
           get;
           set;
       }
       public DateTime CreatedDateTime
       {
           get;
           set;
       }
    }
}
