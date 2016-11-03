using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IntelliTransCentre.Business.Interface;
using IntelliTransCentre.Models.DBObjects;
using IntelliTransCentre.Models.ViewModels;

namespace IntelliTransCentre.Business
{
    public class UserAccountBusiness : IUserAccountBusiness
    {
        

        public IList<UserAccountViewModels> GetUserAccount(Guid userId)
        {
            using (var context = new SpartanEntities())
            {
                var accountlist = new List<UserAccountViewModels>();

                var userAccount = context.CustomerAccounts.Where(rec => rec.UserId == userId);
                var Ids = userAccount.Select(rec => rec.Id);
                var transctions = context.AccountTransactions.Where(rec => Ids.Contains(rec.Id)).ToList();
               

                foreach (var useraccount in userAccount)
                {
                    //var  transction = transctions.FirstOrDefault(rec => rec.Id == useraccount.Id);
                    
                 

                    var accountItem = new UserAccountViewModels()
                    {
                        Id = useraccount.Id,
                        AccountType = useraccount.AccountType,
                        AccountNumber = useraccount.AccountNumber,
                            CVV = useraccount.CVV,
                        PayFrom = "Ray",
                        PayTo = "BroadWay CarPark",
                        TransactionTime = "10/20/2016",
                        CarName = "JeffCar",
                        CarparkName = "Broadway",
                        Duration = "5h 43mins",
                        TotalAmount = "$20",







                    };

                    accountlist.Add(accountItem);
                }

                return accountlist;
            }
        }
    }
}