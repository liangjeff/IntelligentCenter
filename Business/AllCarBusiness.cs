using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using IntelliTransCentre.Business.Interface;
using IntelliTransCentre.Common;
using IntelliTransCentre.Models;
using IntelliTransCentre.Models.BusinessObjects;
using IntelliTransCentre.Models.DBObjects;
using Microsoft.Ajax.Utilities;

namespace IntelliTransCentre.Business
{
    public class AllCarBusiness : IAllCarBusiness
    {
        
        public List<AllCarViewModel> GetCarList()
        {
            var list = new List<AllCarViewModel>();
            using (var context = new SpartanEntities())
            {
                try
                {
                    foreach (var cars in context.Cars)
                    {
                        var carlist = new AllCarViewModel
                        {
                            Id = cars.Id,
                            CarNumber = cars.CarNumber,
                            CarType = cars.CarType,
                            CarName = cars.CarName,
                            Description = cars.Description,
                            HasBluetooth = cars.HasBluetooth.ToString(),
                            HasWiFi = cars.HasWiFi.ToString(),
                            Revision = cars.Revision
                           
                        };
                        list.Add(carlist);
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