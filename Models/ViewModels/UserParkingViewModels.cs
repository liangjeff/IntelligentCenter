using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace IntelliTransCentre.Models.ViewModels
{
    public class UserParkingViewModels
    {
        public Guid Id { get; set; }
        public Guid CarParkId { get; set; }
        public Guid ParkingSpaceId { get; set; }
        public Guid CarId { get; set; }
        public string CarName { get; set; }
        
        public string CarNumber { get; set; }
        public string CarType { get; set; }
        public string EnterTime { get;set; }
        public string ParkingStatus { get; set; }
    }

    public class ParkingInfoViewModel
    {
        public Guid CarId { get; set; }
        public string CarName { get; set; }
        public string ParkingAddress { get; set; }
        public string EnterTime { get; set; }
        public string Fare { get; set; }
        public string Location { get; set; }
    }
}