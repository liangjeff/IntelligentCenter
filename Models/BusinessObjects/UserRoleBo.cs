using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntelliTransCentre.Models.BusinessObjects
{
    public class UserRolesBo
    {
        public Guid Id { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
        public Guid TypeId { get; set; }
    }
}