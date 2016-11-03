using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace IntelliTransCentre.Models.ViewModels
{
    public class UserAccountViewModels
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }    
        public string CVV { get; set; }

        public string PayFrom { get; set; }
        public string PayTo { get; set; }
        public string TransactionTime { get; set; }
        public Guid CarId { get; set; }
        public String CarName { get; set; }
        public Guid CarparkId { get; set; }
        public string CarparkName { get; set; }
        public string Duration { get; set; }
        public string TotalAmount { get; set; }
     
        

        
    }
}