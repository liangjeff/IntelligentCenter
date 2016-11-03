using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IntelliTransCentre.Business.Interface;
using IntelliTransCentre.Models.DBObjects;
using IntelliTransCentre.Models.ViewModels;
using Microsoft.Ajax.Utilities;

namespace IntelliTransCentre.Business
{
    public class FacilityOverViewBusiness : IFacilityOverViewBusiness
    {


        public IList<FacilityoverviewViewModels> Getcarparkinfo(Guid userId)
        {
            using (var context = new SpartanEntities())
            {
                var carparkinfolist = new List<FacilityoverviewViewModels>();

                var usercarparks = context.carparkmanagements.Where(rec => rec.userid == userId);
                var carparkids = usercarparks.Select(rec => rec.carparkid);
                var carparks = context.CarParks.Where(rec => carparkids.Contains(rec.Id)).ToList();
                

                foreach (var usercarpark in usercarparks)
                {

                    var carpark = carparks.FirstOrDefault(rec => rec.Id == usercarpark.carparkid);
                    var carparkparkingitem = new FacilityoverviewViewModels()
                    {
                       FacilityName = "ert",
                        CarParkTypeId = userId,
                        Description = carpark.Description,
                        StreetNumber = carpark.StreetNumber,
                        Postcode = carpark.Postcode,
                        DoorTypeName = carpark.Name,
                        CarNumber = "213",
                        TotalParkingSpace = carpark.TotalPakingSpace.ToString(),
                        DisabledParkingSpace = carpark.TotalPakingSpace.ToString(),
                        SmallParkingSpace = carpark.TotalPakingSpace.ToString(),
                        ContactNumber = carpark.ContactPhoneNumber,
                        ContactName = carpark.ContactName,

                        Rate = "$3.7/h"

                        //Id = useraccount.Id,
                        // AccountType = useraccount.AccountType,
                        // TypeName = useraccounttype.TypeName,
                        // AccountNumber = useraccount.AccountNumber,
                        // ExpiryDate = useraccount.ExpiryDate.HasValue? useraccount.ExpiryDate.ToString() :"",
                        // CVV = useraccount.CVV,
                        //  TransctionTime = transction.TransactionTime.HasValue? transction.TransactionTime.ToString():"",
                        //    TotalAmount = transction.TotalAmount.ToString(),



                    };

                    carparkinfolist.Add(carparkparkingitem);
                }

                return carparkinfolist;
            }
        }









        public IList<CarparkRateViewModels> GetCarparkRate(Guid userId)
        {
            using (var context = new SpartanEntities())
            {
                var carparkratelist = new List<CarparkRateViewModels>();

                var usercarparks = context.carparkmanagements.Where(rec => rec.userid == userId);
                var carparkids = usercarparks.Select(rec => rec.carparkid);
                var rates = context.CarParkRates.Where(rec => carparkids.Contains(rec.CarParkId)).ToList();


                foreach (var usercarpark in usercarparks)
                {

                    var rate = rates.FirstOrDefault(rec => rec.CarParkId == usercarpark.carparkid );

                    var ratelist = new CarparkRateViewModels()
                    {
                       Description =  rate.Description,
                       FeeRate = rate.FeeRate.ToString(),
                       RangeLowerBound = rate.RangeLowerBound.ToString(),
                       RangeUpperBound = rate.RangeUpperBound.ToString(),


                      


                    };

                    carparkratelist.Add(ratelist);
                }

                return carparkratelist;
            }
        }
    }

}
