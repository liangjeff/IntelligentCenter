using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelliTransCentre.Models.ViewModels
{
    public class UserCarGridItem
    {
        public Guid Id { get; set; }
        public string CarNumber { get; set; }
        public Guid CarTypeId { get; set; }
        public string CarType { get; set; }
        public Guid CarId { get; set; }
        public string CarName { get; set; }
        public string Description { get;set; }
        public string RegisteredDate { get; set; }
    }
}