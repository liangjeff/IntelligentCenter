using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace IntelliTransCentre.Models.ViewModels
{
    public class FacilityoverviewViewModels //缺一个从userid转换成carparking id 的表格
    {
        public Guid FacilityTypeId { get; set; }
        public string FacilityName { get; set; } //FacilityTtpe表中
        public Guid Name { get; set; } //carpark
        public string Description { get; set; }
        public Guid CarParkTypeId { get; set; }
        public string CarNumber { get; set; }
        public string ContactName { get; set; }
        public string TotalParkingSpace { get; set; }
        public string DisabledParkingSpace { get; set; }
        public string SmallParkingSpace { get; set; }
        public string ContactNumber { get; set; }
        public string Rate { get; set; }
        public string StreetNumber { get; set; }

        public string Postcode { get; set; }//
        public string DoorTypeName { get; set; }//从carparkid =>door=> doortype

        

        
    }
    public class CarparkRateViewModels //缺一个从userid转换成carparking id 的表格
    {
        public string Description { get; set; }
        public string FeeRate { get; set; }
        public string RangeLowerBound { get; set; }
        public string RangeUpperBound { get; set; }





    }
}