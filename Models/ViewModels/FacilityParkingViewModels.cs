using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace IntelliTransCentre.Models.ViewModels
{
    public class FacilityParkingViewModels//缺一个从userid转换成carparking id 的表格
    {
        public Guid ParkingSpaceTypeId { get; set; }
        public string TypeName { get; set; }//FacilityTtpe表中
       
        public string Latitude   { get; set; }//carpark
        public string Longtitude { get; set; }
        public string LocationCode { get; set; }
        public string ParkingTime { get; set; }
        public Guid CarId { get; set; }



        

        
    }
}