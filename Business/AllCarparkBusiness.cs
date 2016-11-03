using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IntelliTransCentre.Business.Interface;
using IntelliTransCentre.Models;
using IntelliTransCentre.Models.DBObjects;
using IntelliTransCentre.Models.ViewModels;
using Microsoft.ApplicationInsights.Web;

namespace IntelliTransCentre.Business
{
    public class AllCarparkBusiness : IAllCarparkBusiness
    {


        public List<AllCarparkViewModel> GetCarparkList()
        {
            var list = new List<AllCarparkViewModel>();
            using (var context = new SpartanEntities())
            {
                try
                {
                    foreach (var carparks in context.CarParks)
                    {
                        var userVM = new AllCarparkViewModel
                        {
                            Id = carparks.Id,
                            Name = carparks.Name,
                            Description = carparks.Description,
                            StreetNumber = carparks.StreetNumber,
                            StreetName = carparks.StreetName,
                            City = carparks.City,
                            ContactName = carparks.ContactName,
                            
                      


                        };
                        list.Add(userVM);
                    }
                }
                catch
                {

                }
                return list;
            }
        }
    }
}