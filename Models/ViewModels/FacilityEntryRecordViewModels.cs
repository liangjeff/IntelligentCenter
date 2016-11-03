using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace IntelliTransCentre.Models.ViewModels
{
    public class FacilityEntryRecordViewModels//缺一个从userid转换成carparking id 的表格
    {
        public Guid DoorId { get; set; }
        public string DoorName { get; set; }//Door 表中
        public Guid CarId { get; set; }
        public string CarNumber { get; set; }
        public string EntryType { get; set; }
        public string TimeStamp { get; set; }


        public string EntryStatus { get; set; }


        

        
    }
}