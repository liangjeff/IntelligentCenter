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
    public class FacilityParkingBusiness : IFacilityParkingBusiness
    {
        

        public IList<FacilityParkingViewModels> GetFacilityParking()
        {
            using (var context = new SpartanEntities())
            {
                var facilityparking = new List<FacilityParkingViewModels>();

                var carparktypeids = context.ParkingSpaces.Select(rec => rec.ParkingSpaceTypeId);
                var carparktypename = context.ParkingSpaceTypes.Where(rec => carparktypeids.Contains(rec.Id)).ToList();
        
             

                foreach (var parkedcars in context.ParkingSpaces)
                {
                    var  carparktypenamelist = carparktypename.FirstOrDefault(rec => rec.Id == parkedcars.ParkingSpaceTypeId);
                
                    var parkedcarlist = new FacilityParkingViewModels()
                    {
                       TypeName = carparktypenamelist.TypeName,
                       Latitude =  parkedcars.Latitude,
                       Longtitude = parkedcars.Longitude,
                       LocationCode = parkedcars.Name,
                       ParkingTime = parkedcars.ParkingTime.ToString(),
                       



                      
                    };

                    facilityparking.Add(parkedcarlist);
                }

                return facilityparking;
            }
        }
    }
}